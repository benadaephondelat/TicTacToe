namespace TicTacToe.Computer.Models
{
    public interface IComputerGameTileModel
    {
        bool IsEmpty { get; set; }

        string Value { get; set; }
    }
}