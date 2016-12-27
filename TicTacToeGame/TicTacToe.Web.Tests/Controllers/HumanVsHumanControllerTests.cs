namespace TicTacToe.Web.Tests.Controllers
{
    using System.Web.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Web.Controllers;
    using Models.HumanVsHuman.NewGame.InputModels;
    using System.Collections.Generic;
    using Moq;
    using System.Security.Principal;

    [TestClass]
    public class HumanVsHumanControllerTests
    {
        [TestMethod]
        public void HumanVsHuman_Controller_Should_Exist()
        {
            HumanVsHumanController controller = new HumanVsHumanController();

            Assert.IsNotNull(controller);
        }

        #region NewGame Tests

        [TestMethod]
        public void NewGame_Action_Should_Exist()
        {
            HumanVsHumanController controller = CreateHumanVsHumanControllerAsAuthenticatedUser();

            Assert.AreEqual("NewGame", nameof(controller.NewGame));

            bool isActionResult = controller.NewGame() is ActionResult;

            Assert.AreEqual(true, isActionResult);
        }

        [TestMethod]
        public void Authenticated_NewGame_Should_Return_View()
        {
            HumanVsHumanController controller = CreateHumanVsHumanControllerAsAuthenticatedUser();

            ActionResult actionResult = controller.NewGame();

            Assert.IsInstanceOfType(actionResult, typeof(ViewResult));
        }

        [TestMethod]
        public void Authenticated_NewGame_Should_Return_View_Named_NewGame()
        {
            HumanVsHumanController controller = CreateHumanVsHumanControllerAsAuthenticatedUser();

            ActionResult actionResult = controller.NewGame();

            Assert.IsInstanceOfType(actionResult, typeof(ViewResult));

            ViewResult result = actionResult as ViewResult;

            string expectedPartialViewName = "NewGame";

            Assert.AreEqual(expectedPartialViewName, result.ViewName);
        }

        [TestMethod]
        public void Authenticated_NewGame_Should_Pass_NewGameInputModel_To_The_View()
        {
            HumanVsHumanController controller = CreateHumanVsHumanControllerAsAuthenticatedUser();

            ActionResult actionResult = controller.NewGame();

            Assert.IsInstanceOfType(actionResult, typeof(ViewResult));

            ViewResult result = actionResult as ViewResult;

            Assert.AreEqual(result.ViewName, "NewGame");

            NewGameInputModel model = (NewGameInputModel)result.ViewData.Model;

            Assert.IsInstanceOfType(model, typeof(NewGameInputModel));
        }

        [TestMethod]
        public void NewGameInputModel_Should_Have_Property_Named_Players()
        {
            HumanVsHumanController controller = CreateHumanVsHumanControllerAsAuthenticatedUser();

            ActionResult actionResult = controller.NewGame();

            Assert.IsInstanceOfType(actionResult, typeof(ViewResult));

            ViewResult result = actionResult as ViewResult;

            NewGameInputModel model = (NewGameInputModel)result.ViewData.Model;

            Assert.AreEqual("Players", nameof(model.Players));
        }

        [TestMethod]
        public void NewGameInputModel_Players_Property_Should_Be_A_List_Of_Strings()
        {
            HumanVsHumanController controller = CreateHumanVsHumanControllerAsAuthenticatedUser();

            ActionResult actionResult = controller.NewGame();

            Assert.IsInstanceOfType(actionResult, typeof(ViewResult));

            ViewResult result = actionResult as ViewResult;

            NewGameInputModel model = (NewGameInputModel)result.ViewData.Model;

            Assert.IsInstanceOfType(model.Players, typeof(List<string>));
        }

        [TestMethod]
        public void NewGameInputModel_Players_Property_Should_Be_A_List_With_Two_Strings()
        {
            HumanVsHumanController controller = CreateHumanVsHumanControllerAsAuthenticatedUser();

            ActionResult actionResult = controller.NewGame();

            Assert.IsInstanceOfType(actionResult, typeof(ViewResult));

            ViewResult result = actionResult as ViewResult;

            NewGameInputModel model = (NewGameInputModel)result.ViewData.Model;

            Assert.AreEqual(2, model.Players.Count);
        }

        [TestMethod]
        public void NewGameInputModel_Players_Property_Should_Contain_Valid_String_As_First_Parameter()
        {
            HumanVsHumanController controller = CreateHumanVsHumanControllerAsAuthenticatedUser();

            ActionResult actionResult = controller.NewGame();

            Assert.IsInstanceOfType(actionResult, typeof(ViewResult));

            ViewResult result = actionResult as ViewResult;

            NewGameInputModel model = (NewGameInputModel)result.ViewData.Model;

            bool isValidString = string.IsNullOrWhiteSpace(model.Players[0]);

            Assert.IsTrue(isValidString);
        }

        [TestMethod]
        public void NewGameInputModel_Players_Property_Should_Contain_The_other_guy_As_Second_Parameter()
        {
            HumanVsHumanController controller = CreateHumanVsHumanControllerAsAuthenticatedUser();

            ActionResult actionResult = controller.NewGame();

            Assert.IsInstanceOfType(actionResult, typeof(ViewResult));

            ViewResult result = actionResult as ViewResult;

            NewGameInputModel model = (NewGameInputModel)result.ViewData.Model;

            Assert.AreEqual(model.Players[1], "The other guy");
        }

        [TestMethod]
        public void NewGameInputModel_Should_Have_An_OponentName_Property()
        {
            HumanVsHumanController controller = CreateHumanVsHumanControllerAsAuthenticatedUser();

            ActionResult actionResult = controller.NewGame();

            Assert.IsInstanceOfType(actionResult, typeof(ViewResult));

            ViewResult result = actionResult as ViewResult;

            NewGameInputModel model = (NewGameInputModel)result.ViewData.Model;

            Assert.AreEqual("OponentName", nameof(model.OponentName));
        }

        [TestMethod]
        public void NewGameInputModel_OponentName_Property_Should_Be_A_String()
        {
            HumanVsHumanController controller = CreateHumanVsHumanControllerAsAuthenticatedUser();

            ActionResult actionResult = controller.NewGame();

            Assert.IsInstanceOfType(actionResult, typeof(ViewResult));

            ViewResult result = actionResult as ViewResult;

            NewGameInputModel model = (NewGameInputModel)result.ViewData.Model;

            Assert.IsInstanceOfType(model.OponentName, typeof(string));
        }

        [TestMethod]
        public void NewGameInputModel_OponentName_Property_Should_Not_Be_An_Empty_String()
        {
            HumanVsHumanController controller = CreateHumanVsHumanControllerAsAuthenticatedUser();

            ActionResult actionResult = controller.NewGame();

            Assert.IsInstanceOfType(actionResult, typeof(ViewResult));

            ViewResult result = actionResult as ViewResult;

            NewGameInputModel model = (NewGameInputModel)result.ViewData.Model;

            bool isEmptyString = string.IsNullOrWhiteSpace(model.OponentName);

            Assert.IsFalse(isEmptyString);
        }

        [TestMethod]
        public void NewGameInputModel_OponentName_Property_Should_Equal_The_other_guy()
        {
            HumanVsHumanController controller = CreateHumanVsHumanControllerAsAuthenticatedUser();

            ActionResult actionResult = controller.NewGame();

            Assert.IsInstanceOfType(actionResult, typeof(ViewResult));

            ViewResult result = actionResult as ViewResult;

            NewGameInputModel model = (NewGameInputModel)result.ViewData.Model;

            Assert.AreEqual("The other guy", model.OponentName);
        }

        #endregion

        /// <summary>
        /// Creates an instance of HomeController with an aunthenticated user
        /// </summary>
        /// <returns>HomeController</returns>
        private HumanVsHumanController CreateHumanVsHumanControllerAsAuthenticatedUser()
        {
            Mock<IPrincipal> mockPrincipal = SetupMockPrincipalAsAuthenticatedUser("georgi_iliev@yahoo.com");
            Mock<ControllerContext> mockContext = new Mock<ControllerContext>();

            mockContext.SetupGet(p => p.HttpContext.User).Returns(mockPrincipal.Object);
            mockContext.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);
            mockContext.SetupGet(p => p.HttpContext.User.Identity.IsAuthenticated).Returns(true);

            HumanVsHumanController controller = new HumanVsHumanController()
            {
                ControllerContext = mockContext.Object
            };

            return controller;
        }

        /// <summary>
        /// Mocks a fake anonymous user.
        /// User is added to the Role
        /// </summary>
        /// <param name="userName">username of the user to be mocked</param>
        /// <returns>Mock<IPrincipal></returns>
        private static Mock<IPrincipal> SetupMockPrincipalAsAuthenticatedUser(string userName)
        {
            MockRepository mocks = new MockRepository(MockBehavior.Default);
            Mock<IPrincipal> mockPrincipal = mocks.Create<IPrincipal>();

            mockPrincipal.SetupGet(p => p.Identity.Name).Returns(userName);
            mockPrincipal.Setup(p => p.IsInRole("User")).Returns(true);

            return mockPrincipal;
        }
    }
}