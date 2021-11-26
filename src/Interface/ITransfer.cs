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
            TransferModel transfer);

        Task<IList<TransferModel>> ListAsync(string accountId,
            TransferQueryModel transferQuery = null);

        Task<TransferModel> GetAsync(string id,
            GetTransferRequestModel transferRequest);

        Task<TransferOptionsResponseModel> GetTransferOptionsAsync(string accountId,
            TransferOptionsRequestModel transferOptionsRequest);
        #endregion Methods
    }
    #endregion Interface
}