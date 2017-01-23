namespace TicTacToe.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using System.Collections.Generic;
    using TicTacToe.Models;
    using ServiceLayer.TicTacToeGameService;
    using Constants;
    using Models.Game.InputModels;
    using Models.Game.ViewModels;
    using Models.Tiles.ViewModels;
    using FrameworkExtentions.Filters.Security;
    using FrameworkExtentions.Filters.ActionFilters;
    using Models.HumanVsHuman.PlaceTurn.InputModels;
    using AutoMapper;
    using Microsoft.AspNet.Identity;
    using static Views.ViewConstants.ViewConstants;

    [CheckIfLoggedInFilter]
    public class HumanVsHumanController : Controller
    {
        private ITicTacToeGameService ticTacToeGameService;

        public Func<string> GetCurrentUserName;

        public HumanVsHumanController()
        {
        }

        public HumanVsHumanController(ITicTacToeGameService ticTacToeGameService)
        {
            this.ticTacToeGameService = ticTacToeGameService;

            this.GetCurrentUserName = this.CurrentUserName;
        }

        [HttpGet]
        public ActionResult NewGame()
        {
            NewHumanVsHumanGameInputModel inputModel = new NewHumanVsHumanGameInputModel()
            {
                Players = GetDefaultHumanVsHumanPlayersList(),
            };

            return View(NewGameView, inputModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        [CheckModelStateFilter]
        public ActionResult NewGame(NewHumanVsHumanGameInputModel inputModel)
        {
            string homeSideUserName = inputModel.Players[0];

            string currentUserName = GetCurrentUserName();
            
            Game game = ticTacToeGameService.CreateNewHumanVsHumanGame(homeSideUserName, currentUserName);

            HumanVsHumanGameViewModel viewModel = new HumanVsHumanGameViewModel()
            {
                GameInfo = Mapper.Map<HumanVsHumanGameInfoModel>(game),
                GameTiles = Mapper.Map<IEnumerable<TileViewModel>>(game.Tiles)
            };

            return PartialView(HumanVsHumanGame, viewModel);
        }

        [HttpPost, ValidateAntiForgeryTokenAjax]
        [CheckModelStateAjax]
        public ActionResult PlaceTurn(PlaceTurnInputModel model)
        {
            this.ticTacToeGameService.PlaceTurn(model.GameId, model.TileIndex, this.GetCurrentUserName());

            Game game = this.ticTacToeGameService.GetGameById(model.GameId);

            this.ticTacToeGameService.CheckGameForOutcome(game.Id);

            if (game.IsFinished)
            {
                return RedirectToAction("FinishedGame", new { @gameId = game.Id });
            }

            HumanVsHumanGameViewModel viewModel = new HumanVsHumanGameViewModel()
            {
                GameInfo = Mapper.Map<HumanVsHumanGameInfoModel>(game),
                GameTiles = Mapper.Map<IEnumerable<TileViewModel>>(game.Tiles)
            };

            return PartialView(HumanVsHumanGame, viewModel);
        }

        public ActionResult FinishedGame(int gameId)
        {
            Game game = this.ticTacToeGameService.GetGameById(gameId);

            FinishedGameViewModel viewModel = new FinishedGameViewModel()
            {
                GameInfo = Mapper.Map<FinishedGameInfoViewModel>(game),
                GameTiles = Mapper.Map<IEnumerable<TileViewModel>>(game.Tiles)
            };

            return PartialView(FinishedHumanVsHumanGame, viewModel);
        }

        /// <summary>
        /// Returns the current user's username
        /// </summary>
        /// <returns>string</returns>
        private string CurrentUserName()
        {
            string result = this.User.Identity.GetUserName();

            return result;
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