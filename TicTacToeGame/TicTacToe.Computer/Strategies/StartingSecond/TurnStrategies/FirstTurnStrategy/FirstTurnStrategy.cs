namespace TicTacToe.Computer.Strategies.StartingSecond.TurnStrategies.FirstTurnStrategy
{
    using System.Linq;
    using System.Collections.Generic;
    using Models;
    using TicTacToeCommon.Constants;

    /// <summary>
    /// Contains the logic to be executed when the computer is starting second and it's his first turn.
    /// </summary>
    public class FirstTurnStrategy : TurnStrategy
    {
        public FirstTurnStrategy(IEnumerable<IComputerGameTileModel> gameTiles) : base(gameTiles)
        {
        }

        /// <summary>
        /// Returns the center tile if it's empty, else chooses a random edge
        /// </summary>
        /// <returns>int?</returns>
        public override int? GetMove()
        {
            if (this.MiddleTileIsEmpty())
            {
                return TileConstants.MiddleMiddleTile;
            }

            return this.ChooseRandomlyFromEdges();
        }

        /// <summary>
        /// Checks if the middle tile is empty
        /// </summary>
        /// <returns>bool</returns>
        private bool MiddleTileIsEmpty()
        {
            bool isValueEmptyCheck = string.IsNullOrWhiteSpace(this.gameTiles.ElementAt(TileConstants.MiddleMiddleTile).Value);

            bool isEmptyPropertyCheck = this.gameTiles.ElementAt(TileConstants.MiddleMiddleTile).IsEmpty;

            bool isMiddleTileEmpty = isValueEmptyCheck && isEmptyPropertyCheck;

            return isMiddleTileEmpty;
        }
    }
}