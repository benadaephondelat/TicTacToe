namespace TicTacToe.Web.Tests.Controllers
{
    using System.Web.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Web.Controllers;

    [TestClass]
    public class HumanVsHumanControllerTests
    {
        [TestMethod]
        public void HumanVsHuman_Controller_Should_Exist()
        {
            HumanVsHumanController controller = new HumanVsHumanController();

            Assert.IsNotNull(controller);
        }

        #region NewGame Tests

        [TestMethod]
        public void NewGame_Action_Should_Exist()
        {
            HumanVsHumanController controller = new HumanVsHumanController();

            Assert.AreEqual("NewGame", nameof(controller.NewGame));

            bool isActionResult = controller.NewGame() is ActionResult;

            Assert.AreEqual(true, isActionResult);
        }

        [TestMethod]
        public void Authenticated_NewGame_Should_Return_View()
        {
            HumanVsHumanController controller = new HumanVsHumanController();

            ActionResult actionResult = controller.NewGame();

            Assert.IsInstanceOfType(actionResult, typeof(ViewResult));
        }

        [TestMethod]
        public void Authenticated_NewGame_Should_Return_View_Named_NewGame()
        {
            HumanVsHumanController controller = new HumanVsHumanController();

            ActionResult actionResult = controller.NewGame();

            Assert.IsInstanceOfType(actionResult, typeof(ViewResult));

            ViewResult result = actionResult as ViewResult;

            string expectedPartialViewName = "NewGame";

            Assert.AreEqual(expectedPartialViewName, result.ViewName);
        }

        #endregion
    }
}