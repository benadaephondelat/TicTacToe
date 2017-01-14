namespace TicTacToeCommon.Exceptions.Game
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Thrown when the game is already finished.
    /// </summary>
    [Serializable]
    public class GameIsFinishedException : GameException
    {
        private static new string CustomMessage = "This game is already finished.";

        public GameIsFinishedException() : base()
        {
        }

        public GameIsFinishedException(string message)
            : base(message)
        {
        }

        public GameIsFinishedException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        public GameIsFinishedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public GameIsFinishedException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected GameIsFinishedException(SerializationInfo info, StreamingContext context)
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