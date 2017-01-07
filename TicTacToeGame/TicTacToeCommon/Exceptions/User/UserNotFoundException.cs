namespace TicTacToeCommon.Exceptions.User
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Thrown when there is no such user in the database.
    /// </summary>
    [Serializable]
    public class UserNotFoundException : UserException
    {
        public static new string CustomMessage = "No such user is found in the database.";

        public UserNotFoundException() : base()
        {
        }

        public UserNotFoundException(string message)
            : base(message)
        {
        }

        public UserNotFoundException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        public UserNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public UserNotFoundException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected UserNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}