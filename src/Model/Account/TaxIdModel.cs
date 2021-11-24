namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Account
{
    #region Namespace
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class TaxIdModel
    {
        [JsonPropertyName("ein")]
        public EinModel Ein { get; set; }
    }
    #endregion Class
}