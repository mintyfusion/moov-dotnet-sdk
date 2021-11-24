namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Account
{
    #region Namespace
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class BusinessAccountModel : BaseAccountModel
    {
        [JsonPropertyName("legalBusinessName")]
        public string LegalBusinessName { get; set; }

        [JsonPropertyName("doingBusinessAs")]
        public string DoingBusinessAs { get; set; }

        [JsonPropertyName("businessType")]
        public string BusinessType { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("taxID")]
        public TaxIdModel TaxId { get; set; }

        [JsonPropertyName("industryCodes")]
        public IndustryCodesModel IndustryCodes { get; set; }
    }
    #endregion Class
}