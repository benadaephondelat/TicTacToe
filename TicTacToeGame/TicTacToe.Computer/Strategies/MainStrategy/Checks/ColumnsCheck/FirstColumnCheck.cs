namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.ColumnsCheck
{
    using System.Collections.Generic;
    using Models;
    using TicTacToeCommon.Constants;

    /// <summary>
    /// Checks the first column for a possible winner
    /// If there is no winner and there is no successor set it returns null
    /// If there is a successor it delegates the responsibility to him
    /// </summary>
    public class FirstColumnCheck : Responsibility
    {
        public string TopLeftTileValue { get; set; }

        public string MiddleLeftTileValue { get; set; }

        public string BottomLeftTileValue { get; set; }

        public override int? GetMove(IEnumerable<IComputerGameTileModel> tiles)
        {
            this.PopulateFields(tiles);

            int? computerMove = this.CheckFirstColumn();

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

        private int? CheckFirstColumn()
        {
            int? topLeftCheck = this.TopLeftCheck();

            if (topLeftCheck != null)
            {
                return topLeftCheck;
            }

            int? middleLeftCheck = this.MiddleLeftCheck();

            if (middleLeftCheck != null)
            {
                return middleLeftCheck;
            }

            int? bottomLeftCheck = this.BottomLeftCheck();

            if (bottomLeftCheck != null)
            {
                return bottomLeftCheck;
            }

            return null;
        }

        private int? TopLeftCheck()
        {
            if (base.TileIsNotEmpty(this.MiddleLeftTileValue) && base.BothTilesAreTheSame(this.MiddleLeftTileValue, this.BottomLeftTileValue))
            {
                if (base.TileIsEmpty(this.TopLeftTileValue))
                {
                    return TileConstants.TopLeftTile;
                }
            }

            return null;
        }

        private int? MiddleLeftCheck()
        {
            if (base.TileIsNotEmpty(this.TopLeftTileValue) && base.BothTilesAreTheSame(this.TopLeftTileValue, this.BottomLeftTileValue))
            {
                if (base.TileIsEmpty(this.MiddleLeftTileValue))
                {
                    return TileConstants.MiddleLeftTile;
                }
            }

            return null;
        }

        private int? BottomLeftCheck()
        {
            if (base.TileIsNotEmpty(this.TopLeftTileValue) && base.BothTilesAreTheSame(this.TopLeftTileValue, this.MiddleLeftTileValue))
            {
                if (base.TileIsEmpty(this.BottomLeftTileValue))
                {
                    return TileConstants.BottomLeftTile;
                }
            }

            return null;
        }

        /// <summary>
        /// Populates the fields with the coresponding values of the tiles
        /// </summary>
        /// <param name="tiles">IEnumerable<IComputerGameTileModel></ComputerGameTileModel></param>
        private void PopulateFields(IEnumerable<IComputerGameTileModel> tiles)
        {
            this.TopLeftTileValue = base.GetTileByIndex(tiles, TileConstants.TopLeftTile).Value;
            this.MiddleLeftTileValue = base.GetTileByIndex(tiles, TileConstants.MiddleLeftTile).Value;
            this.BottomLeftTileValue = base.GetTileByIndex(tiles, TileConstants.BottomLeftTile).Value;
        }
    }
}