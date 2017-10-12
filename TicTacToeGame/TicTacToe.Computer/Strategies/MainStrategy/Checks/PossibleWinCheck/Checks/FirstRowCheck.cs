namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.PossibleWinCheck.Checks
{
    using System.Collections.Generic;
    using Models;
    using Helpers;
    using TicTacToeCommon.Constants;

    public class FirstRowCheck : Responsibility
    {
        public string TopLeftTileValue { get; set; }

        public string TopMiddleTileValue { get; set; }

        public string TopRightTileValue { get; set; }

        private readonly string CurrentPlayerSign;

        public FirstRowCheck(string currentPlayerSign)
        {
            this.CurrentPlayerSign = currentPlayerSign;
        }

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
            if (this.TopLeftTileValue == this.CurrentPlayerSign)
            {
                if (TileHelper.TileIsEmpty(this.TopMiddleTileValue) && TileHelper.TileIsEmpty(this.TopRightTileValue))
                {
                    return TileConstants.TopRightTile;
                }
            }

            return null;
        }

        private int? TopMiddleCheck()
        {
            if (this.TopMiddleTileValue == this.CurrentPlayerSign)
            {
                if (TileHelper.TileIsEmpty(this.TopLeftTileValue) && TileHelper.TileIsEmpty(this.TopRightTileValue))
                {
                    return TileConstants.TopLeftTile;
                }
            }

            return null;
        }

        private int? TopRightCheck()
        {
            if (this.TopRightTileValue == this.CurrentPlayerSign)
            {
                if (TileHelper.TileIsEmpty(this.TopLeftTileValue) && TileHelper.TileIsEmpty(this.TopMiddleTileValue))
                {
                    return TileConstants.TopMiddleTile;
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