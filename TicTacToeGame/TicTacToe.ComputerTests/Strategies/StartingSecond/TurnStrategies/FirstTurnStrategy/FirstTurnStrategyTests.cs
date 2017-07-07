namespace TicTacToe.ComputerTests.Strategies.StartingSecond.TurnStrategies.FirstTurnStrategy
{
    using System.Linq;
    using Computer;
    using Computer.Models;
    using Computer.Constants;
    using TicTacToeCommon.Constants;
    using DataMockHelper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FirstTurnStrategyTests
    {
        private const int TestMethodsRunCount = 10000;

        private DataMockHelper dataLayerMockHelper;

        public FirstTurnStrategyTests()
        {
            this.dataLayerMockHelper = new DataMockHelper();
        }

        [TestMethod]
        public void FirstStrategy_Should_Return_The_Center_Tile_If_It_Is_Empty()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            model.TurnsCount = 2;

            Computer computer = new Computer();

            int computerMove = computer.GetComputerMoveIndex(model);

            Assert.AreEqual(TileConstants.MiddleMiddleTile, computerMove);
        }

        [TestMethod]
        public void FirstStrategy_If_Center_Tile_Is_Taken_Choose_One_Of_The_Edge_Tiles()
        {
            for (var i = 0; i < TestMethodsRunCount; i++)
            {
                ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

                model.TurnsCount = 2;
                model.Tiles.ElementAt(4).IsEmpty = false;
                model.Tiles.ElementAt(4).Value = ComputerConstants.HomeSideSign;

                Computer computer = new Computer();

                int computerMove = computer.GetComputerMoveIndex(model);

                bool isTopLeft = computerMove == TileConstants.TopLeftTile;

                bool isTopRight = computerMove == TileConstants.TopRightTile;

                bool isBottomLeft = computerMove == TileConstants.BottomLeftTile;

                bool isBottomRight = computerMove == TileConstants.BottomRightTile;

                bool hasComputerChosenAnEdge = isTopLeft == true || isTopRight == true ||
                                               isBottomLeft == true || isBottomRight == true;

                Assert.IsTrue(hasComputerChosenAnEdge);
            }
        }
    }
}