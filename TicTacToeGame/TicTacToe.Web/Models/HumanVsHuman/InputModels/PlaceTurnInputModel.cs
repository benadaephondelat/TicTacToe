namespace TicTacToe.Web.Models.HumanVsHuman.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class PlaceTurnInputModel
    {
        [Required]
        public int GameId { get; set; }

        [Required]
        [Range(0, 8, ErrorMessage = "Tile index is inalid.")]
        public int TileIndex { get; set; }
    }
}