namespace TicTacToe.Computer.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Main Computer Exception
    /// </summary>
    [Serializable]
    public class ComputerException : Exception
    {
        public readonly string CustomMessage = "Unhandled exception occurred in TicTacToe Computer";

        public ComputerException() : base()
        {
        }

        public ComputerException(string message) : base(message)
        {
        }

        public ComputerException(string format, params object[] args) : base(string.Format(format, args))
        {
        }

        public ComputerException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public ComputerException(string format, Exception innerException, params object[] args) : base(string.Format(format, args), innerException)
        {
        }

        protected ComputerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}