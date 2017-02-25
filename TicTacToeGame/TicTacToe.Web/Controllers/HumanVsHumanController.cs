﻿namespace TicTacToe.Web.Controllers
{
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
    using static Views.ViewConstants.ViewConstants;

    [CheckIfLoggedInFilter]
    public class HumanVsHumanController : BaseController
    {
        private readonly ITicTacToeGameService ticTacToeGameService;

        public HumanVsHumanController()
        {
        }

        public HumanVsHumanController(ITicTacToeGameService ticTacToeGameService)
        {
            this.ticTacToeGameService = ticTacToeGameService;
        }

        [HttpGet]
        public ActionResult NewGame()
        {
            NewGameInputModel inputModel = new NewGameInputModel()
            {
                Players = this.GetDefaultPlayersList(),
            };

            return View(NewGameView, inputModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        [CheckModelStateFilter]
        public ActionResult NewGame(NewGameInputModel inputModel)
        {
            string homeSideUserName = inputModel.Players[0];

            string currentUserName = base.CurrentUserName();
            
            Game game = ticTacToeGameService.CreateNewGame(homeSideUserName, currentUserName);

            GameViewModel viewModel = new GameViewModel()
            {
                GameInfo = Mapper.Map<GameInfoViewModel>(game),
                GameTiles = Mapper.Map<IEnumerable<TileViewModel>>(game.Tiles)
            };

            return PartialView(HumanVsHumanGame, viewModel);
        }

        [HttpPost, ValidateAntiForgeryTokenAjax]
        public ActionResult ReplayGame()
        {
            string currentUsername = base.CurrentUserName();

            Game game = ticTacToeGameService.RecreatePreviousGame(currentUsername);

            GameViewModel viewModel = new GameViewModel()
            {
                GameInfo = Mapper.Map<GameInfoViewModel>(game),
                GameTiles = Mapper.Map<IEnumerable<TileViewModel>>(game.Tiles)
            };

            return PartialView(HumanVsHumanGame, viewModel);
        }
        
        [HttpPost, ValidateAntiForgeryTokenAjax]
        [CheckModelStateAjax]
        public ActionResult PlaceTurn(PlaceTurnInputModel model)
        {
            this.ticTacToeGameService.PlaceTurn(model.GameId, model.TileIndex, base.CurrentUserName());

            Game game = this.ticTacToeGameService.GetGameById(model.GameId);

            this.ticTacToeGameService.CheckGameForOutcome(game.Id);

            if (game.IsFinished)
            {
                return RedirectToAction("FinishedGame", new { @gameId = game.Id });
            }

            GameViewModel viewModel = new GameViewModel()
            {
                GameInfo = Mapper.Map<GameInfoViewModel>(game),
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
            string currentUsername = base.CurrentUserName();

            IEnumerable<Game> unfinishedGames = this.ticTacToeGameService.GetAllUnfinishedGames(currentUsername);

            IEnumerable<LoadGameGridViewModel> result = Mapper.Map<IEnumerable<LoadGameGridViewModel>>(unfinishedGames);

            return PartialView(LoadGameGridPartialView, result);
        }

        [HttpPost, ValidateAntiForgeryTokenAjax]
        public ActionResult LoadGame(int gameId)
        {
            Game game = this.ticTacToeGameService.GetGameById(gameId);

            GameViewModel viewModel = new GameViewModel()
            {
                GameInfo = Mapper.Map<GameInfoViewModel>(game),
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
        private List<string> GetDefaultPlayersList()
        {
            List<string> humanVsHumanDefaultPlayers = new List<string>()
            {
                this.CurrentUserName(),
                HumanVsHumanConstants.OponentUsername
            };

            return humanVsHumanDefaultPlayers;
        }
    }
}