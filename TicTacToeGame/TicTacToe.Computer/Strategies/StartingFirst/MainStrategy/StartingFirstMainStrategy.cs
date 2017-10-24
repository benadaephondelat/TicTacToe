namespace TicTacToe.Computer.Strategies.StartingFirst.MainStrategy
{
    using System.Collections.Generic;
    using Strategies.MainStrategy;
    using Models;

    public class StartingFirstMainStrategy : MainStrategy
    {
        public StartingFirstMainStrategy(IEnumerable<IComputerGameTileModel> gameTiles, string playerSign) : base(gameTiles, playerSign)
        {
        }

        protected override void SetupChainOfResponsibility()
        {
            base.canWinCheck.SetSuccessor(this.firstRowCheck);
            base.firstRowCheck.SetSuccessor(this.secondRowCheck);
            base.secondRowCheck.SetSuccessor(this.thirdRowCheck);
            base.thirdRowCheck.SetSuccessor(this.firstColumnCheck);
            base.firstColumnCheck.SetSuccessor(this.secondColumnCheck);
            base.secondColumnCheck.SetSuccessor(this.thirdColumnCheck);
            base.thirdColumnCheck.SetSuccessor(this.firstDiagonalCheck);
            base.firstDiagonalCheck.SetSuccessor(this.secondDiagonalCheck);
            base.secondDiagonalCheck.SetSuccessor(this.possibleWinCheck);
            base.possibleWinCheck.SetSuccessor(this.edgesCheck);
            base.edgesCheck.SetSuccessor(this.oppositeCheck);
            base.oppositeCheck.SetSuccessor(this.firstEmptyTileCheck);
        }
    }
}