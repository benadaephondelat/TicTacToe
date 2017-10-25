namespace TicTacToe.Web.Models.Common.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class PlaceTurnInputModel
    {
        [Required]
        public int GameId { get; set; }

        [Required]
        [Range(0, 8, ErrorMessage = "Tile index is invalid.")]
        public int TileIndex { get; set; }
    }
}