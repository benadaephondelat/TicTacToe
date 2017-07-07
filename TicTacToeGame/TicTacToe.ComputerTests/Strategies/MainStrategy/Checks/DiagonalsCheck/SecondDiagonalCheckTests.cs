namespace TicTacToe.ComputerTests.Strategies.MainStrategy.Checks.DiagonalsCheck
{
    using Computer.Constants;
    using Computer.Models;
    using Computer.Strategies.MainStrategy.Checks.DiagonalsCheck;
    using TicTacToeCommon.Constants;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using DataMockHelper;

    [TestClass]
    public class SecondDiagonalCheckTests
    {
        private DataMockHelper dataLayerMockHelper;

        public SecondDiagonalCheckTests()
        {
            this.dataLayerMockHelper = new DataMockHelper();
        }

        [TestMethod]
        public void SecondDiagonalCheck_Should_Return_Top_Right_Tile_If_Middle_Middle_And_Bottom_Left_Tiles_Has_The_Same_Value()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);

            SecondDiagonalCheck secondDiagonalCheck = new SecondDiagonalCheck();

            int? computerMove = secondDiagonalCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.TopRightTile, computerMove);
        }

        [TestMethod]
        public void SecondDiagonalCheck_Should_Return_Middle_Middle_Tile_If_Top_Right_And_Bottom_Left_Tiles_Has_The_Same_Value()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);

            SecondDiagonalCheck secondDiagonalCheck = new SecondDiagonalCheck();

            int? computerMove = secondDiagonalCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.MiddleMiddleTile, computerMove);
        }

        [TestMethod]
        public void SecondDiagonalCheck_Should_Return_Bottom_Left_Tile_If_Top_Right_And_Middle_Middle_Tiles_Has_The_Same_Value()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.HomeSideSign);

            SecondDiagonalCheck secondDiagonalCheck = new SecondDiagonalCheck();

            int? computerMove = secondDiagonalCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.BottomLeftTile, computerMove);
        }

        [TestMethod]
        public void SecondDiagonalCheck_Should_Return_Null_If_All_Tiles_Are_Empty_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            SecondDiagonalCheck secondDiagonalCheck = new SecondDiagonalCheck();

            int? computerMove = secondDiagonalCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void SecondDiagonalCheck_Should_Return_Null_If_Only_Right_Tile_Is_Taken_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            SecondDiagonalCheck secondDiagonalCheck = new SecondDiagonalCheck();

            int? computerMove = secondDiagonalCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void SecondDiagonalCheck_Should_Return_Null_If_Only_Middle_Middle_Tile_Is_Taken_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.HomeSideSign);

            SecondDiagonalCheck secondDiagonalCheck = new SecondDiagonalCheck();

            int? computerMove = secondDiagonalCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void SecondDiagonalCheck_Should_Return_Null_If_Only_Bottom_Left_Tile_Is_Taken_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);

            SecondDiagonalCheck secondDiagonalCheck = new SecondDiagonalCheck();

            int? computerMove = secondDiagonalCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }
    }
}