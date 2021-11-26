namespace Tutkoo.mintyfusion.Moov.Sdk.Interface
{
    #region namespace
    using Model.Representative;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    #endregion namespace

    #region Interface
    public interface IRepresentative
    {
        #region Methods
        Task<RepresentativeModel> CreateAsync(string accountId,
            RepresentativeRequestModel representative);

        Task<IList<RepresentativeModel>> ListAsync(string accountId);

        Task<RepresentativeModel> GetAsync(string accountId,
            string representativeID);

        Task<bool> DisableAsync(string accountId,
            string representativeID);

        Task<RepresentativeModel> UpdateAsync(string accountId,
            string representativeID,
            RepresentativeRequestModel representative);
        #endregion Methods
    }
    #endregion Interface
}