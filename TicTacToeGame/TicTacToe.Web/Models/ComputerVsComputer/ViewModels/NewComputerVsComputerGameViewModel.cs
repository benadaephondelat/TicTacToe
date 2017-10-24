namespace TicTacToe.Web.Models.ComputerVsComputer.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class NewComputerVsComputerGameViewModel
    {
        [Required(ErrorMessage = "You must choose a starting side.")]
        [Display(Name = "Choose who will go first.")]
        public List<string> Sides { get; set; }

        [Required(ErrorMessage = "You must choose an oponent.")]
        [Display(Name = "Choose an oponent.")]
        public List<string> Computers { get; set; }
    }
}