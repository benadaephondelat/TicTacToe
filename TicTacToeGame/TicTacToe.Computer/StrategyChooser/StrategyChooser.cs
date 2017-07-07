namespace TicTacToe.Computer.StrategyChooser
{
    using Models;
    using Strategies;
    using Strategies.StartingFirst;
    using Strategies.StartingSecond;
    using TicTacToeCommon.Constants;

    /// <summary>
    /// Returns StartingFirstComputerStrategy or StartingSecondComputerStrategy based on the game's current turn
    /// </summary>
    public class StrategyChooser
    {
        /// <summary>
        /// Returns the computer strategy based on who starts first
        /// </summary>
        /// <param name="game">IComputerGameModel</param>
        /// <returns>StartingFirstComputerStrategy or StartingSecondComputerStrategy</returns>
        public ComputerStrategy GetComputerStrategy(IComputerGameModel game)
        {
            if (this.ComputerIsStartingFirst(game.HomesideUsername))
            {
                return new StartingFirstComputerStrategy(game);
            }

            return new StartingSecondComputerStrategy(game);
        }

        /// <summary>
        /// Checks if the computer is starting first
        /// </summary>
        /// <param name="homesideUsername">homeside username</param>
        /// <returns>bool</returns>
        private bool ComputerIsStartingFirst(string homesideUsername)
        {
            if (homesideUsername == UserConstants.ComputerUsername)
            {
                return true;
            }

            return false;
        }
    }
}