namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Transfer
{
    #region Namespace
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class TransferFilterModel
    {
        [JsonPropertyName("accountIDs")]
        public IList<string> AccountIDList { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("startDateTime")]
        public string StartDateTime { get; set; }

        [JsonPropertyName("endDateTime")]
        public string EndDateTime { get; set; }
    }
    #endregion Class
}