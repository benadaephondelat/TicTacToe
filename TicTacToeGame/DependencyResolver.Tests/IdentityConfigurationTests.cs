namespace DependencyResolver.Tests
{
    using System;
    using IdentityConfiguration;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Owin;
    using Microsoft.Owin.Builder;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TicTacToe.Models;
    using TicTacToe.Web;
    using Microsoft.AspNet.Identity.Owin;
    using TicTacToe.DataLayer;

    [TestClass]
    public class IdentityConfigurationTests
    {
        [TestMethod]
        public void OwinConfiguration_ConfigureAuth_Should_Not_Throw_Exception()
        {
            try
            {
                Startup startupAuth = new Startup();

                AppBuilder builder = new AppBuilder();

                startupAuth.Configuration(builder);
            }
            catch
            {
                Assert.Fail();
            }

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ApplicationUserManager_Create_Should_Not_Throw_Exception()
        {
            try
            {
                IOwinContext context = new OwinContext();

                var dbContext = new ApplicationDbContext();

                context.Set<ApplicationDbContext>(dbContext);

                var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(dbContext));

                var options = new IdentityFactoryOptions<ApplicationUserManager>();

                ApplicationUserManager.Create(options, context);
            }
            catch
            {
                Assert.Fail();
            }

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ApplicationSignInManager_Create_Should_Not_Throw_Exception()
        {
            try
            {
                IOwinContext context = new OwinContext();

                var dbContext = new ApplicationDbContext();

                var userManagerTest = new ApplicationUserManager(new UserStore<ApplicationUser>(dbContext));

                context.Set<ApplicationUserManager>(userManagerTest);

                var userStore = new UserStore<ApplicationUser>(dbContext);

                var userManager = new ApplicationUserManager(userStore);

                ApplicationSignInManager signInManager = new ApplicationSignInManager(userManager, context.Authentication);

                ApplicationSignInManager.Create(new IdentityFactoryOptions<ApplicationSignInManager>(), context);
            }
            catch
            {
                Assert.Fail();
            }

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ApplicationSignInManager_CreateUserIdentityAsync_Should_Not_Throw_Exception()
        {
            try
            {
                IOwinContext context = new OwinContext();

                var dbContext = new ApplicationDbContext();

                var userManagerTest = new ApplicationUserManager(new UserStore<ApplicationUser>(dbContext));

                context.Set<ApplicationUserManager>(userManagerTest);

                var userStore = new UserStore<ApplicationUser>(dbContext);

                var userManager = new ApplicationUserManager(userStore);

                ApplicationSignInManager signInManager = new ApplicationSignInManager(userManager, context.Authentication);

                signInManager.CreateUserIdentityAsync(new ApplicationUser());
            }
            catch
            {
                Assert.Fail();
            }

            Assert.IsTrue(true);
        }
    }
}