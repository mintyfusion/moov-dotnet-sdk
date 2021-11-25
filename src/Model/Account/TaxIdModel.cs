namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Account
{
    #region Namespace
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class TaxIDModel
    {
        [JsonPropertyName("ein")]
        public EINModel Ein { get; set; }
    }
    #endregion Class
}