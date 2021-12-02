namespace Tutkoo.mintyfusion.Moov.Sdk.Interface
{
    #region namespace
    using Model.Institution;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    #endregion namespace

    #region Interface
    public interface IInstitution
    {
        #region Methods
        Task<InstitutionSearchResultModel> SearchAsync(Rail rail,
             InstitutionSearchQueryModel institutionSearch);
        #endregion Methods
    }
    #endregion Interface
}