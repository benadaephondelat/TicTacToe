namespace TicTacToe.Computer.Strategies.StartingSecond.TurnStrategies.SecondTurnStrategy
{
    using System.Collections.Generic;
    using Models;
    using Constants;
    using MainStrategy;
    using AggressiveMoveStrategy;

    /// <summary>
    /// Contains the logic to be executed when the computer is starting second and it's his second turn.
    /// </summary>
    public class SecondTurnStrategy : TurnStrategy
    {
        private AggressiveMoveCheck aggresiveMoveCheck;

        public SecondTurnStrategy(IEnumerable<IComputerGameTileModel> gameTiles) : base(gameTiles)
        {
            this.aggresiveMoveCheck = new AggressiveMoveCheck(gameTiles);
        }

        /// <summary>
        /// If the oponent has made an aggressive move - block it, else return MainStrategy's result
        /// </summary>
        /// <returns>int?</returns>
        public override int? GetMove()
        {
            int? move = this.aggresiveMoveCheck.GetMove();

            if (move == null)
            {
                move = this.GetMainStrategyMove(base.gameTiles);
            }

            return move;
        }

        /// <summary>
        /// Returns the MainStrategy's result
        /// </summary>
        /// <param name="gameTiles">IEnumerable<IComputerGameTileModel></IComputerGameTileModel></param>
        /// <returns>int?</returns>
        private int? GetMainStrategyMove(IEnumerable<IComputerGameTileModel> gameTiles)
        {
            StartingSecondMainStrategy mainStrategy = new StartingSecondMainStrategy(gameTiles, ComputerConstants.AwaySideSign);

            int? result = mainStrategy.GetMove();

            return result;
        }
    }
}