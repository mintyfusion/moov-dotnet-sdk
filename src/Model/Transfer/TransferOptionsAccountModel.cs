namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Transfer
{
    #region namespace
    using System.Text.Json.Serialization;
    #endregion namespace

    #region Class
    public class TransferOptionsAccountModel
    {
        #region Properties
        [JsonPropertyName("accountID")]
        public string AccountId { get; set; }

        [JsonPropertyName("paymentMethodID")]
        public string PaymentMethodID { get; set; }
        #endregion Properties
    }
    #endregion Class
}