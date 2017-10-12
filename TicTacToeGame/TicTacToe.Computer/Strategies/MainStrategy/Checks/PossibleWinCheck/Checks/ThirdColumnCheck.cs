
namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.PossibleWinCheck.Checks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Models;
    using Helpers;
    using TicTacToeCommon.Constants;

    public class ThirdColumnCheck : Responsibility
    {
        public string TopRightTileValue { get; set; }

        public string MiddleRightTileValue { get; set; }

        public string BottomRightTileValue { get; set; }

        private readonly string CurrentPlayerSign;

        public ThirdColumnCheck(string currentPlayerSign)
        {
            this.CurrentPlayerSign = currentPlayerSign;
        }

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
            if (this.TopRightTileValue == this.CurrentPlayerSign)
            {
                if (TileHelper.TileIsEmpty(this.MiddleRightTileValue) && TileHelper.TileIsEmpty(this.BottomRightTileValue))
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
                if (TileHelper.TileIsEmpty(this.TopRightTileValue) && TileHelper.TileIsEmpty(this.BottomRightTileValue))
                {
                    return TileConstants.BottomRightTile;
                }
            }

            return null;
        }

        private int? BottomRightCheck()
        {
            if (this.BottomRightTileValue == this.CurrentPlayerSign)
            {
                if (TileHelper.TileIsEmpty(this.TopRightTileValue) && TileHelper.TileIsEmpty(this.MiddleRightTileValue))
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
            this.TopRightTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.TopRightTile).Value;
            this.MiddleRightTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.MiddleRightTile).Value;
            this.BottomRightTileValue = TileHelper.GetTileByIndex(tiles, TileConstants.BottomRightTile).Value;
        }
    }
}