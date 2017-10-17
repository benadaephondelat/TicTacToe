namespace TicTacToe.Web.Models.HumanVsComputer.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class NewHumanVsComputerGameViewModel : IValidatableObject
    {
        private const string SidesErrorMessage = "The player who starts first and the oponent must be different!";

        private const string ComputersErrorMessage = "The oponent can not be the same as the player who is starting first!";

        [Required(ErrorMessage = "You must choose a starting side.")]
        [Display(Name = "Choose who will go first.")]
        public List<string> Sides { get; set; }

        [Required(ErrorMessage = "You must choose an oponent.")]
        [Display(Name = "Choose an oponent.")]
        public List<string> Computers { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Sides[0].Equals(this.Computers[0], StringComparison.OrdinalIgnoreCase))
            {
                yield return new ValidationResult(SidesErrorMessage, this.Sides);
                yield return new ValidationResult(ComputersErrorMessage, this.Computers);
            }
        }
    }
}