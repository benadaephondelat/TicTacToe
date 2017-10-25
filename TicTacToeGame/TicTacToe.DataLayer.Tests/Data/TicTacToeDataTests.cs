namespace TicTacToe.DataLayer.Tests.Data
{
    using DataLayer.Data;
    using Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Repository;
    using Models;
    using DataLayer.Repository;

    [TestClass]
    public class TicTacToeDataTests
    {
        private ITicTacToeData data;
        
        [TestInitialize]
        public void SetUp()
        {
            this.data = new TicTacToeData(ApplicationDbContext.Create());
        }

        [TestMethod]
        public void TicTacToeData_Should_Have_ApplicationUsers_Repository()
        {
            bool isValidCast = data.Users is IGenericRepository<ApplicationUser>;

            Assert.IsTrue(isValidCast);
        }

        [TestMethod]
        public void TicTacToeData_Should_Have_Games_Repository()
        {
            bool isValidCast = data.Games is IGenericRepository<Game>;

            Assert.IsTrue(isValidCast);
        }

        [TestMethod]
        public void TicTacToeData_Should_Have_Tiles_Repository()
        {
            bool isValidCast = data.Tiles is IGenericRepository<Tile>;

            Assert.IsTrue(isValidCast);
        }

        [TestMethod]
        public void TicTacToeData_Should_Have_SaveChanges_Method()
        {
            data.SaveChanges();
        }

        [TestMethod]
        public void TicTacToeData_Should_Have_SaveChangesAsync()
        {
            data.SaveChangesAsync();
        }
    }
}