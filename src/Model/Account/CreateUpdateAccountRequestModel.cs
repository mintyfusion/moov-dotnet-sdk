namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Account
{
    #region namespace
    using System.Text.Json.Serialization;
    #endregion namespace

    #region Class
    public class CreateUpdateAccountRequestModel : AccountRequestModel
    {
        #region Properties
        /// <summary>Use AccountType.Value() to se this Value.</summary>
        [JsonPropertyName("accountType")]
        public string AccountType { get; set; }
        #endregion Properties
    }
    #endregion Class
}