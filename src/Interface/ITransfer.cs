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
        Task<TransferResultModel> InitiateAsync(TransferModel transfer);

        Task<IList<TransferModel>> ListAsync(TransferQueryModel transferQuery = null);

        Task<TransferModel> GetAsync(string transferID);

        Task<TransferOptionsResponseModel> GetTransferOptionsAsync(string accountId,
            TransferOptionsRequestModel transferOptionsRequest);
        #endregion Methods
    }
    #endregion Interface
}