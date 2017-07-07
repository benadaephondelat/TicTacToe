namespace TicTacToe.Computer.Strategies.StartingSecond.TurnStrategies.SecondTurnStrategy.AggressiveMoveStrategy
{
    using System.Collections.Generic;
    using Models;
    using Checks.KnightMoveCheck;
    using Checks.RhombusMoveCheck;
    using Checks.TwoEdgesMoveCheck;

    /// <summary>
    /// If the oponent has made an aggressive move block it.
    /// </summary>
    public class AggressiveMoveCheck
    {
        protected IEnumerable<IComputerGameTileModel> gameTiles;

        private KnightMoveCheck knightMoveCheck = new KnightMoveCheck();
        private RhombusMoveCheck rhombusMoveCheck = new RhombusMoveCheck();
        private TwoEdgesMoveCheck twoEdgesMoveCheck = new TwoEdgesMoveCheck();

        public AggressiveMoveCheck(IEnumerable<IComputerGameTileModel> gameTiles)
        {
            this.gameTiles = gameTiles;
        }

        /// <summary>
        /// Return the aggressive move check's turn or return null
        /// </summary>
        /// <returns>int?</returns>
        public int? GetMove()
        {
            this.SetupChainOfResponsibility();

            int? computerMove = this.knightMoveCheck.GetMove(this.gameTiles);

            return computerMove;
        }

        /// <summary>
        /// Setup the check's order
        /// </summary>
        private void SetupChainOfResponsibility()
        {
            this.knightMoveCheck.SetSuccessor(this.rhombusMoveCheck);
            this.rhombusMoveCheck.SetSuccessor(this.twoEdgesMoveCheck);
        }
    }
}