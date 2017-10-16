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

    public class MainStrategy : TurnStrategy
    {
        private CanWinCheck canWinCheck;
        private FirstRowCheck firstRowCheck;
        private SecondRowCheck secondRowCheck;
        private ThirdRowCheck thirdRowCheck;
        private FirstColumnCheck firstColumnCheck;
        private SecondColumnCheck secondColumnCheck;
        private ThirdColumnCheck thirdColumnCheck;
        private FirstDiagonalCheck firstDiagonalCheck;
        private SecondDiagonalCheck secondDiagonalCheck;
        private PossibleWinCheck possibleWinCheck;
        private ClosestEdgeCheck edgesCheck;
        private OppositeTileCheck oppositeCheck;
        private FirstEmptyTileCheck firstEmptyTileCheck;

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

        private void SetupChainOfResponsibility()
        {
            this.canWinCheck.SetSuccessor(this.firstRowCheck);
            this.firstRowCheck.SetSuccessor(this.secondRowCheck);
            this.secondRowCheck.SetSuccessor(this.thirdRowCheck);
            this.thirdRowCheck.SetSuccessor(this.firstColumnCheck);
            this.firstColumnCheck.SetSuccessor(this.secondColumnCheck);
            this.secondColumnCheck.SetSuccessor(this.thirdColumnCheck);
            this.thirdColumnCheck.SetSuccessor(this.firstDiagonalCheck);
            this.firstDiagonalCheck.SetSuccessor(this.secondDiagonalCheck);

            //IF COMPUTER IS FIRST PLACE POSSIBLE WIN BEFORE EDGED
            //IF COMPUTER IS SECOND PLACE EDGES CHECK BEFORE POSSIBLE WIN

            this.secondDiagonalCheck.SetSuccessor(this.edgesCheck);
            this.edgesCheck.SetSuccessor(this.possibleWinCheck);
            this.possibleWinCheck.SetSuccessor(this.oppositeCheck);
            this.oppositeCheck.SetSuccessor(this.firstEmptyTileCheck);
        }
    }
}