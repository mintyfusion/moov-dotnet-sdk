namespace Tutkoo.mintyfusion.Moov.Sdk.Service
{
    #region Namespace
    using Interface;
    using Model.Representative;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Tutkoo.Essentials;
    #endregion Namespace

    #region Class
    public class RepresentativeService : IRepresentative
    {
        #region Fields
        private readonly IClient moovClient = null;
        #endregion Fields

        #region Constructor
        public RepresentativeService(IClient moovClient)
        {
            this.moovClient = moovClient;
        }
        #endregion Constructor

        #region Public Methods
        /// <summary>
        /// Create Representative for an account
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="createRepresentative"></param>
        /// <returns>RepresentativeModel</returns>
        public async Task<RepresentativeModel> CreateAsync(string accountId,
            CreateUpdateRepresentativeRequestModel createRepresentative)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            if (createRepresentative == null)
                throw new ArgumentNullException(nameof(createRepresentative));

            string scope = Utility.Format(RepresentativeScope.Write.Value(),
                accountId);

            string endpoint = Utility.Format(RepresentativeEndpoint.Create.Value(),
                accountId);

            RepresentativeModel result = await moovClient.PostAsync<RepresentativeModel>(endpoint,
                new List<string>() { scope }, createRepresentative);

            return result;
        }

        /// <summary>
        /// Get list of all representative for an account
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns>List of RepresentativeModel</returns>
        public async Task<IList<RepresentativeModel>> ListAsync(string accountId)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            string scope = Utility.Format(RepresentativeScope.Read.Value(),
                accountId);

            string endpoint = Utility.Format(RepresentativeEndpoint.List.Value());

            IList<RepresentativeModel> representatives = await moovClient.GetAsync<IList<RepresentativeModel>>(endpoint,
                new List<string>() { scope });

            return representatives;
        }

        /// <summary>
        /// Get representative by id for an account
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="representativeID"></param>
        /// <returns>RepresentativeModel</returns>
        public async Task<RepresentativeModel> GetAsync(string accountId,
            string representativeID)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            if (string.IsNullOrEmpty(representativeID))
                throw new ArgumentNullException(nameof(representativeID));

            string scope = Utility.Format(RepresentativeScope.Read.Value(),
                accountId);

            string endpoint = Utility.Format(RepresentativeEndpoint.Get.Value(),
                accountId,
                representativeID);

            RepresentativeModel representative = await moovClient.GetAsync<RepresentativeModel>(endpoint,
                new List<string>() { scope });

            return representative;
        }

        /// <summary>
        /// Remove representative for an account
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="representativeID"></param>
        /// <returns>true/false</returns>
        public async Task<bool> DisableAsync(string accountId,
            string representativeID)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            if (string.IsNullOrEmpty(representativeID))
                throw new ArgumentNullException(nameof(representativeID));

            string scope = Utility.Format(RepresentativeScope.Write.Value(),
                accountId);

            string endpoint = Utility.Format(RepresentativeEndpoint.Disable.Value(),
                accountId,
                representativeID);

            bool success = await moovClient.DeleteAsync<bool>(endpoint,
                new List<string>() { scope });

            return success;
        }

        /// <summary>
        /// Update representative by id for an account
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="representativeID"></param>
        /// <param name="updateRepresentative"></param>
        /// <returns></returns>
        public async Task<RepresentativeModel> UpdateAsync(string accountId,
            string representativeID,
            CreateUpdateRepresentativeRequestModel updateRepresentative)
        {
            if (string.IsNullOrEmpty(accountId))
                throw new ArgumentNullException(nameof(accountId));

            if (string.IsNullOrEmpty(representativeID))
                throw new ArgumentNullException(nameof(representativeID));

            if (updateRepresentative == null)
                throw new ArgumentNullException(nameof(updateRepresentative));

            string scope = Utility.Format(RepresentativeScope.Write.Value(),
                accountId);

            string endpoint = Utility.Format(RepresentativeEndpoint.Update.Value(),
                accountId,
                representativeID);

            RepresentativeModel representative = await moovClient.PutAsync<RepresentativeModel>(endpoint,
                new List<string>() { scope }, updateRepresentative);

            return representative;
        }
        #endregion Public Methods
    }
    #endregion Class
}