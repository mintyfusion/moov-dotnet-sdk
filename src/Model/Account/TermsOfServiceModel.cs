namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Account
{
    #region Namespace
    using System;
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class TermsOfServiceModel
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("acceptedDate")]
        public DateTime AcceptedDate { get; set; }

        [JsonPropertyName("acceptedIP")]
        public string AcceptedIP { get; set; }
    }
    #endregion Class
}