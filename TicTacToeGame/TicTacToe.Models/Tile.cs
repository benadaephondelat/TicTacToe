namespace TicTacToe.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Tile
    {
        [Key]
        public int Id { get; set; }

        public bool IsEmpty { get; set; }

        public string Value { get; set; }

        public int GameId { get; set; }

        public virtual Game Game { get; set; } 
    }
}