namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Account
{
    #region Namespace
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class IndustryCodesModel
    {
        [JsonPropertyName("naics")]
        public string NAICS { get; set; }

        [JsonPropertyName("sic")]
        public string SIC { get; set; }

        [JsonPropertyName("mcc")]
        public string MCC { get; set; }
    }
    #endregion Class
}