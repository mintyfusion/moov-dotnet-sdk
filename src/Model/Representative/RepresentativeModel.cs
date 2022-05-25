namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Representative
{
    #region Namespace
    using Account;
    using System;
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class RepresentativeModel
    {
        [JsonPropertyName("representativeID")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public NameModel Name { get; set; }

        [JsonPropertyName("phone")]
        public PhoneModel Phone { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("address")]
        public AddressModel Address { get; set; }

        [JsonPropertyName("birthDateProvided")]
        public bool BirthDateProvided { get; set; }

        [JsonPropertyName("governmentIDProvided")]
        public bool GovernmentIDProvided { get; set; }

        [JsonPropertyName("responsibilities")]
        public ResponsibilitiesModel Responsibilities { get; set; }

        [JsonPropertyName("createdOn")]
        public DateTime CreatedOn { get; set; }

        [JsonPropertyName("updatedOn")]
        public DateTime UpdatedOn { get; set; }

        [JsonPropertyName("disabledOn")]
        public DateTime DisabledOn { get; set; }
    }
    #endregion Class
}