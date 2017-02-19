namespace TicTacToe.Web.Tests.Controllers
{
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

    [TestClass]
    public class HumanVsComputerControllerTests
    {
        private ServiceLayerMockHelper mockHelper;

        [TestInitialize]
        public void Setup()
        {
            this.mockHelper = new ServiceLayerMockHelper();
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
        public void NewGameInputModel_Players_Property_Should_Be_A_List_With_Two_Strings()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            ActionResult actionResult = controller.NewGame();

            ViewResult result = actionResult as ViewResult;

            Assert.IsNotNull(result);

            NewGameInputModel model = (NewGameInputModel)result.ViewData.Model;

            Assert.AreEqual(2, model.Players.Count);
        }

        [TestMethod]
        public void NewGameInputModel_Players_Property_Should_Contain_Valid_String_As_First_Parameter()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            ActionResult actionResult = controller.NewGame();

            ViewResult result = actionResult as ViewResult;

            Assert.IsNotNull(result);

            NewGameInputModel model = (NewGameInputModel)result.ViewData.Model;

            bool isNotValidString = string.IsNullOrWhiteSpace(model.Players[0]);

            Assert.IsFalse(isNotValidString);
        }

        [TestMethod]
        public void NewGameInputModel_Players_Property_Should_Contain_The_Default_Oponent_Username_As_Second_Parameter()
        {
            HumanVsComputerController controller = this.CreateHumanVsComputerControllerMock();

            ActionResult actionResult = controller.NewGame();

            ViewResult result = actionResult as ViewResult;

            Assert.IsNotNull(result);

            NewGameInputModel model = (NewGameInputModel)result.ViewData.Model;

            Assert.AreEqual("the-other-guy@yahoo.com", model.Players[1]);
        }

        #endregion

        /// <summary>
        /// Creates a mocked instance of HumanVsHuman controller
        /// </summary>
        /// <returns>HumanVsHumanController</returns>
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