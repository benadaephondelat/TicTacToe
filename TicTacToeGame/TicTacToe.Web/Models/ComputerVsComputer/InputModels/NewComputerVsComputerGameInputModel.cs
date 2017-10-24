namespace TicTacToe.Web.Models.ComputerVsComputer.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class NewComputerVsComputerGameInputModel
    {
        private const string ErrorMessage = "The player who starts first and the oponent must be different!";

        [Required]
        public string StartingFirstUsername { get; set; }

        [Required]
        public string OponentUsername { get; set; }
    }
}