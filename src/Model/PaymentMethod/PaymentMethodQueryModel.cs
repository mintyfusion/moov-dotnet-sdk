namespace Tutkoo.mintyfusion.Moov.Sdk.Model.PaymentMethod
{
    #region namespace
    using System.Text.Json.Serialization;
    #endregion namespace

    #region Class
    public class PaymentMethodQueryModel
    {
        #region Properties
        [JsonPropertyName("sourceID")]
        public string SourceID { get; set; }
        #endregion Properties
    }
    #endregion Class
}