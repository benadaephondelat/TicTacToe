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

        /// <summary>
        /// If Game.IsFinished or all Game.Tiles are taken throw exception.
        /// </summary>
        /// <param name="IComputerGameModel">Game to check</param>
        /// <exception cref="GameIsFinishedException"></exception>
        protected void ValidateGame(IComputerGameModel game)
        {
            bool allTilesAreTaken = game.Tiles.Any(tile => string.IsNullOrWhiteSpace(tile.Value) && tile.IsEmpty) == false;

            if (game.IsFinished || allTilesAreTaken)
            {
                throw new GameIsFinishedException();
            }
        }
    }
}