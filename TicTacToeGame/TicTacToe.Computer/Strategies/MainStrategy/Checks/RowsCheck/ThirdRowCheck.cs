namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.RowsCheck
{
    using System.Collections.Generic;
    using Models;
    using TicTacToeCommon.Constants;

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
            if (base.TileIsNotEmpty(this.BottomMiddleTileValue) && base.BothTilesAreTheSame(this.BottomMiddleTileValue, this.BottomRightTileValue))
            {
                if (base.TileIsEmpty(this.BottomLeftTileValue))
                {
                    return TileConstants.BottomLeftTile;
                }
            }

            return null;
        }

        private int? BottomMiddleCheck()
        {
            if (base.TileIsNotEmpty(this.BottomRightTileValue) && base.BothTilesAreTheSame(this.BottomRightTileValue, this.BottomLeftTileValue))
            {
                if (base.TileIsEmpty(this.BottomMiddleTileValue))
                {
                    return TileConstants.BottomMiddleTile;
                }
            }

            return null;
        }

        private int? BottomRightCheck()
        {
            if (base.TileIsNotEmpty(this.BottomLeftTileValue) && base.BothTilesAreTheSame(this.BottomLeftTileValue, this.BottomMiddleTileValue))
            {
                if (base.TileIsEmpty(this.BottomRightTileValue))
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
            this.BottomLeftTileValue = base.GetTileByIndex(tiles, TileConstants.BottomLeftTile).Value;
            this.BottomMiddleTileValue = base.GetTileByIndex(tiles, TileConstants.BottomMiddleTile).Value;
            this.BottomRightTileValue = base.GetTileByIndex(tiles, TileConstants.BottomRightTile).Value;
        }
    }
}