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
        
        /// <summary>
        /// Mocks HttpContext and Identity
        /// </summary>
        /// <returns>Mock<ControllerContext></ControllerContext></returns>
        public Mock<ControllerContext> SetupControllerContextMockForModelBindingTesting(NameValueCollection form)
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