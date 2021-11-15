namespace Tutkoo.mintyfusion.Moov.Sdk.Helper
{
    #region namespace
    using Interface;
    using Microsoft.Extensions.Configuration;
    using Model.Token;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Tutkoo.Essentials;
    using Exception;
    using System;
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
        /// <exception cref="ArgumentNullException">Throws ArgumentNullException when both scopeList or refreshToken are NULL or empty.</exception>
        /// <exception cref="MoovTokenException">Throws MoovTokenException when unable to get the Token.</exception>
        /// <exception cref="MoovSdkException">Throws MoovSdkException when unable to get Success from the API.</exception>
        public async Task<T> GetAsync<T>(string endpoint,
            IList<string> scopeList = null,
            string refreshToken = "")
        {
            string token = await GetTokenAsync(scopeList,
                refreshToken);

            httpClient.DefaultRequestHeaders.Add("Authorization",
                string.Format("bearer {0}", token));

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
        #endregion Public Methods

        #region Private Methods
        /// <summary>
        /// Get's the token based on scopeList or refresh token provided.
        /// </summary>
        /// <param name="scopeList">List of scopes to retrieve the token before making actual request.</param>
        /// <param name="refreshToken">Optional</param>
        /// <returns>T</returns>
        /// <exception cref="ArgumentNullException">Throws ArgumentNullException when both scopeList or refreshToken are NULL or empty.</exception>
        /// <exception cref="MoovTokenException">Throws MoovTokenException when unable to get the Token.</exception>
        private async Task<string> GetTokenAsync(IList<string> scopeList = null,
            string refreshToken = "")
        {
            if (scopeList == null && string.IsNullOrEmpty(refreshToken))
                throw new ArgumentNullException("MoovClient:GetTokenAsync - Both scopeList and refreshToken cannot be null or empty.");

            string scope = string.Join(" ", scopeList);

            TokenRequestModel requestTokenModel = new()
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
                GrantType = string.IsNullOrEmpty(refreshToken) ? GrantType.ClientCredentials.Value() : GrantType.RefreshToken.Value(),
                Scope = scope,
                RefreshToken = refreshToken
            };

            HttpResponseMessage response = await httpClient.PostAsync(Endpoint.GetAccessToken.Value(),
                new StringContent(JsonSerializer.Serialize(requestTokenModel)));

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                TokenResponseModel tokenResponse = JsonSerializer.Deserialize<TokenResponseModel>(responseContent);

                return tokenResponse.AccessToken;
            }

            throw new MoovTokenException(response.ReasonPhrase);
        }
        #endregion Private Methods
    }
    #endregion Class
}