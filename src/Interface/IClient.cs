namespace Tutkoo.mintyfusion.Moov.Sdk.Interface
{
    #region namespace
    using System.Collections.Generic;
    using System.Threading.Tasks;
    #endregion namespace

    #region Interface
    public interface IClient
    {
        #region Methods
        Task<T> GetAsync<T>(string endpoint,
            IList<string> scopeList);

        Task<T> PostAsync<T>(string endpoint,
            IList<string> scopeList,
            object postData = null);

        Task<T> PutAsync<T>(string endpoint,
            IList<string> scopeList,
            object postData = null);

        Task<T> DeleteAsync<T>(string endpoint,
            IList<string> scopeList);
        #endregion Methods
    }
    #endregion Interface
}