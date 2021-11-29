namespace Tutkoo.mintyfusion.Moov.Sdk.Interface
{
    #region namespace
    using Model.Card;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    #endregion namespace

    #region Interface
    public interface ICard
    {
        #region Methods
        Task<CardModel> CreateAsync(string accountId,
            CardModel card);

        Task<IList<CardModel>> ListAsync(string accountId);

        Task<CardModel> GetAsync(string accountId,
            string cardId);

        Task<bool> DisableAsync(string accountId,
            string cardId);
        #endregion Methods
    }
    #endregion Interface
}