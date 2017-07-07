namespace TicTacToe.Computer.Strategies.MainStrategy.Checks.FirstEmptyCheck
{
    using System.Linq;
    using System.Collections.Generic;
    using Models;

    public class FirstEmptyTileCheck : Responsibility
    {
        public override int? GetMove(IEnumerable<IComputerGameTileModel> tiles)
        {
            for (int i = 0; i < tiles.Count(); i++)
            {
                var currentTile = tiles.ElementAt(i);

                if (currentTile.IsEmpty && string.IsNullOrWhiteSpace(currentTile.Value))
                {
                    return i;
                }
            }

            if (base.successor == null)
            {
                return null;
            }

            return base.successor.GetMove(tiles);
        }
    }
}