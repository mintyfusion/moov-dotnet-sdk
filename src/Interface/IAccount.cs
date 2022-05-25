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

        Task<IList<AccountModel>> ListAsync(AccountQueryModel accountQuery = null);

        Task<AccountModel> GetAsync(string accountId);

        Task<string> GetTOSTokenAsync();

        Task<AccountModel> UpdateAsync(string accountId,
            AccountRequestModel updateAccount);

        Task<AccountModel> PatchAsync(string accountId,
            AccountRequestModel patchAccount);
        #endregion Methods
    }
    #endregion Interface
}