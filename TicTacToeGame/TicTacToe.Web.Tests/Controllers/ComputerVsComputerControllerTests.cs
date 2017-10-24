namespace TicTacToe.Web.Tests.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Reflection;
    using MockHelpers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Web.Controllers;
    using ServiceLayer.TicTacToeGameService;
    using Moq;
    using Constants;
    using Models.HumanVsHuman.ViewModels;
    using ServiceLayer.Interfaces;
    using Models.ComputerVsComputer.ViewModels;
    using System.Collections.Generic;
    using TicTacToeCommon.Constants;
    using Models.ComputerVsComputer.InputModels;

    [TestClass]
    public class ComputerVsComputerControllerTests
    {
        private ComputerVsComputerServiceLayerMockHelper mockHelper;

        [TestInitialize]
        public void Setup()
        {
            this.mockHelper = new ComputerVsComputerServiceLayerMockHelper();
        }

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