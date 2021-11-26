namespace Tutkoo.mintyfusion.Moov.Sdk.Service
{
    #region Namespace
    using Interface;
    using Model.Account;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Tutkoo.Essentials;
    #endregion Namespace

    #region Class
    public class AccountService : IAccount
    {
        #region Fields
        private readonly IClient moovClient = null;
        #endregion Fields

        #region Constructor
        public AccountService(IClient moovClient)
        {
            this.moovClient = moovClient;
        }
        #endregion Constructor

        #region Public Methods
        /// <summary>
        /// Create account necessary business or individual details
        /// </summary>
        /// <param name="createAccount"></param>
        /// <returns>AccountModel</returns>
        public async Task<AccountModel> CreateAsync(CreateUpdateAccountRequestModel createAccount)
        {
            if (createAccount == null)
                throw new ArgumentNullException(nameof(createAccount));

            string scope = Utility.Format(AccountScope.Write.Value());

            string endpoint = Utility.Format(AccountEndpoint.Create.Value());

            AccountModel response = await moovClient.PostAsync<AccountModel>(endpoint,
                new List<string> { scope }, createAccount);

            return response;
        }

        /// <summary>
        /// Get accounts linked with moov account
        /// </summary>
        /// <param name="accountId">Moov account id</param>
        /// <param name="accountQuery"></param>
        /// <returns>List of account</returns>
        public async Task<IList<AccountModel>> ListAsync(string accountId,
            AccountQueryModel accountQuery = null)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentException(null, nameof(accountId));

            string scope = Utility.Format(AccountScope.Read.Value());

            string endpoint = Utility.Format(AccountEndpoint.List.Value());

            IList<AccountModel> response = await moovClient.GetAsync<IList<AccountModel>>(endpoint,
                new List<string> { scope }, accountQuery);

            return response;
        }

        /// <summary>
        /// Get account with id
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns>AccountModel</returns>
        public async Task<AccountModel> GetAsync(string accountId)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            string scope = Utility.Format(AccountScope.Read.Value(), accountId);

            string endpoint = Utility.Format(AccountEndpoint.Get.Value(), accountId);

            AccountModel account = await moovClient.GetAsync<AccountModel>(endpoint,
                new List<string> { scope });

            return account;
        }

        /// <summary>
        /// Update account
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="updateAccount"></param>
        /// <returns>UpdatedAccount</returns>
        public async Task<AccountModel> UpdateAsync(string accountId,
            CreateUpdateAccountRequestModel updateAccount)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            if (updateAccount == null)
                throw new ArgumentNullException(nameof(updateAccount));

            string scope = Utility.Format(AccountScope.Update.Value(), accountId);

            string endpoint = Utility.Format(AccountEndpoint.Update.Value(), accountId);

            AccountModel account = await moovClient.PutAsync<AccountModel>(endpoint,
                new List<string> { scope }, updateAccount);

            return account;
        }

        /// <summary>
        /// Patch account with details
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="account"></param>
        /// <returns>AccountModel</returns>
        public async Task<AccountModel> PatchAsync(string accountId,
            AccountRequestModel account)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            if (account == null)
                throw new ArgumentNullException(nameof(account));

            string scope = Utility.Format(AccountScope.Write.Value(), accountId);

            string endpoint = Utility.Format(AccountEndpoint.Patch.Value(), accountId);

            AccountModel patchedAccount = await moovClient.Patch<AccountModel>(endpoint,
                new List<string> { scope }, account);

            return patchedAccount;
        }
        #endregion Public Methods
    }
    #endregion Class
}