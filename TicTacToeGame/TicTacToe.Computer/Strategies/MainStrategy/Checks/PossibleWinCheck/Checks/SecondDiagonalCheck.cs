namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.PossibleWinCheck.Checks
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Helpers;
    using TicTacToeCommon.Constants;

    public class SecondDiagonalCheck : Responsibility
    {
        public string TopRightTileValue { get; set; }

        public string MiddleMiddleTileValue { get; set; }

        public string BottomLeftTileValue { get; set; }

        private readonly string CurrentPlayerSign;

        public SecondDiagonalCheck(string currentPlayerSign)
        {
            this.CurrentPlayerSign = currentPlayerSign;
        }

        public override int? GetMove(IEnumerable<IComputerGameTileModel> tiles)
        {
            this.PopulateFields(tiles);

            int? computerMove = this.CheckSecondDiagonal();

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

        private int? CheckSecondDiagonal()
        {
            int? topRightCheck = this.TopRightCheck();

            if (topRightCheck != null)
            {
                return topRightCheck;
            }

            int? middleMiddleCheck = this.MiddleMiddleCheck();

            if (middleMiddleCheck != null)
            {
                return middleMiddleCheck;
            }

            int? bottomLeftCheck = this.BottomLeftCheck();

            if (bottomLeftCheck != null)
            {
                return bottomLeftCheck;
            }

            return null;
        }
        
        private int? TopRightCheck()
        {
            if (this.TopRightTileValue == this.CurrentPlayerSign)
            {
                if (TileHelper.TileIsEmpty(this.MiddleMiddleTileValue) && TileHelper.TileIsEmpty(this.BottomLeftTileValue))
                {
                    return TileConstants.MiddleMiddleTile;
                }
            }

            return null;
        }

        private int? MiddleMiddleCheck()
        {
            if (this.MiddleMiddleTileValue == this.CurrentPlayerSign)
            {
                if (TileHelper.TileIsEmpty(this.TopRightTileValue) && TileHelper.TileIsEmpty(this.BottomLeftTileValue))
                {
                    return TileConstants.BottomLeftTile;
                }
            }

            return null;
        }

        private int? BottomLeftCheck()
        {
            if (this.BottomLeftTileValue == this.CurrentPlayerSign)
            {
                if (TileHelper.TileIsEmpty(this.MiddleMiddleTileValue) && TileHelper.TileIsEmpty(this.TopRightTileValue))
                {
                    return TileConstants.TopRightTile;
                }
            }

            return null;
        }

        private void PopulateFields(IEnumerable<IComputerGameTileModel> tiles)
        {
            this.TopRightTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.TopRightTile).Value;
            this.MiddleMiddleTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.MiddleMiddleTile).Value;
            this.BottomLeftTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.BottomLeftTile).Value;
        }
    }
}