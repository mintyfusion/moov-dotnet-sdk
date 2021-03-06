namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Institution
{
    #region Namespace
    using System.Text.Json.Serialization;
    using System.Collections.Generic;
    #endregion

    #region Class
    public class InstitutionSearchResultModel
    {
        [JsonPropertyName("achParticipants")]
        public IList<ACHParticipant> ACHParticipants { get; set; }

        [JsonPropertyName("wireParticipants")]
        public IList<WireParticipant> WireParticipants { get; set; }
    }
    #endregion Class
}