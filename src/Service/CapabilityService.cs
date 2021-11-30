namespace Tutkoo.mintyfusion.Moov.Sdk.Service
{
    #region Namespace
    using Interface;
    using Model.Capability;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Tutkoo.Essentials;
    #endregion Namespace

    #region Class
    public class CapabilityService : ICapability
    {
        #region Fields
        private readonly IClient moovClient = null;
        #endregion Fields

        #region Constructor
        public CapabilityService(IClient moovClient)
        {
            this.moovClient = moovClient;
        }
        #endregion Constructor

        #region Public Methods
        /// <summary>
        /// Request multiple capability for an account
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="capabilities"> Use Capability enum to create list of capabilities </param>
        /// <returns>List of requested capabilites</returns>
        public async Task<IList<CapabilityModel>> RequestAsync(string accountId,
            IList<string> capabilities)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            if (capabilities == null || capabilities.Count == 0)
                throw new ArgumentNullException(nameof(capabilities));

            string scope = Utility.Format(CapabilitiesScope.Write.Value(),
                accountId);

            string endpoint = Utility.Format(CapabilityEndpoint.Request.Value(),
                accountId);

            IList<CapabilityModel> requestedCapabilities = await moovClient.PostAsync<IList<CapabilityModel>>(endpoint,
                new List<string>() { scope }, capabilities);

            return requestedCapabilities;
        }

        /// <summary>
        /// List approved capabilities for an account
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns>List of CapabilityModel</returns>
        public async Task<IList<CapabilityModel>> ListAsync(string accountId)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            string scope = Utility.Format(CapabilitiesScope.Read.Value(),
                accountId);

            string endpoint = Utility.Format(CapabilityEndpoint.List.Value(),
                accountId);

            IList<CapabilityModel> capabilities = await moovClient.GetAsync<IList<CapabilityModel>>(endpoint,
                new List<string>() { scope });

            return capabilities;
        }

        /// <summary>
        /// Get previously requested and not approved capabilities for an account
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="capability"></param>
        /// <returns>List of CapabilityModel</returns>
        public async Task<CapabilityModel> GetRequestedAsync(string accountId,
           Capability capability)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            string scope = Utility.Format(CapabilitiesScope.Read.Value(),
                accountId);

            string endpoint = Utility.Format(CapabilityEndpoint.GetRequested.Value(),
                accountId,
                capability.Value());

            CapabilityModel capabilityResult = await moovClient.GetAsync<CapabilityModel>(endpoint,
                new List<string>() { scope });

            return capabilityResult;
        }

        /// <summary>
        /// Disable capability for an account
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="capability"></param>
        /// <returns>true/false</returns>
        public async Task<bool> DisableAsync(string accountId,
           Capability capability)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            string scope = Utility.Format(CapabilitiesScope.Write.Value(),
                accountId);

            string endpoint = Utility.Format(CapabilityEndpoint.Disable.Value(),
                accountId,
                capability.Value());

            bool success = await moovClient.DeleteAsync<bool>(endpoint,
                new List<string>() { scope });

            return success;
        }
        #endregion Public Methods
    }
    #endregion Class
}