namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Institution
{
    #region Namespace
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class AchParticipant
    {
        [JsonPropertyName("routingNumber")]
        public string RoutingNumber { get; set; }

        [JsonPropertyName("officeCode")]
        public string OfficeCode { get; set; }

        [JsonPropertyName("servicingFRBNumber")]
        public string ServicingFRBNumber { get; set; }

        [JsonPropertyName("recordTypeCode")]
        public string RecordTypeCode { get; set; }

        [JsonPropertyName("revised")]
        public string Revised { get; set; }

        [JsonPropertyName("newRoutingNumber")]
        public string NewRoutingNumber { get; set; }

        [JsonPropertyName("customerName")]
        public string CustomerName { get; set; }

        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("statusCode")]
        public string StatusCode { get; set; }

        [JsonPropertyName("viewCode")]
        public string ViewCode { get; set; }

        [JsonPropertyName("location")]
        public InstitutionAddressModel Location { get; set; }
    }
    #endregion Class
}