namespace Tutkoo.mintyfusion.Moov.Sdk.Model.Account
{
    #region Namespace
    using System.Text.Json.Serialization;
    #endregion

    #region Class
    public class BaseAccountModel
    {
        [JsonPropertyName("phone")]
        public PhoneModel Phone { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("address")]
        public AddressModel Address { get; set; }
    }
    #endregion Class
}