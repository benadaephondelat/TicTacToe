namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.ColumnsCheck
{
    using System.Collections.Generic;
    using TicTacToeCommon.Constants;
    using Models;
    using Helpers;

    /// <summary>
    /// Checks the third column for a possible winner
    /// If there is no winner and there is no successor set it returns null
    /// If there is a successor it delegates the responsibility to him
    /// </summary>
    public class ThirdColumnCheck : Responsibility
    {
        public string TopRightTileValue { get; set; }

        public string MiddleRightTileValue { get; set; }

        public string BottomRightTileValue { get; set; }

        public override int? GetMove(IEnumerable<IComputerGameTileModel> tiles)
        {
            this.PopulateFields(tiles);

            int? computerMove = this.CheckThirdColumn();

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

        private int? CheckThirdColumn()
        {
            int? topRightCheck = this.TopRightCheck();

            if (topRightCheck != null)
            {
                return topRightCheck;
            }

            int? middleRightCheck = this.MiddleRightCheck();

            if (middleRightCheck != null)
            {
                return middleRightCheck;
            }

            int? bottomRightCheck = this.BottomRightCheck();

            if (bottomRightCheck != null)
            {
                return bottomRightCheck;
            }

            return null;
        }

        private int? TopRightCheck()
        {
            if (TileHelper.TileIsNotEmpty(this.MiddleRightTileValue) && TileHelper.BothTilesAreTheSame(this.MiddleRightTileValue, this.BottomRightTileValue))
            {
                if (TileHelper.TileIsEmpty(this.TopRightTileValue))
                {
                    return TileConstants.TopRightTile;
                }
            }

            return null;
        }

        private int? MiddleRightCheck()
        {
            if (TileHelper.TileIsNotEmpty(this.BottomRightTileValue) && TileHelper.BothTilesAreTheSame(this.BottomRightTileValue, this.TopRightTileValue))
            {
                if (TileHelper.TileIsEmpty(this.MiddleRightTileValue))
                {
                    return TileConstants.MiddleRightTile;
                }
            }

            return null;
        }

        private int? BottomRightCheck()
        {
            if (TileHelper.TileIsNotEmpty(this.TopRightTileValue) && TileHelper.BothTilesAreTheSame(this.TopRightTileValue, this.MiddleRightTileValue))
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
            this.TopRightTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.TopRightTile).Value;
            this.MiddleRightTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.MiddleRightTile).Value;
            this.BottomRightTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.BottomRightTile).Value;
        }
    }
}