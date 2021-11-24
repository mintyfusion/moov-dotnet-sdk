namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Wallet
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
        public AmountModel AvailableBalance { get; set; }
    }
    #endregion Class
}