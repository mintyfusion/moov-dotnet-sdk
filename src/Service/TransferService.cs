namespace Tutkoo.mintyfusion.Moov.Sdk.Service
{
    #region Namespace
    using Interface;
    using Model.Transfer;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Tutkoo.Essentials;
    #endregion Namespace

    #region Class
    public class TransferService : ITransfer
    {
        #region Fields
        private readonly IClient moovClient = null;
        #endregion Fields

        #region Constructor
        public TransferService(IClient moovClient)
        {
            this.moovClient = moovClient;
        }
        #endregion Constructor

        #region Public Methods
        /// <summary>
        /// Initiate tranfer for account
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="transferModel"></param>
        /// <returns>Transfer unique id</returns>
        public async Task<TransferResultModel> InitiateAsync(string accountId,
            TransferModel transferModel)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            if (transferModel == null)
                throw new ArgumentNullException(nameof(transferModel));

            string scope = Utility.Format(TransferScope.Write.Value(),
                accountId);

            string endpoint = Utility.Format(TransferEndpoint.Create.Value(), accountId);

            TransferResultModel transferResult = await moovClient.PostAsync<TransferResultModel>(endpoint,
                new List<string>() { scope },
                transferModel);

            return transferResult;
        }

        /// <summary>
        /// Get all transfers for single account
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="transferFilterModel"></param>
        /// <returns></returns>
        public async Task<IList<TransferModel>> ListAsync(string accountId,
            TransferFilterModel transferFilterModel = null)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            string scope = Utility.Format(TransferScope.Read.Value(),
                accountId);

            string endpoint = Utility.Format(TransferEndpoint.List.Value());

            IDictionary<string, string> queryParams = new Dictionary<string, string>();

            // Convert model to <string, string> keyvalue pair query dictionary
            if (transferFilterModel != null)
                queryParams = transferFilterModel.AsDictionary().ToDictionary(k => k.Key, k => (string)k.Value);

            IList<TransferModel> tranferList = await moovClient.GetAsync<IList<TransferModel>>(endpoint,
                new List<string>() { scope },
                queryParams);

            return tranferList;
        }

        /// <summary>
        /// Get single transfer by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="requestModel"></param>
        /// <returns>TransferModel</returns>
        public async Task<TransferModel> GetAsync(string id,
            GetTransferRequestModel requestModel)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            if (requestModel == null)
                throw new ArgumentNullException(nameof(requestModel));

            string scope = Utility.Format(TransferScope.Read.Value(),
                requestModel.AccountId);

            string endpoint = Utility.Format(TransferEndpoint.Get.Value(), id);

            IDictionary<string, string> queryParams = new Dictionary<string, string>();

            // Convert model to <string, string> keyvalue pair query dictionary
            if (requestModel != null)
                queryParams = requestModel.AsDictionary().ToDictionary(k => k.Key, k => (string)k.Value);

            TransferModel transfer = await moovClient.GetAsync<TransferModel>(endpoint,
                new List<string>() { scope },
                queryParams,
                new Dictionary<string, string>() { { Constant.X_ACCOUNTID, moovClient.PlatformID } });

            return transfer;
        }

        /// <summary>
        /// Get available transfer options for account
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="transferOptionsRequestModel"></param>
        /// <returns></returns>
        public async Task<TransferOptionsResponseModel> GetTransferOptionsAsync(string accountId,
            TransferOptionsRequestModel transferOptionsRequestModel)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            if (transferOptionsRequestModel == null)
                throw new ArgumentNullException(nameof(transferOptionsRequestModel));

            string scope = Utility.Format(TransferScope.Read.Value(),
                accountId);

            string endpoint = TransferEndpoint.GetTransferOptions.Value();

            TransferOptionsResponseModel transferOptionsResponse = await moovClient.PostAsync<TransferOptionsResponseModel>(endpoint,
                new List<string>() { scope },
                transferOptionsRequestModel);

            return transferOptionsResponse;
        }
        #endregion Public Methods
    }
    #endregion Class
}