namespace TicTacToe.Computer.Strategies.MainStrategy
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Checks.RowsCheck;
    using Checks.ColumnsCheck;
    using Checks.DiagonalsCheck;
    using Checks.EdgesCheck;
    using Checks.InnerCheck;
    using Checks.FirstEmptyCheck;
    using Checks.CanWinCheck;
    using Checks.PossibleWinCheck;

    public abstract class MainStrategy : TurnStrategy
    {
        protected CanWinCheck canWinCheck;
        protected FirstRowCheck firstRowCheck;
        protected SecondRowCheck secondRowCheck;
        protected ThirdRowCheck thirdRowCheck;
        protected FirstColumnCheck firstColumnCheck;
        protected SecondColumnCheck secondColumnCheck;
        protected ThirdColumnCheck thirdColumnCheck;
        protected FirstDiagonalCheck firstDiagonalCheck;
        protected SecondDiagonalCheck secondDiagonalCheck;
        protected PossibleWinCheck possibleWinCheck;
        protected ClosestEdgeCheck edgesCheck;
        protected OppositeTileCheck oppositeCheck;
        protected FirstEmptyTileCheck firstEmptyTileCheck;

        protected abstract void SetupChainOfResponsibility();

        public MainStrategy(IEnumerable<IComputerGameTileModel> gameTiles, string playerSign) : base(gameTiles)
        {
            this.canWinCheck = new CanWinCheck(playerSign);
            this.firstRowCheck = new FirstRowCheck();
            this.secondRowCheck = new SecondRowCheck();
            this.thirdRowCheck = new ThirdRowCheck();
            this.firstColumnCheck = new FirstColumnCheck();
            this.secondColumnCheck = new SecondColumnCheck();
            this.thirdColumnCheck = new ThirdColumnCheck();
            this.firstDiagonalCheck = new FirstDiagonalCheck();
            this.secondDiagonalCheck = new SecondDiagonalCheck();
            this.possibleWinCheck = new PossibleWinCheck(playerSign);
            this.edgesCheck = new ClosestEdgeCheck();
            this.oppositeCheck = new OppositeTileCheck();
            this.firstEmptyTileCheck = new FirstEmptyTileCheck();
        }

        public override int? GetMove()
        {
            this.SetupChainOfResponsibility();

            int? computerMove = this.canWinCheck.GetMove(base.gameTiles);

            if (computerMove == null)
            {
                throw new NotImplementedException();
            }

            return computerMove;
        }
    }
}