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
        #endregion Methods
    }
    #endregion Interface
}