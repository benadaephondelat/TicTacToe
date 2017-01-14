namespace TicTacToeCommon.Exceptions.User
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Thrown when the current user is not authorized for a certain action.
    /// </summary>
    [Serializable]
    public class UserNotAuthorizedException : UserException
    {
        public static new string CustomMessage = "User is not authorized for this action";

        public UserNotAuthorizedException() : base()
        {
        }

        public UserNotAuthorizedException(string message)
            : base(message)
        {
        }

        public UserNotAuthorizedException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        public UserNotAuthorizedException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public UserNotAuthorizedException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected UserNotAuthorizedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}