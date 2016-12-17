namespace TicTacToe.Web.Tests.Controllers
{
    using System.Web.Mvc;
    using System.Security.Principal;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Web.Controllers;

    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void HomeController_Should_Exist()
        {
            HomeController controller = new HomeController();

            Assert.IsNotNull(controller);

            Assert.IsInstanceOfType(controller, controller.GetType());
        }

        [TestMethod]
        public void Index_Action_Method_ShouldExist()
        {
            HomeController controller = CreateHomeControllerAsAnonymousUser();

            bool isActionResult = controller.Index() is ActionResult;

            Assert.AreEqual(true, isActionResult);
        }

        [TestMethod]
        public void When_Authenticated_Index_Action_Should_Return_IndexView_With_AuthenticatedLayout()
        {
            HomeController controller = CreateHomeControllerAsAuthenticatedUser("georgi_iliev@yahoo.com");

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result.ViewName);

            string viewName = result.ViewName;
            Assert.AreEqual(viewName, "Index");

            string layoutName = result.MasterName;
            Assert.AreEqual(layoutName, "_AuthenticatedUserLayout");
        }

        [TestMethod]
        public void When_Anynimous_Index_Action_Should_Return_IndexView_With_AnynimousLayout()
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

            bool isActionResult = controller.HumanVsHuman() is ActionResult;

            Assert.AreEqual(true, isActionResult);
        }

        [TestMethod]
        public void When_Authenticated_User_Calls_Human_Vs_Human_Action_Should_Return_PartialView()
        {
            HomeController controller = CreateHomeControllerAsAuthenticatedUser("georgi_iliev@yahoo.com");

            ActionResult result = controller.HumanVsHuman();

            bool isResultPartialView = result is PartialViewResult;

            Assert.AreEqual(true, isResultPartialView);
        }

        [TestMethod]
        public void When_Authenticated_User_Calls_Human_Vs_Human_Action_Should_Return_PartialView_Named_HumanVsHuman()
        {
            HomeController controller = CreateHomeControllerAsAuthenticatedUser("georgi_iliev@yahoo.com");

            PartialViewResult result = controller.HumanVsHuman() as PartialViewResult;

            string expectedPartialViewName = "_HumanVsHuman";

            Assert.AreEqual(expectedPartialViewName, result.ViewName);
        }

        private HomeController CreateHomeControllerAsAuthenticatedUser(string userName)
        {
            MockRepository mocks = new MockRepository(MockBehavior.Default);
            Mock<IPrincipal> mockPrincipal = mocks.Create<IPrincipal>();
            mockPrincipal.SetupGet(p => p.Identity.Name).Returns(userName);
            mockPrincipal.Setup(p => p.IsInRole("User")).Returns(true);

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

        private HomeController CreateHomeControllerAsAnonymousUser()
        {
            MockRepository mocks = new MockRepository(MockBehavior.Default);

            Mock<IPrincipal> mockPrincipal = mocks.Create<IPrincipal>();
            mockPrincipal.SetupGet(p => p.Identity.Name).Returns("anonymous");
            mockPrincipal.Setup(p => p.IsInRole("User")).Returns(false);

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
    }
}