namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Account
{
    #region Namespace
    using System;
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class AccountFilterModel : QueryModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("foreignID")]
        public string ForeignID { get; set; }
    }
    #endregion Class
}