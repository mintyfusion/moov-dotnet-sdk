﻿namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Transfer
{
    #region Namespace
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class TransferFilterModel : QueryModel
    {
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