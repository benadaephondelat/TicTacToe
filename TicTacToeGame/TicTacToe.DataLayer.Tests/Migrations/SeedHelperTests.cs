namespace TicTacToe.DataLayer.Tests.Migrations
{
    using System.Linq;
    using DataLayer.Migrations;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SeedHelperTests
    {
        private const string FirstComputerUsername = "computer@yahoo.com";

        private const string SecondComputerUsername = "other-computer@yahoo.com";

        private const string FirstHumanUserUsername = "georgi_iliev@yahoo.com";

        private const string SecondHumanUserUsername = "the-other-guy@yahoo.com";

        [TestMethod]
        public void SeedHelper_GetDefaultUsers_Should_Contain_4_Users()
        {
            SeedHelper helper = new SeedHelper();

            var users = helper.GetDefaultUsers();

            Assert.AreEqual(4, users.Count());
        }

        [TestMethod]
        public void SeedHelper_GetDefaultUsers_Should_Contain_FirstComputerUsername()
        {
            SeedHelper helper = new SeedHelper();

            var users = helper.GetDefaultUsers();

            var firstComputer = users.FirstOrDefault(u => u.UserName == FirstComputerUsername);

            Assert.AreEqual(FirstComputerUsername, firstComputer.UserName);
        }

        [TestMethod]
        public void SeedHelper_GetDefaultUsers_Should_Contain_SecondComputerUsername()
        {
            SeedHelper helper = new SeedHelper();

            var users = helper.GetDefaultUsers();

            var secondComputer = users.FirstOrDefault(u => u.UserName == SecondComputerUsername);

            Assert.AreEqual(SecondComputerUsername, secondComputer.UserName);
        }

        [TestMethod]
        public void SeedHelper_GetDefaultUsers_Should_Contain_FirstHumanUserUsername()
        {
            SeedHelper helper = new SeedHelper();

            var users = helper.GetDefaultUsers();

            var firstHuman = users.FirstOrDefault(u => u.UserName == FirstHumanUserUsername);

            Assert.AreEqual(FirstHumanUserUsername, firstHuman.UserName);
        }

        [TestMethod]
        public void SeedHelper_GetDefaultUsers_Should_Contain_SecondHumanUserUsername()
        {
            SeedHelper helper = new SeedHelper();

            var users = helper.GetDefaultUsers();

            var secondHuman = users.FirstOrDefault(u => u.UserName == SecondHumanUserUsername);

            Assert.AreEqual(SecondHumanUserUsername, secondHuman.UserName);
        }
    }
}