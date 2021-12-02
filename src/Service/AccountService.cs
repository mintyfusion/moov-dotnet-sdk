namespace Tutkoo.mintyfusion.Moov.Sdk.Service
{
    #region namespace
    using Interface;
    using Model.Account;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Tutkoo.Essentials;
    #endregion namespace

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

            AccountModel response = await moovClient.PostAsync<AccountModel>(AccountEndpoint.Create.Value(),
                new List<string> { scope }, createAccount);

            return response;
        }

        /// <summary>
        /// Get accounts linked with moov account
        /// </summary>
        /// <param name="accountId">Moov account id</param>
        /// <param name="accountQuery"></param>
        /// <returns>List of account</returns>
        public async Task<IList<AccountModel>> ListAsync(AccountQueryModel accountQuery = null)
        {
            string scope = Utility.Format(AccountScope.Read.Value(), 
                moovClient.PlatformID);

            IList<AccountModel> response = await moovClient.GetAsync<IList<AccountModel>>(AccountEndpoint.List.Value(),
                new List<string> { scope }, accountQuery, new Dictionary<string, string>() { { Constant.X_ACCOUNT_ID, moovClient.PlatformID } });

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

            string scope = Utility.Format(AccountScope.Read.Value(),
                accountId);

            string endpoint = Utility.Format(AccountEndpoint.Get.Value(),
                accountId);

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
            AccountRequestModel updateAccount)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            if (updateAccount == null)
                throw new ArgumentNullException(nameof(updateAccount));

            string scope = Utility.Format(AccountScope.Update.Value(),
                accountId);

            string endpoint = Utility.Format(AccountEndpoint.Update.Value(),
                accountId);

            AccountModel account = await moovClient.PutAsync<AccountModel>(endpoint,
                new List<string> { scope }, updateAccount);

            return account;
        }

        /// <summary>
        /// Patch account with details
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="patchAccount"></param>
        /// <returns>AccountModel</returns>
        public async Task<AccountModel> PatchAsync(string accountId,
            AccountRequestModel patchAccount)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            if (patchAccount == null)
                throw new ArgumentNullException(nameof(patchAccount));

            string scope = Utility.Format(AccountScope.Patch.Value(),
                accountId);

            string endpoint = Utility.Format(AccountEndpoint.Patch.Value(),
                accountId);

            AccountModel patchedAccount = await moovClient.Patch<AccountModel>(endpoint,
                new List<string> { scope }, patchAccount);

            return patchedAccount;
        }
        #endregion Public Methods
    }
    #endregion Class
}