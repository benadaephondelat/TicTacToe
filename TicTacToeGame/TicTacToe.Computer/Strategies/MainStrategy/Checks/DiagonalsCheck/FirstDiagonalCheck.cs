namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.DiagonalsCheck
{
    using System.Collections.Generic;
    using TicTacToeCommon.Constants;
    using Models;
    using Helpers;

    /// <summary>
    /// Checks the first diagonal for a possible winner (topLeft, middle, bottomRight)
    /// If there is no winner and there is no successor set it returns null
    /// If there is a successor it delegates the responsibility to him
    /// </summary>
    public class FirstDiagonalCheck : Responsibility
    {
        public string TopLeftTileValue { get; set; }

        public string MiddleMiddleTileValue { get; set; }

        public string BottomRightTileValue { get; set; }

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
            int? topleftCheck = this.TopLeftCheck();

            if (topleftCheck != null)
            {
                return topleftCheck;
            }

            int? middleCheck = this.MiddleMiddleCheck();

            if (middleCheck != null)
            {
                return middleCheck;
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
            if (TileHelper.TileIsNotEmpty(this.MiddleMiddleTileValue) && TileHelper.BothTilesAreTheSame(this.MiddleMiddleTileValue, this.BottomRightTileValue))
            {
                if (TileHelper.TileIsEmpty(this.TopLeftTileValue))
                {
                    return TileConstants.TopLeftTile;
                }
            }

            return null;
        }

        private int? MiddleMiddleCheck()
        {
            if (TileHelper.TileIsNotEmpty(this.BottomRightTileValue) && TileHelper.BothTilesAreTheSame(this.BottomRightTileValue, this.TopLeftTileValue))
            {
                if (TileHelper.TileIsEmpty(this.MiddleMiddleTileValue))
                {
                    return TileConstants.MiddleMiddleTile;
                }
            }

            return null;
        }

        private int? BottomRightCheck()
        {
            if (TileHelper.TileIsNotEmpty(this.TopLeftTileValue) && TileHelper.BothTilesAreTheSame(this.TopLeftTileValue, this.MiddleMiddleTileValue))
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
            this.TopLeftTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.TopLeftTile).Value;
            this.MiddleMiddleTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.MiddleMiddleTile).Value;
            this.BottomRightTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.BottomRightTile).Value;
        }
    }
}