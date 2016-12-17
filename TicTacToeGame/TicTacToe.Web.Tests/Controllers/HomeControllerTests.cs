namespace TicTacToe.Web.Tests.Controllers
{
    using System.Web.Mvc;
    using System.Security.Principal;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    using Web.Controllers;

    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void HomeController_Should_Exist()
        {
            HomeController controller = new HomeController();

            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void Index_Action_Method_ShouldExist()
        {
            HomeController controller = CreateHomeControllerAsAnonymousUser();

            Assert.AreEqual(nameof(controller.Index), "Index");

            bool isActionResult = controller.Index() is ActionResult;

            Assert.AreEqual(true, isActionResult);
        }

        [TestMethod]
        public void When_Authenticated_Index_Action_Should_Return_IndexView_With_AuthenticatedLayout()
        {
            HomeController controller = CreateHomeControllerAsAuthenticatedUser();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result.ViewName);

            string viewName = result.ViewName;
            Assert.AreEqual(viewName, "Index");

            string layoutName = result.MasterName;
            Assert.AreEqual(layoutName, "_AuthenticatedUserLayout");
        }

        [TestMethod]
        public void When_Anonymous_Index_Action_Should_Return_IndexView_With_Anonymous()
        {
            HomeController controller = CreateHomeControllerAsAnonymousUser();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result.ViewName);

            string viewName = result.ViewName;
            Assert.AreEqual(viewName, "Index");

            string layoutName = result.MasterName;
            Assert.AreEqual(layoutName, "_AnonymousUserLayout");
        }

        [TestMethod]
        public void Human_Vs_Human_Action_Should_Exist()
        {
            HomeController controller = CreateHomeControllerAsAnonymousUser();

            Assert.AreEqual(nameof(controller.HumanVsHuman), "HumanVsHuman");

            bool isActionResult = controller.HumanVsHuman() is ActionResult;

            Assert.AreEqual(true, isActionResult);
        }

        [TestMethod]
        public void When_Authenticated_User_Calls_Human_Vs_Human_Action_Should_Return_PartialView()
        {
            HomeController controller = CreateHomeControllerAsAuthenticatedUser();

            ActionResult result = controller.HumanVsHuman();

            bool isResultPartialView = result is PartialViewResult;

            Assert.AreEqual(true, isResultPartialView);
        }

        [TestMethod]
        public void When_Authenticated_User_Calls_Human_Vs_Human_Action_Should_Return_PartialView_Named_HumanVsHuman()
        {
            HomeController controller = CreateHomeControllerAsAuthenticatedUser();

            PartialViewResult result = controller.HumanVsHuman() as PartialViewResult;

            string expectedPartialViewName = "_HumanVsHuman";

            Assert.AreEqual(expectedPartialViewName, result.ViewName);
        }

        [TestMethod]
        public void When_Anonymous_User_Tries_To_Call_HumanVsHuman_He_Should_Be_Redirected()
        {
            HomeController controller = CreateHomeControllerAsAnonymousUser();

            ViewResult result = controller.HumanVsHuman() as ViewResult;

            Assert.IsNotNull(result.ViewName);

            string viewName = result.ViewName;
            Assert.AreEqual(viewName, "Index");

            string layoutName = result.MasterName;
            Assert.AreEqual(layoutName, "_AnonymousUserLayout");
        }

        /// <summary>
        /// Creates an instance of HomeController with an aunthenticated user
        /// </summary>
        /// <returns>HomeController</returns>
        private HomeController CreateHomeControllerAsAuthenticatedUser()
        {
            Mock<IPrincipal> mockPrincipal = SetupMockPrincipalAsAuthenticatedUser("georgi_iliev@yahoo.com");
            Mock<ControllerContext> mockContext = new Mock<ControllerContext>();

            mockContext.SetupGet(p => p.HttpContext.User).Returns(mockPrincipal.Object);
            mockContext.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);
            mockContext.SetupGet(p => p.HttpContext.User.Identity.IsAuthenticated).Returns(true);

            HomeController controller = new HomeController()
            {
                ControllerContext = mockContext.Object
            };

            return controller;
        }

        /// <summary>
        /// Creates an instance of HomeController with an anonymous user
        /// </summary>
        /// <returns>HomeController</returns>
        private HomeController CreateHomeControllerAsAnonymousUser()
        {
            Mock<IPrincipal> mockPrincipal = SetupMockPrincipalAsAnonymousUser("anonymous");
            Mock<ControllerContext> mockContext = new Mock<ControllerContext>();

            mockContext.SetupGet(p => p.HttpContext.User).Returns(mockPrincipal.Object);
            mockContext.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(false);
            mockContext.SetupGet(p => p.HttpContext.User.Identity.IsAuthenticated).Returns(false);

            HomeController controller = new HomeController()
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

        /// <summary>
        /// Mocks a fake anonymous user.
        /// User is not added to the Role
        /// </summary>
        /// <param name="userName">username of the user to be mocked</param>
        /// <returns>Mock<IPrincipal></returns>
        private static Mock<IPrincipal> SetupMockPrincipalAsAnonymousUser(string userName)
        {
            MockRepository mocks = new MockRepository(MockBehavior.Default);
            Mock<IPrincipal> mockPrincipal = mocks.Create<IPrincipal>();

            mockPrincipal.SetupGet(p => p.Identity.Name).Returns(userName);
            mockPrincipal.Setup(p => p.IsInRole("User")).Returns(false);

            return mockPrincipal;
        }
    }
}