namespace Tutkoo.mintyfusion.Moov.Sdk
{
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