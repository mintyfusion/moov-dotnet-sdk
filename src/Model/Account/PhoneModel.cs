namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Account
{
    #region Namespace
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class PhoneModel
    {
        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("countryCode")]
        public string CountryCode { get; set; }
    }
    #endregion Class
}