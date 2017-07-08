namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.DiagonalsCheck
{
    using System.Collections.Generic;
    using Models;
    using TicTacToeCommon.Constants;
    using Helpers;

    /// <summary>
    /// Checks the second diagonal for a possible winner (topRight, middle, bottomLeft)
    /// If there is no winner and there is no successor set it returns null
    /// If there is a successor it delegates the responsibility to him
    /// </summary>
    public class SecondDiagonalCheck : Responsibility
    {
        public string TopRightTileValue { get; set; }

        public string MiddleMiddleTileValue { get; set; }

        public string BottomLeftTileValue { get; set; }

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

            int? middleCheck = this.MiddleMiddleCheck();

            if (middleCheck != null)
            {
                return middleCheck;
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
            if (TileHelper.TileIsNotEmpty(this.MiddleMiddleTileValue) && TileHelper.BothTilesAreTheSame(this.MiddleMiddleTileValue, this.BottomLeftTileValue))
            {
                if (TileHelper.TileIsEmpty(this.TopRightTileValue))
                {
                    return TileConstants.TopRightTile;
                }
            }

            return null;
        }

        private int? MiddleMiddleCheck()
        {
            if (TileHelper.TileIsNotEmpty(this.BottomLeftTileValue) && TileHelper.BothTilesAreTheSame(this.BottomLeftTileValue, this.TopRightTileValue))
            {
                if (TileHelper.TileIsEmpty(this.MiddleMiddleTileValue))
                {
                    return TileConstants.MiddleMiddleTile;
                }
            }

            return null;
        }

        private int? BottomLeftCheck()
        {
            if (TileHelper.TileIsNotEmpty(this.TopRightTileValue) && TileHelper.BothTilesAreTheSame(this.TopRightTileValue, this.MiddleMiddleTileValue))
            {
                if (TileHelper.TileIsEmpty(this.BottomLeftTileValue))
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
            this.TopRightTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.TopRightTile).Value;
            this.MiddleMiddleTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.MiddleMiddleTile).Value;
            this.BottomLeftTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.BottomLeftTile).Value;
        }
    }
}