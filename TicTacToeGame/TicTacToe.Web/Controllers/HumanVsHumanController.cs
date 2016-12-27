namespace TicTacToe.Web.Controllers
{
    using System.Web.Mvc;
    using System.Collections.Generic;
    using Models.HumanVsHuman.NewGame.InputModels;
    using FrameworkExtentions.Filters.ActionFilters;
    using Constants;
    using Views.ViewConstants;
    
    [CheckIfLoggedInFilter]
    public class HumanVsHumanController : Controller
    {
        [HttpGet]
        public ActionResult NewGame()
        {
            NewGameInputModel viewModel = new NewGameInputModel
            {
                Players = new List<string>() { this.User.Identity.Name, HumanVsHumanConstants.TheOtherGuy },
                OponentName = HumanVsHumanConstants.TheOtherGuy
            };

            return View(ViewConstants.NewGameView, viewModel);
        }
    }
}