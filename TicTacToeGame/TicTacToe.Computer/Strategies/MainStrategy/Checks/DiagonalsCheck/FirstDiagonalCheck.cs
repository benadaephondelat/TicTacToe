namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.DiagonalsCheck
{
    using System.Linq;
    using System.Collections.Generic;
    using TicTacToeCommon.Constants;
    using Models;

    public class FirstDiagonalCheck : Responsibility
    {
        public string TopLeftTileValue { get; set; }

        public string MiddleMiddleTileValue { get; set; }

        public string BottomRightTileValue { get; set; }

        public override int? GetMove(IEnumerable<IComputerGameTileModel> tiles)
        {
            this.PopulateFields(tiles);

            if (this.TopLeftTileValue == this.MiddleMiddleTileValue && this.TopLeftTileValue != string.Empty)
            {
                if (string.IsNullOrWhiteSpace(tiles.ToList().ElementAt(TileConstants.BottomRightTile).Value))
                {
                    return TileConstants.BottomRightTile;
                }
            }
            else if (this.MiddleMiddleTileValue == this.BottomRightTileValue && this.MiddleMiddleTileValue != string.Empty)
            {
                if (string.IsNullOrWhiteSpace(tiles.ToList().ElementAt(TileConstants.TopLeftTile).Value))
                {
                    return TileConstants.TopLeftTile;
                }
            }
            else if (this.BottomRightTileValue == this.TopLeftTileValue && this.BottomRightTileValue != string.Empty)
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
            this.TopLeftTileValue = base.GetTileByIndex(tiles, TileConstants.TopLeftTile).Value;
            this.MiddleMiddleTileValue = base.GetTileByIndex(tiles, TileConstants.MiddleMiddleTile).Value;
            this.BottomRightTileValue = base.GetTileByIndex(tiles, TileConstants.BottomRightTile).Value;
        }
    }
}