namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.RowsCheck
{
    using System.Collections.Generic;
    using Models;
    using TicTacToeCommon.Constants;
    using Helpers;

    /// <summary>
    /// Checks the second row for a possible winner
    /// If there is no winner and there is no successor set it returns null
    /// If there is a successor it delegates the responsibility to him
    /// </summary>
    public class ThirdRowCheck : Responsibility
    {
        public string BottomLeftTileValue { get; set; }

        public string BottomMiddleTileValue { get; set; }

        public string BottomRightTileValue { get; set; }

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
            if (TileHelper.TileIsNotEmpty(this.BottomMiddleTileValue) && TileHelper.BothTilesAreTheSame(this.BottomMiddleTileValue, this.BottomRightTileValue))
            {
                if (TileHelper.TileIsEmpty(this.BottomLeftTileValue))
                {
                    return TileConstants.BottomLeftTile;
                }
            }

            return null;
        }

        private int? BottomMiddleCheck()
        {
            if (TileHelper.TileIsNotEmpty(this.BottomRightTileValue) && TileHelper.BothTilesAreTheSame(this.BottomRightTileValue, this.BottomLeftTileValue))
            {
                if (TileHelper.TileIsEmpty(this.BottomMiddleTileValue))
                {
                    return TileConstants.BottomMiddleTile;
                }
            }

            return null;
        }

        private int? BottomRightCheck()
        {
            if (TileHelper.TileIsNotEmpty(this.BottomLeftTileValue) && TileHelper.BothTilesAreTheSame(this.BottomLeftTileValue, this.BottomMiddleTileValue))
            {
                if (TileHelper.TileIsEmpty(this.BottomRightTileValue))
                {
                    return TileConstants.BottomRightTile;
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