namespace TicTacToe.Web.Tests.Controllers
{
    using System.Web.Mvc;
    using ServiceLayer.TicTacToeGameService;
    using Web.Controllers;
    using MockHelpers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Constants;
    using System.Reflection;
    using System.Linq;

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