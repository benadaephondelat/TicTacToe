namespace TicTacToe.ComputerTests.Strategies.StartingFirst.TurnStrategies.SecondTurnStrategy
{
    using Computer;
    using Computer.Models;
    using TicTacToeCommon.Constants;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using DataMockHelper;

    [TestClass]
    public class SecondTurnStrategyTests
    {
        private const int TestMethodsRunCount = 10;

        private DataMockHelper dataLayerMockHelper;

        public SecondTurnStrategyTests()
        {
            this.dataLayerMockHelper = new DataMockHelper();
        }

        [TestMethod]
        public void SecondTurnStrategy_Second_Turn_If_All_Edges_Are_Empty_Choose_One_Of_Them()
        {
            Computer computer = new Computer();

            for (var i = 0; i < TestMethodsRunCount; i++)
            {
                ComputerGameModel model = this.dataLayerMockHelper.CreateComputerVsHumanSecondTurnGame(TileConstants.TopMiddleTile);

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

        [TestMethod]
        public void SecondTurnStrategy_Second_Turn_If_Player_Chose_TopLeft_Computer_Must_Choose_TopRight_Or_BottomLeft()
        {
            Computer computer = new Computer();

            for (int i = 0; i < TestMethodsRunCount; i++)
            {
                ComputerGameModel model = this.dataLayerMockHelper.CreateComputerVsHumanSecondTurnGame(TileConstants.TopLeftTile);

                int computerMove = computer.GetComputerMoveIndex(model);

                Assert.IsTrue(computerMove == TileConstants.TopRightTile || computerMove == TileConstants.BottomLeftTile);
            }
        }

        [TestMethod]
        public void SecondTurnStrategy_Second_Turn_If_Player_Chose_TopRight_Computer_Must_Choose_TopLeft_Or_BottomRight()
        {
            Computer computer = new Computer();

            for (int i = 0; i < TestMethodsRunCount; i++)
            {
                ComputerGameModel model = this.dataLayerMockHelper.CreateComputerVsHumanSecondTurnGame(TileConstants.TopRightTile);

                int computerMove = computer.GetComputerMoveIndex(model);

                Assert.IsTrue(computerMove == TileConstants.TopLeftTile || computerMove == TileConstants.BottomRightTile);
            }
        }

        [TestMethod]
        public void SecondTurnStrategy_Second_Turn_If_Player_Chose_BottomLeft_Computer_Must_Choose_TopLeft_Or_BottomRight()
        {
            Computer computer = new Computer();

            for (int i = 0; i < TestMethodsRunCount; i++)
            {
                ComputerGameModel model = this.dataLayerMockHelper.CreateComputerVsHumanSecondTurnGame(TileConstants.BottomLeftTile);

                int computerMove = computer.GetComputerMoveIndex(model);

                Assert.IsTrue(computerMove == TileConstants.TopLeftTile || computerMove == TileConstants.BottomRightTile);
            }
        }

        [TestMethod]
        public void SecondTurnStrategy_Second_Turn_If_Player_Chose_BottomRight_Computer_Must_Choose_BottomLeft_Or_TopRight()
        {
            for (int i = 0; i < TestMethodsRunCount; i++)
            {
                ComputerGameModel model = this.dataLayerMockHelper.CreateComputerVsHumanSecondTurnGame(TileConstants.BottomRightTile);

                Computer computer = new Computer();

                int computerMove = computer.GetComputerMoveIndex(model);

                Assert.IsTrue(computerMove == TileConstants.BottomLeftTile || computerMove == TileConstants.TopRightTile);
            }
        }
    }
}