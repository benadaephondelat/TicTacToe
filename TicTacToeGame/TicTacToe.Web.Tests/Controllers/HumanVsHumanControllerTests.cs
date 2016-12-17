namespace TicTacToe.Web.Tests.Controllers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Web.Controllers;

    [TestClass]
    public class HumanVsHumanControllerTests
    {
        [TestMethod]
        public void HumanVsHuman_Controller_ShouldExist()
        {
            HumanVsHumanController controller = new HumanVsHumanController();

            Assert.IsNotNull(controller);
        }
    }
}