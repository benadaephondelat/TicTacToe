namespace TicTacToe.Computer.StrategyChooser
{
    using Models;
    using Strategies;
    using static TicTacToeCommon.Constants.UserConstants;

    public static class StrategyChooser
    {
        /// <summary>
        /// Returns the computer strategy
        /// </summary>
        /// <param name="game">IComputerGameModel</param>
        /// <returns>ComputerStrategy</returns>
        public static ComputerStrategy GetComputerStrategy(IComputerGameModel game)
        {
            if (ComputerIsStartingFirst(game.HomesideUsername))
            {
                return new StartingFirstStrategy(game);
            }

            return new StartingSecondStrategy(game);
        }

        /// <summary>
        /// Checks if the computer is starting first
        /// </summary>
        /// <param name="homesideUsername">homside username</param>
        /// <returns>bool</returns>
        private static bool ComputerIsStartingFirst(string homesideUsername)
        {
            if (homesideUsername == ComputerUsername)
            {
                return true;
            }

            return false;
        }
    }
}