namespace Tutkoo.mintyfusion.Moov.Sdk.Service
{
    #region namespace
    using Interface;
    using Model.Transfer;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Tutkoo.Essentials;
    #endregion namespace

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
        /// <param name="platformAccountID"></param>
        /// <param name="transfer"></param>
        /// <returns>Transfer unique id</returns>
        public async Task<TransferResultModel> InitiateAsync(TransferModel transfer)
        {
            if (transfer == null)
                throw new ArgumentNullException(nameof(transfer));

            string scope = Utility.Format(TransferScope.Write.Value(),
                moovClient.PlatformID);

            TransferResultModel transferResult = await moovClient.PostAsync<TransferResultModel>(TransferEndpoint.Create.Value(),
                new List<string>() { scope }, transfer);

            return transferResult;
        }

        /// <summary>
        /// Get all transfers for single account
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="transferQuery"></param>
        /// <returns></returns>
        public async Task<IList<TransferModel>> ListAsync(TransferQueryModel transferQuery = null)
        {
            string scope = Utility.Format(TransferScope.Read.Value(),
                moovClient.PlatformID);

            IList<TransferModel> list = await moovClient.GetAsync<IList<TransferModel>>(TransferEndpoint.List.Value(),
                new List<string>() { scope }, transferQuery);

            return list;
        }

        /// <summary>
        /// Get single transfer by id
        /// </summary>
        /// <param name="transferId"></param>
        /// <returns>TransferModel</returns>
        public async Task<TransferModel> GetAsync(string transferID)
        {
            if (string.IsNullOrEmpty(transferID))
                throw new ArgumentNullException(nameof(transferID));

            string scope = Utility.Format(TransferScope.Read.Value(),
                moovClient.PlatformID);

            string endpoint = Utility.Format(TransferEndpoint.Get.Value(), transferID);

            TransferModel transfer = await moovClient.GetAsync<TransferModel>(endpoint,
                new List<string>() { scope }, null,
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