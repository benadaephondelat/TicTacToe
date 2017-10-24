namespace TicTacToe.DataLayer.Tests
{
    using System.Data.Entity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;

    [TestClass]
    public class ApplicationDbContextTests
    {
        [TestMethod]
        public void ApplicationDbContext_Should_Exist()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            Assert.IsNotNull(context);
        }

        [TestMethod]
        public void ApplicationDbContext_Create_Method_Should_Return_An_Instance_Of_ApplicationDbContext()
        {
            bool isValidCast = ApplicationDbContext.Create() is ApplicationDbContext;

            Assert.IsNotNull(isValidCast);
        }

        [TestMethod]
        public void ApplicationDbContext_Should_Have_IDbSet_Of_Game()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            Assert.IsTrue(context.Games is IDbSet<Game>);
        }

        [TestMethod]
        public void ApplicationDbContext_Should_Have_IDbSet_Of_Tile()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            Assert.IsTrue(context.Tiles is IDbSet<Tile>);
        }
    }
}