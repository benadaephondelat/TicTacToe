namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.ColumnsCheck
{
    using System.Linq;
    using System.Collections.Generic;
    using TicTacToeCommon.Constants;
    using Models;

    public class ThirdColumnCheck : Responsibility
    {
        public string TopRightTileValue { get; set; }

        public string MiddleRightTileValue { get; set; }

        public string BottomRightTileValue { get; set; }

        public override int? GetMove(IEnumerable<IComputerGameTileModel> tiles)
        {
            this.PopulateFields(tiles);

            if (this.TopRightTileValue == this.MiddleRightTileValue && this.TopRightTileValue != string.Empty)
            {
                if (string.IsNullOrWhiteSpace(tiles.ToList().ElementAt(TileConstants.BottomRightTile).Value))
                {
                    return TileConstants.BottomRightTile;
                }
            }
            else if (this.MiddleRightTileValue == this.BottomRightTileValue && this.MiddleRightTileValue != string.Empty)
            {
                if (string.IsNullOrWhiteSpace(tiles.ToList().ElementAt(TileConstants.TopRightTile).Value))
                {
                    return TileConstants.TopRightTile;
                }
            }
            else if (this.BottomRightTileValue == this.TopRightTileValue && this.BottomRightTileValue != string.Empty)
            {
                if (string.IsNullOrWhiteSpace(tiles.ToList().ElementAt(TileConstants.MiddleRightTile).Value))
                {
                    return TileConstants.MiddleRightTile;
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
            this.MiddleRightTileValue = base.GetTileByIndex(tiles, TileConstants.MiddleRightTile).Value;
            this.BottomRightTileValue = base.GetTileByIndex(tiles, TileConstants.BottomRightTile).Value;
        }
    }
}