namespace TicTacToe.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using System.Collections.Generic;
    using TicTacToe.Models;
    using ServiceLayer.TicTacToeGameService;
    using Constants;
    using FrameworkExtentions.Filters.Security;
    using FrameworkExtentions.Filters.ActionFilters;
    using Models.HumanVsHuman.InputModels;
    using Models.HumanVsHuman.ViewModels;
    using AutoMapper;
    using Microsoft.AspNet.Identity;
    using static Views.ViewConstants.ViewConstants;

    [CheckIfLoggedInFilter]
    public class HumanVsHumanController : Controller
    {
        public Func<string> CurrentUserName;

        public HumanVsHumanController()
        {
        }

        public HumanVsHumanController(ITicTacToeGameService ticTacToeGameService)
        {
            this.ticTacToeGameService = ticTacToeGameService;

            this.CurrentUserName = this.GetUserIdentityUsername;
        }

        private readonly ITicTacToeGameService ticTacToeGameService;

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

            string currentUserName = this.CurrentUserName();
            
            Game game = ticTacToeGameService.CreateNewHumanVsHumanGame(homeSideUserName, currentUserName);

            HumanVsHumanGameViewModel viewModel = new HumanVsHumanGameViewModel()
            {
                GameInfo = Mapper.Map<HumanVsHumanGameInfoModel>(game),
                GameTiles = Mapper.Map<IEnumerable<TileViewModel>>(game.Tiles)
            };

            return PartialView(HumanVsHumanGame, viewModel);
        }

        [HttpPost, ValidateAntiForgeryTokenAjax]
        public ActionResult ReplayGame()
        {
            string currentUsername = this.CurrentUserName();

            Game game = ticTacToeGameService.RecreatePreviousGame(currentUsername);

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
            this.ticTacToeGameService.PlaceTurn(model.GameId, model.TileIndex, this.CurrentUserName());

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

        [HttpGet]
        public ActionResult LoadGame()
        {
            return View(LoadGameView);
        }

        [HttpGet]
        public ActionResult LoadGameGrid()
        {
            string currentUsername = this.CurrentUserName();

            IEnumerable<Game> unfinishedGames = this.ticTacToeGameService.GetAllUnfinishedGames(currentUsername);

            IEnumerable<LoadGameGridViewModel> result = Mapper.Map<IEnumerable<LoadGameGridViewModel>>(unfinishedGames);

            return PartialView(LoadGameGridPartialView, result);
        }

        [HttpPost, ValidateAntiForgeryTokenAjax]
        public ActionResult LoadGame(int gameId)
        {
            Game game = this.ticTacToeGameService.GetGameById(gameId);

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
        /// Returns a list containing the current user's Id and the default oponent's Id
        /// </summary>
        /// <returns>List<string></string></returns>
        private List<string> GetDefaultHumanVsHumanPlayersList()
        {
            List<string> humanVsHumanDefaultPlayers = new List<string>()
            {
                this.CurrentUserName(),
                HumanVsHumanConstants.HumanVsHumanOponentUsername
            };

            return humanVsHumanDefaultPlayers;
        }
        
        /// <summary>
        /// Returns the current user's username
        /// </summary>
        /// <returns>string</returns>
        private string GetUserIdentityUsername()
        {
            string result = this.User.Identity.GetUserName();

            return result;
        }
    }
}