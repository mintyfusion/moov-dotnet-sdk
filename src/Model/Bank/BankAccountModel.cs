namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Bank
{
    #region namespace
    using System.Text.Json.Serialization;
    #endregion namespace

    #region Class
    public class BankAccountModel : BankAccountBaseModel
    {
        #region Propeties
        [JsonPropertyName("bankAccountID")]
        public string BankAccountID { get; set; }

        [JsonPropertyName("fingerprint")]
        public string Fingerprint { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("bankName")]
        public string BankName { get; set; }

        [JsonPropertyName("lastFourAccountNumber")]
        public string LastFourAccountNumber { get; set; }
        #endregion Properties
    }
    #endregion Class
}