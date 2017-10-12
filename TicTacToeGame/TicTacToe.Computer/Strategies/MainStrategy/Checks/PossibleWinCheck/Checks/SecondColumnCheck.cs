namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.PossibleWinCheck.Checks
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Helpers;
    using TicTacToeCommon.Constants;

    public class SecondColumnCheck : Responsibility
    {
        public string TopMiddleTileValue { get; set; }

        public string MiddleMiddleTileValue { get; set; }

        public string BottomMiddleTileValue { get; set; }

        private readonly string CurrentPlayerSign;

        public SecondColumnCheck(string currentPlayerSign)
        {
            this.CurrentPlayerSign = currentPlayerSign;
        }

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
            if (this.TopMiddleTileValue == this.CurrentPlayerSign)
            {
                if (TileHelper.TileIsEmpty(this.MiddleMiddleTileValue) && TileHelper.TileIsEmpty(this.BottomMiddleTileValue))
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
                if (TileHelper.TileIsEmpty(this.TopMiddleTileValue) && TileHelper.TileIsEmpty(this.BottomMiddleTileValue))
                {
                    return TileConstants.BottomMiddleTile;
                }
            }

            return null;
        }

        private int? BottomMiddleCheck()
        {
            if (this.BottomMiddleTileValue == this.CurrentPlayerSign)
            {
                if (TileHelper.TileIsEmpty(this.TopMiddleTileValue) && TileHelper.TileIsEmpty(this.MiddleMiddleTileValue))
                {
                    return TileConstants.TopMiddleTile;
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