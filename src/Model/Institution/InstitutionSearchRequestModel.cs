namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Institution
{
    #region Namespace
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    //TODO: Add base query model with skip and count from other PR merge
    public class InstitutionSearchRequestModel
    {
        [JsonPropertyName("source")]
        public string Name { get; set; }

        [JsonPropertyName("routingNumber")]
        public string RoutingNumber { get; set; }
    }
    #endregion Class
}