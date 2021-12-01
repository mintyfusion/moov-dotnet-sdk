namespace Tutkoo.mintyfusion.Moov.Sdk.Interface
{
    #region namespace
    using Model.Capability;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    #endregion namespace

    #region Interface
    public interface ICapability
    {
        #region Methods
        Task<IList<CapabilityModel>> RequestAsync(string accountId,
            IList<string> capabilities);

        Task<IList<CapabilityModel>> ListAsync(string accountId);

        Task<CapabilityModel> GetRequestedAsync(string accountId,
           Capability capability);

        Task<bool> DisableAsync(string accountId,
           Capability capability);
        #endregion Methods
    }
    #endregion Interface
}