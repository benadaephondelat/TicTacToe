namespace TicTacToe.Computer.Strategies
{
    using System.Linq;
    using Models;
    using TicTacToeCommon.Exceptions.Game;

    /// <summary>
    /// Computer strategy
    /// </summary>
    public abstract class ComputerStrategy
    {
        /// <summary>
        /// Returns the computer's move by choosing the appropriate turn strategy
        /// </summary>
        /// <returns>int</returns>
        public abstract int GetComputerMove();
    }
}