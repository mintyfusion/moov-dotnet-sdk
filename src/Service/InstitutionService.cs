namespace Tutkoo.mintyfusion.Moov.Sdk.Service
{
    #region Namespace
    using Interface;
    using Model.Institution;
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
        /// <param name="requestModel"></param>
        /// <returns>InstitutionSearchResultModel</returns>
        public async Task<InstitutionSearchResultModel> SearchAsync(Rail rail,
             InstitutionSearchRequestModel requestModel)
        {
            if (requestModel == null)
                throw new ArgumentNullException(nameof(requestModel));

            string scope = Utility.Format(InstitutionScope.Read.Value());

            string endpoint = Utility.Format(InstitutionEndpoint.Search.Value());

            IDictionary<string, string> queryParams = new Dictionary<string, string>();

            // Convert model to <string, string> keyvalue pair query dictionary
            if (requestModel != null)
                queryParams = requestModel.AsDictionary().ToDictionary(k => k.Key, k => (string)k.Value);

            InstitutionSearchResultModel resutl = await moovClient.GetAsync<InstitutionSearchResultModel>(endpoint,
                new List<string>() { scope },
                queryParams);

            return resutl;
        }
        #endregion Public Methods
    }
    #endregion Class
}