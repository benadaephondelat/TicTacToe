namespace TicTacToe.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using System.Collections.Generic;
    using ServiceLayer.TicTacToeGameService;
    using TicTacToe.Models;
    using Constants;
    using Views.ViewConstants;
    using FrameworkExtentions.Filters.ActionFilters;
    using Models.HumanVsHuman.NewGame.ViewModels;
    using Models.HumanVsHuman.NewGame.InputModels;
    using Models.Game.ViewModels;
    using Models.Tiles.ViewModels;
    using AutoMapper;
    using Microsoft.AspNet.Identity;

    [CheckIfLoggedInFilter]
    public class HumanVsHumanController : Controller
    {
        public ITicTacToeGameService ticTacToeGameService;

        public Func<string> GetCurrentUserName;

        public HumanVsHumanController()
        {
        }

        public HumanVsHumanController(ITicTacToeGameService ticTacToeGameService)
        {
            this.ticTacToeGameService = ticTacToeGameService;

            this.GetCurrentUserName = () => User.Identity.GetUserName();
        }
        
        [HttpGet]
        public ActionResult NewGame()
        {
            NewHumanVsHumanGameInputModel inputModel = new NewHumanVsHumanGameInputModel()
            {
                Players = GetDefaultHumanVsHumanPlayersList(),
            };

            return View(ViewConstants.NewGameView, inputModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        [CheckModelStateFilter]
        public ActionResult NewGame(NewHumanVsHumanGameInputModel inputModel)
        {
            string homeSideUserName = inputModel.Players[0];

            string currentUserName = GetCurrentUserName();
            
            Game game = ticTacToeGameService.CreateNewHumanVsHumanGame(homeSideUserName, currentUserName);

            NewGameViewModel viewModel = new NewGameViewModel()
            {
                GameInfo = Mapper.Map<NewGameInfoModel>(game),
                GameTiles = Mapper.Map<IEnumerable<TileViewModel>>(game.Tiles)
            };

            return PartialView(ViewConstants.NewGamePartialView, viewModel);
        }

        /// <summary>
        /// Returns a list containing the current user's Id and the default oponent's Id
        /// </summary>
        /// <returns>List<string></string></returns>
        private List<string> GetDefaultHumanVsHumanPlayersList()
        {
            List<string> humanVsHumanDefaultPlayers = new List<string>()
            {
                this.GetCurrentUserName(),
                HumanVsHumanConstants.HumanVsHumanOponentUsername
            };

            return humanVsHumanDefaultPlayers;
        }
    }
}