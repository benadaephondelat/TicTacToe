namespace TicTacToe.Computer.Models
{
    public class ComputerGameTileModel : IComputerGameTileModel
    {
        public bool IsEmpty { get; set; }

        public string Value { get; set; }
    }
}