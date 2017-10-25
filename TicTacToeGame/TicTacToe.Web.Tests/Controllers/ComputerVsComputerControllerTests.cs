namespace TicTacToe.Web.Tests.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Reflection;
    using System.Collections.Generic;
    using MockHelpers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Web.Controllers;
    using Moq;
    using Constants;
    using ServiceLayer.Interfaces;
    using Models.ComputerVsComputer.ViewModels;
    using TicTacToeCommon.Constants;
    using Models.ComputerVsComputer.InputModels;
    using Models.Common.InputModels;
    using Models.Common.ViewModels;

    [TestClass]
    public class ComputerVsComputerControllerTests
    {
        private ComputerVsComputerServiceLayerMockHelper mockHelper;

        [TestInitialize]
        public void Setup()
        {
            this.mockHelper = new ComputerVsComputerServiceLayerMockHelper();
        }

        #region Controller Tests

        [TestMethod]
        public void ComputerVsComputerController_Controller_Should_Exist()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void ComputerVsComputerController_Controller_Should_Have_Empty_Constructor()
        {
            ComputerVsComputerController controller = new ComputerVsComputerController();

            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void ComputerVsComputerController_Controller_Should_Have_Private_Property_Named_TicTacToeGameService()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            bool result = controller.GetType()
                                    .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                    .Any(field => field.Name == "ticTacToeGameService");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ComputerVsComputer_Controller_Should_Have_Public_Property_Named_CurrentUserName()
        {
            BaseController controller = this.CreateComputerVsComputerControllerMock() as BaseController;

            bool result = controller.GetType()
                                    .GetFields(BindingFlags.Instance | BindingFlags.Public)
                                    .Any(field => field.Name == "CurrentUserName");

            Assert.IsTrue(result);
        }

        #endregion

        #region NewGame

        [TestMethod]
        public void NewGame_Action_Should_Exist()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            Assert.AreEqual("NewGame", nameof(controller.NewGame));

            ActionResult newGameAsActionResult = controller.NewGame();

            Assert.IsNotNull(newGameAsActionResult);
        }

        [TestMethod]
        public void NewGame_Should_Return_View()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.NewGame();

            Assert.IsInstanceOfType(actionResult, typeof(ViewResult));
        }

        [TestMethod]
        public void NewGame_Should_Return_View_Named_NewGame()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.NewGame();

            ViewResult result = actionResult as ViewResult;

            Assert.IsNotNull(result);

            string expectedViewName = "NewGame";

            Assert.AreEqual(expectedViewName, result.ViewName);
        }

        [TestMethod]
        public void NewGame_Should_Pass_NewComputerVsComputerGameViewModel_To_The_View()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.NewGame();

            ViewResult result = actionResult as ViewResult;

            Assert.IsNotNull(result);

            NewComputerVsComputerGameViewModel model = result.ViewData.Model as NewComputerVsComputerGameViewModel;

            Assert.IsInstanceOfType(model, typeof(NewComputerVsComputerGameViewModel));
        }

        [TestMethod]
        public void NewComputerVsComputerGameViewModel_Should_Have_Property_Named_Sides()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.NewGame();

            ViewResult result = actionResult as ViewResult;

            Assert.IsNotNull(result);

            NewComputerVsComputerGameViewModel model = result.ViewData.Model as NewComputerVsComputerGameViewModel;

            Assert.IsNotNull(model);

            Assert.IsNotNull(model.Sides);
        }

        [TestMethod]
        public void NewComputerVsComputerGameViewModel_Sides_Property_Should_Be_A_List_Of_Strings()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.NewGame();

            ViewResult result = actionResult as ViewResult;

            Assert.IsNotNull(result);

            NewComputerVsComputerGameViewModel model = (NewComputerVsComputerGameViewModel)result.ViewData.Model;

            Assert.IsInstanceOfType(model.Sides, typeof(List<string>));
        }

        [TestMethod]
        public void NewComputerVsComputerGameViewModel_Sides_Property_Should_Be_A_List_With_Two_Strings()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.NewGame();

            ViewResult result = actionResult as ViewResult;

            Assert.IsNotNull(result);

            NewComputerVsComputerGameViewModel model = (NewComputerVsComputerGameViewModel)result.ViewData.Model;

            Assert.AreEqual(2, model.Sides.Count);
        }

        [TestMethod]
        public void NewComputerVsComputerGameViewModel_Sides_Property_Should_Contain_Valid_Strings_As_First_And_Second_Parameters()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.NewGame();

            ViewResult result = actionResult as ViewResult;

            Assert.IsNotNull(result);

            NewComputerVsComputerGameViewModel model = (NewComputerVsComputerGameViewModel)result.ViewData.Model;

            bool isFirstParameterNotValidString = string.IsNullOrWhiteSpace(model.Sides[0]);

            Assert.IsFalse(isFirstParameterNotValidString);

            bool isSecondParameterNotValidString = string.IsNullOrWhiteSpace(model.Sides[1]);

            Assert.IsFalse(isSecondParameterNotValidString);
        }

        [TestMethod]
        public void NewComputerVsComputerGameViewModel_Sides_Property_Should_Contain_The_First_Computer_Username_As_First_Parameter()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.NewGame();

            ViewResult result = actionResult as ViewResult;

            Assert.IsNotNull(result);

            NewComputerVsComputerGameViewModel model = (NewComputerVsComputerGameViewModel)result.ViewData.Model;

            Assert.AreEqual(UserConstants.ComputerUsername, model.Sides[0]);
        }

        [TestMethod]
        public void NewComputerVsComputerGameViewModel_Sides_Property_Should_Contain_The_Second_Computer_Username_As_Second_Parameter()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.NewGame();

            ViewResult result = actionResult as ViewResult;

            Assert.IsNotNull(result);

            NewComputerVsComputerGameViewModel model = (NewComputerVsComputerGameViewModel)result.ViewData.Model;

            Assert.AreEqual(UserConstants.OtherComputerUsername, model.Sides[1]);
        }

        [TestMethod]
        public void NewComputerVsComputerGameViewModel_Should_Have_Property_Named_Computers()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.NewGame();

            ViewResult result = actionResult as ViewResult;

            Assert.IsNotNull(result);

            NewComputerVsComputerGameViewModel model = result.ViewData.Model as NewComputerVsComputerGameViewModel;

            Assert.IsNotNull(model);

            Assert.IsNotNull(model.Computers);
        }

        [TestMethod]
        public void NewComputerVsComputerGameViewModel_Computers_Property_Should_Be_A_List_Of_Strings()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.NewGame();

            ViewResult result = actionResult as ViewResult;

            Assert.IsNotNull(result);

            NewComputerVsComputerGameViewModel model = (NewComputerVsComputerGameViewModel)result.ViewData.Model;

            Assert.IsInstanceOfType(model.Computers, typeof(List<string>));
        }

        [TestMethod]
        public void NewComputerVsComputerGameViewModel_Computers_Property_Should_Be_A_List_With_Two_Strings()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.NewGame();

            ViewResult result = actionResult as ViewResult;

            Assert.IsNotNull(result);

            NewComputerVsComputerGameViewModel model = (NewComputerVsComputerGameViewModel)result.ViewData.Model;

            Assert.AreEqual(2, model.Computers.Count);
        }

        [TestMethod]
        public void NewComputerVsComputerGameViewModel_Computers_Property_Should_Contain_Valid_Strings_As_First_And_Second_Parameters()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.NewGame();

            ViewResult result = actionResult as ViewResult;

            Assert.IsNotNull(result);

            NewComputerVsComputerGameViewModel model = (NewComputerVsComputerGameViewModel)result.ViewData.Model;

            bool isFirstParameterNotValidString = string.IsNullOrWhiteSpace(model.Computers[0]);

            Assert.IsFalse(isFirstParameterNotValidString);

            bool isSecondParameterNotValidString = string.IsNullOrWhiteSpace(model.Computers[1]);

            Assert.IsFalse(isSecondParameterNotValidString);
        }

        [TestMethod]
        public void NewComputerVsComputerGameViewModel_Computers_Property_Should_Contain_The_First_Computer_Username_As_First_Parameter()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.NewGame();

            ViewResult result = actionResult as ViewResult;

            Assert.IsNotNull(result);

            NewComputerVsComputerGameViewModel model = (NewComputerVsComputerGameViewModel)result.ViewData.Model;

            Assert.AreEqual(UserConstants.ComputerUsername, model.Computers[0]);
        }

        [TestMethod]
        public void NewComputerVsComputerGameViewModelC_Computers_Property_Should_Contain_The_Second_Computer_Username_As_Second_Parameter()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.NewGame();

            ViewResult result = actionResult as ViewResult;

            Assert.IsNotNull(result);

            NewComputerVsComputerGameViewModel model = (NewComputerVsComputerGameViewModel)result.ViewData.Model;

            Assert.AreEqual(UserConstants.OtherComputerUsername, model.Computers[1]);
        }

        #endregion

        #region NewGame POST

        [TestMethod]
        public void NewGame_Post_Should_Exist_And_Accept_NewComputerVsComputerGameInputModel_As_A_Parameter()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            Type controllerType = controller.GetType();

            int methodsCount = controllerType.GetTypeInfo()
                                             .DeclaredMethods
                                             .Count(m => m.Name.Contains(nameof(controller.NewGame)) &&
                                                         m.ToString().Contains(nameof(NewComputerVsComputerGameInputModel)));

            Assert.AreEqual(1, methodsCount);
        }

        [TestMethod]
        public void NewGame_Post_Should_Return_PartialView()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            NewComputerVsComputerGameInputModel model = new NewComputerVsComputerGameInputModel()
            {
                StartingFirstUsername = UserConstants.ComputerUsername,
                OponentUsername = UserConstants.OtherComputerUsername
            };

            ActionResult actionResult = controller.NewGame(model);

            Assert.IsInstanceOfType(actionResult, typeof(PartialViewResult));
        }

        [TestMethod]
        public void NewGame_Post_Should_Return_PartialView_Named__ComputerVsComputerGame()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            NewComputerVsComputerGameInputModel model = new NewComputerVsComputerGameInputModel()
            {
                StartingFirstUsername = UserConstants.ComputerUsername,
                OponentUsername = UserConstants.OtherComputerUsername
            };

            ActionResult actionResult = controller.NewGame(model);

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            string actualPartialViewName = partialViewResult.ViewName;

            Assert.AreEqual("_ComputerVsComputerGame", actualPartialViewName);
        }

        [TestMethod]
        public void NewGame_Post_Should_Return_GameViewModel_As_Model_To_The_View()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            NewComputerVsComputerGameInputModel model = new NewComputerVsComputerGameInputModel()
            {
                StartingFirstUsername = UserConstants.ComputerUsername,
                OponentUsername = UserConstants.OtherComputerUsername
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
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            NewComputerVsComputerGameInputModel model = new NewComputerVsComputerGameInputModel()
            {
                StartingFirstUsername = UserConstants.ComputerUsername,
                OponentUsername = UserConstants.OtherComputerUsername
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
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            NewComputerVsComputerGameInputModel model = new NewComputerVsComputerGameInputModel()
            {
                StartingFirstUsername = UserConstants.ComputerUsername,
                OponentUsername = UserConstants.OtherComputerUsername
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
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            NewComputerVsComputerGameInputModel model = new NewComputerVsComputerGameInputModel()
            {
                StartingFirstUsername = UserConstants.OtherComputerUsername,
                OponentUsername = UserConstants.ComputerUsername
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
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            NewComputerVsComputerGameInputModel model = new NewComputerVsComputerGameInputModel()
            {
                StartingFirstUsername = UserConstants.ComputerUsername,
                OponentUsername = UserConstants.OtherComputerUsername
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
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            NewComputerVsComputerGameInputModel model = new NewComputerVsComputerGameInputModel()
            {
                StartingFirstUsername = UserConstants.OtherComputerUsername,
                OponentUsername = UserConstants.ComputerUsername
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
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            NewComputerVsComputerGameInputModel model = new NewComputerVsComputerGameInputModel()
            {
                StartingFirstUsername = UserConstants.ComputerUsername,
                OponentUsername = UserConstants.OtherComputerUsername
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
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            NewComputerVsComputerGameInputModel model = new NewComputerVsComputerGameInputModel()
            {
                StartingFirstUsername = UserConstants.OtherComputerUsername,
                OponentUsername = UserConstants.ComputerUsername
            };

            ActionResult actionResult = controller.NewGame(model);

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            GameViewModel result = partialViewResult.Model as GameViewModel;

            Assert.IsNotNull(result);

            Assert.AreEqual(2, result.GameInfo.TurnsCount);
        }

        #endregion

        #region GetOponentsDropdown Tests

        [TestMethod]
        public void GetOponentsDropdown_JsonResult_Should_Return_TwoComputers()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            JsonResult getOponentsDropdownResult = controller.GetOponentsDropdown();

            SelectList selectList = getOponentsDropdownResult.Data as SelectList;

            Assert.IsNotNull(selectList);

            IEnumerable<string> selectListItems = selectList.Items.Cast<string>();

            Assert.AreEqual(2, selectListItems.Count());

            bool isComputerPresent = selectListItems.ElementAt(0) == MockConstants.ComputerUsername;

            Assert.IsTrue(isComputerPresent);

            bool isOtherComputerPresent = selectListItems.ElementAt(1) == MockConstants.OtherComputerUsername;

            Assert.IsTrue(isOtherComputerPresent);
        }

        #endregion

        #region PlaceComputerTurn Tests

        [TestMethod]
        public void PlaceComputerTurn_Action_Should_Exist()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            PlaceTurnInputModel model = new PlaceTurnInputModel() { GameId = 1, TileIndex = 0 };

            Assert.IsNotNull(controller.PlaceComputerTurn(model));
        }

        [TestMethod]
        public void PlaceComputerTurn_Action_Should_Accept_PlaceTurnInputModel_As_Parameter()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            Type controllerType = controller.GetType();

            int methodsCount = controllerType.GetTypeInfo()
                                             .DeclaredMethods
                                             .Count(m => m.Name.Contains(nameof(controller.PlaceComputerTurn)) &&
                                                         m.ToString().Contains("PlaceTurnInputModel"));

            Assert.AreEqual(1, methodsCount);
        }

        [TestMethod]
        public void PlaceComputerTurn_Should_Return_PartialView()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            PlaceTurnInputModel model = new PlaceTurnInputModel() { GameId = 1, TileIndex = 0 };

            ActionResult actionResult = controller.PlaceComputerTurn(model);

            Assert.IsInstanceOfType(actionResult, typeof(PartialViewResult));
        }

        [TestMethod]
        public void PlaceComputerTurn_Should_Return_PartialView_Named__ComputerVsComputerGame()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            PlaceTurnInputModel model = new PlaceTurnInputModel() { GameId = 1, TileIndex = 0 };

            ActionResult actionResult = controller.PlaceComputerTurn(model);

            PartialViewResult result = actionResult as PartialViewResult;

            Assert.IsNotNull(result);

            Assert.AreEqual("_ComputerVsComputerGame", result.ViewName);
        }

        [TestMethod]
        public void PlaceComputerTurn_Should_Return_GameViewModel_As_Model_To_The_View()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            PlaceTurnInputModel model = new PlaceTurnInputModel() { GameId = 1, TileIndex = 0 };

            ActionResult actionResult = controller.PlaceComputerTurn(model);

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            bool isCastValidCast = partialViewResult.Model is GameViewModel;

            Assert.IsTrue(isCastValidCast);
        }

        [TestMethod]
        public void PlaceComputerTurn_GameViewModel_Properties_Should_Not_Be_Null()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            PlaceTurnInputModel model = new PlaceTurnInputModel() { GameId = 1, TileIndex = 0 };

            ActionResult actionResult = controller.PlaceComputerTurn(model);

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
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            PlaceTurnInputModel model = new PlaceTurnInputModel() { GameId = 3, TileIndex = 0 };

            ActionResult actionResult = controller.PlaceComputerTurn(model);

            RedirectToRouteResult routeResult = actionResult as RedirectToRouteResult;

            Assert.IsNotNull(routeResult);

            Assert.AreEqual(routeResult.RouteValues["action"], "FinishedGame");

            Assert.AreEqual(routeResult.RouteValues["controller"], "ComputerVsComputer");
        }

        #endregion

        #region FinishedGame Tests

        [TestMethod]
        public void FinishedGame_Action_Should_Exist()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            Assert.IsNotNull(controller.FinishedGame(1));
        }

        [TestMethod]
        public void FinishedGame_Action_Should_Accept_gameId_As_Parameter()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            Type controllerType = controller.GetType();

            var method = controllerType.GetTypeInfo().DeclaredMethods.ToList().FirstOrDefault(m => m.Name == "FinishedGame");

            Assert.IsNotNull(method);

            Assert.IsTrue(method.ToString().Contains("Int32"));
        }

        [TestMethod]
        public void FinishedGame_Should_Return_PartialView()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.FinishedGame(1);

            Assert.IsInstanceOfType(actionResult, typeof(PartialViewResult));
        }

        [TestMethod]
        public void FinishedGame_Should_Return_PartialView_Named__FinishedComputerVsComputerGame()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.FinishedGame(1);

            PartialViewResult result = actionResult as PartialViewResult;

            Assert.IsNotNull(result);

            Assert.AreEqual("_FinishedComputerVsComputerGame", result.ViewName);
        }

        [TestMethod]
        public void FinishedGame_Should_Return_FinishedGameViewModel_As_Model_To_The_View()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.FinishedGame(1);

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            bool isCastValidCast = partialViewResult.Model is FinishedGameViewModel;

            Assert.IsTrue(isCastValidCast);
        }

        [TestMethod]
        public void FinishedGame_FinishedGameViewModel_Properties_Should_Not_Be_Null()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

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
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            Assert.IsNotNull(controller.ReplayGame());
        }

        [TestMethod]
        public void ReplayGame_Should_Return_PartialView_Named__ComputerVsComputerGame()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.ReplayGame();

            PartialViewResult result = actionResult as PartialViewResult;

            Assert.IsNotNull(result);

            Assert.AreEqual("_ComputerVsComputerGame", result.ViewName);
        }

        [TestMethod]
        public void Replay_Should_Return_GameViewModel_As_Model_To_The_View()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.ReplayGame();

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            bool isCastValid = partialViewResult.Model is GameViewModel;

            Assert.IsTrue(isCastValid);
        }

        [TestMethod]
        public void ReplayGame_GameViewModel_Properties_Should_Not_Be_Null()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.ReplayGame();

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            GameViewModel result = partialViewResult.Model as GameViewModel;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.GameInfo);
            Assert.IsNotNull(result.GameTiles);
        }

        [TestMethod]
        public void ReplayGame_GameViewModel_First_Turn_Should_Be_Placed()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.ReplayGame();

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            GameViewModel result = partialViewResult.Model as GameViewModel;

            Assert.AreEqual(2, result.GameInfo.TurnsCount);
        }

        #endregion

        #region LoadGame Tests

        [TestMethod]
        public void LoadGame_Action_Should_Exist()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            Assert.IsNotNull(controller.LoadGame());
        }

        [TestMethod]
        public void LoadGame_Should_Return_View()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.LoadGame();

            Assert.IsInstanceOfType(actionResult, typeof(ViewResult));
        }

        [TestMethod]
        public void LoadGame_Should_Return_View_Named_LoadGame()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.LoadGame();

            ViewResult result = actionResult as ViewResult;

            Assert.IsNotNull(result);

            string expectedViewName = "LoadGame";

            Assert.AreEqual(expectedViewName, result.ViewName);
        }

        [TestMethod]
        public void LoadGame_Post_Action_Should_Exist()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            Assert.IsNotNull(controller.LoadGame(1));
        }

        [TestMethod]
        public void LoadGame_Post_Should_Return_PartialView()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.LoadGame(1);

            Assert.IsInstanceOfType(actionResult, typeof(PartialViewResult));
        }

        [TestMethod]
        public void LoadGame_Post_Should_Return_PartialView_Named__ComputerVsComputerGame()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.LoadGame(1);

            PartialViewResult result = actionResult as PartialViewResult;

            Assert.IsNotNull(result);

            string expectedViewName = "_ComputerVsComputerGame";

            Assert.AreEqual(expectedViewName, result.ViewName);
        }

        [TestMethod]
        public void LoadGame_Post_Should_Accept_Int_As_Parameter()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            Type controllerType = controller.GetType();

            var method = controllerType.GetTypeInfo().DeclaredMethods.ToList()
                                       .Where(m => m.Name == "LoadGame").ElementAt(1);

            Assert.IsNotNull(method);

            Assert.IsTrue(method.ToString().Contains("Int32"));
        }

        [TestMethod]
        public void LoadGame_Post_Should_Pass_GameViewModel_As_Model_To_The_View()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.LoadGame(1);

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            bool isCastValidCast = partialViewResult.Model is GameViewModel;

            Assert.IsTrue(isCastValidCast);
        }

        [TestMethod]
        public void LoadGame_Post_GameViewModel_Properties_Should_Not_Be_Null()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

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
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            Assert.IsNotNull(controller.LoadGameGrid());
        }

        [TestMethod]
        public void LoadGameGrid_Should_Return_PartialView()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.LoadGameGrid();

            Assert.IsInstanceOfType(actionResult, typeof(PartialViewResult));
        }

        [TestMethod]
        public void LoadGameGrid_Should_Return_PartialView_Named__LoadGameGrid()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.LoadGameGrid();

            PartialViewResult result = actionResult as PartialViewResult;

            Assert.IsNotNull(result);

            Assert.AreEqual("_LoadGameGrid", result.ViewName);
        }

        [TestMethod]
        public void LoadGameGrid_Should_Pass_List_Of_LoadGameGridViewModel_To_The_View()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.LoadGameGrid();

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            bool isCastValidCast = partialViewResult.Model is IEnumerable<LoadGameGridViewModel>;

            Assert.IsTrue(isCastValidCast);
        }

        [TestMethod]
        public void LoadGameGrid_LoadGameGridViewModel_Properties_Should_Not_Be_Null()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

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
        /// Creates a mocked instance of ComputerVsComputer controller
        /// </summary>
        /// <returns>ComputerVsComputer</returns>
        private ComputerVsComputerController CreateComputerVsComputerControllerMock()
        {
            Mock<ITicTacToeGameService> ticTacToeServiceMock = mockHelper.SetupTicTacToeServiceMock();

            Mock<ControllerContext> mockContext = mockHelper.SetupControllerContextMock();

            ComputerVsComputerController controller = new ComputerVsComputerController(ticTacToeServiceMock.Object)
            {
                ControllerContext = mockContext.Object,
                CurrentUserName = () => MockConstants.UserEmail
            };

            return controller;
        }
    }
}