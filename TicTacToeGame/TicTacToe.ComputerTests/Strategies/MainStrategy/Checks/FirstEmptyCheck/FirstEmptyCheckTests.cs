namespace TicTacToe.ComputerTests.Strategies.MainStrategy.Checks.FirstEmptyCheck
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Computer.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TicTacToeCommon.Constants;
    using Computer.Constants;
    using Computer.Strategies.MainStrategy.Checks.FirstEmptyCheck;

    [TestClass]
    public class FirstEmptyCheckTests
    {
        private DataMockHelper.DataMockHelper dataLayerMockHelper;

        public FirstEmptyCheckTests()
        {
            this.dataLayerMockHelper = new DataMockHelper.DataMockHelper();
        }

        [TestMethod]
        public void Should_Return_Top_Left_Tile_If_All_Tiles_Are_Empty()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            FirstEmptyTileCheck firstEmptyCheck = new FirstEmptyTileCheck();

            var result = firstEmptyCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.TopLeftTile, result);
        }

        [TestMethod]
        public void Should_Return_Top_Middle_Tile_If_Top_Left_Tile_Is_Not_Empty()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            FirstEmptyTileCheck firstEmptyTileCheck = new FirstEmptyTileCheck();

            var result = firstEmptyTileCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.TopMiddleTile, result);
        }

        [TestMethod]
        public void Should_Return_Top_Right_Tile_If_Top_Left_And_Top_Middle_Tiles_Are_Not_Empty()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopMiddleTile, ComputerConstants.HomeSideSign);

            FirstEmptyTileCheck firstEmptyTileCheck = new FirstEmptyTileCheck();

            var result = firstEmptyTileCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.TopRightTile, result);
        }

        [TestMethod]
        public void Should_Return_Middle_Left_Tile_If_All_Top_Tiles_Are_Not_Empty()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopMiddleTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            FirstEmptyTileCheck firstEmptyTileCheck = new FirstEmptyTileCheck();

            var result = firstEmptyTileCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.MiddleLeftTile, result);
        }

        [TestMethod]
        public void Should_Return_Middle_Middle_Tile_If_All_Top_Tiles_And_Middle_Left_Tile_Are_Not_Empty()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopMiddleTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleLeftTile, ComputerConstants.HomeSideSign);

            FirstEmptyTileCheck firstEmptyTileCheck = new FirstEmptyTileCheck();

            var result = firstEmptyTileCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.MiddleMiddleTile, result);
        }

        [TestMethod]
        public void Should_Return_Middle_Right_Tile_If_All_Top_Tiles_And_Middle_Left_And_Middle_Middle_Tiles_Are_Not_Empty()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopMiddleTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleLeftTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.HomeSideSign);

            FirstEmptyTileCheck firstEmptyTileCheck = new FirstEmptyTileCheck();

            var result = firstEmptyTileCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.MiddleRightTile, result);
        }

        [TestMethod]
        public void Should_Return_Bottom_Left_Tile_If_All_Top_And_Middle_Tiles_Are_Not_Empty()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);
            
            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopMiddleTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleLeftTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleRightTile, ComputerConstants.HomeSideSign);

            FirstEmptyTileCheck firstEmptyTileCheck = new FirstEmptyTileCheck();

            var result = firstEmptyTileCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.BottomLeftTile, result);
        }

        [TestMethod]
        public void Should_Return_Bottom_Middle_Tile_If_All_Top_Middle_And_Bottom_Left_Tiles_Are_Not_Empty()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopMiddleTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleLeftTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleRightTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);

            FirstEmptyTileCheck firstEmptyTileCheck = new FirstEmptyTileCheck();

            var result = firstEmptyTileCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.BottomMiddleTile, result);
        }

        [TestMethod]
        public void Should_Return_Bottom_Right_Tile_If_All_Other_Tiles_Are_Not_Empty()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopMiddleTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleLeftTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleRightTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomMiddleTile, ComputerConstants.HomeSideSign);

            FirstEmptyTileCheck firstEmptyTileCheck = new FirstEmptyTileCheck();

            var result = firstEmptyTileCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.BottomRightTile, result);
        }

        [TestMethod]
        public void Should_Return_Null_If_All_Tiles_Are_Not_Empty_And_There_Is_No_Successor_Set()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopMiddleTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleLeftTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleRightTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomMiddleTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomRightTile, ComputerConstants.HomeSideSign);

            FirstEmptyTileCheck firstEmptyTileCheck = new FirstEmptyTileCheck();

            var result = firstEmptyTileCheck.GetMove(model.Tiles);

            Assert.IsNull(result);
        }
    }
}