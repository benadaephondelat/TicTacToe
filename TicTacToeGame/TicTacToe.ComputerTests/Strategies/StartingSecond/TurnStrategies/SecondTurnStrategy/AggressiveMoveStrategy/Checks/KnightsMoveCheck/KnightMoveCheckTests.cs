namespace TicTacToe.ComputerTests.Strategies.StartingSecond.TurnStrategies.SecondTurnStrategy.AggressiveMoveStrategy.Checks.KnightsMoveCheck
{
    using Computer.Constants;
    using Computer.Models;
    using Computer.Strategies.StartingSecond.TurnStrategies.SecondTurnStrategy.AggressiveMoveStrategy.Checks.KnightMoveCheck;
    using Computer.Strategies.StartingSecond.TurnStrategies.SecondTurnStrategy.AggressiveMoveStrategy.Checks.TwoEdgesMoveCheck;
    using DataMockHelper;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using System.Reflection;
    using TicTacToeCommon.Constants;

    [TestClass]
    public class KnightMoveCheckTests
    {
        private DataMockHelper dataLayerMockHelper;

        public KnightMoveCheckTests()
        {
            this.dataLayerMockHelper = new DataMockHelper();
        }

        [TestMethod]
        public void Should_Return_Null_If_The_Oponent_Has_Not_Made_Knight_Move_And_There_Is_No_Successor_Set()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            KnightMoveCheck knightMoveCheck = new KnightMoveCheck();

            int? result = knightMoveCheck.GetMove(model.Tiles);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Should_Return_Successor_Move_If_The_Oponent_Has_Not_Made_Knight_Move_And_There_Is_Successor_Set()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            KnightMoveCheck knightMoveCheck = new KnightMoveCheck();

            knightMoveCheck.SetSuccessor(new EdgesMoveCheck());

            int? result = knightMoveCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.TopMiddleTile, result); 
        }

        [TestMethod]
        public void If_The_Oponent_Has_Placed_On_TopMiddle_And_BottomLeft_Tiles_Return_Top_Left()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopMiddleTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);

            KnightMoveCheck knightMoveCheck = new KnightMoveCheck();

            int? result = knightMoveCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.TopLeftTile, result);
        }

        [TestMethod]
        public void If_The_Oponent_Has_Placed_On_TopMiddle_And_BottomRight_Tiles_Return_TopRight()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopMiddleTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomRightTile, ComputerConstants.HomeSideSign);

            KnightMoveCheck knightMoveCheck = new KnightMoveCheck();

            int? result = knightMoveCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.TopRightTile, result);
        }

        [TestMethod]
        public void If_The_Oponent_Has_Placed_On_BottomMiddle_And_TopLeft_Tiles_Return_BottomLeft()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomMiddleTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            KnightMoveCheck knightMoveCheck = new KnightMoveCheck();

            int? result = knightMoveCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.BottomLeftTile, result);
        }

        [TestMethod]
        public void If_The_Oponent_Has_Placed_On_BottomMiddle_And_TopRight_Tiles_Return_BottomRight()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomMiddleTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            KnightMoveCheck knightMoveCheck = new KnightMoveCheck();

            int? result = knightMoveCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.BottomRightTile, result);
        }

        [TestMethod]
        public void If_The_Oponent_Has_Placed_On_MiddleLeft_And_TopRight_Tiles_Return_TopLeft()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            KnightMoveCheck knightMoveCheck = new KnightMoveCheck();

            int? result = knightMoveCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.TopLeftTile, result);
        }

        [TestMethod]
        public void If_The_Oponent_Has_Placed_On_MiddleLeft_And_BottomRight_Tiles_Return_BottomLeft()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomRightTile, ComputerConstants.HomeSideSign);

            KnightMoveCheck knightMoveCheck = new KnightMoveCheck();

            int? result = knightMoveCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.BottomLeftTile, result);
        }

        [TestMethod]
        public void If_The_Oponent_Has_Placed_On_MiddleRight_And_TopLeft_Tiles_Return_TopRight()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleRightTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            KnightMoveCheck knightMoveCheck = new KnightMoveCheck();

            int? result = knightMoveCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.TopRightTile, result);
        }

        [TestMethod]
        public void If_The_Oponent_Has_Placed_On_MiddleRight_And_BottomLeft_Tiles_Return_BottomRight()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleRightTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);

            KnightMoveCheck knightMoveCheck = new KnightMoveCheck();

            int? result = knightMoveCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.BottomRightTile, result);
        }
    }
}