namespace Tutkoo.mintyfusion.Moov.Sdk.Service
{
    #region Namespace
    using Interface;
    using Model.Card;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Tutkoo.Essentials;
    #endregion Namespace

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
        /// Add card to an account
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="card"></param>
        /// <returns>CardModel</returns>
        public async Task<CardModel> CreateAsync(string accountId,
            CardModel card)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            if (card == null)
                throw new ArgumentNullException(nameof(card));

            string scope = Utility.Format(CardScope.Write.Value(),
                accountId);

            string endpoint = Utility.Format(CardEndpoint.Create.Value(),
                accountId);

            CardModel cardResult = await moovClient.PostAsync<CardModel>(endpoint,
                new List<string>() { scope }, card);

            return cardResult;
        }

        /// <summary>
        /// Get all cards for an account
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns>List of CardModel</returns>
        public async Task<IList<CardModel>> ListAsync(string accountId)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            string scope = Utility.Format(CardScope.Read.Value(),
                accountId);

            string endpoint = Utility.Format(CardEndpoint.List.Value(),
                accountId);

            IList<CardModel> cards = await moovClient.GetAsync<IList<CardModel>>(endpoint,
                new List<string>() { scope });

            return cards;
        }

        /// <summary>
        /// Get card by id for an account
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="cardId"></param>
        /// <returns>CardModel</returns>
        public async Task<CardModel> GetAsync(string accountId,
            string cardId)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            if (string.IsNullOrEmpty(cardId))
                throw new ArgumentNullException(nameof(cardId));

            string scope = Utility.Format(CardScope.Read.Value(),
                accountId);

            string endpoint = Utility.Format(CardEndpoint.Get.Value(),
                accountId,
                cardId);

            CardModel card = await moovClient.GetAsync<CardModel>(endpoint,
                new List<string>() { scope });

            return card;
        }

        /// <summary>
        /// Disable card by id for an account
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="cardId"></param>
        /// <returns>true/false</returns>
        public async Task<bool> DisableAsync(string accountId,
            string cardId)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            if (string.IsNullOrEmpty(cardId))
                throw new ArgumentNullException(nameof(cardId));

            string scope = Utility.Format(CardScope.Write.Value(),
                accountId);

            string endpoint = Utility.Format(CardEndpoint.Disable.Value(),
                accountId,
                cardId);

            bool success = await moovClient.DeleteAsync<bool>(endpoint,
                new List<string>() { scope });

            return success;
        }
        #endregion Public Methods
    }
    #endregion Class
}