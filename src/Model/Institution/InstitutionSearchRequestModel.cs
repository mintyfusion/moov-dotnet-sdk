namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Institution
{
    #region Namespace
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class InstitutionSearchRequestModel : QueryBaseModel
    {
        [JsonPropertyName("source")]
        public string Name { get; set; }

        [JsonPropertyName("routingNumber")]
        public string RoutingNumber { get; set; }
    }
    #endregion Class
}