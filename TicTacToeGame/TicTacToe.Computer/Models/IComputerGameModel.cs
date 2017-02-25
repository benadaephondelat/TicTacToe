namespace TicTacToe.Computer.Models
{
    using System.Collections.Generic;

    public interface IComputerGameModel
    {
        string HomesideUsername { get; set; }

        string AwaysideUsername { get; set; }

        int TurnsCount { get; set; }

        bool IsFinished { get; set; }

        IEnumerable<ComputerGameTileModel> Tiles { get; set; }
    }
}