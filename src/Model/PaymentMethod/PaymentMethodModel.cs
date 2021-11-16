namespace Tutkoo.mintyfusion.Moov.Sdk.Model.PaymentMethod
{
    #region Namespace
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class PaymentMethodModel
    {
        [JsonPropertyName("paymentMethodID")]
        public string Id { get; set; }

        [JsonPropertyName("paymentMethodType")]
        public string PaymentMethodType { get; set; }

        [JsonPropertyName("wallet")]
        public WalletModel Wallet { get; set; }
    }
    #endregion Class
}