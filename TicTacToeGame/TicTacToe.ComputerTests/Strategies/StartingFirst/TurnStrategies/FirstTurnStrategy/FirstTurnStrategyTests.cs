namespace TicTacToe.ComputerTests.Strategies.StartingFirst.TurnStrategies.FirstTurnStrategy
{
    using Computer;
    using Computer.Models;
    using TicTacToeCommon.Constants;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using DataMockHelper;

    [TestClass]
    public class FirstTurnStrategyTests
    {
        private DataMockHelper dataLayerMockHelper;

        public FirstTurnStrategyTests()
        {
            this.dataLayerMockHelper = new DataMockHelper();
        }

        [TestMethod]
        public void FirstStrategy_Should_Return_The_Center_Tile()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            Computer computer = new Computer();

            int computerMove = computer.GetComputerMoveIndex(model);

            Assert.AreEqual(TileConstants.MiddleMiddleTile, computerMove);
        }
    }
}