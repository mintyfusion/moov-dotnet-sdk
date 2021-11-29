namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Account
{
    #region Namespace
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class VerificationModel
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("details")]
        public string Details { get; set; }

        [JsonPropertyName("acceptedIP")]
        public string AcceptedIP { get; set; }

        [JsonPropertyName("documents")]
        public IList<DocumentModel> Documents { get; set; }
    }
    #endregion Class
}