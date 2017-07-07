namespace TicTacToe.Computer.Strategies.StartingFirst.TurnStrategies.FirstTurnStrategy
{
    using System.Collections.Generic;
    using Constants;
    using Models;

    /// <summary>
    /// Contains the logic to be executed when the computer is starting first and it's his first turn.
    /// </summary>
    public class FirstTurnStrategy : TurnStrategy
    {
        public FirstTurnStrategy(IEnumerable<IComputerGameTileModel> gameTiles) : base(gameTiles)
        {
        }

        /// <summary>
        /// Returns the center tile
        /// </summary>
        /// <returns>int</returns>
        public override int? GetMove()
        {
            return ComputerConstants.CenterPosition;
        }
    }
}