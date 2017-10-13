namespace TicTacToe.Web.Controllers
{
    using System.Web.Mvc;
    using System.Collections.Generic;
    using ServiceLayer.TicTacToeGameService;
    using FrameworkExtentions.Filters.ActionFilters;
    using TicTacToe.Models;
    using Models.HumanVsHuman.ViewModels;
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

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult NewGame()
        {
            string currentUserName = base.CurrentUserName();

            Game game = this.ticTacToeGameService.CreateNewComputerVsComputerGame(currentUserName);

            GameViewModel viewModel = new GameViewModel()
            {
                GameInfo = Mapper.Map<GameInfoViewModel>(game),
                GameTiles = Mapper.Map<IEnumerable<TileViewModel>>(game.Tiles)
            };

            return PartialView(ViewConstants.ComputerVsComputerGame, viewModel);
        }
    }
}