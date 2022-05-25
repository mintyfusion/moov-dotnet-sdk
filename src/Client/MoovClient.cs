namespace Tutkoo.mintyfusion.Moov.Sdk.Helper
{
    #region namespace
    using Exception;
    using Interface;
    using Microsoft.AspNetCore.WebUtilities;
    using Microsoft.Extensions.Configuration;
    using Model.Token;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Tutkoo.Essentials;
    #endregion namespace

    #region Class
    public class MoovClient : IClient
    {
        #region Fields
        private readonly HttpClient httpClient = null;

        private readonly string clientId = string.Empty;

        private readonly string clientSecret = string.Empty;

        private readonly string platformID = string.Empty;
        #endregion Fields

        #region Constructor
        public MoovClient(IConfiguration configuration,
            IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient(Constant.MOOV_HTTP_NAMED_CLIENT);

            clientId = configuration[Constant.MOOV_CLIENT_ID];
            clientSecret = configuration[Constant.MOOV_SECRET];
            platformID = configuration[Constant.MOOV_PLATFORM_ID];
        }
        #endregion Constructor

        #region Properties
        public string PlatformID
        {
            get => platformID;
        }
        #endregion Properties

        #region Public Methods
        /// <summary>
        /// Call's the API and returns the result as T.
        /// </summary>
        /// <param name="scopeList">List of scopes to retrieve the token before making actual request.</param>
        /// <param name="endpoint">Endpoint of the request.</param>
        /// <param name="queryParams">Extra parameter to append at end of url</param>
        /// <param name="headers">Extra special headers</param>
        /// <returns>T</returns>
        /// <exception cref="InvalidOperationException">Throws ArgumentNullException when scopeList are NULL or empty.</exception>
        /// <exception cref="MoovTokenException">Throws MoovTokenException when unable to get the Token.</exception>
        /// <exception cref="MoovSdkException">Throws MoovSdkException when unable to get Success from the API.</exception>
        public async Task<T> GetAsync<T>(string endpoint,
            IList<string> scopeList,
            object queryParametersObject = null,
            IDictionary<string, string> headers = null)
        {
            if (scopeList != null) //Special case to handle /tos-token
                await GetTokenAsync(scopeList);

            if (queryParametersObject != null)
            {
                IDictionary<string, object> queryParams = queryParametersObject.AsDictionary();

                if (queryParams != null)
                {
                    foreach (KeyValuePair<string, object> parameters in queryParams)
                        endpoint = QueryHelpers.AddQueryString(endpoint, parameters.Key, (string)parameters.Value);
                }
            }

            AddHeaders(headers);

            HttpResponseMessage response = await httpClient.GetAsync(endpoint);

            return await ParseResponse<T>(response);
        }

        public async Task<T> PostAsync<T>(string endpoint,
            IList<string> scopeList,
            object data = null,
            IDictionary<string, string> headers = null)
        {
            await GetTokenAsync(scopeList);

            if (headers == null)
                headers = new Dictionary<string, string>();

            headers.Add(RequestHeader.IdempotencyKey.Value(), 
                Guid.NewGuid().ToString());

            AddHeaders(headers);

            HttpResponseMessage response = await httpClient.PostAsync(endpoint,
                SerializeObjectAsJson(data));

            return await ParseResponse<T>(response);
        }

        public async Task<T> PutAsync<T>(string endpoint,
            IList<string> scopeList,
            object data = null,
            IDictionary<string, string> headers = null)
        {
            await GetTokenAsync(scopeList);

            AddHeaders(headers);

            HttpResponseMessage response = await httpClient.PutAsync(endpoint,
                SerializeObjectAsJson(data));

            return await ParseResponse<T>(response);
        }

        public async Task<T> Patch<T>(string endpoint,
            IList<string> scopeList,
            object data = null,
            IDictionary<string, string> headers = null)
        {
            await GetTokenAsync(scopeList);

            AddHeaders(headers);

            HttpResponseMessage response = await httpClient.PatchAsync(endpoint,
                SerializeObjectAsJson(data));

            return await ParseResponse<T>(response);
        }

        public async Task<T> DeleteAsync<T>(string endpoint,
            IList<string> scopeList,
            IDictionary<string, string> headers = null)
        {
            await GetTokenAsync(scopeList);

            AddHeaders(headers);

            HttpResponseMessage response = await httpClient.DeleteAsync(endpoint);

            return await ParseResponse<T>(response);
        }
        #endregion Public Methods

        #region Private Methods
        /// <summary>
        /// Get's the token based on scopeList or refresh token provided.
        /// </summary>
        /// <param name="scopeList">List of scopes to retrieve the token before making actual request.</param>
        /// <param name="addTokenToAuthHeader">Adds token as Authorization Header for outgoing HttpRequest</param>
        /// <returns>T</returns>
        /// <exception cref="InvalidOperationException">Throws ArgumentNullException when scopeList are NULL or empty.</exception>
        /// <exception cref="MoovTokenException">Throws MoovTokenException when unable to get the Token.</exception>
        private async Task<string> GetTokenAsync(IList<string> scopeList,
            bool addTokenToAuthHeader = true)
        {
            if (scopeList == null)
                throw new ArgumentNullException(nameof(scopeList));

            string scope = string.Join(" ", scopeList);

            TokenRequestModel requestTokenModel = new()
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
                GrantType = GrantType.ClientCredentials.Value(),
                Scope = scope
            };

            string jsonString = JsonSerializer.Serialize(requestTokenModel, new JsonSerializerOptions
            {
                IgnoreNullValues = true,
            });

            HttpResponseMessage response = await httpClient.PostAsync(TokenEndpoint.Get.Value(),
                new StringContent(jsonString, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                TokenResponseModel tokenResponse = JsonSerializer.Deserialize<TokenResponseModel>(responseContent);

                if (addTokenToAuthHeader)
                    httpClient.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", tokenResponse.AccessToken));

                return tokenResponse.AccessToken;
            }

            throw new MoovTokenException(response.ReasonPhrase);
        }

        private void AddHeaders(IDictionary<string, string> headers)
        {
            if (headers != null && headers.Count > 0)
            {
                foreach (KeyValuePair<string, string> keyValuePair in headers)
                {
                    httpClient.DefaultRequestHeaders.Add(keyValuePair.Key, keyValuePair.Value);
                }
            }
        }

        private static StringContent SerializeObjectAsJson(object data = null)
        {
            StringContent stringContent = null;

            if (data != null)
            {
                string json = JsonSerializer.Serialize(data, new JsonSerializerOptions
                {
                    IgnoreNullValues = true,
                });

                stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            }

            return stringContent;
        }

        private static async Task<T> ParseResponse<T>(HttpResponseMessage response)
        {
            string responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                if (string.IsNullOrEmpty(responseContent))
                    return default;

                return JsonSerializer.Deserialize<T>(responseContent);
            }

            throw new MoovSdkException(response.ReasonPhrase);
        }
        #endregion Private Methods
    }
    #endregion Class
}