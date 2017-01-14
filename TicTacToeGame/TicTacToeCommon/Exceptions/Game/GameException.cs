namespace TicTacToeCommon.Exceptions.Game
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Main User Exception
    /// </summary>
    [Serializable]
    public class GameException : TicTacToeException
    {
        public new string CustomMessage = "Game Exception";

        public GameException() : base()
        {
        }

        public GameException(string message)
            : base(message)
        {
        }

        public GameException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        public GameException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public GameException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected GameException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}