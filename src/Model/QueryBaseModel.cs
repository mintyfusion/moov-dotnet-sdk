namespace Tutkoo.mintyfusion.Moov.Sdk.Model
{
    #region namespace
    using System.Text.Json.Serialization;
    #endregion namespace

    #region Class
    public class QueryBaseModel
    {
        #region Properties
        [JsonPropertyName("skip")]
        public int Skip { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }
        #endregion Properties
    }
    #endregion Class
}