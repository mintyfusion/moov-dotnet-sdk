namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Account
{
    #region Namespace
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class IndividualAccountModel : BaseAccountModel
    {
        [JsonPropertyName("name")]
        public NameModel Name { get; set; }

        [JsonPropertyName("birthDate")]
        public DateModel BirthDate { get; set; }

        [JsonPropertyName("governmentID")]
        public GovernmentIdModel GovernmentID { get; set; }
    }
    #endregion Class
}