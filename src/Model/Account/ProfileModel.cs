namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Account
{
    #region namespace
    using System.Text.Json.Serialization;
    #endregion namespace

    #region Class
    public class ProfileModel
    {
        [JsonPropertyName("individual")]
        public IndividualAccountModel Individual { get; set; }

        [JsonPropertyName("business")]
        public BusinessAccountModel Business { get; set; }
    }
    #endregion Class
}