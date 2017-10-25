namespace TicTacToe.Web.Models.HumanVsHuman.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class NewHumanVsHumanGameViewModel
    {
        [Required(ErrorMessage = "You must choose who will go first.")]
        [Display(Name = "Choose a side")]
        public List<string> Players { get; set; }
    }
}