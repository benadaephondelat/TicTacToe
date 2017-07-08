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
    }
}