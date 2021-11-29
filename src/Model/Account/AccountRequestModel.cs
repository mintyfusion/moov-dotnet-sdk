namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Account
{
    #region Namespace
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class AccountRequestModel
    {
        /// <summary>
        /// Id from system database
        /// </summary>
        [JsonPropertyName("foreignID")]
        public string ForeignID { get; set; }

        [JsonPropertyName("profile")]
        public ProfileModel Profile { get; set; }

        [JsonPropertyName("metadata")]
        public IDictionary<string, string> Metadata { get; set; }

        [JsonPropertyName("termsOfService")]
        public TermsOfServiceModel TermsOfService { get; set; }
    }
    #endregion Class
}