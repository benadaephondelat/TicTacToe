namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.PossibleWinCheck.Checks
{
    using System.Collections.Generic;
    using Models;
    using Helpers;
    using TicTacToeCommon.Constants;

    public class SecondRowCheck : Responsibility
    {
        public string MiddleLeftTileValue { get; set; }

        public string MiddleMiddleTileValue { get; set; }

        public string MiddleRightTileValue { get; set; }

        private readonly string CurrentPlayerSign;

        public SecondRowCheck(string currentPlayerSign)
        {
            this.CurrentPlayerSign = currentPlayerSign;
        }

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
            if (this.MiddleLeftTileValue == this.CurrentPlayerSign)
            {
                if (TileHelper.TileIsEmpty(this.MiddleMiddleTileValue) && TileHelper.TileIsEmpty(this.MiddleRightTileValue))
                {
                    return TileConstants.MiddleMiddleTile;
                }
            }

            return null;
        }

        private int? MiddleMiddleCheck()
        {
            if (this.MiddleMiddleTileValue == this.CurrentPlayerSign)
            {
                if (TileHelper.TileIsEmpty(this.MiddleLeftTileValue) && TileHelper.TileIsEmpty(this.MiddleRightTileValue))
                {
                    return TileConstants.MiddleRightTile;
                }
            }

            return null;
        }

        private int? MiddleRightCheck()
        {
            if (this.MiddleRightTileValue == this.CurrentPlayerSign)
            {
                if (TileHelper.TileIsEmpty(this.MiddleLeftTileValue) && TileHelper.TileIsEmpty(this.MiddleMiddleTileValue))
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
            this.MiddleLeftTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.MiddleLeftTile).Value;
            this.MiddleMiddleTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.MiddleMiddleTile).Value;
            this.MiddleRightTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.MiddleRightTile).Value;
        }
    }
}