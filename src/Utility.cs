namespace Tutkoo.mintyfusion.Moov.Sdk
{
    #region Namespace
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    #endregion Namespace

    #region Class
    public static class Utility
    {
        #region Public Static Methods
        public static string Format(string formatString,
            params string?[] param)
        {
            return string.Format(formatString, param);
        }
        #endregion Public Static Methods
    }
    #endregion Class
}