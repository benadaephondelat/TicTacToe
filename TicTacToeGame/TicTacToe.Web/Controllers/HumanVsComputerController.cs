namespace TicTacToe.Web.Controllers
{
    using System.Web.Mvc;
    using System.Collections.Generic;
    using ServiceLayer.TicTacToeGameService;
    using TicTacToe.Models;
    using Models.HumanVsHuman.InputModels;
    using Models.HumanVsHuman.ViewModels;
    using FrameworkExtentions.Filters.ActionFilters;
    using AutoMapper;
    using static Views.ViewConstants.ViewConstants;

    [CheckIfLoggedInFilter]
    public class HumanVsComputerController : BaseController
    {
        private readonly ITicTacToeGameService ticTacToeGameService;

        public HumanVsComputerController()
        {
        }

        public HumanVsComputerController(ITicTacToeGameService ticTacToeGameService)
        {
            this.ticTacToeGameService = ticTacToeGameService;
        }

        [HttpGet]
        public ActionResult NewGame()
        {
            NewGameInputModel inputModel = new NewGameInputModel()
            {
                Players = base.GetDefaultPlayersList(),
            };

            return View(NewGameView, inputModel);
        }
    }
}