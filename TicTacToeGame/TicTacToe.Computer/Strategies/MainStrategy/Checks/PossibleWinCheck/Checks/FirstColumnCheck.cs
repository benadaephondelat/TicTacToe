namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.PossibleWinCheck.Checks
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Helpers;
    using TicTacToeCommon.Constants;

    public class FirstColumnCheck : Responsibility
    {
        public string TopLeftTileValue { get; set; }

        public string MiddleLeftTileValue { get; set; }

        public string BottomLeftTileValue { get; set; }

        private readonly string CurrentPlayerSign;

        public FirstColumnCheck(string currentPlayerSign)
        {
            this.CurrentPlayerSign = currentPlayerSign;
        }

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
            if (this.TopLeftTileValue == this.CurrentPlayerSign)
            {
                if (TileHelper.TileIsEmpty(this.MiddleLeftTileValue) && TileHelper.TileIsEmpty(this.BottomLeftTileValue))
                {
                    return TileConstants.MiddleLeftTile;
                }
            }

            return null;
        }

        private int? MiddleLeftCheck()
        {
            if (this.MiddleLeftTileValue == this.CurrentPlayerSign)
            {
                if (TileHelper.TileIsEmpty(this.TopLeftTileValue) && TileHelper.TileIsEmpty(this.BottomLeftTileValue))
                {
                    return TileConstants.BottomLeftTile;
                }
            }

            return null;
        }

        private int? BottomLeftCheck()
        {
            if (this.BottomLeftTileValue == this.CurrentPlayerSign)
            {
                if (TileHelper.TileIsEmpty(this.MiddleLeftTileValue) && TileHelper.TileIsEmpty(this.TopLeftTileValue))
                {
                    return TileConstants.TopLeftTile;
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
            this.TopLeftTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.TopLeftTile).Value;
            this.MiddleLeftTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.MiddleLeftTile).Value;
            this.BottomLeftTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.BottomLeftTile).Value;
        }
    }
}