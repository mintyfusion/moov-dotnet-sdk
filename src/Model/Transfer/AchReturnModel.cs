namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Transfer
{
    #region Namespace
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class AchReturnModel
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("reason")]
        public string Reason { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
    #endregion Class
}
