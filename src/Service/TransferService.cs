namespace Tutkoo.mintyfusion.Moov.Sdk.Service
{
    #region Namespace
    using Interface;
    using Model.Transfer;
    using System;
    using System.Collections.Generic;
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
        /// <param name="transfer"></param>
        /// <returns>Transfer unique id</returns>
        public async Task<TransferResultModel> InitiateAsync(string accountId,
            TransferModel transfer)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            if (transfer == null)
                throw new ArgumentNullException(nameof(transfer));

            string scope = Utility.Format(TransferScope.Write.Value(),
                accountId);

            string endpoint = Utility.Format(TransferEndpoint.Create.Value(), accountId);

            TransferResultModel transferResult = await moovClient.PostAsync<TransferResultModel>(endpoint,
                new List<string>() { scope }, transfer);

            return transferResult;
        }

        /// <summary>
        /// Get all transfers for single account
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="transferQuery"></param>
        /// <returns></returns>
        public async Task<IList<TransferModel>> ListAsync(string accountId,
            TransferQueryModel transferQuery = null)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            string scope = Utility.Format(TransferScope.Read.Value(),
                accountId);

            string endpoint = Utility.Format(TransferEndpoint.List.Value());

            IList<TransferModel> list = await moovClient.GetAsync<IList<TransferModel>>(endpoint,
                new List<string>() { scope }, transferQuery);

            return list;
        }

        /// <summary>
        /// Get single transfer by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="transferRequest"></param>
        /// <returns>TransferModel</returns>
        public async Task<TransferModel> GetAsync(string id,
            GetTransferRequestModel transferRequest)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentNullException(nameof(id));

            if (transferRequest == null)
                throw new ArgumentNullException(nameof(transferRequest));

            string scope = Utility.Format(TransferScope.Read.Value(),
                transferRequest.AccountId);

            string endpoint = Utility.Format(TransferEndpoint.Get.Value(), id);

            TransferModel transfer = await moovClient.GetAsync<TransferModel>(endpoint,
                new List<string>() { scope }, transferRequest,
                new Dictionary<string, string>() { { Constant.X_ACCOUNT_ID, moovClient.PlatformID } });

            return transfer;
        }

        /// <summary>
        /// Get available transfer options for account
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="transferOptionsRequest"></param>
        /// <returns></returns>
        public async Task<TransferOptionsResponseModel> GetTransferOptionsAsync(string accountId,
            TransferOptionsRequestModel transferOptionsRequest)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            if (transferOptionsRequest == null)
                throw new ArgumentNullException(nameof(transferOptionsRequest));

            string scope = Utility.Format(TransferScope.Read.Value(),
                accountId);

            string endpoint = TransferEndpoint.GetTransferOptions.Value();

            TransferOptionsResponseModel transferOptionsResponse = await moovClient.PostAsync<TransferOptionsResponseModel>(endpoint,
                new List<string>() { scope }, transferOptionsRequest);

            return transferOptionsResponse;
        }
        #endregion Public Methods
    }
    #endregion Class
}