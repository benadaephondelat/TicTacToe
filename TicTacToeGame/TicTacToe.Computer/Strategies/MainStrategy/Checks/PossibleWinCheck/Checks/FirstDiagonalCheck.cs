namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.PossibleWinCheck.Checks
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Helpers;
    using TicTacToeCommon.Constants;

    public class FirstDiagonalCheck : Responsibility
    {
        public string TopLeftTileValue { get; set; }

        public string MiddleMiddleTileValue { get; set; }

        public string BottomRightTileValue { get; set; }

        private readonly string CurrentPlayerSign;

        public FirstDiagonalCheck(string currentPlayerSign)
        {
            this.CurrentPlayerSign = currentPlayerSign;
        }

        public override int? GetMove(IEnumerable<IComputerGameTileModel> tiles)
        {
            this.PopulateFields(tiles);

            int? computerMove = this.CheckFirstDiagonal();

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

        private int? CheckFirstDiagonal()
        {
            int? topLeftCheck = this.TopLeftCheck();

            if (topLeftCheck != null)
            {
                return topLeftCheck;
            }

            int? middleMiddleCheck = this.MiddleMiddleCheck();

            if (middleMiddleCheck != null)
            {
                return middleMiddleCheck;
            }

            int? bottomRightCheck = this.BottomRightCheck();

            if (bottomRightCheck != null)
            {
                return bottomRightCheck;
            }

            return null;
        }
        
        private int? TopLeftCheck()
        {
            if (this.TopLeftTileValue == this.CurrentPlayerSign)
            {
                if (TileHelper.TileIsEmpty(this.MiddleMiddleTileValue) && TileHelper.TileIsEmpty(this.BottomRightTileValue))
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
                if (TileHelper.TileIsEmpty(this.TopLeftTileValue) && TileHelper.TileIsEmpty(this.BottomRightTileValue))
                {
                    return TileConstants.BottomRightTile;
                }
            }

            return null;
        }

        private int? BottomRightCheck()
        {
            if (this.BottomRightTileValue == this.CurrentPlayerSign)
            {
                if (TileHelper.TileIsEmpty(this.MiddleMiddleTileValue) && TileHelper.TileIsEmpty(this.TopLeftTileValue))
                {
                    return TileConstants.TopLeftTile;
                }
            }

            return null;
        }

        /// <summary>
        /// Populates the fields
        /// </summary>
        /// <param name="tiles">IEnumerable<IComputerGameTileModel></ComputerGameTileModel></param>
        private void PopulateFields(IEnumerable<IComputerGameTileModel> tiles)
        {
            this.TopLeftTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.TopLeftTile).Value;
            this.MiddleMiddleTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.MiddleMiddleTile).Value;
            this.BottomRightTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.BottomRightTile).Value;
        }
    }
}