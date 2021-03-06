namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Account
{
    #region Namespace
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class CreateUpdateAccountRequestModel : AccountRequestModel
    {
        [JsonPropertyName("accountType")]
        public string AccountType { get; set; }
    }
    #endregion Class
}