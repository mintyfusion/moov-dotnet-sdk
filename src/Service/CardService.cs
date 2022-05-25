namespace Tutkoo.mintyfusion.Moov.Sdk.Service
{
    #region namespace
    using Interface;
    using Model.Card;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Tutkoo.Essentials;
    #endregion namespace

    #region Class
    public class CardService : ICard
    {
        #region Fields
        private readonly IClient moovClient = null;
        #endregion Fields

        #region Constructor
        public CardService(IClient moovClient)
        {
            this.moovClient = moovClient;
        }
        #endregion Constructor

        #region Public Methods
        /// <summary>
        /// Get all cards for an account
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns>List of CardModel</returns>
        public async Task<IList<CardModel>> ListAsync(string accountID)
        {
            if (string.IsNullOrEmpty(accountID))
                throw new ArgumentNullException(nameof(accountID));

            string scope = Utility.Format(CardScope.Read.Value(),
                accountID);

            string endpoint = Utility.Format(CardEndpoint.List.Value(),
                accountID);

            IList<CardModel> cards = await moovClient.GetAsync<IList<CardModel>>(endpoint,
                new List<string>() { scope });

            return cards;
        }

        /// <summary>
        /// Get card by id for an account
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="cardID"></param>
        /// <returns>CardModel</returns>
        public async Task<CardModel> GetAsync(string accountID,
            string cardID)
        {
            if (string.IsNullOrEmpty(accountID))
                throw new ArgumentNullException(nameof(accountID));

            if (string.IsNullOrEmpty(cardID))
                throw new ArgumentNullException(nameof(cardID));

            string scope = Utility.Format(CardScope.Read.Value(),
                accountID);

            string endpoint = Utility.Format(CardEndpoint.Get.Value(),
                accountID,
                cardID);

            CardModel card = await moovClient.GetAsync<CardModel>(endpoint,
                new List<string>() { scope });

            return card;
        }

        /// <summary>
        /// Disable card by id for an account
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="cardID"></param>
        /// <returns>true/false</returns>
        public async Task<bool> DisableAsync(string accountID,
            string cardID)
        {
            if (string.IsNullOrEmpty(accountID))
                throw new ArgumentNullException(nameof(accountID));

            if (string.IsNullOrEmpty(cardID))
                throw new ArgumentNullException(nameof(cardID));

            string scope = Utility.Format(CardScope.Write.Value(),
                accountID);

            string endpoint = Utility.Format(CardEndpoint.Disable.Value(),
                accountID,
                cardID);

            bool success = await moovClient.DeleteAsync<bool>(endpoint,
                new List<string>() { scope });

            return success;
        }

        /// <summary>
        /// Add card to an account
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="card"></param>
        /// <returns>CardModel</returns>
        public async Task<CardModel> CreateAsync(string accountID,
            CardModel card,
            bool synchronous)
        {
            if (string.IsNullOrEmpty(accountID))
                throw new ArgumentNullException(nameof(accountID));

            if (card == null)
                throw new ArgumentNullException(nameof(card));

            string scope = Utility.Format(CardScope.Write.Value(),
                accountID);

            string endpoint = Utility.Format(CardEndpoint.Create.Value(),
                accountID);

            IDictionary<string, string> headers = new Dictionary<string, string>
            {
                { RequestHeader.WaitFor.Value(), WaitFor.PaymentMethod.Value() }
            };

            CardModel cardResult = await moovClient.PostAsync<CardModel>(endpoint,
                new List<string>() { scope }, card, synchronous ? headers : null);

            return cardResult;
        }
        #endregion Public Methods
    }
    #endregion Class
}