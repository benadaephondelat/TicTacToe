namespace TicTacToe.Computer.Interfaces
{
    using Models;

    /// <summary>
    /// TicTacToe Computer interface
    /// </summary>
    public interface IComputer
    {
        /// <summary>
        /// Returns a tile index that represents the computer's move
        /// </summary>
        /// <param name="game">IComputerGameModel</param>
        /// <returns>int</returns>
        int GetComputerMoveIndex(IComputerGameModel game);
    }
}