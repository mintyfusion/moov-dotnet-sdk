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
        Task<AccountModel> CreateAsync(CreateUpdateAccountRequestModel createAccount);

        Task<IList<AccountModel>> ListAsync(string accountId,
            AccountQueryModel accountQuery = null);

        Task<AccountModel> GetAsync(string accountId);

        Task<AccountModel> UpdateAsync(string accountId,
            CreateUpdateAccountRequestModel updateAccount);

        Task<AccountModel> PatchAsync(string accountId,
            AccountRequestModel account);
        #endregion Methods
    }
    #endregion Interface
}