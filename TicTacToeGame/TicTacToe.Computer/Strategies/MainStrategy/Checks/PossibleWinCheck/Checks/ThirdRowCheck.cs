namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.PossibleWinCheck.Checks
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Helpers;
    using TicTacToeCommon.Constants;

    public class ThirdRowCheck : Responsibility
    {
        public string BottomLeftTileValue { get; set; }

        public string BottomMiddleTileValue { get; set; }

        public string BottomRightTileValue { get; set; }

        private readonly string CurrentPlayerSign;

        public ThirdRowCheck(string currentPlayerSign)
        {
            this.CurrentPlayerSign = currentPlayerSign;
        }

        public override int? GetMove(IEnumerable<IComputerGameTileModel> tiles)
        {
            this.PopulateFields(tiles);

            int? computerMove = this.CheckThirdRow();

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

        private int? CheckThirdRow()
        {
            int? bottomLeftCheck = this.BottomLeftCheck();

            if (bottomLeftCheck != null)
            {
                return bottomLeftCheck;
            }

            int? bottomMiddleCheck = this.BottomMiddleCheck();

            if (bottomMiddleCheck != null)
            {
                return bottomMiddleCheck;
            }

            int? bottomRightCheck = this.BottomRightCheck();

            if (bottomRightCheck != null)
            {
                return bottomRightCheck;
            }

            return null;
        }
        
        private int? BottomLeftCheck()
        {
            if (this.BottomLeftTileValue == this.CurrentPlayerSign)
            {
                if (TileHelper.TileIsEmpty(this.BottomMiddleTileValue) && TileHelper.TileIsEmpty(this.BottomRightTileValue))
                {
                    return TileConstants.BottomMiddleTile;
                }
            }

            return null;
        }

        private int? BottomMiddleCheck()
        {
            if (this.BottomMiddleTileValue == this.CurrentPlayerSign)
            {
                if (TileHelper.TileIsEmpty(this.BottomLeftTileValue) && TileHelper.TileIsEmpty(this.BottomRightTileValue))
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
                if (TileHelper.TileIsEmpty(this.BottomLeftTileValue) && TileHelper.TileIsEmpty(this.BottomMiddleTileValue))
                {
                    return TileConstants.BottomLeftTile;
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
            this.BottomLeftTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.BottomLeftTile).Value;
            this.BottomMiddleTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.BottomMiddleTile).Value;
            this.BottomRightTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.BottomRightTile).Value;
        }
    }
}