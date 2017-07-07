namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.RowsCheck
{
    using System.Linq;
    using System.Collections.Generic;
    using Models;
    using TicTacToeCommon.Constants;

    public class FirstRowCheck : Responsibility
    {
        public string TopLeftTileValue { get; set; }

        public string TopMiddleTileValue { get; set; }

        public string TopRightTileValue { get; set; }

        public override int? GetMove(IEnumerable<IComputerGameTileModel> tiles)
        {
            this.PopulateFields(tiles);

            if (TileIsNotEmpty(TopLeftTileValue) && BothTilesAreTheSame(TopLeftTileValue, TopMiddleTileValue))
            {
                if (TileIsEmpty(this.TopRightTileValue))
                {
                    return TileConstants.TopRightTile;
                }
            }
            else if (TileIsNotEmpty(TopMiddleTileValue) && BothTilesAreTheSame(TopMiddleTileValue, TopRightTileValue))
            {
                if (TileIsEmpty(this.TopLeftTileValue))
                {
                    return TileConstants.TopLeftTile;
                }
            }
            else if (TileIsNotEmpty(TopRightTileValue) && BothTilesAreTheSame(TopRightTileValue, TopLeftTileValue))
            {
                if (TileIsEmpty(this.TopMiddleTileValue))
                {
                    return TileConstants.TopMiddleTile;
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
            this.TopMiddleTileValue = base.GetTileByIndex(tiles, TileConstants.TopMiddleTile).Value;
            this.TopRightTileValue = base.GetTileByIndex(tiles, TileConstants.TopRightTile).Value;
        }
    }
}