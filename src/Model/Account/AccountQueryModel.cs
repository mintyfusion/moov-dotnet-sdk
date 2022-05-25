namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Account
{
    #region namespace
    using System.Text.Json.Serialization;
    #endregion namespace

    #region Class
    public class AccountQueryModel : QueryBaseModel
    {
        #region Properties
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("foreignID")]
        public string ForeignID { get; set; }
        #endregion Properties
    }
    #endregion Class
}