namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.ColumnsCheck
{
    using System.Collections.Generic;
    using Models;
    using TicTacToeCommon.Constants;
    using Helpers;

    /// <summary>
    /// Checks the second column for a possible winner
    /// If there is no winner and there is no successor set it returns null
    /// If there is a successor it delegates the responsibility to him
    /// </summary>
    public class SecondColumnCheck : Responsibility
    {
        public string TopMiddleTileValue { get; set; }

        public string MiddleMiddleTileValue { get; set; }

        public string BottomMiddleTileValue { get; set; }

        public override int? GetMove(IEnumerable<IComputerGameTileModel> tiles)
        {
            this.PopulateFields(tiles);

            int? computerMove = this.CheckSecondColumn();

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

        private int? CheckSecondColumn()
        {
            int? topMiddleCheck = this.TopMiddleCheck();

            if (topMiddleCheck != null)
            {
                return topMiddleCheck;
            }

            int? middleMiddleCheck = this.MiddleMiddleCheck();

            if (middleMiddleCheck != null)
            {
                return middleMiddleCheck;
            }

            int? bottomMiddleCheck = this.BottomMiddleCheck();

            if (bottomMiddleCheck != null)
            {
                return bottomMiddleCheck;
            }

            return null;
        }

        private int? TopMiddleCheck()
        {
            if (TileHelper.TileIsNotEmpty(this.MiddleMiddleTileValue) && TileHelper.BothTilesAreTheSame(this.MiddleMiddleTileValue, this.BottomMiddleTileValue))
            {
                if (TileHelper.TileIsEmpty(this.TopMiddleTileValue))
                {
                    return TileConstants.TopMiddleTile;
                }
            }

            return null;
        }

        private int? MiddleMiddleCheck()
        {
            if (TileHelper.TileIsNotEmpty(this.BottomMiddleTileValue) && TileHelper.BothTilesAreTheSame(this.BottomMiddleTileValue, this.TopMiddleTileValue))
            {
                if (TileHelper.TileIsEmpty(this.MiddleMiddleTileValue))
                {
                    return TileConstants.MiddleMiddleTile;
                }
            }

            return null;
        }

        private int? BottomMiddleCheck()
        {
            if (TileHelper.TileIsNotEmpty(this.TopMiddleTileValue) && TileHelper.BothTilesAreTheSame(this.TopMiddleTileValue, this.MiddleMiddleTileValue))
            {
                if (TileHelper.TileIsEmpty(this.BottomMiddleTileValue))
                {
                    return TileConstants.BottomMiddleTile;
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
            this.TopMiddleTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.TopMiddleTile).Value;
            this.MiddleMiddleTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.MiddleMiddleTile).Value;
            this.BottomMiddleTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.BottomMiddleTile).Value;
        }
    }
}