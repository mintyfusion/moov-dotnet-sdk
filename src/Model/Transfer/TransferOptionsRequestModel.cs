namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Transfer
{
    #region namespace
    using System.Text.Json.Serialization;
    #endregion namespace

    #region Class
    public class TransferOptionsRequestModel
    {
        #region Properties
        [JsonPropertyName("source")]
        public TransferOptionsAccountModel Source { get; set; }

        [JsonPropertyName("destination")]
        public TransferOptionsAccountModel Destination { get; set; }

        [JsonPropertyName("amount")]
        public AmountModel Amount { get; set; }
        #endregion Properties
    }
    #endregion Class
}