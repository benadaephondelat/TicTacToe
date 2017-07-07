namespace TicTacToeCommon.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Main Exception Class
    /// </summary>
    [Serializable]
    public abstract class TicTacToeException : Exception
    {
        public static string CustomMessage = "TicTacToe Main Application Exception.";

        public TicTacToeException() : base()
        {
        }

        public TicTacToeException(string message)
            : base(message)
        {
        }

        public TicTacToeException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        public TicTacToeException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public TicTacToeException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected TicTacToeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}