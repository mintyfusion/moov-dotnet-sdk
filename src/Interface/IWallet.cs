namespace Tutkoo.mintyfusion.Moov.Sdk.Interface
{
    #region namespace
    using Model.Wallet;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    #endregion namespace

    #region Interface
    public interface IWallet
    {
        #region Methods
        Task<IList<WalletModel>> ListAsync(string accountID);

        Task<WalletModel> GetAsync(string accountID,
           string walletID);
        #endregion Methods
    }
    #endregion Interface
}