namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Representative
{
    #region Namespace
    using Account;
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class CreateUpdateRepresentativeRequestModel
    {
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
    }
    #endregion Class
}