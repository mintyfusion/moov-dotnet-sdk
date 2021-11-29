namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Transfer
{
    #region Namespace
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class GetTransferRequestModel
    {
        [JsonPropertyName("accountId")]
        public string AccountId { get; set; }
    }
    #endregion Class
}