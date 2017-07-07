namespace TicTacToe.Computer.Strategies
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Constants;

    /// <summary>
    /// Turn strategy 
    /// </summary>
    public abstract class TurnStrategy
    {
        protected IEnumerable<IComputerGameTileModel> gameTiles;

        public TurnStrategy(IEnumerable<IComputerGameTileModel> gameTiles)
        {
            this.gameTiles = gameTiles;
        }

        /// <summary>
        /// Returns the computer's move
        /// </summary>
        /// <returns>int</returns>
        public abstract int? GetMove();

        /// <summary>
        /// Choose a random edge tile index
        /// </summary>
        /// <returns>int</returns>
        protected int ChooseRandomlyFromEdges()
        {
            Random random = new Random();

            int randomIndex = random.Next(0, ComputerConstants.Edges.Length - 1);

            int result = ComputerConstants.Edges[randomIndex];

            return result;
        }
    }
}