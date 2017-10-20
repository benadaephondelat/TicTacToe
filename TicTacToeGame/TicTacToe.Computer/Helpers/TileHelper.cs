namespace TicTacToe.Computer.Helpers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Models;
    using TicTacToeCommon.Exceptions.Tile;

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
                throw new TileValidationException("Tile is not found");
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new TileValidationException("Tile index is out of range");
            }
        }

        /// <summary>
        /// Checks if the two tiles has the same Tile.Value
        /// </summary>
        /// <param name="firstTileValue">string</param>
        /// <param name="secondTileValue">string</param>
        /// <returns>bool</returns>
        public static bool BothTilesAreTheSame(string firstTileValue, string secondTileValue)
        {
            if (firstTileValue.Equals(secondTileValue, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// If Tile.IsEmpty and Tile.Value is empty returns true, else returns false
        /// </summary>
        /// <param name="tileValue">string</param>
        /// <returns>bool</returns>
        public static bool TileIsEmpty(string tileValue)
        {
            if (string.IsNullOrWhiteSpace(tileValue))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// If string is empty return false, else return true
        /// </summary>
        /// <param name="tileValue">string</param>
        /// <returns>bool</returns>
        public static bool TileIsNotEmpty(string tileValue)
        {
            if (string.IsNullOrWhiteSpace(tileValue))
            {
                return false;
            }

            return true;
        }
    }
}