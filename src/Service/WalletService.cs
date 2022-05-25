namespace Tutkoo.mintyfusion.Moov.Sdk.Service
{
    #region namespace
    using Interface;
    using Model.Wallet;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Tutkoo.Essentials;
    #endregion namespace

    #region Class
    public class WalletService : IWallet
    {
        #region Fields
        private readonly IClient moovClient = null;
        #endregion Fields

        #region Constructor
        public WalletService(IClient moovClient)
        {
            this.moovClient = moovClient;
        }
        #endregion Constructor

        #region Public Methods
        /// <summary>
        /// Get list of wallets for an account
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns>List of WalletModel</returns>
        public async Task<IList<WalletModel>> ListAsync(string accountID)
        {
            if (string.IsNullOrEmpty(accountID))
                throw new ArgumentNullException(nameof(accountID));

            string scope = Utility.Format(WalletScope.Read.Value(),
                accountID);

            string endpoint = Utility.Format(WalletEndpoint.List.Value(),
                accountID);

            IList<WalletModel> wallets = await moovClient.GetAsync<IList<WalletModel>>(endpoint,
                new List<string>() { scope });

            return wallets;
        }

        /// <summary>
        /// Get wallet by id for an account
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="walletID"></param>
        /// <returns>WalletModel</returns>
        public async Task<WalletModel> GetAsync(string accountID,
           string walletID)
        {
            if (string.IsNullOrEmpty(accountID))
                throw new ArgumentNullException(nameof(accountID));

            if (string.IsNullOrEmpty(walletID))
                throw new ArgumentNullException(nameof(walletID));

            string scope = Utility.Format(WalletScope.Read.Value(),
                accountID);

            string endpoint = Utility.Format(WalletEndpoint.Get.Value(),
                accountID, walletID);

            WalletModel wallet = await moovClient.GetAsync<WalletModel>(endpoint,
                new List<string>() { scope });

            return wallet;
        }
        #endregion Public Methods
    }
    #endregion Class
}