namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Transfer
{
    #region namespace
    using System.Text.Json.Serialization;
    #endregion namespace

    #region Class
    public class TransferQueryModel : QueryBaseModel
    {
        /// <summary>Comma separated list if looking to retrieve transactions for specific connected accounts.</summary>
        [JsonPropertyName("accountIDs")]
        public string AccountIDs { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("startDateTime")]
        public string StartDateTime { get; set; }

        [JsonPropertyName("endDateTime")]
        public string EndDateTime { get; set; }
    }
    #endregion Class
}