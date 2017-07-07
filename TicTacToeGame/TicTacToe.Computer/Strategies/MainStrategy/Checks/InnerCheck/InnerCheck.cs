namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.InnerCheck
{
    using System.Collections.Generic;
    using Models;
    using TicTacToeCommon.Constants;

    public class InnerCheck : Responsibility
    {
        public string TopMiddleTileValue { get; set; }

        public string BottomMiddleTileValue { get; set; }

        public string MiddleLeftTileValue { get; set; }

        public string MiddleRightTileValue { get; set; }

        public override int? GetMove(IEnumerable<IComputerGameTileModel> tiles)
        {
            this.PopulateFields(tiles);

            if (string.IsNullOrWhiteSpace(this.TopMiddleTileValue) == false)
            {
                if (string.IsNullOrWhiteSpace(this.BottomMiddleTileValue))
                {
                    return TileConstants.BottomMiddleTile;
                }
            }

            if (string.IsNullOrWhiteSpace(this.BottomMiddleTileValue) == false)
            {
                if (string.IsNullOrWhiteSpace(this.TopMiddleTileValue))
                {
                    return TileConstants.TopMiddleTile;
                }
            }

            if (string.IsNullOrWhiteSpace(this.MiddleLeftTileValue) == false)
            {
                if (string.IsNullOrWhiteSpace(this.MiddleRightTileValue))
                {
                    return TileConstants.MiddleRightTile;
                }
            }

            if (string.IsNullOrWhiteSpace(this.MiddleRightTileValue) == false)
            {
                if (string.IsNullOrWhiteSpace(this.MiddleLeftTileValue))
                {
                    return TileConstants.MiddleLeftTile;
                }
            }

            if (base.successor == null)
            {
                return null;
            }

            return base.successor.GetMove(tiles);
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