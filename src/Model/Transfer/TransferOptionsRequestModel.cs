namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Transfer
{
    #region Namespace
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class TransferOptionsRequestModel
    {
        [JsonPropertyName("source")]
        public TransferOptionsAccountModel Source { get; set; }

        [JsonPropertyName("destination")]
        public TransferOptionsAccountModel Destination { get; set; }

        [JsonPropertyName("amount")]
        public AmountModel Amount { get; set; }
    }

    public class TransferOptionsAccountModel
    {
        [JsonPropertyName("accountID")]
        public string AccountId { get; set; }

        [JsonPropertyName("paymentMethodID")]
        public string PaymentMethodID { get; set; }
    }
    #endregion Class
}