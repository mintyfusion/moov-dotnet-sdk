namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Institution
{
    #region Namespace
    using System;
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class WireParticipant
    {
        public class AchParticipant
        {
            [JsonPropertyName("routingNumber")]
            public string RoutingNumber { get; set; }

            [JsonPropertyName("telegraphicName")]
            public string TelegraphicName { get; set; }

            [JsonPropertyName("customerName")]
            public string CustomerName { get; set; }

            [JsonPropertyName("fundsTransferStatus")]
            public string FundsTransferStatus { get; set; }

            [JsonPropertyName("fundsSettlementOnlyStatus")]
            public string FundsSettlementOnlyStatus { get; set; }

            [JsonPropertyName("bookEntrySecuritiesTransferStatus")]
            public string BookEntrySecuritiesTransferStatus { get; set; }

            [JsonPropertyName("date")]
            public DateTime Date { get; set; }

            [JsonPropertyName("location")]
            public InstitutionAddressModel Location { get; set; }
        }
    }
    #endregion Class
}