namespace Tutkoo.mintyfusion.Moov.Sdk.Service
{
    #region Namespace
    using Interface;
    using Model.Transfer;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
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
        /// <param name="key"></param>
        /// <param name="transferModel"></param>
        /// <returns>Transfer unique id</returns>
        public async Task<string> InitiateAsync(string accountId,
            string key,
            TransferModel transferModel)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            if (transferModel == null)
                throw new ArgumentNullException(nameof(transferModel));

            string scope = Utility.Format(TransferScope.Write.Value(),
                accountId);

            string endpoint = Utility.Format(TransferEndpoint.Create.Value(), accountId);

            IDictionary<string, string> transferDetails = await moovClient.PostAsync<IDictionary<string, string>>(endpoint,
                new List<string>() { scope },
                transferModel,
                new Dictionary<string, string>() { { "X-Idempotency-Key" , key} });

            return transferDetails["transferID"];
        }

        /// <summary>
        /// Get all transfers for single account
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="transferFilterModel"></param>
        /// <param name="count"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        public async Task<IList<TransferModel>> ListAsync(string accountId,
            TransferFilterModel transferFilterModel = null,
            int? count = null,
            int? skip = null)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException("accountId");

            string scope = Utility.Format(TransferScope.Read.Value(),
                accountId);

            string endpoint = Utility.Format(TransferEndpoint.List.Value());

            IDictionary<string, string> queryParams = new Dictionary<string, string>();

            // Convert model to <string, string> keyvalue pair query dictionary
            if (transferFilterModel != null)
            {
                queryParams = transferFilterModel.GetType()
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .ToDictionary(prop => prop.Name, prop => (string)prop.GetValue(transferFilterModel, null));
            }

            if (count.HasValue)
                queryParams["count"] = count.ToString();

            if (skip.HasValue)
                queryParams["skip"] = skip.ToString();

            IList<TransferModel> tranferList = await moovClient.GetAsync<IList<TransferModel>>(endpoint,
                new List<string>() { scope },
                queryParams);

            return tranferList;
        }

        /// <summary>
        /// Get singel transfer by id
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="transferId"></param>
        /// <returns>TransferModel</returns>
        public async Task<TransferModel> GetAsync(string accountId,
            string transferId)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            if (string.IsNullOrEmpty(transferId))
                throw new ArgumentNullException(nameof(transferId));

            string scope = Utility.Format(TransferScope.Read.Value(),
                accountId);

            string endpoint = Utility.Format(TransferEndpoint.Get.Value(), transferId);

            TransferModel transfer = await moovClient.GetAsync<TransferModel>(endpoint,
                new List<string>() { scope },
                new Dictionary<string, string> { { "accountId", accountId } },
                new Dictionary<string, string>() { { "X-Account-ID", accountId } });

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
                throw new ArgumentNullException("accountId");

            if (transferOptionsRequestModel == null)
                throw new ArgumentNullException("transferOptionsRequestModel");

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