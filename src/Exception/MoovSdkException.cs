namespace Tutkoo.mintyfusion.Moov.Sdk.Exception
{
    #region namespace
    using System;
    #endregion namespace

    #region Class
    public class MoovSdkException : Exception
    {
        #region Exception
        public MoovSdkException() { }

        public MoovSdkException(string message)
            : base(message) { }

        public MoovSdkException(string message, Exception inner)
            : base(message, inner) { }
        #endregion Exception
    }
    #endregion Class
}