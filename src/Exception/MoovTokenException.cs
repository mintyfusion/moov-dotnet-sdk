namespace Tutkoo.mintyfusion.Moov.Sdk.Exception
{
    #region namespace
    using System;
    #endregion namespace

    #region Class
    public class MoovTokenException : Exception
    {
        #region Exception
        public MoovTokenException() { }

        public MoovTokenException(string message)
            : base(message) { }

        public MoovTokenException(string message, Exception inner)
            : base(message, inner) { }
        #endregion Exception
    }
    #endregion Class
}