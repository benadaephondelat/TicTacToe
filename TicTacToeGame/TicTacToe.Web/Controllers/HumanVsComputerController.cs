namespace TicTacToe.Web.Controllers
{
    using System.Web.Mvc;
    using System.Collections.Generic;
    using TicTacToe.Models.Enums;
    using TicTacToe.Models;
    using TicTacToeCommon.Constants;
    using ServiceLayer.Interfaces;
    using FrameworkExtentions.ModelBinders;
    using FrameworkExtentions.Filters.Security;
    using FrameworkExtentions.Filters.ActionFilters;
    using Models.HumanVsComputer.InputModels;
    using Models.HumanVsComputer.ViewModels;
    using Models.Common.InputModels;
    using Models.Common.ViewModels;
    using Views.ViewConstants;
    using AutoMapper;

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
            NewHumanVsComputerGameViewModel viewModel = new NewHumanVsComputerGameViewModel()
            {
                Sides = this.GetAllPossibleSides(),
                Computers = base.GetComputersUsernames()
            };

            return View(ViewConstants.NewGameView, viewModel);
        }
        
        [HttpPost, ValidateAntiForgeryToken]
        [CheckModelStateAjax]
        public ActionResult NewGame([ModelBinder(typeof(NewHumanVsComputerGameModelBinder))]NewHumanVsComputerInputModel inputModel)
        {
            string currentUserName = base.CurrentUserName();

            bool isHumanPlayerFirst = this.HumanIsStartingFirst(currentUserName, inputModel.StartingFirstUsername);

            string computerName = this.GetComputerName(inputModel.StartingFirstUsername, inputModel.OponentUsername);

            Game game = this.ticTacToeGameService.CreateNewHumanVsComputerGame(currentUserName, computerName, isHumanPlayerFirst);

            if (this.ComputerIsStartingFirst(game.ApplicationUser.UserName))
            {
                this.PlaceComputerTurn(game.Id, currentUserName);
            }

            GameViewModel viewModel = new GameViewModel()
            {
                GameInfo = Mapper.Map<GameInfoViewModel>(game),
                GameTiles = Mapper.Map<IEnumerable<TileViewModel>>(game.Tiles)
            };

            return PartialView(ViewConstants.HumanVsComputerGame, viewModel);
        }

        [HttpPost, ValidateAntiForgeryTokenAjax]
        public JsonResult GetOponentsDropdown(string startingFirst)
        {
            string currentUser = base.CurrentUserName();

            if (startingFirst == currentUser)
            {
                return new JsonResult { Data = new SelectList(base.GetComputersUsernames()) };
            }

            return new JsonResult { Data = new SelectList(new List<string> { currentUser }) };
        }

        [HttpPost, ValidateAntiForgeryTokenAjax]
        [CheckModelStateAjax]
        public ActionResult PlaceTurn(PlaceTurnInputModel model)
        {
            string currentUsername = base.CurrentUserName();

            this.PlaceHumanPlayerTurn(model.GameId, model.TileIndex, currentUsername);

            this.ticTacToeGameService.CheckGameForOutcome(model.GameId);

            Game game = this.ticTacToeGameService.GetGameById(model.GameId);

            if (game.IsFinished)
            {
                return RedirectToAction(ViewConstants.FinishedGame, ViewConstants.HumanVsComputerController, new { model.GameId });
            }
            
            GameViewModel viewModel = new GameViewModel()
            {
                GameInfo = Mapper.Map<GameInfoViewModel>(game),
                GameTiles = Mapper.Map<IEnumerable<TileViewModel>>(game.Tiles)
            };

            return PartialView(ViewConstants.HumanVsComputerGame, viewModel);
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
                return RedirectToAction(ViewConstants.FinishedGame, ViewConstants.HumanVsComputerController, new { model.GameId });
            }

            GameViewModel viewModel = new GameViewModel()
            {
                GameInfo = Mapper.Map<GameInfoViewModel>(game),
                GameTiles = Mapper.Map<IEnumerable<TileViewModel>>(game.Tiles)
            };

            return PartialView(ViewConstants.HumanVsComputerGame, viewModel);
        }

        public ActionResult FinishedGame(int gameId)
        {
            Game game = this.ticTacToeGameService.GetGameById(gameId);

            FinishedGameViewModel viewModel = new FinishedGameViewModel()
            {
                GameInfo = Mapper.Map<FinishedGameInfoViewModel>(game),
                GameTiles = Mapper.Map<IEnumerable<TileViewModel>>(game.Tiles)
            };

            return PartialView(ViewConstants.FinishedComputerVsHumanGame, viewModel);
        }

        [HttpPost, ValidateAntiForgeryTokenAjax]
        public ActionResult ReplayGame()
        {
            string currentUsername = base.CurrentUserName();

            Game game = ticTacToeGameService.RecreatePreviousGame(currentUsername, GameMode.HumanVsComputer);

            if (this.ComputerIsStartingFirst(game.ApplicationUser.UserName))
            {
                this.PlaceComputerTurn(game.Id, currentUsername);
            }

            GameViewModel viewModel = new GameViewModel()
            {
                GameInfo = Mapper.Map<GameInfoViewModel>(game),
                GameTiles = Mapper.Map<IEnumerable<TileViewModel>>(game.Tiles)
            };

            return PartialView(ViewConstants.HumanVsComputerGame, viewModel);
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

            IEnumerable<Game> unfinishedGames = this.ticTacToeGameService.GetAllUnfinishedGames(currentUsername, GameMode.HumanVsComputer);

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

            return PartialView(ViewConstants.HumanVsComputerGame, viewModel);
        }

        /// <summary>
        /// Places a human player turn on a Game
        /// </summary>
        /// <param name="gameId">Game.Id</param>
        /// <param name="tileIndex">Position to place the turn</param>
        /// <param name="currentUsername">Username of the current user.</param>
        private void PlaceHumanPlayerTurn(int gameId, int tileIndex, string currentUsername)
        {
            this.ticTacToeGameService.PlaceTurn(gameId, tileIndex, currentUsername);
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

        /// <summary>
        /// Checks if the computer is starting first
        /// </summary>
        /// <param name="homesideUsername">Game.ApplicationUser.Username field</param>
        /// <returns>bool</returns>
        private bool ComputerIsStartingFirst(string homesideUsername)
        {
            if (homesideUsername == UserConstants.ComputerUsername || homesideUsername == UserConstants.OtherComputerUsername)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns the name of the computer oponent
        /// </summary>
        /// <param name="startingFirst">who is starting first</param>
        /// <param name="oponentName">the oponent's name</param>
        /// <returns>string</returns>
        private string GetComputerName(string startingFirst, string oponentName)
        {
            if (startingFirst.Equals(base.CurrentUserName()))
            {
                return oponentName;
            }

            return startingFirst;
        }

        /// <summary>
        /// Checks if the human is starting first
        /// </summary>
        /// <param name="currentUser">username of the current user</param>
        /// <param name="startingFirst">who is starting first</param>
        /// <returns>bool</returns>
        private bool HumanIsStartingFirst(string currentUser, string startingFirst)
        {
            bool isHumanFirst = currentUser.Equals(startingFirst);

            return isHumanFirst;
        }

        /// <summary>
        /// Returns a list containing the current user's username and both computers
        /// </summary>
        /// <returns>List<string></string></returns>
        private List<string> GetAllPossibleSides()
        {
            List<string> humanVsComputerDefaultPlayers = new List<string>()
            {
                this.CurrentUserName(),
                UserConstants.ComputerUsername,
                UserConstants.OtherComputerUsername
            };

            return humanVsComputerDefaultPlayers;
        }
    }
}