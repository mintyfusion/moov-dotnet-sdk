namespace Tutkoo.mintyfusion.Moov.Sdk.Model.PaymentMethod
{
    #region Namespace
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class PaymentMethodQueryModel
    {
        [JsonPropertyName("sourceID")]
        public string SourceID { get; set; }
    }
    #endregion Class
}