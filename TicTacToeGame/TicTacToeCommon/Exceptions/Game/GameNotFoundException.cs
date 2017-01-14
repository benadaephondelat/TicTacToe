namespace TicTacToeCommon.Exceptions.Game
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Thrown when there is no such game in the database.
    /// </summary>
    [Serializable]
    public class GameNotFoundException : GameException
    {
        private static new string CustomMessage = "No such user is found in the database.";

        public GameNotFoundException() : base()
        {
        }

        public GameNotFoundException(string message)
            : base(message)
        {
        }

        public GameNotFoundException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        public GameNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public GameNotFoundException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected GameNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public static string CustomMessage1
        {
            get
            {
                return CustomMessage;
            }

            set
            {
                CustomMessage = value;
            }
        }
    }
}