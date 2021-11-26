namespace Tutkoo.mintyfusion.Moov.Sdk.Interface
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
        Task<TransferResultModel> InitiateAsync(string accountId,
            TransferModel transferModel);

        Task<IList<TransferModel>> ListAsync(string accountId,
            TransferFilterModel transferFilterModel = null);

        Task<TransferModel> GetAsync(string id,
            GetTransferRequestModel requestModel);

        Task<TransferOptionsResponseModel> GetTransferOptionsAsync(string accountId,
            TransferOptionsRequestModel transferOptionsRequestModel);
        #endregion Methods
    }
    #endregion Interface
}