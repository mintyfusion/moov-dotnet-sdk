﻿namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Transfer
{
    #region Namespace
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class TransferModel
    {
        [JsonPropertyName("transferID")]
        public string Id { get; set; }

        [JsonPropertyName("createdAt")]
        public string CreatedAt { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("source")]
        public TransferAccountModel Source { get; set; }

        [JsonPropertyName("destination")]
        public TransferAccountModel Destination { get; set; }

        [JsonPropertyName("amount")]
        public AmountModel Amount { get; set; }

        [JsonPropertyName("description")]
        public AmountModel Description { get; set; }
    }
    #endregion Class
}