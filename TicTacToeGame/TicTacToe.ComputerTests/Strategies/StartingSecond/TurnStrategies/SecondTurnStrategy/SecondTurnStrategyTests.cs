namespace TicTacToe.ComputerTests.Strategies.StartingSecond.TurnStrategies.SecondTurnStrategy
{
    using System.Linq;
    using Computer.Models;
    using Computer.Constants;
    using Computer.Strategies.StartingSecond.TurnStrategies.SecondTurnStrategy;
    using DataMockHelper;
    using TicTacToeCommon.Constants;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SecondTurnStrategyTests
    {
        private const int TestMethodsRunCount = 10000;

        private DataMockHelper dataLayerMockHelper;

        public SecondTurnStrategyTests()
        {
            this.dataLayerMockHelper = new DataMockHelper();
        }

        [TestMethod]
        public void GetMove_Should_Not_Throw_Exception()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            this.SimulateValidSecondTurnPreconditions(model);

            SecondTurnStrategy strat = new SecondTurnStrategy(model.Tiles);

            int? move = strat.GetMove();

            Assert.IsTrue(true);
        }

        private void SimulateValidSecondTurnPreconditions(ComputerGameModel model)
        {
            model.TurnsCount = 4;

            model.Tiles.ElementAt(TileConstants.TopLeftTile).Value = ComputerConstants.HomeSideSign;
            model.Tiles.ElementAt(TileConstants.TopLeftTile).IsEmpty = false;

            model.Tiles.ElementAt(TileConstants.MiddleMiddleTile).Value = ComputerConstants.AwaySideSign;
            model.Tiles.ElementAt(TileConstants.MiddleMiddleTile).IsEmpty = false;

            model.Tiles.ElementAt(TileConstants.TopRightTile).Value = ComputerConstants.HomeSideSign;
            model.Tiles.ElementAt(TileConstants.TopRightTile).IsEmpty = false;
        }


        [TestMethod]
        public void If_Oponent_Has_Made_Knight_Move_It_Should_Block_It()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            this.SimulateOponentKnightMove(model);

            SecondTurnStrategy strat = new SecondTurnStrategy(model.Tiles);

            int? move = strat.GetMove();

            Assert.AreEqual(TileConstants.BottomLeftTile, move);
        }

        private void SimulateOponentKnightMove(ComputerGameModel model)
        {
            model.TurnsCount = 4;

            model.Tiles.ElementAt(TileConstants.BottomMiddleTile).Value = ComputerConstants.HomeSideSign;
            model.Tiles.ElementAt(TileConstants.BottomMiddleTile).IsEmpty = false;

            model.Tiles.ElementAt(TileConstants.MiddleMiddleTile).Value = ComputerConstants.AwaySideSign;
            model.Tiles.ElementAt(TileConstants.MiddleMiddleTile).IsEmpty = false;

            model.Tiles.ElementAt(TileConstants.TopLeftTile).Value = ComputerConstants.HomeSideSign;
            model.Tiles.ElementAt(TileConstants.TopLeftTile).IsEmpty = false;
        }


        [TestMethod]
        public void If_Oponent_Has_Made_Rhombus_Move_It_Should_Block_It()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            this.SimulateOponentRhombusMove(model);

            SecondTurnStrategy strat = new SecondTurnStrategy(model.Tiles);

            int? move = strat.GetMove();

            Assert.AreEqual(TileConstants.TopLeftTile, move);
        }

        private void SimulateOponentRhombusMove(ComputerGameModel model)
        {
            model.TurnsCount = 4;

            model.Tiles.ElementAt(TileConstants.TopMiddleTile).Value = ComputerConstants.HomeSideSign;
            model.Tiles.ElementAt(TileConstants.TopMiddleTile).IsEmpty = false;

            model.Tiles.ElementAt(TileConstants.MiddleMiddleTile).Value = ComputerConstants.AwaySideSign;
            model.Tiles.ElementAt(TileConstants.MiddleMiddleTile).IsEmpty = false;

            model.Tiles.ElementAt(TileConstants.MiddleLeftTile).Value = ComputerConstants.HomeSideSign;
            model.Tiles.ElementAt(TileConstants.MiddleLeftTile).IsEmpty = false;
        }


        [TestMethod]
        public void If_Oponent_Has_Made_Two_Edges_Move_It_Should_Block_It()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            this.SimulateOponentTwoEdgesMove(model);

            SecondTurnStrategy strat = new SecondTurnStrategy(model.Tiles);

            int? move = strat.GetMove();

            Assert.AreEqual(TileConstants.TopMiddleTile, move);
        }

        private void SimulateOponentTwoEdgesMove(ComputerGameModel model)
        {
            model.TurnsCount = 4;

            model.Tiles.ElementAt(TileConstants.TopLeftTile).Value = ComputerConstants.HomeSideSign;
            model.Tiles.ElementAt(TileConstants.TopLeftTile).IsEmpty = false;

            model.Tiles.ElementAt(TileConstants.MiddleMiddleTile).Value = ComputerConstants.AwaySideSign;
            model.Tiles.ElementAt(TileConstants.MiddleMiddleTile).IsEmpty = false;

            model.Tiles.ElementAt(TileConstants.TopRightTile).Value = ComputerConstants.HomeSideSign;
            model.Tiles.ElementAt(TileConstants.TopRightTile).IsEmpty = false;
        }


        [TestMethod]
        public void If_Oponent_Has_Placed_On_TopLeft_And_TopMiddle_Tiles_It_Should_Choose_TopRight_Tile()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            this.SimulateNoneAggressiveMove(model);

            SecondTurnStrategy strat = new SecondTurnStrategy(model.Tiles);

            int? move = strat.GetMove();

            Assert.AreEqual(TileConstants.TopRightTile, move);
        }

        private void SimulateNoneAggressiveMove(ComputerGameModel model)
        {
            model.TurnsCount = 4;

            model.Tiles.ElementAt(TileConstants.TopLeftTile).Value = ComputerConstants.HomeSideSign;
            model.Tiles.ElementAt(TileConstants.TopLeftTile).IsEmpty = false;

            model.Tiles.ElementAt(TileConstants.MiddleMiddleTile).Value = ComputerConstants.AwaySideSign;
            model.Tiles.ElementAt(TileConstants.MiddleMiddleTile).IsEmpty = false;

            model.Tiles.ElementAt(TileConstants.TopMiddleTile).Value = ComputerConstants.HomeSideSign;
            model.Tiles.ElementAt(TileConstants.TopMiddleTile).IsEmpty = false;
        }
    }
}