﻿namespace Tutkoo.mintyfusion.Moov.Sdk.Interface
{
    #region namespace
    using Model.Transfer;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    #endregion namespace

    #region Interface
    public interface ITransfer
    {
        #region Methods
        Task<string> InitiateAsync(string accountId,
            string key,
            TransferModel transferModel);

        Task<IList<TransferModel>> ListAsync(string accountId,
            TransferFilterModel transferFilterModel = null,
            int? count = null,
            int? skip = null);

        Task<TransferModel> GetAsync(string accountId,
            string transferId);

        Task<TransferOptionsResponseModel> GetTransferOptionsAsync(string accountId,
            TransferOptionsRequestModel transferOptionsRequestModel);
        #endregion Methods
    }
    #endregion Interface
}