namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Transfer
{
    #region Namespace
    using Account;
    using Bank;
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class TransferAccountModel
    {
        [JsonPropertyName("paymentMethodID")]
        public string PaymentMethodId { get; set; }

        [JsonPropertyName("paymentMethodType")]
        public string PaymentMethodType { get; set; }

        [JsonPropertyName("bankAccount")]
        public BankAccountModel BankAccount { get; set; }

        [JsonPropertyName("account")]
        public IndividualAccountModel Account { get; set; }
    }
    #endregion Class
}