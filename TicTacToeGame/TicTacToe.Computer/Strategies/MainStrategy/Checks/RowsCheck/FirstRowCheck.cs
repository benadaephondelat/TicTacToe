namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.RowsCheck
{
    using System.Collections.Generic;
    using Models;
    using TicTacToeCommon.Constants;
    using Helpers;

    /// <summary>
    /// Checks the first row for a possible winner
    /// If there is no winner and there is no successor set it returns null
    /// If there is a successor it delegates the responsibility to him
    /// </summary>
    public class FirstRowCheck : Responsibility
    {
        public string TopLeftTileValue { get; set; }

        public string TopMiddleTileValue { get; set; }

        public string TopRightTileValue { get; set; }

        public override int? GetMove(IEnumerable<IComputerGameTileModel> tiles)
        {
            this.PopulateFields(tiles);

            int? computerMove = this.CheckFirstRow();

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

        private int? CheckFirstRow()
        {
            int? topLeftCheck = this.TopLeftCheck();

            if (topLeftCheck != null)
            {
                return topLeftCheck;
            }

            int? topMiddleCheck = this.TopMiddleCheck();

            if (topMiddleCheck != null)
            {
                return topMiddleCheck;
            }

            int? topRightCheck = this.TopRightCheck();

            if (topRightCheck != null)
            {
                return topRightCheck;
            }

            return null;
        }

        private int? TopLeftCheck()
        {
            if (TileHelper.TileIsNotEmpty(this.TopMiddleTileValue) && TileHelper.BothTilesAreTheSame(this.TopMiddleTileValue, this.TopRightTileValue))
            {
                if (TileHelper.TileIsEmpty(this.TopLeftTileValue))
                {
                    return TileConstants.TopLeftTile;
                }
            }

            return null;
        }

        private int? TopMiddleCheck()
        {
            if (TileHelper.TileIsNotEmpty(TopRightTileValue) && TileHelper.BothTilesAreTheSame(this.TopRightTileValue, this.TopLeftTileValue))
            {
                if (TileHelper.TileIsEmpty(this.TopMiddleTileValue))
                {
                    return TileConstants.TopMiddleTile;
                }
            }

            return null;
        }

        private int? TopRightCheck()
        {
            if (TileHelper.TileIsNotEmpty(this.TopLeftTileValue) && TileHelper.BothTilesAreTheSame(this.TopLeftTileValue, this.TopMiddleTileValue))
            {
                if (TileHelper.TileIsEmpty(this.TopRightTileValue))
                {
                    return TileConstants.TopRightTile;
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
            this.TopMiddleTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.TopMiddleTile).Value;
            this.TopRightTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.TopRightTile).Value;
        }
    }
}