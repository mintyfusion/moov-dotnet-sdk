namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Card
{
    #region Namespace
    using Account;
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class CardModel
    {
        [JsonPropertyName("cardID")]
        public string CardID { get; set; }

        [JsonPropertyName("fingerprint")]
        public string Fingerprint { get; set; }

        [JsonPropertyName("cardNumber")]
        public string CardNumber { get; set; }

        [JsonPropertyName("cardCvv")]
        public string CardCvv { get; set; }

        [JsonPropertyName("brand")]
        public string Brand { get; set; }

        [JsonPropertyName("cardType")]
        public string CardType { get; set; }

        [JsonPropertyName("lastFourCardNumber")]
        public string LastFourCardNumber { get; set; }

        [JsonPropertyName("firstSixCardNumber")]
        public string FirstSixCardNumber { get; set; }

        [JsonPropertyName("expiration")]
        public CardExpirationModel Expiration { get; set; }

        [JsonPropertyName("holderName")]
        public string HolderName { get; set; }

        [JsonPropertyName("billingAddress")]
        public AddressModel BillingAddress { get; set; }
    }
    #endregion Class
}