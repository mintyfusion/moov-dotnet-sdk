namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Capability
{
    #region Namespace
    using System;
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class CapabilityModel
    {
        [JsonPropertyName("capability")]
        public string Capability { get; set; }

        [JsonPropertyName("accountID")]
        public string AccountId { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("disabledReason")]
        public string DisabledReason { get; set; }

        [JsonPropertyName("createdOn")]
        public DateTime CreatedOn { get; set; }

        [JsonPropertyName("updatedOn")]
        public DateTime UpdatedOn { get; set; }

        [JsonPropertyName("disabledOn")]
        public DateTime DisabledOn { get; set; }

        [JsonPropertyName("requirements")]
        public CapabilityRequirementsModel Requirements { get; set; }
    }
    #endregion Class
}