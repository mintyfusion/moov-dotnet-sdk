namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Representative
{
    #region namespace
    using Account;
    using System.Text.Json.Serialization;
    #endregion namespace

    #region Class
    public class CreateUpdateRepresentativeRequestModel
    {
        #region Properties
        [JsonPropertyName("name")]
        public NameModel Name { get; set; }

        [JsonPropertyName("phone")]
        public PhoneModel Phone { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("address")]
        public AddressModel Address { get; set; }

        [JsonPropertyName("birthDate")]
        public DateModel BirthDate { get; set; }

        [JsonPropertyName("governmentID")]
        public GovernmentIdModel GovernmentID { get; set; }

        [JsonPropertyName("responsibilities")]
        public ResponsibilitiesModel Responsibilities { get; set; }
        #endregion Properties
    }
    #endregion Class
}