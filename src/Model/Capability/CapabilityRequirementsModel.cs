namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Capability
{
    #region Namespace
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class CapabilityRequirementsModel
    {
        [JsonPropertyName("currentlyDue")]
        public IList<string> CurrentlyDue { get; set; }

        [JsonPropertyName("errors")]
        public IList<CapabilityErrorModel> Errors { get; set; }
    }
    #endregion Class
}