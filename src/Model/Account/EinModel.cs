namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Account
{
    #region Namespace
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class EINModel
    {
        [JsonPropertyName("number")]
        public string Number { get; set; }
    }
    #endregion Class
}