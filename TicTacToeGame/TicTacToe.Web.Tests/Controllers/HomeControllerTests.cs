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
        #region Controller Tests

        [TestMethod]
        public void HomeController_Should_Exist()
        {
            HomeController controller = new HomeController();

            Assert.IsNotNull(controller);
        }
        
        #endregion

        #region Index Tests

        [TestMethod]
        public void Index_Action_Should_Exist()
        {
            HomeController controller = CreateHomeControllerAsAnonymousUser();

            Assert.IsNotNull(controller);

            string indexActionName = nameof(controller.Index);

            Assert.AreEqual("Index", indexActionName);
        }

        [TestMethod]
        public void Authenticated_Index_Should_Return_IndexView_With_AuthenticatedLayout()
        {
            HomeController controller = CreateHomeControllerAsAuthenticatedUser();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);

            string viewName = result.ViewName;
            Assert.AreEqual(viewName, "Index");

            string layoutName = result.MasterName;
            Assert.AreEqual(layoutName, "_AuthenticatedUserLayout");
        }
                    
        [TestMethod]
        public void Anonymous_Index_Should_Return_IndexView_With_AnonymousUserLayout()
        {
            HomeController controller = CreateHomeControllerAsAnonymousUser();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);

            string viewName = result.ViewName;
            Assert.AreEqual(viewName, "Index");

            string layoutName = result.MasterName;
            Assert.AreEqual(layoutName, "_AnonymousUserLayout");
        }
        
        #endregion 

        #region HumanVsHuman Tests

        [TestMethod]
        public void HumanVsHuman_Action_Should_Exist()
        {
            HomeController controller = CreateHomeControllerAsAnonymousUser();

            Assert.IsNotNull(controller);

            string indexActionName = nameof(controller.HumanVsHuman);

            Assert.AreEqual("HumanVsHuman", indexActionName);
        }

        [TestMethod]
        public void Anonymous_HumanVsHuman_Should_Redirect_To_Index()
        {
            HomeController controller = CreateHomeControllerAsAnonymousUser();

            ActionResult actionResult = controller.HumanVsHuman();

            Assert.IsInstanceOfType(actionResult, typeof(RedirectToRouteResult));

            RedirectToRouteResult routeResult = actionResult as RedirectToRouteResult;

            Assert.IsNotNull(routeResult);

            Assert.AreEqual(routeResult.RouteValues["action"], "Index");
        }

        [TestMethod]
        public void Authenticated_HumanVsHuman_Should_Return_PartialView()
        {
            HomeController controller = CreateHomeControllerAsAuthenticatedUser();

            ActionResult actionResult = controller.HumanVsHuman();

            Assert.IsInstanceOfType(actionResult, typeof(PartialViewResult));
        }
                    
        [TestMethod]
        public void Authenticated_HumanVsHuman_Should_Return_PartialView_Named_HumanVsHuman()
        {
            HomeController controller = CreateHomeControllerAsAuthenticatedUser();

            ActionResult actionResult = controller.HumanVsHuman();

            Assert.IsInstanceOfType(actionResult, typeof(PartialViewResult));

            PartialViewResult result = actionResult as PartialViewResult;

            Assert.IsNotNull(result);

            string expectedPartialViewName = "_HumanVsHuman";

            Assert.AreEqual(expectedPartialViewName, result.ViewName);
        }

        #endregion

        #region HumanVsComputer Tests

        [TestMethod]
        public void HumanVsComputer_Action_Should_Exist()
        {
            HomeController controller = CreateHomeControllerAsAnonymousUser();

            Assert.IsNotNull(controller);

            string indexActionName = nameof(controller.HumanVsComputer);

            Assert.AreEqual("HumanVsComputer", indexActionName);
        }

        [TestMethod]
        public void Anonymous_HumanVsComputer_Should_Redirect_To_Index()
        {
            HomeController controller = CreateHomeControllerAsAnonymousUser();

            ActionResult actionResult = controller.HumanVsComputer();

            Assert.IsInstanceOfType(actionResult, typeof(RedirectToRouteResult));

            RedirectToRouteResult routeResult = actionResult as RedirectToRouteResult;

            Assert.IsNotNull(routeResult);

            Assert.AreEqual(routeResult.RouteValues["action"], "Index");
        }

        [TestMethod]
        public void Authenticated_HumanVsComputer_Should_Return_PartialView()
        {
            HomeController controller = CreateHomeControllerAsAuthenticatedUser();

            ActionResult actionResult = controller.HumanVsComputer();

            Assert.IsInstanceOfType(actionResult, typeof(PartialViewResult));
        }

        [TestMethod]
        public void Authenticated_HumanVsComputer_Should_Return_PartialView_Named_HumanVsComputer()
        {
            HomeController controller = CreateHomeControllerAsAuthenticatedUser();

            ActionResult actionResult = controller.HumanVsComputer();

            Assert.IsInstanceOfType(actionResult, typeof(PartialViewResult));

            PartialViewResult result = actionResult as PartialViewResult;

            Assert.IsNotNull(result);

            string expectedPartialViewName = "_HumanVsComputer";

            Assert.AreEqual(expectedPartialViewName, result.ViewName);
        }

        #endregion

        #region ComputerVsComputer Tests

        [TestMethod]
        public void ComputerVsComputer_Action_Should_Exist()
        {
            HomeController controller = CreateHomeControllerAsAnonymousUser();

            Assert.IsNotNull(controller);

            string indexActionName = nameof(controller.ComputerVsComputer);

            Assert.AreEqual("ComputerVsComputer", indexActionName);
        }

        [TestMethod]
        public void Anonymous_ComputerVsComputer_Should_Redirect_To_Index()
        {
            HomeController controller = CreateHomeControllerAsAnonymousUser();

            ActionResult actionResult = controller.ComputerVsComputer();

            Assert.IsInstanceOfType(actionResult, typeof(RedirectToRouteResult));

            RedirectToRouteResult routeResult = actionResult as RedirectToRouteResult;

            Assert.IsNotNull(routeResult);

            Assert.AreEqual(routeResult.RouteValues["action"], "Index");
        }

        [TestMethod]
        public void Authenticated_ComputerVsComputer_Should_Return_PartialView()
        {
            HomeController controller = CreateHomeControllerAsAuthenticatedUser();

            ActionResult actionResult = controller.ComputerVsComputer();

            Assert.IsInstanceOfType(actionResult, typeof(PartialViewResult));
        }

        [TestMethod]
        public void Authenticated_ComputerVsComputer_Should_Return_PartialView_Named_ComputerVsComputer()
        {
            HomeController controller = CreateHomeControllerAsAuthenticatedUser();

            ActionResult actionResult = controller.ComputerVsComputer();

            Assert.IsInstanceOfType(actionResult, typeof(PartialViewResult));

            PartialViewResult result = actionResult as PartialViewResult;

            Assert.IsNotNull(result);

            string expectedPartialViewName = "_ComputerVsComputer";

            Assert.AreEqual(expectedPartialViewName, result.ViewName);
        }

        #endregion

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
        /// <returns>Mock<IPrincipal></IPrincipal></returns>
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
        /// <returns>Mock<IPrincipal></IPrincipal></returns>
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