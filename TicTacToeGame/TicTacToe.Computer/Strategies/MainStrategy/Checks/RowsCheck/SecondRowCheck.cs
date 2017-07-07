namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.RowsCheck
{
    using System.Linq;
    using System.Collections.Generic;
    using Models;
    using TicTacToeCommon.Constants;

    public class SecondRowCheck : Responsibility
    {
        public string MiddleLeftTileValue { get; set; }

        public string MiddleMiddleTileValue { get; set; }

        public string MiddleRightTileValue { get; set; }

        public override int? GetMove(IEnumerable<IComputerGameTileModel> tiles)
        {
            this.PopulateFields(tiles);

            if (this.MiddleLeftTileValue == this.MiddleMiddleTileValue && this.MiddleLeftTileValue != string.Empty)
            {
                if (string.IsNullOrWhiteSpace(tiles.ToList().ElementAt(TileConstants.MiddleRightTile).Value))
                {
                    return TileConstants.MiddleRightTile;
                }
            }
            else if (this.MiddleMiddleTileValue == this.MiddleRightTileValue && this.MiddleMiddleTileValue != string.Empty)
            {
                if (string.IsNullOrWhiteSpace(tiles.ToList().ElementAt(TileConstants.MiddleLeftTile).Value))
                {
                    return TileConstants.MiddleLeftTile;
                }
            }
            else if (this.MiddleRightTileValue == this.MiddleLeftTileValue && this.MiddleRightTileValue != string.Empty)
            {
                if (string.IsNullOrWhiteSpace(tiles.ToList().ElementAt(TileConstants.MiddleMiddleTile).Value))
                {
                    return TileConstants.MiddleMiddleTile;
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
            this.MiddleLeftTileValue = base.GetTileByIndex(tiles, TileConstants.MiddleLeftTile).Value;
            this.MiddleMiddleTileValue = base.GetTileByIndex(tiles, TileConstants.MiddleMiddleTile).Value;
            this.MiddleRightTileValue = base.GetTileByIndex(tiles, TileConstants.MiddleRightTile).Value;
        }
    }
}