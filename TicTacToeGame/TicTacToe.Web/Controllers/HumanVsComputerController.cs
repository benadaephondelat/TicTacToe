namespace TicTacToe.Web.Controllers
{
    using System.Web.Mvc;
    using System.Collections.Generic;
    using ServiceLayer.TicTacToeGameService;
    using TicTacToeCommon.Constants;
    using TicTacToe.Models;
    using Models.HumanVsHuman.InputModels;
    using Models.HumanVsHuman.ViewModels;
    using AutoMapper;
    using FrameworkExtentions.Filters.Security;
    using FrameworkExtentions.Filters.ActionFilters;
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

            if (this.ComputerIsStartingFirst(game.ApplicationUser.UserName))
            {
                this.PlaceComputerTurn(game.Id, currentUserName);
            }

            GameViewModel viewModel = new GameViewModel()
            {
                GameInfo = Mapper.Map<GameInfoViewModel>(game),
                GameTiles = Mapper.Map<IEnumerable<TileViewModel>>(game.Tiles)
            };

            return PartialView(HumanVsComputerGame, viewModel);
        }

        [HttpPost, ValidateAntiForgeryTokenAjax]
        [CheckModelStateAjax]
        public ActionResult PlaceTurn(PlaceTurnInputModel model)
        {
            string currentUsername = base.CurrentUserName();

            this.PlaceHumanPlayerTurn(model.GameId, model.TileIndex, currentUsername);

            this.PlaceComputerTurn(model.GameId, currentUsername);

            Game game = this.ticTacToeGameService.GetGameById(model.GameId);

            if (game.IsFinished)
            {
                return RedirectToAction("FinishedGame", "HumanVsHuman", new { @gameId = game.Id });
            }

            GameViewModel viewModel = new GameViewModel()
            {
                GameInfo = Mapper.Map<GameInfoViewModel>(game),
                GameTiles = Mapper.Map<IEnumerable<TileViewModel>>(game.Tiles)
            };

            return PartialView(HumanVsComputerGame, viewModel);
        }

        /// <summary>
        /// Places a computer turn on a Game and checks the game for outcome
        /// </summary>
        /// <param name="gameId">Game.Id</param>
        /// <param name="currentUsername">Username of the current user.</param>
        private void PlaceComputerTurn(int gameId, string currentUsername)
        {
            int computerMoveTileIndex = this.ticTacToeGameService.GetComputerMove(gameId);

            this.ticTacToeGameService.PlaceTurn(gameId, computerMoveTileIndex, currentUsername);

            //TODO REMOVE THAT CHECK FROM THIS FUNCTION
            this.ticTacToeGameService.CheckGameForOutcome(gameId);
        }

        /// <summary>
        /// Places a human player turn on a Game and checks the game for outcome
        /// </summary>
        /// <param name="gameId">Game.Id</param>
        /// <param name="tileIndex">Position to place the turn</param>
        /// <param name="currentUsername">Username of the current user.</param>
        private void PlaceHumanPlayerTurn(int gameId, int tileIndex, string currentUsername)
        {
            this.ticTacToeGameService.PlaceTurn(gameId, tileIndex, currentUsername);

            //TODO REMOVE THIS CALL FROM THIS FUNCTION
            this.ticTacToeGameService.CheckGameForOutcome(gameId);
        }

        /// <summary>
        /// Checks if the computer is starting first
        /// </summary>
        /// <param name="homesideUsername">Game.ApplicationUser.Username field</param>
        /// <returns>bool</returns>
        private bool ComputerIsStartingFirst(string homesideUsername)
        {
            if (homesideUsername == UserConstants.ComputerUsername)
            {
                return true;
            }

            return false;
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
                UserConstants.ComputerUsername
            };

            return humanVsHumanDefaultPlayers;
        }
    }
}