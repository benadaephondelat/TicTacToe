namespace TicTacToe.Computer.Strategies.StartingSecond
{
    using Models;
    using Constants;
    using Strategies;
    using MainStrategy;
    using TurnStrategies.FirstTurnStrategy;
    using TurnStrategies.SecondTurnStrategy;

    /// <summary>
    /// Contains the Computer Starting Second Logic
    /// </summary>
    public class StartingSecondComputerStrategy : ComputerStrategy
    {
        private IComputerGameModel game;

        public StartingSecondComputerStrategy(IComputerGameModel game)
        {
            base.ValidateGame(game);
            this.game = game;
        }

        /// <summary>
        /// Choose a turn strategy and get the computer's move
        /// </summary>
        /// <returns>int</returns>
        public override int GetComputerMove()
        {
            TurnStrategy turnStrategy = this.ChooseTurnStrategy();

            int? computerMove = turnStrategy.GetMove();

            return computerMove.Value;
        }

        /// <summary>
        /// Chooses a turn strategy based on the Game.TurnsCount property
        /// </summary>
        /// <returns>TurnStrategy</returns>
        private TurnStrategy ChooseTurnStrategy()
        {
            TurnStrategy strategy;

            if (this.IsFirstTurn(this.game.TurnsCount))
            {
                strategy = new FirstTurnStrategy(this.game.Tiles);
            }
            else if (this.IsSecondTurn(this.game.TurnsCount))
            {
                strategy = new SecondTurnStrategy(this.game.Tiles);
            }
            else
            {
                strategy = new MainStrategy(this.game.Tiles, ComputerConstants.AwaySideSign);
            }

            return strategy;
        }

        /// <summary>
        /// Checks if it's the computer's first turn
        /// </summary>
        /// <param name="turnsCount">Game.TurnsCount</param>
        /// <returns>bool</returns>
        private bool IsFirstTurn(int turnsCount)
        {
            if (turnsCount == 2)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if it's the computer's second turn
        /// </summary>
        /// <param name="turnsCount">Game.TurnsCount</param>
        /// <returns>bool</returns>
        private bool IsSecondTurn(int turnsCount)
        {
            if (turnsCount == 4)
            {
                return true;
            }

            return false;
        }
    }
}