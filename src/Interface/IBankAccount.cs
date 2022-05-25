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
        Task<IList<BankAccountModel>> ListAsync(string accountID);

        Task<BankAccountModel> GetAsync(string accountID,
            string bankAccountID);

        Task<bool> DisableAsync(string accountID,
            string bankAccountID);

        Task<BankAccountModel> CreateAsync(string accountID,
            CreateBankAccountModel createBankAccount);

        Task<BankAccountModel> CreateAsync(string accountID,
            string token,
            bool usePlaidLink = false);

        Task InitiateMicroDepositVerificationAsync(string accountID,
           string bankAccountID);

        Task<string> CompleteMicroDepositVerificationAsync(string accountID,
           string bankAccountID, IList<int> amounts);
        #endregion Methods
    }
    #endregion Interface
}