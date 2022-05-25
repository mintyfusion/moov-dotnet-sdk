namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Card
{
    #region namespace
    using System.Text.Json.Serialization;
    #endregion namespace

    #region Class
    public class CardExpirationModel
    {
        [JsonPropertyName("month")]
        public string Month { get; set; }

        [JsonPropertyName("year")]
        public string Year { get; set; }
    }
    #endregion Class
}