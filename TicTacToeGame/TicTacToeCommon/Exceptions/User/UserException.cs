namespace TicTacToeCommon.Exceptions.User
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Main User Exception
    /// </summary>
    [Serializable]
    public class UserException : TicTacToeException
    {
        public UserException() : base()
        {
        }

        public UserException(string message)
            : base(message)
        {
        }

        public UserException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        public UserException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public UserException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected UserException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}