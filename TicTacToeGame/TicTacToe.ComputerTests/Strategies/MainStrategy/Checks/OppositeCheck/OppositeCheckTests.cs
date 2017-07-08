namespace TicTacToe.ComputerTests.Strategies.MainStrategy.Checks.InnerCheck
{
    using Computer.Models;
    using Computer.Constants;
    using Computer.Strategies.MainStrategy.Checks.InnerCheck;
    using TicTacToeCommon.Constants;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using DataMockHelper;

    [TestClass]
    public class OppositeCheckTests
    {
        private DataMockHelper dataLayerMockHelper;

        public OppositeCheckTests()
        {
            this.dataLayerMockHelper = new DataMockHelper();
        }

        [TestMethod]
        public void OppositeCheck_Should_Return_Null_If_All_Acceptable_Tiles_Are_Taken_And_There_Is_No_Successor_Set()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopMiddleTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomMiddleTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleRightTile, ComputerConstants.HomeSideSign);

            OppositeTileCheck oppositeCheck = new OppositeTileCheck();

            var result = oppositeCheck.GetMove(model.Tiles);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Should_Return_BottomMiddle_Tile_If_Free_And_TopMiddle_Tile_Is_Taken()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopMiddleTile, ComputerConstants.HomeSideSign);

            OppositeTileCheck oppositeCheck = new OppositeTileCheck();

            var result = oppositeCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.BottomMiddleTile, result);
        }

        [TestMethod]
        public void Should_Return_TopMiddle_Tile_If_Free_And_BottomMiddle_Tile_Is_Taken()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomMiddleTile, ComputerConstants.HomeSideSign);

            OppositeTileCheck oppositeCheck = new OppositeTileCheck();

            var result = oppositeCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.TopMiddleTile, result);
        }

        [TestMethod]
        public void Should_Return_MiddleRight_Tile_If_Free_And_MiddleLeft_Tile_Is_Taken()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleLeftTile, ComputerConstants.HomeSideSign);

            OppositeTileCheck oppositeCheck = new OppositeTileCheck();

            var result = oppositeCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.MiddleRightTile, result);
        }

        [TestMethod]
        public void Should_Return_MiddleLeft_Tile_If_Free_And_MiddleRight_Tile_Is_Taken()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleRightTile, ComputerConstants.HomeSideSign);

            OppositeTileCheck oppositeCheck = new OppositeTileCheck();

            var result = oppositeCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.MiddleLeftTile, result);
        }
    }
}