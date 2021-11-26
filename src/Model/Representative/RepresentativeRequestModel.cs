namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Representative
{
    #region Namespace
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    //TODO: Fix this model once AccountService Branch gets merged
    public class RepresentativeRequestModel
    {
        //[JsonPropertyName("name")]
        //public NameModel Name { get; set; }

        //[JsonPropertyName("phone")]
        //public PhoneModel Phone { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        //[JsonPropertyName("address")]
        //public AddressModel Address { get; set; }

        //[JsonPropertyName("birthDate")]
        //public DateModel BirthDate { get; set; }

        //[JsonPropertyName("governmentID")]
        //public GovernmentIdModel GovernmentIdModel { get; set; }

        [JsonPropertyName("responsibilities")]
        public ResponsibilitiesModel Responsibilities { get; set; }
    }
    #endregion Class
}