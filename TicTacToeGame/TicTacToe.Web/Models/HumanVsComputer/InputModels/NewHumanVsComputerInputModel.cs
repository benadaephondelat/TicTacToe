namespace TicTacToe.Web.Models.HumanVsComputer.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class NewHumanVsComputerInputModel : IValidatableObject
    {
        private const string ErrorMessage = "The player who starts first and the oponent must be different!";

        [Required]
        [MaxLength(30)]
        public string StartingFirstUsername { get; set; }

        [Required]
        [MaxLength(30)]
        public string OponentUsername { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.StartingFirstUsername.Equals(this.OponentUsername, StringComparison.OrdinalIgnoreCase))
            {
                IEnumerable<string> memberNames = new List<string> { this.StartingFirstUsername, this.OponentUsername };

                yield return new ValidationResult(ErrorMessage, memberNames);
            }
        }
    }
}