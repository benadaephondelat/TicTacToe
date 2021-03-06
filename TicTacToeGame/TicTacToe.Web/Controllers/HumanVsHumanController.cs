﻿namespace TicTacToe.Web.Controllers
{
    using System.Web.Mvc;
    using System.Collections.Generic;
    using ServiceLayer.Interfaces;
    using TicTacToe.Models;
    using TicTacToe.Models.Enums;
    using FrameworkExtentions.ModelBinders;
    using FrameworkExtentions.Filters.Security;
    using FrameworkExtentions.Filters.ActionFilters;
    using Models.HumanVsHuman.InputModels;
    using Models.HumanVsHuman.ViewModels;
    using Models.Common.InputModels;
    using Models.Common.ViewModels;
    using Views.ViewConstants;
    using Constants;
    using AutoMapper;

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
            NewHumanVsHumanGameViewModel inputModel = new NewHumanVsHumanGameViewModel()
            {
                Players = this.GetDefaultPlayersList(),
            };

            return View(ViewConstants.NewGameView, inputModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        [CheckModelStateFilter]
        public ActionResult NewGame([ModelBinder(typeof(NewHumanVsHumanGameModelBinder))]NewHumanVsHumanGameInputModel inputModel)
        {
            string startingFirstUsername = inputModel.StartingFirstUsername;

            string currentUserName = base.CurrentUserName();
            
            Game game = this.ticTacToeGameService.CreateNewGame(startingFirstUsername, currentUserName);

            GameViewModel viewModel = new GameViewModel()
            {
                GameInfo = Mapper.Map<GameInfoViewModel>(game),
                GameTiles = Mapper.Map<IEnumerable<TileViewModel>>(game.Tiles)
            };

            return PartialView(ViewConstants.HumanVsHumanGame, viewModel);
        }

        [HttpPost, ValidateAntiForgeryTokenAjax]
        public ActionResult ReplayGame()
        {
            string currentUsername = base.CurrentUserName();

            Game game = this.ticTacToeGameService.RecreatePreviousGame(currentUsername, GameMode.HumanVsHuman);

            GameViewModel viewModel = new GameViewModel()
            {
                GameInfo = Mapper.Map<GameInfoViewModel>(game),
                GameTiles = Mapper.Map<IEnumerable<TileViewModel>>(game.Tiles)
            };

            return PartialView(ViewConstants.HumanVsHumanGame, viewModel);
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
                return RedirectToAction(ViewConstants.FinishedGame, new { @gameId = game.Id });
            }

            GameViewModel viewModel = new GameViewModel()
            {
                GameInfo = Mapper.Map<GameInfoViewModel>(game),
                GameTiles = Mapper.Map<IEnumerable<TileViewModel>>(game.Tiles)
            };

            return PartialView(ViewConstants.HumanVsHumanGame, viewModel);
        }

        [HttpGet]
        public ActionResult LoadGame()
        {
            return View(ViewConstants.LoadGameView);
        }

        [HttpGet]
        public ActionResult LoadGameGrid()
        {
            string currentUsername = base.CurrentUserName();

            IEnumerable<Game> unfinishedGames = this.ticTacToeGameService.GetAllUnfinishedGames(currentUsername, GameMode.HumanVsHuman);

            IEnumerable<LoadGameGridViewModel> result = Mapper.Map<IEnumerable<LoadGameGridViewModel>>(unfinishedGames);

            return PartialView(ViewConstants.LoadGameGridPartialView, result);
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

            return PartialView(ViewConstants.HumanVsHumanGame, viewModel);
        }

        public ActionResult FinishedGame(int gameId)
        {
            Game game = this.ticTacToeGameService.GetGameById(gameId);

            FinishedGameViewModel viewModel = new FinishedGameViewModel()
            {
                GameInfo = Mapper.Map<FinishedGameInfoViewModel>(game),
                GameTiles = Mapper.Map<IEnumerable<TileViewModel>>(game.Tiles)
            };

            return PartialView(ViewConstants.FinishedHumanVsHumanGame, viewModel);
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