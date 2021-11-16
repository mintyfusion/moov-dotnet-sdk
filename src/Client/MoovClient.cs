namespace Tutkoo.mintyfusion.Moov.Sdk.Helper
{
    #region namespace
    using Exception;
    using Interface;
    using Microsoft.Extensions.Configuration;
    using Model.Token;
    using System;
    using System.Collections.Generic;
    using System.Net;
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
        #endregion Fields

        #region Constructor
        public MoovClient(IConfiguration configuration,
            IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient(Constant.MOOV_HTTP_NAMED_CLIENT);

            clientId = configuration[Constant.MOOV_CLIENT_ID];
            clientSecret = configuration[Constant.MOOV_SECRET];
        }
        #endregion Constructor

        #region Public Methods
        /// <summary>
        /// Call's the API and returns the result as T.
        /// </summary>
        /// <param name="scopeList">List of scopes to retrieve the token before making actual request.</param>
        /// <param name="endpoint">Endpoint of the request.</param>
        /// <param name="refreshToken">Optional</param>
        /// <returns>T</returns>
        /// <exception cref="InvalidOperationException">Throws ArgumentNullException when both scopeList or refreshToken are NULL or empty.</exception>
        /// <exception cref="MoovTokenException">Throws MoovTokenException when unable to get the Token.</exception>
        /// <exception cref="MoovSdkException">Throws MoovSdkException when unable to get Success from the API.</exception>
        public async Task<T> GetAsync<T>(string endpoint,
            IList<string> scopeList = null,
            string refreshToken = "")
        {
            await GetTokenAsync(scopeList,
                refreshToken);

            HttpResponseMessage response = await httpClient.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(responseContent))
                    return default;

                return JsonSerializer.Deserialize<T>(responseContent);
            }

            throw new MoovSdkException(response.ReasonPhrase);
        }

        public async Task<T> PostAsync<T>(string endpoint,
            IList<string> scopeList = null,
            object postData = null,
            string refreshToken = "")
        {
            await GetTokenAsync(scopeList,
                refreshToken);

            StringContent stringContent = null;

            if (postData != null)
            {
                string json = JsonSerializer.Serialize(postData, new JsonSerializerOptions
                {
                    IgnoreNullValues = true,
                });

                stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            }

            HttpResponseMessage response = await httpClient.PostAsync(endpoint,
                stringContent);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(responseContent))
                    return default;

                return JsonSerializer.Deserialize<T>(responseContent);
            }

            throw new MoovSdkException(response.ReasonPhrase);
        }

        public async Task<T> PutAsync<T>(string endpoint,
            IList<string> scopeList = null,
            object postData = null,
            string refreshToken = "")
        {
            await GetTokenAsync(scopeList,
                refreshToken);

            StringContent stringContent = null;

            if (postData != null)
            {
                string json = JsonSerializer.Serialize(postData, new JsonSerializerOptions
                {
                    IgnoreNullValues = true,
                });

                stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            }

            HttpResponseMessage response = await httpClient.PutAsync(endpoint,
                stringContent);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(responseContent))
                    return default;

                return JsonSerializer.Deserialize<T>(responseContent);
            }

            throw new MoovSdkException(response.ReasonPhrase);
        }

        public async Task<T> DeleteAsync<T>(string endpoint,
            IList<string> scopeList = null,
            string refreshToken = "")
        {
            await GetTokenAsync(scopeList,
                refreshToken);

            HttpResponseMessage response = await httpClient.DeleteAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(responseContent))
                    return default;

                return JsonSerializer.Deserialize<T>(responseContent);
            }

            throw new MoovSdkException(response.ReasonPhrase);
        }
        #endregion Public Methods

        #region Private Methods
        /// <summary>
        /// Get's the token based on scopeList or refresh token provided.
        /// </summary>
        /// <param name="scopeList">List of scopes to retrieve the token before making actual request.</param>
        /// <param name="refreshToken">Optional</param>
        /// <param name="addTokenToAuthHeader">Adds token as Authorization Header for outgoing HttpRequest</param>
        /// <returns>T</returns>
        /// <exception cref="InvalidOperationException">Throws ArgumentNullException when both scopeList or refreshToken are NULL or empty.</exception>
        /// <exception cref="MoovTokenException">Throws MoovTokenException when unable to get the Token.</exception>
        private async Task<string> GetTokenAsync(IList<string> scopeList = null,
            string refreshToken = "", bool addTokenToAuthHeader = true)
        {
            if (scopeList == null && string.IsNullOrEmpty(refreshToken))
                throw new InvalidOperationException("MoovClient:GetTokenAsync - Both scopeList and refreshToken cannot be null or empty.");

            string scope = string.Join(" ", scopeList);

            TokenRequestModel requestTokenModel = new()
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
                GrantType = scopeList != null ? GrantType.ClientCredentials.Value() : GrantType.RefreshToken.Value(),
                Scope = scope,
                RefreshToken = refreshToken
            };

            string jsonString = JsonSerializer.Serialize(requestTokenModel, new JsonSerializerOptions
            {
                IgnoreNullValues = true,
            });

            HttpResponseMessage response = await httpClient.PostAsync(Endpoint.GetAccessToken.Value(),
                new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json"));

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
        #endregion Private Methods
    }
    #endregion Class
}