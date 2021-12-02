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
        /// <param name="accountID">Id of the Account.</param>
        /// <returns>List of BankAccounts</returns>
        /// <exception cref="MoovTokenException">Throws MoovTokenException when unable to get the Token.</exception>
        /// <exception cref="MoovSdkException">Throws MoovSdkException when unable to get Success from the API.</exception>
        public async Task<IList<BankAccountModel>> ListAsync(string accountID)
        {
            if (string.IsNullOrEmpty(accountID))
                throw new ArgumentNullException(nameof(accountID));

            string scope = Utility.Format(BankAccountScope.Read.Value(),
                accountID);

            string endpoint = Utility.Format(BankAccountEndpoint.List.Value(),
                accountID);

            IList<BankAccountModel> bankAccountList = await moovClient.GetAsync<IList<BankAccountModel>>(endpoint,
                new List<string>() { scope });

            return bankAccountList;
        }

        /// <summary>
        /// Returns single bank account associated with bank account Id.
        /// </summary>
        /// <param name="accountID">Id of the Account.</param>
        /// <param name="bankAccountID">Id of the Bank acocunt.</param>
        /// <returns>Single bank account</returns>
        /// <exception cref="MoovTokenException">Throws MoovTokenException when unable to get the Token.</exception>
        /// <exception cref="MoovSdkException">Throws MoovSdkException when unable to get Success from the API.</exception>
        public async Task<BankAccountModel> GetAsync(string accountID,
            string bankAccountID)
        {
            if (string.IsNullOrEmpty(accountID))
                throw new ArgumentNullException(nameof(accountID));

            if (string.IsNullOrEmpty(bankAccountID))
                throw new ArgumentNullException(nameof(bankAccountID));

            string scope = Utility.Format(BankAccountScope.Read.Value(),
                accountID);

            string endpoint = Utility.Format(BankAccountEndpoint.Get.Value(),
                accountID, bankAccountID);

            BankAccountModel bankAccount = await moovClient.GetAsync<BankAccountModel>(endpoint,
                new List<string>() { scope });

            return bankAccount;
        }

        /// <summary>
        /// Disable bank account associated with bank account Id.
        /// </summary>
        /// <param name="accountID">Id of the Account.</param>
        /// <param name="bankAccountID">Id of the Bank acocunt.</param>
        /// <returns>true if disables</returns>
        /// <exception cref="MoovTokenException">Throws MoovTokenException when unable to get the Token.</exception>
        /// <exception cref="MoovSdkException">Throws MoovSdkException when unable to get Success from the API.</exception>
        public async Task<bool> DisableAsync(string accountID,
            string bankAccountID)
        {
            if (string.IsNullOrEmpty(accountID))
                throw new ArgumentNullException(nameof(accountID));

            if (string.IsNullOrEmpty(bankAccountID))
                throw new ArgumentNullException(nameof(bankAccountID));

            string scope = Utility.Format(BankAccountScope.Write.Value(),
               accountID);

            string endpoint = Utility.Format(BankAccountEndpoint.Disable.Value(),
                accountID, bankAccountID);

            bool success = await moovClient.DeleteAsync<bool>(endpoint,
                new List<string>() { scope });

            return success;
        }

        /// <summary>
        /// Add bank account with necessary details inside an account with id
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="bankAccount"></param>
        /// <returns>BankAccountModel with id</returns>
        public async Task<BankAccountModel> CreateAsync(string accountID,
            CreateBankAccountModel createBankAccount)
        {
            if (string.IsNullOrEmpty(accountID))
                throw new ArgumentNullException(nameof(accountID));

            if (createBankAccount == null)
                throw new ArgumentNullException(nameof(createBankAccount));

            string scope = Utility.Format(BankAccountScope.Write.Value(),
                accountID);

            string endpoint = Utility.Format(BankAccountEndpoint.Create.Value(),
                accountID);

            BankAccountModel result = await moovClient.PostAsync<BankAccountModel>(endpoint,
                new List<string>() { scope }, createBankAccount);

            return result;
        }

        /// <summary>
        /// Add bank account with plaid token details
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="token">Can be token in case of Plaid Processor or Public token in case of Plaid Link</param>
        /// <param name="usePlaidLink">True if add plaid with link, false if add plaid with token</param>
        /// <returns>Bankaccount</returns>
        public async Task<BankAccountModel> CreateAsync(string accountID,
            string token,
            bool usePlaidLink = false)
        {
            if (string.IsNullOrEmpty(accountID))
                throw new ArgumentNullException(nameof(accountID));

            if (string.IsNullOrEmpty(token))
                throw new ArgumentNullException(nameof(token));

            string scope = Utility.Format(BankAccountScope.Write.Value(),
                accountID);

            string endpoint = Utility.Format(BankAccountEndpoint.Create.Value(), accountID);

            IDictionary<string, object> postData = new Dictionary<string, object>();

            if (usePlaidLink)
                postData.Add("plaidLink", new Dictionary<string, string>() { { "publicToken", token } });
            else
                postData.Add("plaid", new Dictionary<string, string>() { { "token", token } });

            BankAccountModel result = await moovClient.PostAsync<BankAccountModel>(endpoint,
                new List<string>() { scope }, postData);

            return result;
        }

        public async Task InitiateMicroDepositVerificationAsync(string accountID,
           string bankAccountID)
        {
            if (string.IsNullOrEmpty(accountID))
                throw new ArgumentNullException(nameof(accountID));

            if (string.IsNullOrEmpty(bankAccountID))
                throw new ArgumentNullException(nameof(bankAccountID));

            string scope = Utility.Format(BankAccountScope.Write.Value(),
              accountID);

            string endpoint = Utility.Format(BankAccountEndpoint.InitiateMicroDepositeVerification.Value(),
                accountID, bankAccountID);

            await moovClient.PostAsync<string>(endpoint,
                new List<string>() { scope });
        }

        public async Task<string> CompleteMicroDepositVerificationAsync(string accountID,
           string bankAccountID, IList<int> amounts)
        {
            if (string.IsNullOrEmpty(accountID))
                throw new ArgumentNullException(nameof(accountID));

            if (string.IsNullOrEmpty(bankAccountID))
                throw new ArgumentNullException(nameof(bankAccountID));

            if (amounts == null || amounts.Count != 2)
                throw new ArgumentNullException(nameof(amounts));

            string scope = Utility.Format(BankAccountScope.Write.Value(),
              accountID);

            string endpoint = Utility.Format(BankAccountEndpoint.CompleteMicroDepositeVerification.Value(),
                accountID, bankAccountID);

            string status = await moovClient.PutAsync<string>(endpoint,
                new List<string>() { scope }, amounts);

            return status;
        }
        #endregion Public Methods
    }
    #endregion Class
}