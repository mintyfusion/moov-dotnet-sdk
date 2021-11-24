namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Account
{
    #region Namespace
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class BasicAccountModel
    {
        [JsonPropertyName("accountID")]
        public string Id { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }
    }
    #endregion Class
}