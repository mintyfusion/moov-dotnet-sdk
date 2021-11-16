namespace Tutkoo.mintyfusion.Moov.Sdk.Service
{
    #region namespace
    using Interface;
    using Model.Bank;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Tutkoo.Essentials;
    #endregion namespace

    #region Class
    public class BankAccountService : IBankAccount
    {
        #region Fields
        private readonly IClient moovClient = null;
        #endregion Fields

        #region Constructor
        public BankAccountService(IClient moovClient)
        {
            this.moovClient = moovClient;
        }
        #endregion Constructor

        #region Public Methods
        /// <summary>
        /// Returns list of bank account(s) associated with account Id.
        /// </summary>
        /// <param name="accountId">Id of the Account.</param>
        /// <returns>List of BankAccounts</returns>
        /// <exception cref="MoovTokenException">Throws MoovTokenException when unable to get the Token.</exception>
        /// <exception cref="MoovSdkException">Throws MoovSdkException when unable to get Success from the API.</exception>
        public async Task<IList<BankAccountModel>> ListAsync(string accountId)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            string scope = string.Format(Scope.BankAccountsRead.Value(),
                accountId);

            string endpoint = string.Format(Endpoint.ListBankAccounts.Value(), accountId);

            IList<BankAccountModel> bankAccountList = await moovClient.GetAsync<IList<BankAccountModel>>(endpoint,
                new List<string>() { scope });

            return bankAccountList;
        }

        /// <summary>
        /// Returns single bank account associated with bank account Id.
        /// </summary>
        /// <param name="accountId">Id of the Account.</param>
        /// <param name="bankAccountId">Id of the Bank acocunt.</param>
        /// <returns>Single bank account</returns>
        /// <exception cref="MoovTokenException">Throws MoovTokenException when unable to get the Token.</exception>
        /// <exception cref="MoovSdkException">Throws MoovSdkException when unable to get Success from the API.</exception>
        public async Task<BankAccountModel> GetAsync(string accountId,
            string bankAccountId)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            if (string.IsNullOrEmpty(bankAccountId))
                throw new ArgumentNullException(nameof(bankAccountId));

            string scope = string.Format(Scope.BankAccountsRead.Value(),
                accountId);

            string endpoint = string.Format(Endpoint.GetBankAccount.Value(), accountId, bankAccountId);

            BankAccountModel bankAccount = await moovClient.GetAsync<BankAccountModel>(endpoint,
                new List<string>() { scope });

            return bankAccount;
        }

        /// <summary>
        /// Disable bank account associated with bank account Id.
        /// </summary>
        /// <param name="accountId">Id of the Account.</param>
        /// <param name="bankAccountId">Id of the Bank acocunt.</param>
        /// <returns>true if disables</returns>
        /// <exception cref="MoovTokenException">Throws MoovTokenException when unable to get the Token.</exception>
        /// <exception cref="MoovSdkException">Throws MoovSdkException when unable to get Success from the API.</exception>
        public async Task<bool> DisableAsync(string accountId,
            string bankAccountId)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            if (string.IsNullOrEmpty(bankAccountId))
                throw new ArgumentNullException(nameof(bankAccountId));

            string scope = string.Format(Scope.BankAccountsWrite.Value(),
               accountId);

            string endpoint = string.Format(Endpoint.DisableBankAccount.Value(), accountId, bankAccountId);

            bool success = await moovClient.DeleteAsync<bool>(endpoint,
                new List<string>() { scope });

            return success;
        }

        /// <summary>
        /// Add bank account with necessary details inside an account with id
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="bankAccount"></param>
        /// <returns>BankAccountModel with id</returns>
        public async Task<BankAccountModel> AddAsync(string accountId,
            BankAccountModel bankAccount)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            if (bankAccount == null)
                throw new ArgumentNullException(nameof(bankAccount));

            string scope = string.Format(Scope.BankAccountsWrite.Value(),
                accountId);

            string endpoint = string.Format(Endpoint.AddBankAccount.Value(), accountId);

            BankAccountModel result = await moovClient.PostAsync<BankAccountModel>(endpoint,
                new List<string>() { scope },
                bankAccount);

            return result;
        }

        /// <summary>
        /// Add bank account with plaid token details
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="plaidToken"></param>
        /// <returns>Bank account with id</returns>
        public async Task<BankAccountModel> AddPlaidWithTokenAsync(string accountId,
            string plaidToken)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            if (string.IsNullOrEmpty(plaidToken))
                throw new ArgumentNullException(nameof(plaidToken));

            string scope = string.Format(Scope.BankAccountsWrite.Value(),
                accountId);

            string endpoint = string.Format(Endpoint.AddBankAccount.Value(), accountId);

            BankAccountModel result = await moovClient.PostAsync<BankAccountModel>(endpoint,
                new List<string>() { scope },
                new Dictionary<string, object>()
                {
                    { "plaid", new Dictionary<string, string>() { { "token", plaidToken} } }
                });

            return result;
        }

        /// <summary>
        /// Add bank account with public token details
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="publicToken"></param>
        /// <returns>Bank account with id</returns>
        public async Task<BankAccountModel> AddPlaidWithLinkAsync(string accountId,
            string publicToken)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            if (string.IsNullOrEmpty(publicToken))
                throw new ArgumentNullException(nameof(publicToken));

            string scope = string.Format(Scope.BankAccountsWrite.Value(),
                accountId);

            string endpoint = string.Format(Endpoint.AddBankAccount.Value(), accountId);

            BankAccountModel result = await moovClient.PostAsync<BankAccountModel>(endpoint,
                new List<string>() { scope },
                new Dictionary<string, object>()
                {
                    { "plaidLink", new Dictionary<string, string>() { { "publicToken", publicToken } } }
                });

            return result;
        }

        public async Task<bool> InitiateMicroDepositsAsync(string accountId,
           string bankAccountId)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            if (string.IsNullOrEmpty(bankAccountId))
                throw new ArgumentNullException(nameof(bankAccountId));

            string scope = string.Format(Scope.BankAccountsWrite.Value(),
              accountId);

            string endpoint = string.Format(Endpoint.InitiateMicroDeposite.Value(), accountId, bankAccountId);

            bool success = await moovClient.PostAsync<bool>(endpoint,
                new List<string>() { scope });

            return success;
        }

        public async Task<bool> CompleteMicroDepositsAsync(string accountId,
           string bankAccountId)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            if (string.IsNullOrEmpty(bankAccountId))
                throw new ArgumentNullException(nameof(bankAccountId));

            string scope = string.Format(Scope.BankAccountsWrite.Value(),
              accountId);

            string endpoint = string.Format(Endpoint.CompleteMicroDeposite.Value(), accountId, bankAccountId);

            bool success = await moovClient.PutAsync<bool>(endpoint,
                new List<string>() { scope });

            return success;
        }
        #endregion Public Methods
    }
    #endregion Class
}