namespace TicTacToeCommon.Exceptions.Tile
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Thrown when there is an invalid operation on Tile.
    /// </summary>
    [Serializable]
    public class TileValidationException : TileException
    {
        public static new string CustomMessage = "Invalid operation on Tile";

        public TileValidationException() : base()
        {
        }

        public TileValidationException(string message)
            : base(message)
        {
        }

        public TileValidationException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        public TileValidationException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public TileValidationException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected TileValidationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
