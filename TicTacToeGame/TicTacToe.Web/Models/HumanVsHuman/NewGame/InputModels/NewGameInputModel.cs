namespace TicTacToe.Web.Models.HumanVsHuman.NewGame.InputModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class NewGameInputModel
    {
        [Required(ErrorMessage = "Please choose who will go first")]
        [Display(Name = "Choose a side")]
        public List<string> Players { get; set; }
        
        [Required]
        [Display(Name = "Oponent Name")]
        [StringLength(50, ErrorMessage = "Oponent name must be between 3 and 50 chars long.", MinimumLength = 3)]
        public string OponentName { get; set; }
    }
}