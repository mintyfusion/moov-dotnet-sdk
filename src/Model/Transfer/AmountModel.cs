namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Transfer
{
    #region Namespace
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class AmountModel
    {
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("value")]
        public int Value { get; set; }
    }
    #endregion Class
}