namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Card
{
    #region namespace
    using System.Text.Json.Serialization;
    #endregion namespace

    #region Class
    public class CardStatusModel
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("reason")]
        public string Reason { get; set; }
    }
    #endregion Class
}