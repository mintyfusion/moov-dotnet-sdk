namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Bank
{
    #region namespace
    using System.Text.Json.Serialization;
    #endregion namespace

    #region Class
    public class BankAccountBaseModel
    {
        #region Properties
        [JsonPropertyName("holderName")]
        public string HolderName { get; set; }

        [JsonPropertyName("holderType")]
        public string HolderType { get; set; }

        [JsonPropertyName("bankAccountType")]
        public string BankAccountType { get; set; }

        [JsonPropertyName("routingNumber")]
        public string RoutingNumber { get; set; }
        #endregion Properties
    }
    #endregion Class
}