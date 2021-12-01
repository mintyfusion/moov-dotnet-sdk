namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Representative
{
    #region Namespace
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class ResponsibilitiesModel
    {
        [JsonPropertyName("isController")]
        public bool IsController { get; set; }

        [JsonPropertyName("isOwner")]
        public bool IsOwner { get; set; }

        [JsonPropertyName("ownershipPercentage")]
        public int OwnershipPercentage { get; set; }

        [JsonPropertyName("jobTitle")]
        public string JobTitle { get; set; }
    }
    #endregion Class
}