namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Bank
{
    #region namespace
    using System.Text.Json.Serialization;
    #endregion namespace

    #region Class
    public class BankAccountModel
    {
        #region Propeties
        [JsonPropertyName("bankAccountID")]
        public string Id { get; set; }

        [JsonPropertyName("bankAccountType")]
        public string BankAccountType { get; set; }

        [JsonPropertyName("accountNumber")]
        public string AccountNumber { get; set; }

        [JsonPropertyName("routingNumber")]
        public string RoutingNumber { get; set; }

        [JsonPropertyName("fingerprint")]
        public string Fingerprint { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("holderName")]
        public string HolderName { get; set; }

        [JsonPropertyName("holderType")]
        public string HolderType { get; set; }

        [JsonPropertyName("bankName")]
        public string BankName { get; set; }

        [JsonPropertyName("lastFourAccountNumber")]
        public string LastFourAccountNumber { get; set; }
        #endregion Properties
    }
    #endregion Class
}