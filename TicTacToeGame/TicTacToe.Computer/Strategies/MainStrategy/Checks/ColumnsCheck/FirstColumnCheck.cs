namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.ColumnsCheck
{
    using System.Collections.Generic;
    using Models;
    using TicTacToeCommon.Constants;

    /// <summary>
    /// Checks the first column for a possible winner
    /// If there is no winner and there is no successor set it returns null
    /// If there is a successor it delegates the responsibility to him
    /// </summary>
    public class FirstColumnCheck : Responsibility
    {
        public string TopLeftTileValue { get; set; }

        public string MiddleLeftTileValue { get; set; }

        public string BottomLeftTileValue { get; set; }

        public override int? GetMove(IEnumerable<IComputerGameTileModel> tiles)
        {
            this.PopulateFields(tiles);

            if (TileIsNotEmpty(this.TopLeftTileValue) && BothTilesAreTheSame(this.TopLeftTileValue, this.MiddleLeftTileValue))
            {
                if (TileIsEmpty(this.BottomLeftTileValue))
                {
                    return TileConstants.BottomLeftTile;
                }
            }
            else if (TileIsNotEmpty(this.MiddleLeftTileValue) && BothTilesAreTheSame(this.MiddleLeftTileValue, this.BottomLeftTileValue))
            {
                if (TileIsEmpty(this.TopLeftTileValue))
                {
                    return TileConstants.TopLeftTile;
                }
            }
            else if (TileIsNotEmpty(this.TopLeftTileValue) && BothTilesAreTheSame(this.TopLeftTileValue, this.BottomLeftTileValue))
            {
                if (TileIsEmpty(this.MiddleLeftTileValue))
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
        /// Populates the fields with the coresponding values of the tiles
        /// </summary>
        /// <param name="tiles">IEnumerable<IComputerGameTileModel></ComputerGameTileModel></param>
        private void PopulateFields(IEnumerable<IComputerGameTileModel> tiles)
        {
            this.TopLeftTileValue = base.GetTileByIndex(tiles, TileConstants.TopLeftTile).Value;
            this.MiddleLeftTileValue = base.GetTileByIndex(tiles, TileConstants.MiddleLeftTile).Value;
            this.BottomLeftTileValue = base.GetTileByIndex(tiles, TileConstants.BottomLeftTile).Value;
        }
    }
}