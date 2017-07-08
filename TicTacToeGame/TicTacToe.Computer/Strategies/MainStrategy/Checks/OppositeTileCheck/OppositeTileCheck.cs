namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.InnerCheck
{
    using System.Collections.Generic;
    using Models;
    using TicTacToeCommon.Constants;
    using Helpers;

    /// <summary>
    /// If the oponent has placed a turn on an outer inner tile - choose the opposite tile
    /// <see cref="Documents/opposite-check-example.png"/>
    /// </summary>
    public class OppositeTileCheck : Responsibility
    {
        public string TopMiddleTileValue { get; set; }

        public string BottomMiddleTileValue { get; set; }

        public string MiddleLeftTileValue { get; set; }

        public string MiddleRightTileValue { get; set; }

        public override int? GetMove(IEnumerable<IComputerGameTileModel> tiles)
        {
            this.PopulateFields(tiles);

            int? computerMove = this.OppositeCheck();

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

        private int? OppositeCheck()
        {
            int? topMiddleCheck = this.TopMiddleCheck();

            if (topMiddleCheck != null)
            {
                return topMiddleCheck;
            }

            int? bottomMiddleCheck = this.BottomMiddleCheck();

            if (bottomMiddleCheck != null)
            {
                return bottomMiddleCheck;
            }

            int? middleLeftCheck = this.MiddleLeftCheck();

            if (middleLeftCheck != null)
            {
                return middleLeftCheck;
            }

            int? middleRightCheck = this.MiddleRightCheck();

            if (middleRightCheck != null)
            {
                return middleRightCheck;
            }

            return null;
        }

        private int? TopMiddleCheck()
        {
            if (TileHelper.TileIsNotEmpty(this.TopMiddleTileValue))
            {
                if (TileHelper.TileIsEmpty(BottomMiddleTileValue))
                {
                    return TileConstants.BottomMiddleTile;
                }
            }

            return null;
        }

        private int? BottomMiddleCheck()
        {
            if (TileHelper.TileIsNotEmpty(this.BottomMiddleTileValue))
            {
                if (TileHelper.TileIsEmpty(this.TopMiddleTileValue))
                {
                    return TileConstants.TopMiddleTile;
                }
            }

            return null;
        }

        private int? MiddleLeftCheck()
        {
            if (TileHelper.TileIsNotEmpty(this.MiddleLeftTileValue))
            {
                if (TileHelper.TileIsEmpty(this.MiddleRightTileValue))
                {
                    return TileConstants.MiddleRightTile;
                }
            }

            return null;
        }

        private int? MiddleRightCheck()
        {
            if (TileHelper.TileIsNotEmpty(this.MiddleRightTileValue))
            {
                if (TileHelper.TileIsEmpty(this.MiddleLeftTileValue))
                {
                    return TileConstants.MiddleLeftTile;
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
            this.TopMiddleTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.TopMiddleTile).Value;
            this.BottomMiddleTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.BottomMiddleTile).Value;
            this.MiddleLeftTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.MiddleLeftTile).Value;
            this.MiddleRightTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.MiddleRightTile).Value;
        }
    }
}