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
    public class SecondRowCheck : Responsibility
    {
        public string MiddleLeftTileValue { get; set; }

        public string MiddleMiddleTileValue { get; set; }

        public string MiddleRightTileValue { get; set; }

        public override int? GetMove(IEnumerable<IComputerGameTileModel> tiles)
        {
            this.PopulateFields(tiles);

            int? computerMove = this.CheckSecondRow();

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

        private int? CheckSecondRow()
        {
            int? middleLeftCheck = this.MiddleLeftCheck();

            if (middleLeftCheck != null)
            {
                return middleLeftCheck;
            }

            int? middleMiddleCheck = this.MiddleMiddleCheck();

            if (middleMiddleCheck != null)
            {
                return middleMiddleCheck;
            }

            int? middleRightCheck = this.MiddleRightCheck();

            if (middleRightCheck != null)
            {
                return middleRightCheck;
            }

            return null;
        }

        private int? MiddleLeftCheck()
        {
            if (base.TileIsNotEmpty(this.MiddleMiddleTileValue) && base.BothTilesAreTheSame(this.MiddleMiddleTileValue, this.MiddleRightTileValue)) 
            {
                if (base.TileIsEmpty(this.MiddleLeftTileValue))
                {
                    return TileConstants.MiddleLeftTile;
                }
            }

            return null;
        }

        private int? MiddleMiddleCheck()
        {
            if (base.TileIsNotEmpty(this.MiddleRightTileValue) && this.BothTilesAreTheSame(this.MiddleRightTileValue, this.MiddleLeftTileValue))
            {
                if (base.TileIsEmpty(this.MiddleMiddleTileValue))
                {
                    return TileConstants.MiddleMiddleTile;
                }
            }

            return null;
        }

        private int? MiddleRightCheck()
        {
            if (base.TileIsNotEmpty(this.MiddleLeftTileValue) && base.BothTilesAreTheSame(this.MiddleLeftTileValue, this.MiddleMiddleTileValue))
            {
                if (base.TileIsEmpty(this.MiddleRightTileValue))
                {
                    return TileConstants.MiddleRightTile;
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
            this.MiddleLeftTileValue = base.GetTileByIndex(tiles, TileConstants.MiddleLeftTile).Value;
            this.MiddleMiddleTileValue = base.GetTileByIndex(tiles, TileConstants.MiddleMiddleTile).Value;
            this.MiddleRightTileValue = base.GetTileByIndex(tiles, TileConstants.MiddleRightTile).Value;
        }
    }
}