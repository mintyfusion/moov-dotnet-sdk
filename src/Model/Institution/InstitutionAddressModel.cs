namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Institution
{
    #region Namespace
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class InstitutionAddressModel
    {
        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }

        [JsonPropertyName("postalCodeExtension")]
        public string PostalCodeExtension { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }
    }
    #endregion Class
}