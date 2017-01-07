namespace TicTacToe.Web.Models.HumanVsHuman.NewGame.InputModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class NewHumanVsHumanGameInputModel
    {
        [Required(ErrorMessage = "You must choose who will go first.")]
        [Display(Name = "Choose a side")]
        public List<string> Players { get; set; }
    }
}