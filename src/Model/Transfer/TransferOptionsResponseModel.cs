namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Transfer
{
    #region Namespace
    using PaymentMethod;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class TransferOptionsResponseModel
    {
        [JsonPropertyName("sourceOptions")]
        public IList<PaymentMethodModel> SourceOptions { get; set; }

        [JsonPropertyName("destinationOptions")]
        public IList<PaymentMethodModel> DestinationOptions { get; set; }
    }
    #endregion Class
}