namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Token
{
    #region namespace
    using System.Text.Json.Serialization;
    #endregion namespace

    #region Class
    public class TokenResponseModel
    {
        #region Properties
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonPropertyName("scope")]
        public string Scope { get; set; }
        #endregion Properties
    }
    #endregion Class
}