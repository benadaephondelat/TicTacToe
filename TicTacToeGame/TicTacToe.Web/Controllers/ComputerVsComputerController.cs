namespace TicTacToe.Web.Controllers
{
    using System.Web.Mvc;
    using System.Collections.Generic;
    using ServiceLayer.Interfaces;
    using FrameworkExtentions.ModelBinders;
    using FrameworkExtentions.Filters.Security;
    using FrameworkExtentions.Filters.ActionFilters;
    using TicTacToe.Models;
    using TicTacToeCommon.Constants;
    using Models.HumanVsHuman.ViewModels;
    using Models.ComputerVsComputer.InputModels;
    using Models.ComputerVsComputer.ViewModels;
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
        public JsonResult GetOponentsDropdown()
        {
            JsonResult result = new JsonResult();

            result.Data = new SelectList(base.GetComputersUsernames());

            return result;
        }
    }
}