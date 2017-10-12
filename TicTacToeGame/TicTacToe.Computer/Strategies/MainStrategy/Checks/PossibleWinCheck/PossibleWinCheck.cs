namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.PossibleWinCheck
{
    using System.Collections.Generic;
    using Models;
    using Checks;

    public class PossibleWinCheck : Responsibility
    {
        private FirstRowCheck firstRowCheck;

        private SecondRowCheck secondRowCheck;

        private ThirdRowCheck thirdRowCheck;

        private FirstColumnCheck firstColumnCheck;

        private SecondColumnCheck secondColumnCheck;

        private ThirdColumnCheck thirdColumnCheck;

        private FirstDiagonalCheck firstDiagonalCheck;

        private SecondDiagonalCheck secondDiagonalCheck;

        public PossibleWinCheck(string currentPlayerSign)
        {
            this.firstRowCheck = new FirstRowCheck(currentPlayerSign);
            this.secondRowCheck = new SecondRowCheck(currentPlayerSign);
            this.thirdRowCheck = new ThirdRowCheck(currentPlayerSign);
            this.firstColumnCheck = new FirstColumnCheck(currentPlayerSign);
            this.secondColumnCheck = new SecondColumnCheck(currentPlayerSign);
            this.thirdColumnCheck = new ThirdColumnCheck(currentPlayerSign);
            this.firstDiagonalCheck = new FirstDiagonalCheck(currentPlayerSign);
            this.secondDiagonalCheck = new SecondDiagonalCheck(currentPlayerSign);
        }

        public override int? GetMove(IEnumerable<IComputerGameTileModel> tiles)
        {
            this.SetupChainOfResponsibility();

            int? computerMove = this.firstRowCheck.GetMove(tiles);

            if (computerMove != null)
            {
                return computerMove;
            }

            if (base.successor == null)
            {
                return null;
            }

            return base.successor.GetMove(tiles);
        }

        private void SetupChainOfResponsibility()
        {
            this.firstDiagonalCheck.SetSuccessor(this.secondDiagonalCheck);
            this.secondDiagonalCheck.SetSuccessor(this.firstRowCheck);
            this.firstRowCheck.SetSuccessor(this.secondRowCheck);
            this.secondRowCheck.SetSuccessor(this.thirdRowCheck);
            this.thirdRowCheck.SetSuccessor(this.firstColumnCheck);
            this.firstColumnCheck.SetSuccessor(this.secondColumnCheck);
            this.secondColumnCheck.SetSuccessor(this.thirdColumnCheck);
        }
    }
}