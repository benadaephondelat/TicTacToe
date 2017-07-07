namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.DiagonalsCheck
{
    using System.Linq;
    using System.Collections.Generic;
    using Models;
    using TicTacToeCommon.Constants;

    public class SecondDiagonalCheck : Responsibility
    {
        public string TopRightTileValue { get; set; }

        public string MiddleMiddleTileValue { get; set; }

        public string BottomLeftTileValue { get; set; }

        public override int? GetMove(IEnumerable<IComputerGameTileModel> tiles)
        {
            this.PopulateFields(tiles);

            if (this.TopRightTileValue == this.MiddleMiddleTileValue && this.TopRightTileValue != string.Empty) 
            {
                if (string.IsNullOrWhiteSpace(tiles.ToList().ElementAt(TileConstants.BottomLeftTile).Value))
                {
                    return TileConstants.BottomLeftTile;
                }
            }
            else if (this.MiddleMiddleTileValue == this.BottomLeftTileValue && this.MiddleMiddleTileValue != string.Empty)
            {
                if (string.IsNullOrWhiteSpace(tiles.ToList().ElementAt(TileConstants.TopRightTile).Value))
                {
                    return TileConstants.TopRightTile;
                }
            }
            else if (this.BottomLeftTileValue == this.TopRightTileValue && this.BottomLeftTileValue != string.Empty)
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
            this.TopRightTileValue = base.GetTileByIndex(tiles, TileConstants.TopRightTile).Value;
            this.MiddleMiddleTileValue = base.GetTileByIndex(tiles, TileConstants.MiddleMiddleTile).Value;
            this.BottomLeftTileValue = base.GetTileByIndex(tiles, TileConstants.BottomLeftTile).Value;
        }
    }
}