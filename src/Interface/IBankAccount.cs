namespace Tutkoo.mintyfusion.Moov.Sdk.Interface
{
    #region namespace
    using Model.Bank;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    #endregion namespace

    #region Interface
    public interface IBankAccount
    {
        #region Methods
        Task<IList<BankAccountModel>> ListAsync(string accountId);
        #endregion Methods
    }
    #endregion Interface
}