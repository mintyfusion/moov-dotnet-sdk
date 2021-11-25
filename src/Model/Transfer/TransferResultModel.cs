namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Transfer
{
    #region Namespace
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class TransferResultModel
    {
        [JsonPropertyName("transferID")]
        public string TransferId { get; set; }
    }
    #endregion Class
}