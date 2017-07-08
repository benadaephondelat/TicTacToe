namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.DiagonalsCheck
{
    using System.Collections.Generic;
    using Models;
    using TicTacToeCommon.Constants;

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
            if (base.TileIsNotEmpty(this.MiddleMiddleTileValue) && base.BothTilesAreTheSame(this.MiddleMiddleTileValue, this.BottomLeftTileValue))
            {
                if (base.TileIsEmpty(this.TopRightTileValue))
                {
                    return TileConstants.TopRightTile;
                }
            }

            return null;
        }

        private int? MiddleMiddleCheck()
        {
            if (base.TileIsNotEmpty(this.BottomLeftTileValue) && base.BothTilesAreTheSame(this.BottomLeftTileValue, this.TopRightTileValue))
            {
                if (base.TileIsEmpty(this.MiddleMiddleTileValue))
                {
                    return TileConstants.MiddleMiddleTile;
                }
            }

            return null;
        }

        private int? BottomLeftCheck()
        {
            if (base.TileIsNotEmpty(this.TopRightTileValue) && base.BothTilesAreTheSame(this.TopRightTileValue, this.MiddleMiddleTileValue))
            {
                if (base.TileIsEmpty(this.BottomLeftTileValue))
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
            this.TopRightTileValue = base.GetTileByIndex(tiles, TileConstants.TopRightTile).Value;
            this.MiddleMiddleTileValue = base.GetTileByIndex(tiles, TileConstants.MiddleMiddleTile).Value;
            this.BottomLeftTileValue = base.GetTileByIndex(tiles, TileConstants.BottomLeftTile).Value;
        }
    }
}