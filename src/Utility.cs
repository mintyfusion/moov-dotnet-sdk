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

        public static string ToQueryString(this IDictionary<string, string> source)
        {
            return string.Join("&", source.Where(f => !string.IsNullOrEmpty(f.Value))
                .Select(kvp => String.Format("{0}={1}", HttpUtility.UrlEncode(kvp.Key), HttpUtility.UrlEncode(kvp.Value))).ToArray());
        }
        #endregion Public Static Methods
    }
    #endregion Class
}