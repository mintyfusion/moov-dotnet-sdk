namespace Tutkoo.mintyfusion.Moov.Sdk.Service
{
    #region Namespace
    using Interface;
    using Model.PaymentMethod;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Tutkoo.Essentials;
    #endregion Namespace

    #region Class
    public class PaymentMethodService : IPaymentMethod
    {
        #region Fields
        private readonly IClient moovClient = null;
        #endregion Fields

        #region Constructor
        public PaymentMethodService(IClient moovClient)
        {
            this.moovClient = moovClient;
        }
        #endregion Constructor

        #region Public Methods
        /// <summary>
        /// Get payment methods supported by an account
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="paymentMethodQuery">Optional parameter containing sourceId</param>
        /// <returns>List of supported PaymentMethodModel</returns>
        public async Task<IList<PaymentMethodModel>> ListAsync(string accountId,
            PaymentMethodQueryModel paymentMethodQuery = null)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            string scope = Utility.Format(PaymentMethodScope.Read.Value(),
                accountId);

            string endpoint = Utility.Format(PaymentMethodEndpoint.List.Value(), accountId);

            IList<PaymentMethodModel> paymentMethods = await moovClient.GetAsync<IList<PaymentMethodModel>>(endpoint,
                new List<string>() { scope }, paymentMethodQuery);

            return paymentMethods;
        }

        /// <summary>
        /// Get paymentmethod by id for an account
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="paymentMethodID"></param>
        /// <returns>PaymentMethodModel</returns>
        public async Task<PaymentMethodModel> GetAsync(string accountId,
            string paymentMethodID)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            if (string.IsNullOrEmpty(paymentMethodID))
                throw new ArgumentNullException(nameof(paymentMethodID));

            string scope = Utility.Format(PaymentMethodScope.Read.Value(),
                accountId);

            string endpoint = Utility.Format(PaymentMethodEndpoint.Get.Value(),
                accountId,
                paymentMethodID);

            PaymentMethodModel paymentMethod = await moovClient.GetAsync<PaymentMethodModel>(endpoint,
                new List<string>() { scope });

            return paymentMethod;
        }
        #endregion Public Methods
    }
    #endregion Class
}