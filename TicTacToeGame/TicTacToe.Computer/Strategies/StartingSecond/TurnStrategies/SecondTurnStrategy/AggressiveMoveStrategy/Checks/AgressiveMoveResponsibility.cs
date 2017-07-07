namespace TicTacToe.Computer.Strategies.StartingSecond.TurnStrategies.SecondTurnStrategy.AggressiveMoveStrategy.Checks
{
    using System.Collections.Generic;
    using Models;

    public abstract class AgressiveMoveResponsibility
    {
        protected AgressiveMoveResponsibility successor;

        public void SetSuccessor(AgressiveMoveResponsibility successor)
        {
            this.successor = successor;
        }

        public abstract int? GetMove(IEnumerable<IComputerGameTileModel> gameTiles);

        protected bool IsSuccessorSet()
        {
            if (this.successor != null)
            {
                return true;
            }

            return false;
        }
    }
}