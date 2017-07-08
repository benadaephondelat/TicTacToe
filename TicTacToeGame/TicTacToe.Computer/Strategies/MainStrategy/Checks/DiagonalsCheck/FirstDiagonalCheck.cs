namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.DiagonalsCheck
{
    using System.Collections.Generic;
    using TicTacToeCommon.Constants;
    using Models;

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
            if (base.TileIsNotEmpty(this.MiddleMiddleTileValue) && base.BothTilesAreTheSame(this.MiddleMiddleTileValue, this.BottomRightTileValue))
            {
                if (base.TileIsEmpty(this.TopLeftTileValue))
                {
                    return TileConstants.TopLeftTile;
                }
            }

            return null;
        }

        private int? MiddleMiddleCheck()
        {
            if (this.TileIsNotEmpty(this.BottomRightTileValue) && base.BothTilesAreTheSame(this.BottomRightTileValue, this.TopLeftTileValue))
            {
                if (base.TileIsEmpty(this.MiddleMiddleTileValue))
                {
                    return TileConstants.MiddleMiddleTile;
                }
            }

            return null;
        }

        private int? BottomRightCheck()
        {
            if (base.TileIsNotEmpty(this.TopLeftTileValue) && base.BothTilesAreTheSame(this.TopLeftTileValue, this.MiddleMiddleTileValue))
            {
                if (this.TileIsEmpty(this.BottomRightTileValue))
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
            this.TopLeftTileValue = base.GetTileByIndex(tiles, TileConstants.TopLeftTile).Value;
            this.MiddleMiddleTileValue = base.GetTileByIndex(tiles, TileConstants.MiddleMiddleTile).Value;
            this.BottomRightTileValue = base.GetTileByIndex(tiles, TileConstants.BottomRightTile).Value;
        }
    }
}