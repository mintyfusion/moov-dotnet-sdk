namespace Tutkoo.mintyfusion.Moov.Sdk.Interface
{
    #region namespace
    using Model.PaymentMethod;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    #endregion namespace

    #region Interface
    public interface IPaymentMethod
    {
        #region Methods
        Task<IList<PaymentMethodModel>> ListAsync(string accountID,
            PaymentMethodQueryModel paymentMethodQuery = null);

        Task<PaymentMethodModel> GetAsync(string accountID,
            string paymentMethodID);
        #endregion Methods
    }
    #endregion Interface
}