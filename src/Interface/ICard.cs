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
        Task<IList<CardModel>> ListAsync(string accountID);

        Task<CardModel> GetAsync(string accountID,
            string cardID);

        Task<bool> DisableAsync(string accountID,
            string cardID);

        Task<CardModel> CreateAsync(string accountID,
            CardModel card,
            bool synchronous);
        #endregion Methods
    }
    #endregion Interface
}