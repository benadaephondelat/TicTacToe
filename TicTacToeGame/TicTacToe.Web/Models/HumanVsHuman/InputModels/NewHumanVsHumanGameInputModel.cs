namespace TicTacToe.Web.Models.HumanVsHuman.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class NewHumanVsHumanGameInputModel
    {
        [Required]
        public string StartingFirstUsername { get; set; }
    }
}