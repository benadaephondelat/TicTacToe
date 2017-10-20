namespace TicTacToe.Computer.Interfaces
{
    using Models;

    /// <summary>
    /// TicTacToe Computer interface
    /// </summary>
    public interface IComputer
    {
        /// <summary>
        /// Returns a tile index that represents the computer's move or throws an exception
        /// </summary>
        /// <param name="game">IComputerGameModel</param>
        /// <exception cref="ComputerException">Thrown when there is unhandled exception during execution</exception>
        /// <returns>int</returns>
        int GetComputerMoveIndex(IComputerGameModel game);
    }
}