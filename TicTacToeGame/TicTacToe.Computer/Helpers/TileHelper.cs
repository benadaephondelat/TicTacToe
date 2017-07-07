namespace TicTacToe.Computer.Helpers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Models;
    using Exceptions;

    /// <summary>
    /// Contains useful methods that operate on ComputerGameTileModel
    /// </summary>
    public static class TileHelper
    {
        /// <summary>
        /// Returns a Tile by it's index from a list of tiles or throws exception
        /// </summary>
        /// <param name="gameTiles">tiles</param>
        /// <param name="index">tile index</param>
        /// <exception cref="ComputerException"></exception>
        /// <returns>ComputerGameTileModel</returns>
        public static IComputerGameTileModel GetTileByIndex(IEnumerable<IComputerGameTileModel> gameTiles, int index)
        {
            try
            {
                IComputerGameTileModel result = gameTiles.ElementAt(index);

                return result;
            }
            catch (ArgumentNullException)
            {
                throw new ComputerException("Tile is not found");
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ComputerException("Tile index is out of range");
            }
        }

        /// <summary>
        /// Checks if the two tiles has the same Tile.Value
        /// </summary>
        /// <param name="firstTile"></param>
        /// <param name="secondTile"></param>
        /// <returns>bool</returns>
        public static bool BothTilesAreTheSame(IComputerGameTileModel firstTile, IComputerGameTileModel secondTile)
        {
            if (firstTile.Value.Equals(secondTile.Value, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// If Tile.IsEmpty and Tile.Value is empty returns true, else returns false
        /// </summary>
        /// <param name="tile">IComputerGameTileModel</param>
        /// <returns>bool</returns>
        public static bool TileIsEmpty(IComputerGameTileModel tile)
        {
            if (string.IsNullOrWhiteSpace(tile.Value) && tile.IsEmpty)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// If string is empty return false, else return true
        /// </summary>
        /// <param name="tile">IComputerGameTileModel</param>
        /// <returns>bool</returns>
        public static bool TileIsNotEmpty(IComputerGameTileModel tile)
        {
            if (string.IsNullOrWhiteSpace(tile.Value) && tile.IsEmpty)
            {
                return false;
            }

            return true;
        }
    }
}