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
            if (this.TurnsCountIsEvenNumber(game.TurnsCount))
            {
                return new StartingSecondComputerStrategy(game);
            }

            return new StartingFirstComputerStrategy(game);
        }

        /// <summary>
        /// Checks if the Game.TurnsCount is an even number
        /// </summary>
        /// <param name="gameTurnsCount">Game.TurnsCount</param>
        /// <returns>bool</returns>
        private bool TurnsCountIsEvenNumber(int gameTurnsCount)
        {
            if (gameTurnsCount % 2 == 0)
            {
                return true;
            }

            return false;
        }
    }
}