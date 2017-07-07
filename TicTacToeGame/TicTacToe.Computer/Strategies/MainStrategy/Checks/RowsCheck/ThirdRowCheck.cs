namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.RowsCheck
{
    using System.Linq;
    using System.Collections.Generic;
    using Models;
    using TicTacToeCommon.Constants;

    public class ThirdRowCheck : Responsibility
    {
        public string BottomLeftTileValue { get; set; }

        public string BottomMiddleTileValue { get; set; }

        public string BottomRightTileValue { get; set; }

        public override int? GetMove(IEnumerable<IComputerGameTileModel> tiles)
        {
            this.PopulateFields(tiles);

            if (this.BottomLeftTileValue == this.BottomMiddleTileValue && this.BottomLeftTileValue != string.Empty)
            {
                if (string.IsNullOrWhiteSpace(tiles.ToList().ElementAt(TileConstants.BottomRightTile).Value))
                {
                    return TileConstants.BottomRightTile;
                }
            }
            else if (this.BottomMiddleTileValue == this.BottomRightTileValue && this.BottomMiddleTileValue != string.Empty)
            {
                if (string.IsNullOrWhiteSpace(tiles.ToList().ElementAt(TileConstants.BottomLeftTile).Value))
                {
                    return TileConstants.BottomLeftTile;
                }
            }
            else if (this.BottomRightTileValue == this.BottomLeftTileValue && this.BottomRightTileValue != string.Empty)
            {
                if (string.IsNullOrWhiteSpace(tiles.ToList().ElementAt(TileConstants.BottomMiddleTile).Value))
                {
                    return TileConstants.BottomMiddleTile;
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
            this.BottomLeftTileValue = base.GetTileByIndex(tiles, TileConstants.BottomLeftTile).Value;
            this.BottomMiddleTileValue = base.GetTileByIndex(tiles, TileConstants.BottomMiddleTile).Value;
            this.BottomRightTileValue = base.GetTileByIndex(tiles, TileConstants.BottomRightTile).Value;
        }
    }
}