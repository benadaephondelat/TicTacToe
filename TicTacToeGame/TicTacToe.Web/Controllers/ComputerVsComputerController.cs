namespace TicTacToe.Web.Controllers
{
    using System.Web.Mvc;
    using System.Collections.Generic;
    using TicTacToe.Models;
    using TicTacToe.Models.Enums;
    using ServiceLayer.Interfaces;
    using FrameworkExtentions.ModelBinders;
    using FrameworkExtentions.Filters.Security;
    using FrameworkExtentions.Filters.ActionFilters;
    using Models.ComputerVsComputer.InputModels;
    using Models.ComputerVsComputer.ViewModels;
    using Models.Common.InputModels;
    using Models.Common.ViewModels;
    using Views.ViewConstants;
    using AutoMapper;

    [CheckIfLoggedInFilter]
    public class ComputerVsComputerController : BaseController
    {
        private readonly ITicTacToeGameService ticTacToeGameService;

        public ComputerVsComputerController()
        {
        }

        public ComputerVsComputerController(ITicTacToeGameService ticTacToeGameService)
        {
            this.ticTacToeGameService = ticTacToeGameService;
        }

        [HttpGet]
        public ActionResult NewGame()
        {
            NewComputerVsComputerGameViewModel model = new NewComputerVsComputerGameViewModel()
            {
                Sides = base.GetComputersUsernames(),
                Computers = this.GetComputersUsernames()
            };

            return View(ViewConstants.NewGameView, model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        [CheckModelStateAjax]
        public ActionResult NewGame([ModelBinder(typeof(NewComputerVsComputerGameModelBinder))]NewComputerVsComputerGameInputModel inputModel)
        {
            string currentUserName = base.CurrentUserName();

            Game game = this.ticTacToeGameService.CreateNewComputerVsComputerGame(currentUserName, inputModel.StartingFirstUsername, inputModel.OponentUsername);

            int computerMove = this.ticTacToeGameService.GetComputerMove(game.Id);

            this.ticTacToeGameService.PlaceTurn(game.Id, computerMove, currentUserName);
            
            GameViewModel viewModel = new GameViewModel()
            {
                GameInfo = Mapper.Map<GameInfoViewModel>(game),
                GameTiles = Mapper.Map<IEnumerable<TileViewModel>>(game.Tiles)
            };

            return PartialView(ViewConstants.ComputerVsComputerGame, viewModel);
        }

        [HttpPost, ValidateAntiForgeryTokenAjax]
        [CheckModelStateAjax]
        public ActionResult PlaceComputerTurn([Bind(Exclude = "TileIndex")]PlaceTurnInputModel model)
        {
            string currentUsername = base.CurrentUserName();

            this.PlaceComputerTurn(model.GameId, currentUsername);

            this.ticTacToeGameService.CheckGameForOutcome(model.GameId);

            Game game = this.ticTacToeGameService.GetGameById(model.GameId);

            if (game.IsFinished)
            {
                return RedirectToAction(ViewConstants.FinishedGame, ViewConstants.ComputerVsComputerController, new { model.GameId });
            }

            GameViewModel viewModel = new GameViewModel()
            {
                GameInfo = Mapper.Map<GameInfoViewModel>(game),
                GameTiles = Mapper.Map<IEnumerable<TileViewModel>>(game.Tiles)
            };

            return PartialView(ViewConstants.ComputerVsComputerGame, viewModel);
        }

        public ActionResult FinishedGame(int gameId)
        {
            Game game = this.ticTacToeGameService.GetGameById(gameId);

            FinishedGameViewModel viewModel = new FinishedGameViewModel()
            {
                GameInfo = Mapper.Map<FinishedGameInfoViewModel>(game),
                GameTiles = Mapper.Map<IEnumerable<TileViewModel>>(game.Tiles)
            };

            return PartialView(ViewConstants.FinishedComputerVsComputerGame, viewModel);
        }


        [HttpPost, ValidateAntiForgeryTokenAjax]
        public ActionResult ReplayGame()
        {
            string currentUsername = base.CurrentUserName();

            Game game = this.ticTacToeGameService.RecreatePreviousGame(currentUsername, GameMode.ComputerVsComputer);

            this.PlaceComputerTurn(game.Id, currentUsername);

            GameViewModel viewModel = new GameViewModel()
            {
                GameInfo = Mapper.Map<GameInfoViewModel>(game),
                GameTiles = Mapper.Map<IEnumerable<TileViewModel>>(game.Tiles)
            };

            return PartialView(ViewConstants.ComputerVsComputerGame, viewModel);
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

            IEnumerable<Game> unfinishedGames = this.ticTacToeGameService.GetAllUnfinishedGames(currentUsername, GameMode.ComputerVsComputer);

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

            return PartialView(ViewConstants.ComputerVsComputerGame, viewModel);
        }

        [HttpPost, ValidateAntiForgeryTokenAjax]
        public JsonResult GetOponentsDropdown()
        {
            JsonResult result = new JsonResult();

            result.Data = new SelectList(base.GetComputersUsernames());

            return result;
        }

        /// <summary>
        /// Places a computer turn on a Game
        /// </summary>
        /// <param name="gameId">Game.Id</param>
        /// <param name="currentUsername">Username of the current user.</param>
        private void PlaceComputerTurn(int gameId, string currentUsername)
        {
            int computerMoveTileIndex = this.ticTacToeGameService.GetComputerMove(gameId);

            this.ticTacToeGameService.PlaceTurn(gameId, computerMoveTileIndex, currentUsername);
        }
    }
}