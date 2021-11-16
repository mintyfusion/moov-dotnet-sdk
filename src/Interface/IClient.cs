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
            IList<string> scopeList = null,
            string refreshToken = "");

        Task<T> PostAsync<T>(string endpoint,
            IList<string> scopeList = null,
            object postData = null,
            string refreshToken = "");

        Task<T> PutAsync<T>(string endpoint,
            IList<string> scopeList = null,
            object postData = null,
            string refreshToken = "");

        Task<T> DeleteAsync<T>(string endpoint,
            IList<string> scopeList = null,
            string refreshToken = "");
        #endregion Methods
    }
    #endregion Interface
}