namespace TicTacToe.Computer.Strategies.StartingFirst
{
    using Models;
    using MainStrategy;
    using TurnStrategies.FirstTurnStrategy;
    using TurnStrategies.SecondTurnStrategy;
    using Constants;

    /// <summary>
    /// Contains the Computer Starting First Logic
    /// </summary>
    public class StartingFirstComputerStrategy : ComputerStrategy
    {
        private IComputerGameModel game;

        public StartingFirstComputerStrategy(IComputerGameModel game)
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
                strategy = new MainStrategy(this.game.Tiles, ComputerConstants.HomeSideSign);
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
            if (turnsCount == 1)
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
            if (turnsCount == 3)
            {
                return true;
            }

            return false;
        }
    }
}