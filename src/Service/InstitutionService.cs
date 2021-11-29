namespace Tutkoo.mintyfusion.Moov.Sdk.Service
{
    #region Namespace
    using Interface;
    using Model.Institution;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Tutkoo.Essentials;
    #endregion Namespace

    #region Class
    public class InstitutionService : IInstitution
    {
        #region Fields
        private readonly IClient moovClient = null;
        #endregion Fields

        #region Constructor
        public InstitutionService(IClient moovClient)
        {
            this.moovClient = moovClient;
        }
        #endregion Constructor

        #region Public Methods
        /// <summary>
        /// Search institution by Rail
        /// </summary>
        /// <param name="rail"></param>
        /// <param name="institutionSearch"></param>
        /// <returns>InstitutionSearchResultModel</returns>
        public async Task<InstitutionSearchResultModel> SearchAsync(Rail rail,
             InstitutionSearchRequestModel institutionSearch)
        {
            if (institutionSearch == null)
                throw new ArgumentNullException(nameof(institutionSearch));

            string scope = Utility.Format(InstitutionScope.Read.Value());

            string endpoint = Utility.Format(InstitutionEndpoint.Search.Value());

            InstitutionSearchResultModel institutionSearchResult = await moovClient.GetAsync<InstitutionSearchResultModel>(endpoint,
                new List<string>() { scope }, institutionSearch);

            return institutionSearchResult;
        }
        #endregion Public Methods
    }
    #endregion Class
}