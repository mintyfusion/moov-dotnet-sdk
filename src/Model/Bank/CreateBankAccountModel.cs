namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Bank
{
    #region namespace
    using System.Text.Json.Serialization;
    #endregion namespace

    #region Class
    public class CreateBankAccountModel : BankAccountBaseModel
    {
        #region Properties
        [JsonPropertyName("accountNumber")]
        public string AccountNumber { get; set; }
        #endregion Properties
    }
    #endregion Class
}