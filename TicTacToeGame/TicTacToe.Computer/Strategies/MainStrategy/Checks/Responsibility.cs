namespace TicTacToe.Computer.Strategies.MainStrategy.Checks
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Models;

    public abstract class Responsibility
    {
        protected Responsibility successor;

        public void SetSuccessor(Responsibility successor)
        {
            this.successor = successor;
        }

        /// <summary>
        /// Gets the Computer's move or returns null.
        /// </summary>
        /// <param name="tiles">Game tiles</param>
        /// <returns>int?</returns>
        public abstract int? GetMove(IEnumerable<IComputerGameTileModel> tiles);

        //TODO EXTRACT THIS OR NOT
        /// <summary>
        /// Returns tile by it's index from a list of tiles or throws exception
        /// </summary>
        /// <param name="gameTiles">tiles</param>
        /// <param name="index">tile index</param>
        /// <returns>ComputerGameTileModel</returns>
        protected IComputerGameTileModel GetTileByIndex(IEnumerable<IComputerGameTileModel> gameTiles, int index)
        {
            //TODO VALIDATION

            IComputerGameTileModel result = gameTiles.ElementAt(index);

            return result;
        }

        /// <summary>
        /// Checks if two strings are equal, ignoring the case
        /// </summary>
        /// <param name="firstTileValue">firstTileValue</param>
        /// <param name="secondTileValue">secondTileValue</param>
        /// <returns>bool</returns>
        protected bool BothTilesAreTheSame(string firstTileValue, string secondTileValue)
        {
            if (firstTileValue.Equals(secondTileValue, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// If string is empty return true, else return false
        /// </summary>
        /// <param name="tileValue">string to check</param>
        /// <returns>bool</returns>
        protected bool TileIsEmpty(string tileValue)
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
        /// <param name="tileValue">string to check</param>
        /// <returns>bool</returns>
        protected bool TileIsNotEmpty(string tileValue)
        {
            if (string.IsNullOrWhiteSpace(tileValue))
            {
                return false;
            }

            return true;
        }
    }
}