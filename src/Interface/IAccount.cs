namespace Tutkoo.mintyfusion.Moov.Sdk.Interface
{
    #region namespace
    using Model.Account;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    #endregion namespace

    #region Interface
    public interface IAccount
    {
        #region Methods
        Task<AccountModel> CreateAsync(CreateAccountRequestModel requestModel);

        Task<IList<AccountModel>> ListAsync(string accountId,
            AccountFilterModel filterModel = null);

        Task<AccountModel> GetAsync(string accountId);

        Task<AccountModel> UpdateAsync(string accountId,
            CreateAccountRequestModel updateRequestModel);

        Task<AccountModel> PatchAsync(string accountId,
            AccountRequestModel requestModel);
        #endregion Methods
    }
    #endregion Interface
}