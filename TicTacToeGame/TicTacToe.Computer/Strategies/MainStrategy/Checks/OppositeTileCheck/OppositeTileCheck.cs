namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.InnerCheck
{
    using System.Collections.Generic;
    using Models;
    using TicTacToeCommon.Constants;

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
            if (base.TileIsNotEmpty(this.TopMiddleTileValue))
            {
                if (base.TileIsEmpty(BottomMiddleTileValue))
                {
                    return TileConstants.BottomMiddleTile;
                }
            }

            return null;
        }

        private int? BottomMiddleCheck()
        {
            if (base.TileIsNotEmpty(this.BottomMiddleTileValue))
            {
                if (base.TileIsEmpty(this.TopMiddleTileValue))
                {
                    return TileConstants.TopMiddleTile;
                }
            }

            return null;
        }

        private int? MiddleLeftCheck()
        {
            if (base.TileIsNotEmpty(this.MiddleLeftTileValue))
            {
                if (base.TileIsEmpty(this.MiddleRightTileValue))
                {
                    return TileConstants.MiddleRightTile;
                }
            }

            return null;
        }

        private int? MiddleRightCheck()
        {
            if (base.TileIsNotEmpty(this.MiddleRightTileValue))
            {
                if (base.TileIsEmpty(this.MiddleLeftTileValue))
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
            this.TopMiddleTileValue = base.GetTileByIndex(tiles, TileConstants.TopMiddleTile).Value;
            this.BottomMiddleTileValue = base.GetTileByIndex(tiles, TileConstants.BottomMiddleTile).Value;
            this.MiddleLeftTileValue = base.GetTileByIndex(tiles, TileConstants.MiddleLeftTile).Value;
            this.MiddleRightTileValue = base.GetTileByIndex(tiles, TileConstants.MiddleRightTile).Value;
        }
    }
}