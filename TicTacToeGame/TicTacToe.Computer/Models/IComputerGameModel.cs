namespace TicTacToe.Computer.Models
{
    public interface IComputerGameModel
    {
        string HomesideUsername { get; set; }

        string AwaysideUsername { get; set; }

        int TurnsCount { get; set; }

        bool IsFinished { get; set; }
    }
}