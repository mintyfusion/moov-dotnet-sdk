namespace Tutkoo.mintyfusion.Moov.Sdk.Service
{
    #region Namespace
    using Interface;
    using Model.Account;
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
        /// <param name="requestModel"></param>
        /// <returns>AccountModel</returns>
        public async Task<AccountModel> CreateAsync(CreateAccountRequestModel requestModel)
        {
            if (requestModel == null)
                throw new ArgumentNullException(nameof(requestModel));

            string scope = Utility.Format(AccountScope.Write.Value());

            string endpoint = Utility.Format(AccountEndpoint.Create.Value());

            AccountModel response = await moovClient.PostAsync<AccountModel>(endpoint,
                new List<string> { scope },
                requestModel);

            return response;
        }

        /// <summary>
        /// Get accounts linked with moov account
        /// </summary>
        /// <param name="accountId">Moov account id</param>
        /// <param name="filterModel"></param>
        /// <param name="count"></param>
        /// <param name="skip"></param>
        /// <returns>List of account</returns>
        public async Task<IList<AccountModel>> ListAsync(string accountId,
            AccountFilterModel filterModel = null,
            int? count = null,
            int? skip = null)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentException(nameof(accountId));

            IDictionary<string, string> queryParams = null;

            // Convert model to <string, string> keyvalue pair query dictionary
            if (filterModel != null)
                queryParams = filterModel.AsDictionary().ToDictionary(k => k.Key, k => (string)k.Value);

            if (count.HasValue)
                queryParams[Constant.COUNT] = count.ToString();

            if (skip.HasValue)
                queryParams[Constant.SKIP] = skip.ToString();

            string scope = Utility.Format(AccountScope.Read.Value());

            string endpoint = Utility.Format(AccountEndpoint.List.Value());

            IList<AccountModel> response = await moovClient.GetAsync<IList<AccountModel>>(endpoint,
                new List<string> { scope },
                queryParams);

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
        /// <param name="updateRequestModel"></param>
        /// <returns>UpdatedAccount</returns>
        public async Task<AccountModel> UpdateAsync(string accountId,
            CreateAccountRequestModel updateRequestModel)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            if (updateRequestModel == null)
                throw new ArgumentNullException(nameof(updateRequestModel));

            string scope = Utility.Format(AccountScope.Update.Value(), accountId);

            string endpoint = Utility.Format(AccountEndpoint.Update.Value(), accountId);

            AccountModel account = await moovClient.PutAsync<AccountModel>(endpoint,
                new List<string> { scope },
                updateRequestModel);

            return account;
        }

        /// <summary>
        /// Patch account with details
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="requestModel"></param>
        /// <returns>AccountModel</returns>
        public async Task<AccountModel> PatchAsync(string accountId,
            AccountRequestModel requestModel)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            if (requestModel == null)
                throw new ArgumentNullException(nameof(requestModel));

            string scope = Utility.Format(AccountScope.Write.Value(), accountId);

            string endpoint = Utility.Format(AccountEndpoint.Patch.Value(), accountId);

            AccountModel account = await moovClient.Patch<AccountModel>(endpoint,
                new List<string> { scope },
                requestModel);

            return account;
        }
        #endregion Public Methods
    }
    #endregion Class
}