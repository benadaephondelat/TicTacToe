namespace TicTacToe.Web.Tests.FrameworkExtentionsTests
{
    using System.Reflection;
    using System.Web.Mvc;
    using System.Security.Principal;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using FrameworkExtentions.UserIdentityHelpers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using FrameworkExtentions.ModelBinders;
    using Models.ComputerVsComputer.InputModels;
    using Constants;
    using Models.HumanVsComputer.InputModels;
    using Models.HumanVsHuman.InputModels;
    using FrameworkExtentions.Mappings;
    using System.Web;
    using System.Web.Routing;
    using Web.Controllers;
    using MockHelpers;
    using System;
    using FrameworkExtentions.Filters.ActionFilters;
    using ServiceLayer.Interfaces;

    [TestClass]
    public class FrameworkExtentionsTests
    {
        [TestMethod]
        public void UserIdentityHelper_Should_Return_True_If_User_Is_Authenticated()
        {
            Mock<IPrincipal> mockPrincipal = new Mock<IPrincipal>();

            mockPrincipal.Setup(p => p.Identity.Name).Returns("georgi_iliev@yahoo.com");
            mockPrincipal.Setup(p => p.Identity.IsAuthenticated).Returns(true);

            bool isAuthenticated = UserIdentityHelper.UserIsLoggedIn(mockPrincipal.Object);

            Assert.IsTrue(isAuthenticated);
        }

        [TestMethod]
        public void UserIdentityHelper_Should_Return_False_If_User_Is_Not_Authenticated()
        {
            Mock<IPrincipal> mockPrincipal = new Mock<IPrincipal>();

            mockPrincipal.Setup(p => p.Identity.Name).Returns(string.Empty);
            mockPrincipal.Setup(p => p.Identity.IsAuthenticated).Returns(false);

            bool isAuthenticated = UserIdentityHelper.UserIsLoggedIn(mockPrincipal.Object);

            Assert.IsFalse(isAuthenticated);
        }

        [TestMethod]
        public void NewComputerVsComputerGameModelBinder_Should_Return_NewComputerVsComputerGameInputModel()
        {
            NameValueCollection form = new NameValueCollection
            {
                { "Sides", MockConstants.ComputerUsername },
                { "Computers", MockConstants.ComputerUsername },
            };

            var model = new NewComputerVsComputerGameInputModel();

            var bindingContext = new ModelBindingContext()
            {
                ModelName = "NewComputerVsComputerGameInputModel",
            };

            var metadata = ModelMetadataProviders.Current.GetMetadataForType(null, typeof(NewComputerVsComputerGameInputModel));

            bindingContext.ModelMetadata = metadata;

            var binder = new NewComputerVsComputerGameModelBinder();

            Mock<ControllerContext> mockContext = this.SetupControllerContextMockForModelBindingTesting(form);

            NewComputerVsComputerGameInputModel result = binder.BindModel(mockContext.Object, bindingContext) as NewComputerVsComputerGameInputModel;

            Assert.AreEqual(MockConstants.ComputerUsername, result.StartingFirstUsername);
            Assert.AreEqual(MockConstants.ComputerUsername, result.OponentUsername);
        }

        [TestMethod]
        public void NewHumanVsComputerGameModelBinder_Should_Return_NewHumanVsComputerInputModel()
        {
            NameValueCollection form = new NameValueCollection
            {
                { "Sides", MockConstants.UserUsername },
                { "Computers", MockConstants.ComputerUsername },
            };

            var model = new NewHumanVsComputerInputModel();

            var bindingContext = new ModelBindingContext()
            {
                ModelName = "NewHumanVsComputerInputModel",
            };

            var metadata = ModelMetadataProviders.Current.GetMetadataForType(null, typeof(NewHumanVsComputerInputModel));

            bindingContext.ModelMetadata = metadata;

            var binder = new NewHumanVsComputerGameModelBinder();

            Mock<ControllerContext> mockContext = this.SetupControllerContextMockForModelBindingTesting(form);

            NewHumanVsComputerInputModel result = binder.BindModel(mockContext.Object, bindingContext) as NewHumanVsComputerInputModel;

            Assert.AreEqual(MockConstants.UserUsername, result.StartingFirstUsername);
            Assert.AreEqual(MockConstants.ComputerUsername, result.OponentUsername);
        }

        [TestMethod]
        public void NewHumanVsHumanGameModelBinder_Should_Return_NewHumanVsHumanGameInputModel()
        {
            NameValueCollection form = new NameValueCollection
            {
                { "Players", MockConstants.UserUsername },
            };

            var model = new NewHumanVsHumanGameInputModel();

            var bindingContext = new ModelBindingContext()
            {
                ModelName = "NewHumanVsHumanGameInputModel",
            };

            var metadata = ModelMetadataProviders.Current.GetMetadataForType(null, typeof(NewHumanVsHumanGameInputModel));

            bindingContext.ModelMetadata = metadata;

            var binder = new NewHumanVsHumanGameModelBinder();

            Mock<ControllerContext> mockContext = this.SetupControllerContextMockForModelBindingTesting(form);

            NewHumanVsHumanGameInputModel result = binder.BindModel(mockContext.Object, bindingContext) as NewHumanVsHumanGameInputModel;

            Assert.AreEqual(MockConstants.UserUsername, result.StartingFirstUsername);
        }

        [TestMethod]
        public void AutoMapper_Should_Not_Throw_Exception()
        {
            try
            {
                Assembly webAssembly = Assembly.Load("TicTacToe.Web");

                List<Assembly> executingAssembly = new List<Assembly>
                {
                    webAssembly
                };

                AutoMapperConfig autoMapperConfig = new AutoMapperConfig(executingAssembly);

                autoMapperConfig.LoadMappings();
            }
            catch
            {
                Assert.Fail();
            }

            Assert.IsTrue(true);
        }
        
        [TestMethod]
        public void CheckIfLoggedInFilter_Should_Redirect_To_HomeController_Index_Action_If_User_Is_Not_Logged_In()
        {
            Mock<ActionExecutingContext> filterContextMock = this.CreateFilterContextMock(false);

            CheckIfLoggedInFilter filter = new CheckIfLoggedInFilter();
            filter.OnActionExecuting(filterContextMock.Object);

            RedirectToRouteResult result = filterContextMock.Object.Result as RedirectToRouteResult;
            Assert.IsNotNull(result);

            object controllerName;
            bool isControllerPresent = result.RouteValues.TryGetValue("controller", out controllerName);
            Assert.AreEqual("Home", controllerName.ToString());

            object actionName;
            bool isActionPresent = result.RouteValues.TryGetValue("action", out actionName);
            Assert.AreEqual("Index", actionName.ToString());
        }

        [TestMethod]
        public void CheckIfLoggedInFilter_Result_Should_Not_Be_RedirectToRouteResult_If_User_Is_Logged_In()
        {
            Mock<ActionExecutingContext> filterContextMock = this.CreateFilterContextMock(true);

            CheckIfLoggedInFilter filter = new CheckIfLoggedInFilter();
            filter.OnActionExecuting(filterContextMock.Object);

            var result = filterContextMock.Object.Result;

            Assert.IsNotInstanceOfType(result, typeof(RedirectToRouteResult));
        }

        [TestMethod]
        public void CheckModelStateAjax_Should_Not_Do_Anything_If_The_Request_Is_Not_Ajax_Request()
        {
            Mock<ActionExecutingContext> filterContextMock = this.CreateFilterContextMock(true);

            CheckModelStateAjax filter = new CheckModelStateAjax();
            filter.OnActionExecuting(filterContextMock.Object);

            var result = filterContextMock.Object.Result;

            Assert.IsNull(result);
        }

        [TestMethod]
        public void CheckModelStateAjax_Should_Not_Do_Anything_If_The_Input_Model_Is_Valid()
        {
            Mock<ActionExecutingContext> filterContextMock = this.CreateFilterContextMock(true);
            filterContextMock.Setup(r => r.HttpContext.Request["X-Requested-With"]).Returns("XMLHttpRequest");

            CheckModelStateAjax filter = new CheckModelStateAjax();
            filter.OnActionExecuting(filterContextMock.Object);

            var result = filterContextMock.Object.Result;

            Assert.IsNull(result);
        }

        [TestMethod]
        public void CheckModelStateAjax_Should_Return_Model_State_Errors_As_JSON()
        {
            Mock<ActionExecutingContext> filterContextMock = new Mock<ActionExecutingContext>();
            RouteData routeData = new RouteData();
            Mock<HttpContextBase> httpContextMock = new Mock<HttpContextBase>();
            RequestContext requestContext = new RequestContext(httpContextMock.Object, routeData);
            HumanVsComputerController controller = new HumanVsComputerController();
            controller.ControllerContext = new ControllerContext(requestContext, controller);
            controller.ModelState.AddModelError("newModelError", "newModelErrorMessage");
            filterContextMock.SetupGet(f => f.Controller).Returns(controller);
            filterContextMock.Setup(r => r.HttpContext.Request["X-Requested-With"]).Returns("XMLHttpRequest");

            CheckModelStateAjax filter = new CheckModelStateAjax();
            filter.OnActionExecuting(filterContextMock.Object);

            var result = filterContextMock.Object.Result;
            Assert.IsInstanceOfType(result, typeof(JsonResult));

            JsonResult jsonResult = result as JsonResult;
            Assert.IsNotNull(jsonResult.Data);
        }

        [TestMethod]
        public void CheckModelState_Should_Not_Do_Anything_If_The_Input_Model_Is_Valid()
        {
            Mock<ActionExecutingContext> filterContextMock = this.CreateFilterContextMock(true);

            CheckModelStateFilter filter = new CheckModelStateFilter();
            filter.OnActionExecuting(filterContextMock.Object);

            var result = filterContextMock.Object.Result;

            Assert.IsNull(result);
        }

        [TestMethod]
        public void CheckModelState_Should_Return_ViewResult_If_The_Input_Model_Is_Not_Valid()
        {
            Mock<ActionExecutingContext> filterContextMock = new Mock<ActionExecutingContext>();
            RouteData routeData = new RouteData();
            Mock<HttpContextBase> httpContextMock = new Mock<HttpContextBase>();
            RequestContext requestContext = new RequestContext(httpContextMock.Object, routeData);
            HumanVsComputerController controller = new HumanVsComputerController();
            controller.ControllerContext = new ControllerContext(requestContext, controller);
            controller.ModelState.AddModelError("newModelError", "newModelErrorMessage");
            filterContextMock.SetupGet(f => f.Controller).Returns(controller);
            filterContextMock.SetupGet(f => f.ActionDescriptor.ActionName).Returns("SomeActionMethod");

            CheckModelStateFilter filter = new CheckModelStateFilter();
            filter.OnActionExecuting(filterContextMock.Object);

            var result = filterContextMock.Object.Result;
            Assert.IsInstanceOfType(result, typeof(ViewResult));

            ViewResult viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult);
        }

        private Mock<ActionExecutingContext> CreateFilterContextMock(bool isUserLoggedIn)
        {
            if (isUserLoggedIn)
            {
                return this.CreateFilterContextMockForLoggedInUser();
            }

            return this.CreateFilterContextMockForUnauthorizedUser();
        }

        private Mock<ActionExecutingContext> CreateFilterContextMockForLoggedInUser()
        {
            Mock<ActionExecutingContext> filterContextMock = new Mock<ActionExecutingContext>();

            RouteData routeData = new RouteData();
            routeData.Values.Add("controller", "HumanVsComputer");
            routeData.Values.Add("action", "NewGame");

            Mock<HttpContextBase> httpContextMock = new Mock<HttpContextBase>();
            RequestContext requestContext = new RequestContext(httpContextMock.Object, routeData);
            HumanVsComputerController controller = new HumanVsComputerController();

            controller.ControllerContext = new ControllerContext(requestContext, controller);

            filterContextMock.SetupGet(f => f.Controller).Returns(controller);
            filterContextMock.SetupGet(f => f.RouteData).Returns(routeData);
            filterContextMock.SetupGet(p => p.HttpContext.User.Identity.IsAuthenticated).Returns(true);
            filterContextMock.SetupGet(p => p.HttpContext.User.Identity.Name).Returns(MockConstants.UserUsername);
            filterContextMock.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);

            return filterContextMock;
        }

        private Mock<ActionExecutingContext> CreateFilterContextMockForUnauthorizedUser()
        {
            Mock<ActionExecutingContext> filterContextMock = new Mock<ActionExecutingContext>();

            RouteData routeData = new RouteData();
            routeData.Values.Add("controller", "HumanVsComputer");
            routeData.Values.Add("action", "NewGame");

            Mock<HttpContextBase> httpContextMock = new Mock<HttpContextBase>();
            RequestContext requestContext = new RequestContext(httpContextMock.Object, routeData);
            HumanVsComputerController controller = new HumanVsComputerController();

            controller.ControllerContext = new ControllerContext(requestContext, controller);

            filterContextMock.SetupGet(f => f.Controller).Returns(controller);
            filterContextMock.SetupGet(f => f.RouteData).Returns(routeData);
            filterContextMock.SetupGet(p => p.HttpContext.User.Identity.IsAuthenticated).Returns(false);
            filterContextMock.SetupGet(p => p.HttpContext.User.Identity.Name).Returns(string.Empty);
            filterContextMock.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(false);

            return filterContextMock;
        }

        private Mock<ControllerContext> SetupControllerContextMockForModelBindingTesting(NameValueCollection form)
        {
            Mock<ControllerContext> mockContext = new Mock<ControllerContext>();

            mockContext.SetupGet(p => p.HttpContext.User.Identity.IsAuthenticated).Returns(true);
            mockContext.SetupGet(p => p.HttpContext.User.Identity.Name).Returns(MockConstants.UserEmail);
            mockContext.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);
            mockContext.SetupGet(p => p.HttpContext.Request.Form).Returns(form);

            Mock<IPrincipal> mockPrincipal = new Mock<IPrincipal>();
            mockPrincipal.Setup(p => p.Identity.Name).Returns(MockConstants.UserEmail);
            mockPrincipal.Setup(p => p.Identity.IsAuthenticated).Returns(true);

            return mockContext;
        }
    }
}