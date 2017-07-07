namespace TicTacToe.ComputerTests.Strategies.StartingSecond.TurnStrategies.SecondTurnStrategy.AggressiveMoveStrategy.Checks.TwoEdgesCheck
{
    using Computer.Constants;
    using Computer.Models;
    using Computer.Strategies.StartingSecond.TurnStrategies.SecondTurnStrategy.AggressiveMoveStrategy.Checks.TwoEdgesMoveCheck;
    using DataMockHelper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TicTacToeCommon.Constants;
    using Computer.Strategies.StartingSecond.TurnStrategies.SecondTurnStrategy.AggressiveMoveStrategy.Checks.RhombusMoveCheck;

    [TestClass]
    public class TwoEdgesMoveCheckTests
    {
        private DataMockHelper dataLayerMockHelper;

        public TwoEdgesMoveCheckTests()
        {
            this.dataLayerMockHelper = new DataMockHelper();
        }

        [TestMethod]
        public void Should_Return_Null_If_The_Oponent_Has_Not_Made_Two_Edges_Move_And_There_Is_No_Successor_Set()
        {
            IComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomMiddleTile, ComputerConstants.HomeSideSign);

            TwoEdgesMoveCheck twoEdgesMoveCheck = new TwoEdgesMoveCheck();

            int? result = twoEdgesMoveCheck.GetMove(model.Tiles);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Should_Return_Successor_Move_If_The_Oponent_Has_Not_Made_Two_Edges_Move_And_There_Is_Successor_Set()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopMiddleTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleLeftTile, ComputerConstants.HomeSideSign);

            TwoEdgesMoveCheck twoEdgesMoveCheck = new TwoEdgesMoveCheck();

            twoEdgesMoveCheck.SetSuccessor(new RhombusMoveCheck());

            int? result = twoEdgesMoveCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.TopLeftTile, result);
        }

        [TestMethod]
        public void If_The_Oponent_Has_Placed_On_TopLeft_And_TopRight_Tiles_Return_TopMiddle()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            TwoEdgesMoveCheck twoEdgesMoveCheck = new TwoEdgesMoveCheck();

            int? result = twoEdgesMoveCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.TopMiddleTile, result);
        }

        [TestMethod]
        public void If_The_Oponent_Has_Placed_On_BottomLeft_And_BottomRight_Tiles_Return_BottomMiddle()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomRightTile, ComputerConstants.HomeSideSign);

            TwoEdgesMoveCheck twoEdgesMoveCheck = new TwoEdgesMoveCheck();

            int? result = twoEdgesMoveCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.BottomMiddleTile, result);
        }

        [TestMethod]
        public void If_The_Oponent_Has_Placed_On_TopLeft_And_BottomLeft_Tiles_Return_MiddleLeft()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);

            TwoEdgesMoveCheck twoEdgesMoveCheck = new TwoEdgesMoveCheck();

            int? result = twoEdgesMoveCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.MiddleLeftTile, result);
        }

        [TestMethod]
        public void If_The_Oponent_Has_Placed_On_TopRight_And_BottomRight_Tiles_Return_MiddleRight()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomRightTile, ComputerConstants.HomeSideSign);

            TwoEdgesMoveCheck twoEdgesMoveCheck = new TwoEdgesMoveCheck();

            int? result = twoEdgesMoveCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.MiddleRightTile, result);
        }

        [TestMethod]
        public void If_The_Oponent_Has_Placed_On_TopLeft_And_BottomRight_Tiles_Return_TopMiddle()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomRightTile, ComputerConstants.HomeSideSign);

            TwoEdgesMoveCheck twoEdgesMoveCheck = new TwoEdgesMoveCheck();

            int? result = twoEdgesMoveCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.TopMiddleTile, result);
        }

        [TestMethod]
        public void If_The_Oponent_Has_Placed_On_TopRight_And_BottomLeft_Tiles_Return_BottomMiddle()
        {
            IComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);

            TwoEdgesMoveCheck twoEdgesMoveCheck = new TwoEdgesMoveCheck();

            int? result = twoEdgesMoveCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.BottomMiddleTile, result);
        }
    }
}