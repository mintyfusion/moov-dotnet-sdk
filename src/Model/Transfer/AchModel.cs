namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Transfer
{
    #region Namespace
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class AchModel
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("traceNumber")]
        public string TraceNumber { get; set; }

        [JsonPropertyName("return")]
        public AchReturnModel Return { get; set; }

        [JsonPropertyName("correction")]
        public AchReturnModel Correction { get; set; }
    }
    #endregion Class
}
