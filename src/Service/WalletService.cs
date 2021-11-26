namespace Tutkoo.mintyfusion.Moov.Sdk.Service
{
    #region Namespace
    using Interface;
    using Model.Wallet;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Tutkoo.Essentials;
    #endregion Namespace

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
        /// <param name="accountId"></param>
        /// <returns>List of WalletModel</returns>
        public async Task<IList<WalletModel>> ListAsync(string accountId)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            string scope = Utility.Format(WalletScope.Read.Value(),
                accountId);

            string endpoint = Utility.Format(WalletEndpoint.List.Value(),
                accountId);

            IList<WalletModel> wallets = await moovClient.GetAsync<IList<WalletModel>>(endpoint,
                new List<string>() { scope });

            return wallets;
        }

        /// <summary>
        /// Get wallet by id for an account
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="walletId"></param>
        /// <returns>WalletModel</returns>
        public async Task<WalletModel> GetAsync(string accountId,
           string walletId)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            if (string.IsNullOrEmpty(walletId))
                throw new ArgumentNullException(nameof(walletId));

            string scope = Utility.Format(WalletScope.Read.Value(),
                accountId);

            string endpoint = Utility.Format(WalletEndpoint.Get.Value(),
                accountId,
                walletId);

            WalletModel wallet = await moovClient.GetAsync<WalletModel>(endpoint,
                new List<string>() { scope });

            return wallet;
        }
        #endregion Public Methods
    }
    #endregion Class
}