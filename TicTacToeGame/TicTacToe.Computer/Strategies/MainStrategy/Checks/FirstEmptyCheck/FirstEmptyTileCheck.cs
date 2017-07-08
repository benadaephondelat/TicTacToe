namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.FirstEmptyCheck
{
    using System.Linq;
    using System.Collections.Generic;
    using Models;
    using Helpers;

    /// <summary>
    /// Returns the first empty tile.
    /// If there is no free tile it delegates the responsibility to the successor
    /// If there is no successor set, it returns null
    /// </summary>
    public class FirstEmptyTileCheck : Responsibility
    {
        public override int? GetMove(IEnumerable<IComputerGameTileModel> tiles)
        {
            int? computerMove = this.GetFirstEmptyTile(tiles);

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

        private int? GetFirstEmptyTile(IEnumerable<IComputerGameTileModel> tiles)
        {
            for (int i = 0; i < tiles.Count(); i++)
            {
                var currentTile = tiles.ElementAt(i);

                if (TileHelper.TileIsEmpty(currentTile.Value))
                {
                    return i;
                }
            }

            return null;
        }
    }
}