namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Transfer
{
    #region Namespace
    using Account;
    using Bank;
    using Card;
    using System.Text.Json.Serialization;
    using Wallet;
    #endregion

    #region Class
    public class TransferAccountModel
    {
        [JsonPropertyName("paymentMethodID")]
        public string PaymentMethodId { get; set; }

        [JsonPropertyName("paymentMethodType")]
        public string PaymentMethodType { get; set; }

        [JsonPropertyName("account")]
        public BasicAccountModel Account { get; set; }

        [JsonPropertyName("bankAccount")]
        public BankAccountModel BankAccount { get; set; }

        [JsonPropertyName("wallet")]
        public WalletModel Wallet { get; set; }

        [JsonPropertyName("card")]
        public CardModel Card { get; set; }

        [JsonPropertyName("ach")]
        public AchModel Ach { get; set; }

        [JsonPropertyName("achDetails")]
        public AchModel AchDetails { get; set; }

        [JsonPropertyName("cardDetails")]
        public CardStatusModel CardDetails { get; set; }
    }
    #endregion Class
}