namespace Tutkoo.mintyfusion.Moov.Sdk.Interface
{
    #region namespace
    using Model.Bank;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    #endregion namespace

    #region Interface
    public interface IBankAccount
    {
        #region Methods
        Task<IList<BankAccountModel>> ListAsync(string accountId);

        Task<BankAccountModel> GetAsync(string accountId,
            string bankAccountId);

        Task<bool> DisableAsync(string accountId,
            string bankAccountId);

        Task<BankAccountModel> AddAsync(string accountId,
            BankAccountModel bankAccount);

        Task<BankAccountModel> AddPlaidWithTokenAsync(string accountId,
            string plaidToken);

        Task<BankAccountModel> AddPlaidWithLinkAsync(string accountId,
            string publicToken);

        Task<bool> InitiateMicroDepositsAsync(string accountId,
           string bankAccountId);

        Task<bool> CompleteMicroDepositsAsync(string accountId,
           string bankAccountId);
        #endregion Methods
    }
    #endregion Interface
}