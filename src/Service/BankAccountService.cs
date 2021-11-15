namespace Tutkoo.mintyfusion.Moov.Sdk.Service
{
    #region namespace
    using Helper;
    using Interface;
    using Model.Bank;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Tutkoo.Essentials;
    #endregion namespace

    #region Class
    public class BankAccountService : IBankAccount
    {
        #region Fields
        private readonly MoovClient moovClient = null;
        #endregion Fields

        #region Constructor
        public BankAccountService(MoovClient moovClient)
        {
            this.moovClient = moovClient;
        }
        #endregion Constructor

        #region Public Methods
        /// <summary>
        /// Returns list of bank account(s) associated with account Id.
        /// </summary>
        /// <param name="accountId">Id of the Account.</param>
        /// <returns>List of BankAccounts</returns>
        /// <exception cref="MoovTokenException">Throws MoovTokenException when unable to get the Token.</exception>
        /// <exception cref="MoovSdkException">Throws MoovSdkException when unable to get Success from the API.</exception>
        public async Task<IList<BankAccountModel>> ListAsync(string accountId)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            string scope = string.Format(Scope.BankAccountsWrite.Value(),
                accountId);

            IList<BankAccountModel> bankAccountList = await moovClient.GetAsync<IList<BankAccountModel>>(string.Format(Endpoint.AddBankAccount.Value(),
                new List<string>() { scope }, accountId));

            return bankAccountList;
        }
        #endregion Public Methods
    }
    #endregion Class
}