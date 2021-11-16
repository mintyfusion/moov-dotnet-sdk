namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Account
{
    #region Namespace
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class GovernmentIdModel
    {
        [JsonPropertyName("ssn")]
        public GovernmentIdPropertyModel SSN { get; set; }

        [JsonPropertyName("itin")]
        public GovernmentIdPropertyModel Itin { get; set; }
    }
    #endregion Class
}