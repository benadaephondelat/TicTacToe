namespace TicTacToe.ComputerTests.Strategies.MainStrategy.Checks.CanWinCheck
{
    using Computer.Constants;
    using Computer.Models;
    using DataMockHelper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Computer.Strategies.MainStrategy.Checks.CanWinCheck;
    using TicTacToeCommon.Constants;

    [TestClass]
    public class CanWinCheckTests
    {
        private DataMockHelper dataMockHelper;

        public CanWinCheckTests()
        {
            this.dataMockHelper = new DataMockHelper();
        }

        [TestMethod]
        public void CanWinCheck_Should_Return_Top_Right_Tile_If_It_Is_Empty_And_Top_Left_And_Top_Middle_Tiles_Are_Taken_By_The_Player_In_Turn()
        {
            ComputerGameModel model = this.dataMockHelper.CreateNewComputerVsHumanGame();

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.TopMiddleTile, ComputerConstants.HomeSideSign);

            CanWinCheck canWinCheck = new CanWinCheck(ComputerConstants.HomeSideSign);

            var result = canWinCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.TopRightTile, result);
        }

        [TestMethod]
        public void CanWinCheck_Should_Return_Top_Middle_Tile_If_It_Is_Empty_And_Top_Left_And_Top_Right_Tiles_Are_Taken_By_The_Player_In_Turn()
        {
            ComputerGameModel model = this.dataMockHelper.CreateNewComputerVsHumanGame();

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            CanWinCheck canWinCheck = new CanWinCheck(ComputerConstants.HomeSideSign);

            var result = canWinCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.TopMiddleTile, result);
        }

        [TestMethod]
        public void CanWinCheck_Should_Return_Top_Left_Tile_If_It_Is_Empty_And_Top_Middle_And_Top_Right_Tiles_Are_Taken_By_The_Player_In_Turn()
        {
            ComputerGameModel model = this.dataMockHelper.CreateNewComputerVsHumanGame();

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.TopMiddleTile, ComputerConstants.HomeSideSign);

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            CanWinCheck canWinCheck = new CanWinCheck(ComputerConstants.HomeSideSign);

            var result = canWinCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.TopLeftTile, result);
        }

        [TestMethod]
        public void CanWinCheck_Should_Return_Middle_Left_Tile_If_Is_Empty_And_Middle_Middle_And_Middle_Right_Tiles_Are_Taken_By_The_Player_In_Turn()
        {
            ComputerGameModel model = this.dataMockHelper.CreateNewComputerVsHumanGame();

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.HomeSideSign);

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleRightTile, ComputerConstants.HomeSideSign);

            CanWinCheck canWinCheck = new CanWinCheck(ComputerConstants.HomeSideSign);

            var result = canWinCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.MiddleLeftTile, result);
        }

        [TestMethod]
        public void CanWinCheck_Should_Return_Middle_Middle_Tile_If_Is_Empty_And_Middle_Left_And_Middle_Right_Tiles_Are_Taken_By_The_Player_In_Turn()
        {
            ComputerGameModel model = this.dataMockHelper.CreateNewComputerVsHumanGame();

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleLeftTile, ComputerConstants.HomeSideSign);

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleRightTile, ComputerConstants.HomeSideSign);

            CanWinCheck canWinCheck = new CanWinCheck(ComputerConstants.HomeSideSign);

            var result = canWinCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.MiddleMiddleTile, result);
        }

        [TestMethod]
        public void CanWinCheck_Should_Return_Middle_Right_Tile_If_Is_Empty_And_Middle_Left_And_Middle_Middle_Tiles_Are_Taken_By_The_Player_In_Turn()
        {
            ComputerGameModel model = this.dataMockHelper.CreateNewComputerVsHumanGame();

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleLeftTile, ComputerConstants.HomeSideSign);

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.HomeSideSign);

            CanWinCheck canWinCheck = new CanWinCheck(ComputerConstants.HomeSideSign);

            var result = canWinCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.MiddleRightTile, result);
        }

        [TestMethod]
        public void CanWinCheck_Should_Return_Bottom_Left_Tile_If_Is_Empty_And_Bottom_Middle_And_Bottom_Right_Tiles_Are_Taken_By_The_Player_In_Turn()
        {
            ComputerGameModel model = this.dataMockHelper.CreateNewComputerVsHumanGame();

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.BottomMiddleTile, ComputerConstants.HomeSideSign);

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.BottomRightTile, ComputerConstants.HomeSideSign);

            CanWinCheck canWinCheck = new CanWinCheck(ComputerConstants.HomeSideSign);

            var result = canWinCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.BottomLeftTile, result);
        }

        [TestMethod]
        public void CanWinCheck_Should_Return_Bottom_Middle_Tile_If_Is_Empty_And_Bottom_Left_And_Bottom_Right_Tiles_Are_Taken_By_The_Player_In_Turn()
        {
            ComputerGameModel model = this.dataMockHelper.CreateNewComputerVsHumanGame();

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.BottomRightTile, ComputerConstants.HomeSideSign);

            CanWinCheck canWinCheck = new CanWinCheck(ComputerConstants.HomeSideSign);

            var result = canWinCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.BottomMiddleTile, result);
        }

        [TestMethod]
        public void CanWinCheck_Should_Return_Bottom_Right_Tile_If_Is_Empty_And_Bottom_Left_And_Bottom_Middle_Tiles_Are_Taken_By_The_Player_In_Turn()
        {
            ComputerGameModel model = this.dataMockHelper.CreateNewComputerVsHumanGame();

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.BottomMiddleTile, ComputerConstants.HomeSideSign);

            CanWinCheck canWinCheck = new CanWinCheck(ComputerConstants.HomeSideSign);

            var result = canWinCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.BottomRightTile, result);
        }

        [TestMethod]
        public void CanWinCheck_Should_Return_Top_Left_Tile_If_Is_Empty_And_Middle_Left_And_Bottom_Left_Tiles_Are_Taken_By_The_Player_In_Turn()
        {
            ComputerGameModel model = this.dataMockHelper.CreateNewComputerVsHumanGame();

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleLeftTile, ComputerConstants.HomeSideSign);

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);

            CanWinCheck canWinCheck = new CanWinCheck(ComputerConstants.HomeSideSign);

            var result = canWinCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.TopLeftTile, result);
        }

        [TestMethod]
        public void CanWinCheck_Should_Return_Middle_Left_Tile_If_Is_Empty_And_Top_Left_And_Bottom_Left_Tiles_Are_Taken_By_The_Player_In_Turn()
        {
            ComputerGameModel model = this.dataMockHelper.CreateNewComputerVsHumanGame();

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);

            CanWinCheck canWinCheck = new CanWinCheck(ComputerConstants.HomeSideSign);

            var result = canWinCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.MiddleLeftTile, result);
        }

        [TestMethod]
        public void CanWinCheck_Should_Return_Bottom_Left_Tile_If_Is_Empty_And_Top_Left_And_Middle_Left_Tiles_Are_Taken_By_The_Player_In_Turn()
        {
            ComputerGameModel model = this.dataMockHelper.CreateNewComputerVsHumanGame();

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleLeftTile, ComputerConstants.HomeSideSign);

            CanWinCheck canWinCheck = new CanWinCheck(ComputerConstants.HomeSideSign);

            var result = canWinCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.BottomLeftTile, result);
        }

        [TestMethod]
        public void CanWinCheck_Should_Return_Top_Middle_Tile_If_Is_Empty_And_Middle_Middle_And_Bottom_Middle_Tiles_Are_Taken_By_The_Player_In_Turn()
        {
            ComputerGameModel model = this.dataMockHelper.CreateNewComputerVsHumanGame();

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.HomeSideSign);

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.BottomMiddleTile, ComputerConstants.HomeSideSign);

            CanWinCheck canWinCheck = new CanWinCheck(ComputerConstants.HomeSideSign);

            var result = canWinCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.TopMiddleTile, result);
        }

        [TestMethod]
        public void CanWinCheck_Should_Return_Middle_Middle_Tile_If_Is_Empty_And_Top_Middle_And_Bottom_Middle_Tiles_Are_Taken_By_The_Player_In_Turn()
        {
            ComputerGameModel model = this.dataMockHelper.CreateNewComputerVsHumanGame();

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.TopMiddleTile, ComputerConstants.HomeSideSign);

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.BottomMiddleTile, ComputerConstants.HomeSideSign);

            CanWinCheck canWinCheck = new CanWinCheck(ComputerConstants.HomeSideSign);

            var result = canWinCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.MiddleMiddleTile, result);
        }

        [TestMethod]
        public void CanWinCheck_Should_Return_Bottom_Middle_Tile_If_Is_Empty_And_Top_Middle_And_Middle_Middle_Tiles_Are_Taken_By_The_Player_In_Turn()
        {
            ComputerGameModel model = this.dataMockHelper.CreateNewComputerVsHumanGame();

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.TopMiddleTile, ComputerConstants.HomeSideSign);

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.HomeSideSign);

            CanWinCheck canWinCheck = new CanWinCheck(ComputerConstants.HomeSideSign);

            var result = canWinCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.BottomMiddleTile, result);
        }

        [TestMethod]
        public void CanWinCheck_Should_Return_Top_Right_Tile_If_Is_Empty_And_Middle_Right_And_Bottom_Right_Tiles_Are_Taken_By_The_Player_In_Turn()
        {
            ComputerGameModel model = this.dataMockHelper.CreateNewComputerVsHumanGame();

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleRightTile, ComputerConstants.HomeSideSign);

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.BottomRightTile, ComputerConstants.HomeSideSign);

            CanWinCheck canWinCheck = new CanWinCheck(ComputerConstants.HomeSideSign);

            var result = canWinCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.TopRightTile, result);
        }

        [TestMethod]
        public void CanWinCheck_Should_Return_Middle_Right_Tile_If_Is_Empty_And_Top_Right_And_Bottom_Right_Tiles_Are_Taken_By_The_Player_In_Turn()
        {
            ComputerGameModel model = this.dataMockHelper.CreateNewComputerVsHumanGame();

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.BottomRightTile, ComputerConstants.HomeSideSign);

            CanWinCheck canWinCheck = new CanWinCheck(ComputerConstants.HomeSideSign);

            var result = canWinCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.MiddleRightTile, result);
        }

        [TestMethod]
        public void CanWinCheck_Should_Return_Bottom_Right_Tile_If_Is_Empty_And_Top_Right_And_Middle_Right_Tiles_Are_Taken_By_The_Player_In_Turn()
        {
            ComputerGameModel model = this.dataMockHelper.CreateNewComputerVsHumanGame();

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleRightTile, ComputerConstants.HomeSideSign);

            CanWinCheck canWinCheck = new CanWinCheck(ComputerConstants.HomeSideSign);

            var result = canWinCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.BottomRightTile, result);
        }

        [TestMethod]
        public void CanWinCheck_Should_Return_Middle_Middle_Tile_If_Is_Empty_And_Top_Left_And_Bottom_Right_Tiles_Are_Taken_By_The_Player_In_Turn()
        {
            ComputerGameModel model = this.dataMockHelper.CreateNewComputerVsHumanGame();

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.BottomRightTile, ComputerConstants.HomeSideSign);

            CanWinCheck canWinCheck = new CanWinCheck(ComputerConstants.HomeSideSign);

            var result = canWinCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.MiddleMiddleTile, result);
        }

        [TestMethod]
        public void CanWinCheck_Should_Return_Middle_Middle_Tile_If_Is_Empty_And_Top_Right_And_Bottom_Left_Tiles_Are_Taken_By_The_Player_In_Turn()
        {
            ComputerGameModel model = this.dataMockHelper.CreateNewComputerVsHumanGame();

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            this.dataMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);

            CanWinCheck canWinCheck = new CanWinCheck(ComputerConstants.HomeSideSign);

            var result = canWinCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.MiddleMiddleTile, result);
        }

        [TestMethod]
        public void CanWinCheck_Should_Return_Null_If_The_Player_In_Turn_Can_Not_Win_And_There_Is_No_Successor_Set()
        {
            ComputerGameModel model = this.dataMockHelper.CreateNewComputerVsHumanGame();

            CanWinCheck canWinCheck = new CanWinCheck(ComputerConstants.HomeSideSign);

            var result = canWinCheck.GetMove(model.Tiles);

            Assert.IsNull(result);
        }
    }
}