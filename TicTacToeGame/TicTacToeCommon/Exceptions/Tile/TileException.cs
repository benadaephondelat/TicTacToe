namespace TicTacToeCommon.Exceptions.Tile
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Main Tile Exception
    /// </summary>
    [Serializable]
    public class TileException : TicTacToeException
    {
        public TileException() : base()
        {
        }

        public TileException(string message)
            : base(message)
        {
        }

        public TileException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        public TileException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public TileException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected TileException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}