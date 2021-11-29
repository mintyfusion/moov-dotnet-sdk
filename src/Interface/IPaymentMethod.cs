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
        Task<IList<PaymentMethodModel>> ListAsync(string accountId,
            PaymentMethodQueryModel paymentMethodQuery = null);

        Task<PaymentMethodModel> GetAsync(string accountId,
            string paymentMethodID);
        #endregion Methods
    }
    #endregion Interface
}