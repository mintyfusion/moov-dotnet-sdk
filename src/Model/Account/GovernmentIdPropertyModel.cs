namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Account
{
    #region Namespace
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class GovernmentIdPropertyModel
    {
        [JsonPropertyName("full")]
        public string Full { get; set; }

        [JsonPropertyName("lastFour")]
        public string LastFour { get; set; }
    }
    #endregion Class
}