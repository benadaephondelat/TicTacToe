namespace TicTacToe.Computer.Models
{
    using System.Collections.Generic;

    public class ComputerGameModel : IComputerGameModel
    {
        public string HomesideUsername { get; set; }

        public string AwaysideUsername { get; set; }

        public int TurnsCount { get; set; }

        public bool IsFinished { get; set; }

        public IEnumerable<IComputerGameTileModel> Tiles { get; set; }
    }
}