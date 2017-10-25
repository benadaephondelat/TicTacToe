namespace TicTacToe.Web.Models.ComputerVsComputer.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class NewComputerVsComputerGameInputModel
    {
        [Required]
        public string StartingFirstUsername { get; set; }

        [Required]
        public string OponentUsername { get; set; }
    }
}