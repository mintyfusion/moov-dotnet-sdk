namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Account
{
    #region Namespace
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class IndustryCodesModel
    {
        [JsonPropertyName("naics")]
        public string Naics { get; set; }

        [JsonPropertyName("sic")]
        public string Sic { get; set; }

        [JsonPropertyName("mcc")]
        public string Mcc { get; set; }
    }
    #endregion Class
}