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

            string scope = Utility.Format(BankAccountScope.Read.Value(),
                accountId);

            string endpoint = Utility.Format(BankAccountEndpoint.List.Value(), accountId);

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

            string scope = Utility.Format(BankAccountScope.Read.Value(),
                accountId);

            string endpoint = Utility.Format(BankAccountEndpoint.Get.Value(),
                accountId,
                bankAccountId);

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

            string scope = Utility.Format(BankAccountScope.Write.Value(),
               accountId);

            string endpoint = Utility.Format(BankAccountEndpoint.Disable.Value(), accountId, bankAccountId);

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
        public async Task<BankAccountModel> CreateAsync(string accountId,
            BankAccountModel bankAccount)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            if (bankAccount == null)
                throw new ArgumentNullException(nameof(bankAccount));

            string scope = Utility.Format(BankAccountScope.Write.Value(),
                accountId);

            string endpoint = Utility.Format(BankAccountEndpoint.Create.Value(), accountId);

            BankAccountModel result = await moovClient.PostAsync<BankAccountModel>(endpoint,
                new List<string>() { scope },
                bankAccount);

            return result;
        }

        /// <summary>
        /// Add bank account with plaid token details
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="token"></param>
        /// <param name="usingPlaidLink">True if add plaid with link, false if add plaid with token</param>
        /// <returns>Bankaccount</returns>
        public async Task<BankAccountModel> CreateAsync(string accountId,
            string token,
            bool usingPlaidLink = false)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            if (string.IsNullOrEmpty(token))
                throw new ArgumentNullException(nameof(token));

            string scope = Utility.Format(BankAccountScope.Write.Value(),
                accountId);

            string endpoint = Utility.Format(BankAccountEndpoint.Create.Value(), accountId);

            IDictionary<string, object> postData = new Dictionary<string, object>();

            if (usingPlaidLink)
            {
                postData["plaidLink"] = new Dictionary<string, string>() { { "publicToken", token } };
            }
            else
            {
                postData["plaid"] = new Dictionary<string, string>() { { "token", token } };
            }

            BankAccountModel result = await moovClient.PostAsync<BankAccountModel>(endpoint,
                new List<string>() { scope },
                postData);

            return result;
        }

        public async Task<bool> InitiateMicroDepositVerificationAsync(string accountId,
           string bankAccountId)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            if (string.IsNullOrEmpty(bankAccountId))
                throw new ArgumentNullException(nameof(bankAccountId));

            string scope = Utility.Format(BankAccountScope.Write.Value(),
              accountId);

            string endpoint = Utility.Format(BankAccountEndpoint.InitiateMicroDepositeVerification.Value(), accountId, bankAccountId);

            bool success = await moovClient.PostAsync<bool>(endpoint,
                new List<string>() { scope });

            return success;
        }

        public async Task<bool> CompleteMicroDepositVerificationAsync(string accountId,
           string bankAccountId)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            if (string.IsNullOrEmpty(bankAccountId))
                throw new ArgumentNullException(nameof(bankAccountId));

            string scope = Utility.Format(BankAccountScope.Write.Value(),
              accountId);

            string endpoint = Utility.Format(BankAccountEndpoint.CompleteMicroDepositeVerification.Value(), accountId, bankAccountId);

            bool success = await moovClient.PutAsync<bool>(endpoint,
                new List<string>() { scope });

            return success;
        }
        #endregion Public Methods
    }
    #endregion Class
}