namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Account
{
    #region Namespace
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class DocumentModel
    {
        [JsonPropertyName("documentID")]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("contentType")]
        public string ContentType { get; set; }

        [JsonPropertyName("parseErrors")]
        public IList<string> ParseErrors { get; set; }

        [JsonPropertyName("uploadedAt")]
        public DateTime UploadedAt { get; set; }
    }
    #endregion Class
}