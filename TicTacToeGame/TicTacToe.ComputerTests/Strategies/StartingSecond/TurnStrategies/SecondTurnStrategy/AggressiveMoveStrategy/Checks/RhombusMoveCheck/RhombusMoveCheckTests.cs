namespace TicTacToe.ComputerTests.Strategies.StartingSecond.TurnStrategies.SecondTurnStrategy.AggressiveMoveStrategy.Checks.RhombusMoveCheck
{
    using Computer.Constants;
    using Computer.Models;
    using Computer.Strategies.StartingSecond.TurnStrategies.SecondTurnStrategy.AggressiveMoveStrategy.Checks.TwoEdgesMoveCheck;
    using DataMockHelper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TicTacToeCommon.Constants;
    using Computer.Strategies.StartingSecond.TurnStrategies.SecondTurnStrategy.AggressiveMoveStrategy.Checks.RhombusMoveCheck;

    [TestClass]
    public class RhombusMoveCheckTests
    {
        private DataMockHelper dataLayerMockHelper;

        public RhombusMoveCheckTests()
        {
            this.dataLayerMockHelper = new DataMockHelper();
        }

        [TestMethod]
        public void Should_Return_Null_If_The_Oponent_Has_Not_Made_Rhombus_Move_And_There_Is_No_Successor_Set()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            RhombusMoveCheck knightMoveCheck = new RhombusMoveCheck();

            int? result = knightMoveCheck.GetMove(model.Tiles);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Should_Return_Successor_Move_If_The_Oponent_Has_Not_Made_Rhombus_Move_And_There_Is_Successor_Set()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            RhombusMoveCheck rhombusMoveCheck = new RhombusMoveCheck();

            rhombusMoveCheck.SetSuccessor(new TwoEdgesMoveCheck());

            int? result = rhombusMoveCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.TopMiddleTile, result);
        }

        [TestMethod]
        public void If_The_Oponent_Has_Placed_On_TopMiddle_And_MiddleRight_Tiles_Return_TopRight()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopMiddleTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleRightTile, ComputerConstants.HomeSideSign);

            RhombusMoveCheck rhombusMoveCheck = new RhombusMoveCheck();

            int? result = rhombusMoveCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.TopRightTile, result);
        }

        [TestMethod]
        public void If_The_Oponent_Has_Placed_On_MiddleRight_And_BottomMiddle_Tiles_Return_BottomRight()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleRightTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomMiddleTile, ComputerConstants.HomeSideSign);

            RhombusMoveCheck rhombusMoveCheck = new RhombusMoveCheck();

            int? result = rhombusMoveCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.BottomRightTile, result);
        }

        [TestMethod]
        public void If_The_Oponent_Has_Placed_On_BottomMiddle_And_MiddleLeft_Tiles_Return_BottomLeft()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomMiddleTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleLeftTile, ComputerConstants.HomeSideSign);

            RhombusMoveCheck rhombusMoveCheck = new RhombusMoveCheck();

            int? result = rhombusMoveCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.BottomLeftTile, result);
        }

        [TestMethod]
        public void If_The_Oponent_Has_Placed_On_MiddleLeft_And_TopMiddle_Tiles_Return_TopLeft()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopMiddleTile, ComputerConstants.HomeSideSign);

            RhombusMoveCheck rhombusMoveCheck = new RhombusMoveCheck();

            int? result = rhombusMoveCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.TopLeftTile, result);
        }
    }
}