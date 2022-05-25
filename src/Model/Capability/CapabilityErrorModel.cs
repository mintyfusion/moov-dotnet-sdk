namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Capability
{
    #region Namespace
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class CapabilityErrorModel
    {
        [JsonPropertyName("requirement")]
        public string Requirement { get; set; }

        [JsonPropertyName("errorCode")]
        public string ErrorCode { get; set; }
    }
    #endregion Class
}