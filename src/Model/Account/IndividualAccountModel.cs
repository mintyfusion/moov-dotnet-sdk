namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Account
{
    #region namespace
    using System.Text.Json.Serialization;
    #endregion namespace

    #region Class
    public class IndividualAccountModel : AccountBaseModel
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