namespace Tutkoo.mintyfusion.Moov.Sdk.Model.PaymentMethod
{
    #region Namespace
    using System.Text.Json.Serialization;
    using Transfer;
    #endregion

    #region Class
    public class WalletModel
    {
        [JsonPropertyName("walletID")]
        public string Id { get; set; }

        [JsonPropertyName("availableBalance")]
        public AmountModel availableBalance { get; set; }
    }
    #endregion Class
}