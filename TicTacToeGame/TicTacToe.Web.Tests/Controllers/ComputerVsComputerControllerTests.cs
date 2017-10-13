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

    [TestClass]
    public class ComputerVsComputerControllerTests
    {
        private ComputerVsComputerServiceLayerMockHelper mockHelper;

        [TestInitialize]
        public void Setup()
        {
            this.mockHelper = new ComputerVsComputerServiceLayerMockHelper();
        }

        [TestMethod]
        public void NewGame_Post_Should_Exist_And_Accept_No_Parameters()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            Type controllerType = controller.GetType();

            MethodInfo newGameActionMethod = controllerType.GetTypeInfo()
                                             .DeclaredMethods
                                             .FirstOrDefault(m => m.Name.Contains(nameof(controller.NewGame)));

            int parametersCount = newGameActionMethod.GetParameters().Count();

            Assert.AreEqual(0, parametersCount);
        }

        [TestMethod]
        public void NewGame_Post_Should_Return_PartialView()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.NewGame();

            Assert.IsInstanceOfType(actionResult, typeof(PartialViewResult));
        }

        [TestMethod]
        public void NewGame_Post_Should_Return_PartialView_Named__ComputerVsComputerGame()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.NewGame();

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            string actualPartialViewName = partialViewResult.ViewName;

            Assert.AreEqual("_ComputerVsComputerGame", actualPartialViewName);
        }

        [TestMethod]
        public void NewGame_Post_Should_Return_GameViewModel_As_Model_To_The_View()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.NewGame();

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            bool isCastValidCast = partialViewResult.Model is GameViewModel;

            Assert.IsTrue(isCastValidCast);
        }

        [TestMethod]
        public void NewGame_Post_GameViewModel_Properties_Should_Not_Be_Null()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.NewGame();

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            GameViewModel result = partialViewResult.Model as GameViewModel;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.GameInfo);
            Assert.IsNotNull(result.GameTiles);
        }

        [TestMethod]
        public void NewGame_Post_If_Computer_Is_First_GameViewModel_Should_Reflect_New_Game()
        {
            ComputerVsComputerController controller = this.CreateComputerVsComputerControllerMock();

            ActionResult actionResult = controller.NewGame();

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            GameViewModel result = partialViewResult.Model as GameViewModel;

            Assert.IsNotNull(result);

            Assert.AreEqual(9, result.GameTiles.Count(t => t.IsEmpty));

            Assert.AreEqual(9, result.GameTiles.Count(t => string.IsNullOrWhiteSpace(t.Value)));

            Assert.AreEqual(1, result.GameInfo.TurnsCount);
        }

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