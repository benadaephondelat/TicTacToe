namespace TicTacToe.Web.Tests.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Reflection;
    using System.Collections.Generic;
    using ServiceLayer.TicTacToeGameService;
    using Models.HumanVsHuman.InputModels;
    using Constants;
    using Web.Controllers;
    using Moq;
    using MockHelpers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TicTacToeCommon.Constants;
    using Models.HumanVsHuman.ViewModels;
    using ServiceLayer.Interfaces;

    [TestClass]
    public class HumanVsComputerControllerTests
    {
        private HumanVsComputerServiceLayerMockHelper mockHelper;

        [TestInitialize]
        public void Setup()
        {
            this.mockHelper = new HumanVsComputerServiceLayerMockHelper();
        }

        #region Controller Tests

        [TestMethod]
        public void HumanVsComputer_Controller_Should_Exist()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void HumanVsComputer_Controller_Should_Have_Empty_Constructor()
        {
            HumanVsComputerController controller = new HumanVsComputerController();

            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void HumanVsComputer_Controller_Should_Have_Private_Property_Named_TicTacToeGameService()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            bool result = controller.GetType()
                                    .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                    .Any(field => field.Name == "ticTacToeGameService");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void HumanVsComputer_Controller_Should_Have_Public_Property_Named_CurrentUserName()
        {
            BaseController controller = this.CreateHumanVsComputerControllerMock() as BaseController;

            bool result = controller.GetType()
                                    .GetFields(BindingFlags.Instance | BindingFlags.Public)
                                    .Any(field => field.Name == "CurrentUserName");

            Assert.IsTrue(result);
        }

        #endregion

        #region NewGame Tests

        [TestMethod]
        public void NewGame_Action_Should_Exist()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            Assert.AreEqual("NewGame", nameof(controller.NewGame));

            ActionResult newGameAsActionResult = controller.NewGame();

            Assert.IsNotNull(newGameAsActionResult);
        }

        [TestMethod]
        public void NewGame_Should_Return_View()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            ActionResult actionResult = controller.NewGame();

            Assert.IsInstanceOfType(actionResult, typeof(ViewResult));
        }

        [TestMethod]
        public void NewGame_Should_Return_View_Named_NewGame()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            ActionResult actionResult = controller.NewGame();

            ViewResult result = actionResult as ViewResult;

            Assert.IsNotNull(result);

            string expectedPartialViewName = "NewGame";

            Assert.AreEqual(expectedPartialViewName, result.ViewName);
        }

        [TestMethod]
        public void NewGame_Should_Pass_NewGameInputModel_To_The_View()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            ActionResult actionResult = controller.NewGame();

            ViewResult result = actionResult as ViewResult;

            Assert.IsNotNull(result);

            NewGameInputModel model = (NewGameInputModel)result.ViewData.Model;

            Assert.IsInstanceOfType(model, typeof(NewGameInputModel));
        }

        [TestMethod]
        public void NewGameInputModel_Should_Have_Property_Named_Players()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            ActionResult actionResult = controller.NewGame();

            ViewResult result = actionResult as ViewResult;

            Assert.IsNotNull(result);

            NewGameInputModel model = result.ViewData.Model as NewGameInputModel;

            Assert.IsNotNull(model);

            Assert.IsNotNull(model.Players);
        }

        [TestMethod]
        public void NewGameInputModel_Players_Property_Should_Be_A_List_Of_Strings()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            ActionResult actionResult = controller.NewGame();

            ViewResult result = actionResult as ViewResult;

            Assert.IsNotNull(result);

            NewGameInputModel model = (NewGameInputModel)result.ViewData.Model;

            Assert.IsInstanceOfType(model.Players, typeof(List<string>));
        }

        [TestMethod]
        public void NewGameInputModel_Players_Property_Should_Be_A_List_With_Three_Strings()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            ActionResult actionResult = controller.NewGame();

            ViewResult result = actionResult as ViewResult;

            Assert.IsNotNull(result);

            NewGameInputModel model = (NewGameInputModel)result.ViewData.Model;

            Assert.AreEqual(3, model.Players.Count);
        }

        [TestMethod]
        public void NewGameInputModel_Players_Property_Should_Contain_Valid_Strings_As_First_Second_And_Third_Parameters()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            ActionResult actionResult = controller.NewGame();

            ViewResult result = actionResult as ViewResult;

            Assert.IsNotNull(result);

            NewGameInputModel model = (NewGameInputModel)result.ViewData.Model;

            bool isFirstParameterNotValidString = string.IsNullOrWhiteSpace(model.Players[0]);

            Assert.IsFalse(isFirstParameterNotValidString);

            bool isSecondParameterNotValidString = string.IsNullOrWhiteSpace(model.Players[1]);

            Assert.IsFalse(isSecondParameterNotValidString);

            bool isThirdParameterNotValidString = string.IsNullOrWhiteSpace(model.Players[2]);

            Assert.IsFalse(isThirdParameterNotValidString);
        }

        [TestMethod]
        public void NewGameInputModel_Players_Property_Should_Contain_The_First_Computer_Username_As_Second_Parameter()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            ActionResult actionResult = controller.NewGame();

            ViewResult result = actionResult as ViewResult;

            Assert.IsNotNull(result);

            NewGameInputModel model = (NewGameInputModel)result.ViewData.Model;

            Assert.AreEqual(UserConstants.ComputerUsername, model.Players[1]);
        }

        [TestMethod]
        public void NewGameInputModel_Players_Property_Should_Contain_The_Second_Computer_Username_As_Second_Parameter()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            ActionResult actionResult = controller.NewGame();

            ViewResult result = actionResult as ViewResult;

            Assert.IsNotNull(result);

            NewGameInputModel model = (NewGameInputModel)result.ViewData.Model;

            Assert.AreEqual(UserConstants.OtherComputerUsername, model.Players[2]);
        }


        [TestMethod]
        public void NewGame_Post_Should_Exist_And_Accept_NewGameInputModel_As_A_Parameter()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            Type controllerType = controller.GetType();

            int methodsCount = controllerType.GetTypeInfo()
                                             .DeclaredMethods
                                             .Count(m => m.Name.Contains(nameof(controller.NewGame)) &&
                                                         m.ToString().Contains(nameof(NewGameInputModel)));

            Assert.AreEqual(1, methodsCount);
        }

        [TestMethod]
        public void NewGame_Post_Should_Return_PartialView()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            NewGameInputModel model = new NewGameInputModel()
            {
                Players = new List<string>()
                {
                    UserConstants.ComputerUsername
                }
            };

            ActionResult actionResult = controller.NewGame(model);

            Assert.IsInstanceOfType(actionResult, typeof(PartialViewResult));
        }

        [TestMethod]
        public void NewGame_Post_Should_Return_PartialView_Named__HumanVsComputerGame()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            NewGameInputModel model = new NewGameInputModel();

            model.Players = new List<string>()
            {
                UserConstants.ComputerUsername
            };

            ActionResult actionResult = controller.NewGame(model);

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            string actualPartialViewName = partialViewResult.ViewName;

            Assert.AreEqual("_HumanVsComputerGame", actualPartialViewName);
        }

        [TestMethod]
        public void NewGame_Post_Should_Return_GameViewModel_As_Model_To_The_View()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            NewGameInputModel model = new NewGameInputModel();

            model.Players = new List<string>()
            {
                UserConstants.ComputerUsername
            };

            ActionResult actionResult = controller.NewGame(model);

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            bool isCastValidCast = partialViewResult.Model is GameViewModel;

            Assert.IsTrue(isCastValidCast);
        }

        [TestMethod]
        public void NewGame_Post_GameViewModel_Properties_Should_Not_Be_Null()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            NewGameInputModel model = new NewGameInputModel();

            model.Players = new List<string>()
            {
                UserConstants.ComputerUsername
            };

            ActionResult actionResult = controller.NewGame(model);

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            GameViewModel result = partialViewResult.Model as GameViewModel;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.GameInfo);
            Assert.IsNotNull(result.GameTiles);
        }

        [TestMethod]
        public void NewGame_Post_If_Computer_Is_First_GameViewModel_Should_Contain_8_Empty_Tiles()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            NewGameInputModel model = new NewGameInputModel();

            model.Players = new List<string>()
            {
               UserConstants.ComputerUsername
            };

            ActionResult actionResult = controller.NewGame(model);

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            GameViewModel result = partialViewResult.Model as GameViewModel;

            Assert.IsNotNull(result);

            Assert.AreEqual(8, result.GameTiles.Count(t => t.IsEmpty));
        }

        [TestMethod]
        public void NewGame_Post_If_Other_Computer_Is_First_GameViewModel_Should_Contain_8_Empty_Tiles()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            NewGameInputModel model = new NewGameInputModel();

            model.Players = new List<string>()
            {
               UserConstants.OtherComputerUsername
            };

            ActionResult actionResult = controller.NewGame(model);

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            GameViewModel result = partialViewResult.Model as GameViewModel;

            Assert.IsNotNull(result);

            Assert.AreEqual(8, result.GameTiles.Count(t => t.IsEmpty));
        }

        [TestMethod]
        public void NewGame_Post_If_Computer_Is_First_GameViewModel_Should_Contain_1_Tile_With_Value_X()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            NewGameInputModel model = new NewGameInputModel();

            model.Players = new List<string>()
            {
               UserConstants.ComputerUsername
            };

            ActionResult actionResult = controller.NewGame(model);

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            GameViewModel result = partialViewResult.Model as GameViewModel;

            Assert.IsNotNull(result);

            Assert.AreEqual(1, result.GameTiles.Count(t => t.IsEmpty == false && t.Value == "X"));
        }

        [TestMethod]
        public void NewGame_Post_If_Other_Computer_Is_First_GameViewModel_Should_Contain_1_Tile_With_Value_X()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            NewGameInputModel model = new NewGameInputModel();

            model.Players = new List<string>()
            {
               UserConstants.OtherComputerUsername
            };

            ActionResult actionResult = controller.NewGame(model);

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            GameViewModel result = partialViewResult.Model as GameViewModel;

            Assert.IsNotNull(result);

            Assert.AreEqual(1, result.GameTiles.Count(t => t.IsEmpty == false && t.Value == "X"));
        }

        [TestMethod]
        public void NewGame_Post_If_Computer_Is_First_Game_Turns_Count_Shoud_Be_2()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            NewGameInputModel model = new NewGameInputModel();

            model.Players = new List<string>()
            {
               UserConstants.ComputerUsername
            };

            ActionResult actionResult = controller.NewGame(model);

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            GameViewModel result = partialViewResult.Model as GameViewModel;

            Assert.IsNotNull(result);

            Assert.AreEqual(2, result.GameInfo.TurnsCount);
        }

        [TestMethod]
        public void NewGame_Post_If_Other_Computer_Is_First_Game_Turns_Count_Shoud_Be_2()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            NewGameInputModel model = new NewGameInputModel();

            model.Players = new List<string>()
            {
               UserConstants.OtherComputerUsername
            };

            ActionResult actionResult = controller.NewGame(model);

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            GameViewModel result = partialViewResult.Model as GameViewModel;

            Assert.IsNotNull(result);

            Assert.AreEqual(2, result.GameInfo.TurnsCount);
        }

        [TestMethod]
        public void NewGame_Post_If_Human_Is_First_GameViewModel_Should_Contain_9_Empty_Tiles()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            NewGameInputModel model = new NewGameInputModel();

            model.Players = new List<string>()
            {
               UserConstants.UserUsername
            };

            ActionResult actionResult = controller.NewGame(model);

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            GameViewModel result = partialViewResult.Model as GameViewModel;

            Assert.IsNotNull(result);

            Assert.AreEqual(9, result.GameTiles.Count(t => t.IsEmpty));
        }

        [TestMethod]
        public void NewGame_Post_If_Human_Player_Is_First_Game_Turns_Count_Shoud_Be_1()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            NewGameInputModel model = new NewGameInputModel();

            model.Players = new List<string>()
            {
               UserConstants.UserEmail
            };

            ActionResult actionResult = controller.NewGame(model);

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            GameViewModel result = partialViewResult.Model as GameViewModel;

            Assert.IsNotNull(result);

            Assert.AreEqual(1, result.GameInfo.TurnsCount);
        }

        #endregion

        #region PlaceTurn Tests

        [TestMethod]
        public void PlaceTurn_Action_Should_Exist()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            PlaceTurnInputModel model = new PlaceTurnInputModel() { GameId = 1, TileIndex = 0 };

            Assert.IsNotNull(controller.PlaceTurn(model));
        }

        [TestMethod]
        public void PlaceTurn_Action_Should_Accept_PlaceTurnInputModel_As_Parameter()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            Type controllerType = controller.GetType();

            int methodsCount = controllerType.GetTypeInfo()
                                             .DeclaredMethods
                                             .Count(m => m.Name.Contains(nameof(controller.PlaceTurn)) &&
                                                         m.ToString().Contains("PlaceTurnInputModel"));

            Assert.AreEqual(1, methodsCount);
        }

        [TestMethod]
        public void PlaceTurn_Should_Return_PartialView()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            PlaceTurnInputModel model = new PlaceTurnInputModel() { GameId = 1, TileIndex = 0 };

            ActionResult actionResult = controller.PlaceTurn(model);

            Assert.IsInstanceOfType(actionResult, typeof(PartialViewResult));
        }

        [TestMethod]
        public void PlaceTurn_Should_Return_PartialView_Named__HumanVsComputerGame()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            PlaceTurnInputModel model = new PlaceTurnInputModel() { GameId = 1, TileIndex = 0 };

            ActionResult actionResult = controller.PlaceTurn(model);

            PartialViewResult result = actionResult as PartialViewResult;

            Assert.IsNotNull(result);

            Assert.AreEqual("_HumanVsComputerGame", result.ViewName);
        }

        [TestMethod]
        public void PlaceTurn_Should_Return_GameViewModel_As_Model_To_The_View()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            PlaceTurnInputModel model = new PlaceTurnInputModel() { GameId = 1, TileIndex = 0 };

            ActionResult actionResult = controller.PlaceTurn(model);

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            bool isCastValidCast = partialViewResult.Model is GameViewModel;

            Assert.IsTrue(isCastValidCast);
        }

        [TestMethod]
        public void PlaceTurn_GameViewModel_Properties_Should_Not_Be_Null()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            PlaceTurnInputModel model = new PlaceTurnInputModel() { GameId = 1, TileIndex = 0 };

            ActionResult actionResult = controller.PlaceTurn(model);

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            GameViewModel result = partialViewResult.Model as GameViewModel;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.GameInfo);
            Assert.IsNotNull(result.GameTiles);
        }

        [TestMethod]
        public void PlaceTurn_Should_Redirect_To_FinishedGame_ActionMethod_If_Game_Is_Finished()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            PlaceTurnInputModel model = new PlaceTurnInputModel() { GameId = 3, TileIndex = 0 };

            ActionResult actionResult = controller.PlaceTurn(model);

            RedirectToRouteResult routeResult = actionResult as RedirectToRouteResult;

            Assert.IsNotNull(routeResult);

            Assert.AreEqual(routeResult.RouteValues["action"], "FinishedGame");

            Assert.AreEqual(routeResult.RouteValues["controller"], "HumanVsComputer");
        }

        #endregion

        #region PlaceComputerTurn Tests

        [TestMethod]
        public void PlaceComputerTurn_Action_Should_Exist()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            PlaceTurnInputModel model = new PlaceTurnInputModel() { GameId = 1, TileIndex = 0 };

            Assert.IsNotNull(controller.PlaceComputerTurn(model));
        }


        [TestMethod]
        public void PlaceComputerTurn_Action_Should_Accept_PlaceTurnInputModel_As_Parameter()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            Type controllerType = controller.GetType();

            int methodsCount = controllerType.GetTypeInfo()
                                             .DeclaredMethods
                                             .Count(m => m.Name.Contains(nameof(controller.PlaceTurn)) &&
                                                         m.ToString().Contains("PlaceTurnInputModel"));

            Assert.AreEqual(1, methodsCount);
        }

        [TestMethod]
        public void PlaceComputerTurn_Should_Return_PartialView()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            PlaceTurnInputModel model = new PlaceTurnInputModel() { GameId = 1, TileIndex = 0 };

            ActionResult actionResult = controller.PlaceTurn(model);

            Assert.IsInstanceOfType(actionResult, typeof(PartialViewResult));
        }

        [TestMethod]
        public void PlaceComputerTurn_Should_Return_PartialView_Named__HumanVsComputerGame()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            PlaceTurnInputModel model = new PlaceTurnInputModel() { GameId = 1, TileIndex = 0 };

            ActionResult actionResult = controller.PlaceTurn(model);

            PartialViewResult result = actionResult as PartialViewResult;

            Assert.IsNotNull(result);

            Assert.AreEqual("_HumanVsComputerGame", result.ViewName);
        }

        [TestMethod]
        public void PlaceComputerTurn_Should_Return_GameViewModel_As_Model_To_The_View()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            PlaceTurnInputModel model = new PlaceTurnInputModel() { GameId = 1, TileIndex = 0 };

            ActionResult actionResult = controller.PlaceTurn(model);

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            bool isCastValidCast = partialViewResult.Model is GameViewModel;

            Assert.IsTrue(isCastValidCast);
        }

        [TestMethod]
        public void PlaceComputerTurn_GameViewModel_Properties_Should_Not_Be_Null()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            PlaceTurnInputModel model = new PlaceTurnInputModel() { GameId = 1, TileIndex = 0 };

            ActionResult actionResult = controller.PlaceTurn(model);

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            GameViewModel result = partialViewResult.Model as GameViewModel;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.GameInfo);
            Assert.IsNotNull(result.GameTiles);
        }

        [TestMethod]
        public void PlaceComputerTurn_Should_Redirect_To_FinishedGame_ActionMethod_If_Game_Is_Finished()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            PlaceTurnInputModel model = new PlaceTurnInputModel() { GameId = 3, TileIndex = 0 };

            ActionResult actionResult = controller.PlaceTurn(model);

            RedirectToRouteResult routeResult = actionResult as RedirectToRouteResult;

            Assert.IsNotNull(routeResult);

            Assert.AreEqual(routeResult.RouteValues["action"], "FinishedGame");

            Assert.AreEqual(routeResult.RouteValues["controller"], "HumanVsComputer");
        }

        #endregion

        #region FinishedGame Tests

        [TestMethod]
        public void FinishedGame_Action_Should_Exist()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            Assert.IsNotNull(controller.FinishedGame(1));
        }

        [TestMethod]
        public void FinishedGame_Action_Should_Accept_gameId_As_Parameter()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            Type controllerType = controller.GetType();

            var method = controllerType.GetTypeInfo().DeclaredMethods.ToList().FirstOrDefault(m => m.Name == "FinishedGame");

            Assert.IsNotNull(method);

            Assert.IsTrue(method.ToString().Contains("Int32"));
        }

        [TestMethod]
        public void FinishedGame_Should_Return_PartialView()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            ActionResult actionResult = controller.FinishedGame(1);

            Assert.IsInstanceOfType(actionResult, typeof(PartialViewResult));
        }

        [TestMethod]
        public void FinishedGame_Should_Return_PartialView_Named__FinishedComputerVsHumanGame()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            ActionResult actionResult = controller.FinishedGame(1);

            PartialViewResult result = actionResult as PartialViewResult;

            Assert.IsNotNull(result);

            Assert.AreEqual("_FinishedComputerVsHumanGame", result.ViewName);
        }

        [TestMethod]
        public void FinishedGame_Should_Return_FinishedGameViewModel_As_Model_To_The_View()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            ActionResult actionResult = controller.FinishedGame(1);

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            bool isCastValidCast = partialViewResult.Model is FinishedGameViewModel;

            Assert.IsTrue(isCastValidCast);
        }

        [TestMethod]
        public void FinishedGame_FinishedGameViewModel_Properties_Should_Not_Be_Null()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            ActionResult actionResult = controller.FinishedGame(1);

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            FinishedGameViewModel result = partialViewResult.Model as FinishedGameViewModel;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.GameInfo);
            Assert.IsNotNull(result.GameTiles);
        }

        #endregion

        #region ReplayGame Tests

        [TestMethod]
        public void ReplayGame_Action_Should_Exist()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            Assert.IsNotNull(controller.ReplayGame());
        }

        [TestMethod]
        public void ReplayGame_Should_Return_PartialView_Named__HumanVsHumanGame()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            ActionResult actionResult = controller.ReplayGame();

            PartialViewResult result = actionResult as PartialViewResult;

            Assert.IsNotNull(result);

            Assert.AreEqual("_HumanVsComputerGame", result.ViewName);
        }

        [TestMethod]
        public void Replay_Should_Return_GameViewModel_As_Model_To_The_View()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            ActionResult actionResult = controller.ReplayGame();

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            bool isCastValid = partialViewResult.Model is GameViewModel;

            Assert.IsTrue(isCastValid);
        }

        [TestMethod]
        public void ReplayGame_GameViewModel_Properties_Should_Not_Be_Null()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            ActionResult actionResult = controller.ReplayGame();

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            GameViewModel result = partialViewResult.Model as GameViewModel;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.GameInfo);
            Assert.IsNotNull(result.GameTiles);
        }

        #endregion

        #region LoadGame Tests

        [TestMethod]
        public void LoadGame_Action_Should_Exist()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            Assert.IsNotNull(controller.LoadGame());
        }

        [TestMethod]
        public void LoadGame_Should_Return_View()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            ActionResult actionResult = controller.LoadGame();

            Assert.IsInstanceOfType(actionResult, typeof(ViewResult));
        }

        [TestMethod]
        public void LoadGame_Should_Return_View_Named_LoadGame()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            ActionResult actionResult = controller.LoadGame();

            ViewResult result = actionResult as ViewResult;

            Assert.IsNotNull(result);

            string expectedViewName = "LoadGame";

            Assert.AreEqual(expectedViewName, result.ViewName);
        }

        [TestMethod]
        public void LoadGame_Post_Action_Should_Exist()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            Assert.IsNotNull(controller.LoadGame(1));
        }

        [TestMethod]
        public void LoadGame_Post_Should_Return_PartialView()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            ActionResult actionResult = controller.LoadGame(1);

            Assert.IsInstanceOfType(actionResult, typeof(PartialViewResult));
        }

        [TestMethod]
        public void LoadGame_Post_Should_Return_PartialView_Named__HumanVsComputerGame()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            ActionResult actionResult = controller.LoadGame(1);

            PartialViewResult result = actionResult as PartialViewResult;

            Assert.IsNotNull(result);

            string expectedViewName = "_HumanVsComputerGame";

            Assert.AreEqual(expectedViewName, result.ViewName);
        }

        [TestMethod]
        public void LoadGame_Post_Should_Accept_Int_As_Parameter()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            Type controllerType = controller.GetType();

            var method = controllerType.GetTypeInfo().DeclaredMethods.ToList()
                                       .Where(m => m.Name == "LoadGame").ElementAt(1);

            Assert.IsNotNull(method);

            Assert.IsTrue(method.ToString().Contains("Int32"));
        }

        [TestMethod]
        public void LoadGame_Post_Should_Pass_GameViewModel_As_Model_To_The_View()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            ActionResult actionResult = controller.LoadGame(1);

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            bool isCastValidCast = partialViewResult.Model is GameViewModel;

            Assert.IsTrue(isCastValidCast);
        }

        [TestMethod]
        public void LoadGame_Post_GameViewModel_Properties_Should_Not_Be_Null()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            ActionResult actionResult = controller.LoadGame(1);

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            GameViewModel result = partialViewResult.Model as GameViewModel;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.GameInfo);
            Assert.IsNotNull(result.GameTiles);
        }

        #endregion

        #region LoadGameGrid Tests

        [TestMethod]
        public void LoadGameGrid_Action_Should_Exist()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            Assert.IsNotNull(controller.LoadGameGrid());
        }

        [TestMethod]
        public void LoadGameGrid_Should_Return_PartialView()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            ActionResult actionResult = controller.LoadGameGrid();

            Assert.IsInstanceOfType(actionResult, typeof(PartialViewResult));
        }

        [TestMethod]
        public void LoadGameGrid_Should_Return_PartialView_Named__LoadGameGrid()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            ActionResult actionResult = controller.LoadGameGrid();

            PartialViewResult result = actionResult as PartialViewResult;

            Assert.IsNotNull(result);

            Assert.AreEqual("_LoadGameGrid", result.ViewName);
        }

        [TestMethod]
        public void LoadGameGrid_Should_Pass_List_Of_LoadGameGridViewModel_To_The_View()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            ActionResult actionResult = controller.LoadGameGrid();

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            bool isCastValidCast = partialViewResult.Model is IEnumerable<LoadGameGridViewModel>;

            Assert.IsTrue(isCastValidCast);
        }

        [TestMethod]
        public void LoadGameGrid_LoadGameGridViewModel_Properties_Should_Not_Be_Null()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            ActionResult actionResult = controller.LoadGameGrid();

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            var result = partialViewResult.Model as IEnumerable<LoadGameGridViewModel>;

            var firstUnfinishedGame = result.FirstOrDefault();

            Assert.IsNotNull(firstUnfinishedGame);
            Assert.IsNotNull(firstUnfinishedGame.Id);
            Assert.IsNotNull(firstUnfinishedGame.StartDate);
            Assert.IsNotNull(firstUnfinishedGame.TurnsCount);
            Assert.IsFalse(string.IsNullOrWhiteSpace(firstUnfinishedGame.HomeSideUserName));
            Assert.IsFalse(string.IsNullOrWhiteSpace(firstUnfinishedGame.OponentName));
        }

        #endregion

        /// <summary>
        /// Creates a mocked instance of HumanVsComputer controller
        /// </summary>
        /// <returns>HumanVsComputerController</returns>
        private HumanVsComputerController CreateHumanVsComputerControllerMock()
        {
            Mock<ITicTacToeGameService> ticTacToeServiceMock = mockHelper.SetupTicTacToeServiceMock();

            Mock<ControllerContext> mockContext = mockHelper.SetupControllerContextMock();

            HumanVsComputerController controller = new HumanVsComputerController(ticTacToeServiceMock.Object)
            {
                ControllerContext = mockContext.Object,
                CurrentUserName = () => MockConstants.UserEmail
            };

            return controller;
        }
    }
}