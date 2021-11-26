namespace Tutkoo.mintyfusion.Moov.Sdk.Model
{
    #region Namespace
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class QueryModel
    {
        [JsonPropertyName("skip")]
        public int Skip { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
    #endregion Class
}