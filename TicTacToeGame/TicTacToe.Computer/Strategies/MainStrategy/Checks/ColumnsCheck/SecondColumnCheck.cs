namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.ColumnsCheck
{
    using System.Linq;
    using System.Collections.Generic;
    using Models;
    using TicTacToeCommon.Constants;

    /// <summary>
    /// Checks the second column for a possible winner
    /// If there is no winner and there is no successor set it returns null
    /// If there is a successor it delegates the responsibility to him
    /// </summary>
    public class SecondColumnCheck : Responsibility
    {
        public string TopMiddleTileValue { get; set; }

        public string MiddleMiddleTileValue { get; set; }

        public string BottomMiddleTileValue { get; set; }

        public override int? GetMove(IEnumerable<IComputerGameTileModel> tiles)
        {
            this.PopulateFields(tiles);

            if (TileIsNotEmpty(this.TopMiddleTileValue) && BothTilesAreTheSame(this.TopMiddleTileValue, this.MiddleMiddleTileValue))
            {
                if (TileIsEmpty(this.BottomMiddleTileValue))
                {
                    return TileConstants.BottomMiddleTile;
                }
            }
            else if (this.MiddleMiddleTileValue == this.BottomMiddleTileValue && this.MiddleMiddleTileValue != string.Empty)
            {
                if (string.IsNullOrWhiteSpace(tiles.ToList().ElementAt(TileConstants.TopMiddleTile).Value))
                {
                    return TileConstants.TopMiddleTile;
                }
            }
            else if (this.BottomMiddleTileValue == this.TopMiddleTileValue && this.BottomMiddleTileValue != string.Empty)
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
        /// Populates the fields with the coresponding values of the tiles
        /// </summary>
        /// <param name="tiles">IEnumerable<IComputerGameTileModel></ComputerGameTileModel></param>
        private void PopulateFields(IEnumerable<IComputerGameTileModel> tiles)
        {
            this.TopMiddleTileValue = base.GetTileByIndex(tiles, TileConstants.TopMiddleTile).Value;
            this.MiddleMiddleTileValue = base.GetTileByIndex(tiles, TileConstants.MiddleMiddleTile).Value;
            this.BottomMiddleTileValue = base.GetTileByIndex(tiles, TileConstants.BottomMiddleTile).Value;
        }
    }
}