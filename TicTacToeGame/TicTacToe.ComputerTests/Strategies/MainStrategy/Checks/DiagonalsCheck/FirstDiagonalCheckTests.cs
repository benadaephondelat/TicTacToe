namespace TicTacToe.ComputerTests.Strategies.MainStrategy.Checks.DiagonalsCheck
{
    using Computer.Constants;
    using Computer.Models;
    using Computer.Strategies.MainStrategy.Checks.DiagonalsCheck;
    using TicTacToeCommon.Constants;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using DataMockHelper;

    [TestClass]
    public class FirstDiagonalCheckTests
    {
        private DataMockHelper dataLayerMockHelper;

        public FirstDiagonalCheckTests()
        {
            this.dataLayerMockHelper = new DataMockHelper();
        }

        [TestMethod]
        public void FirstDiagonalCheck_Should_Return_Top_Left_Tile_If_Middle_Middle_And_Bottom_Right_Tiles_Has_The_Same_Value()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomRightTile, ComputerConstants.HomeSideSign);

            FirstDiagonalCheck firstDiagonalCheck = new FirstDiagonalCheck();

            int? computerMove = firstDiagonalCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.TopLeftTile, computerMove);
        }

        [TestMethod]
        public void FirstDiagonalCheck_Should_Return_Middle_Middle_Tile_If_Top_Left_And_Bottom_Right_Tiles_Has_The_Same_Value()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomRightTile, ComputerConstants.HomeSideSign);

            FirstDiagonalCheck firstDiagonalCheck = new FirstDiagonalCheck();

            int? computerMove = firstDiagonalCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.MiddleMiddleTile, computerMove);
        }

        [TestMethod]
        public void FirstDiagonalCheck_Should_Return_Bottom_Right_Tile_If_Top_Left_And_Middle_Middle_Tiles_Has_The_Same_Value()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.HomeSideSign);

            FirstDiagonalCheck firstDiagonalCheck = new FirstDiagonalCheck();

            int? computerMove = firstDiagonalCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.BottomRightTile, computerMove);
        }

        [TestMethod]
        public void FirstDiagonalCheck_Should_Return_Null_If_All_Tiles_Are_Empty_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            FirstDiagonalCheck firstDiagonalCheck = new FirstDiagonalCheck();

            int? computerMove = firstDiagonalCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void FirstDiagonalCheck_Should_Return_Null_If_Only_TopLeft_Tile_Is_Taken_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            FirstDiagonalCheck firstDiagonalCheck = new FirstDiagonalCheck();

            int? computerMove = firstDiagonalCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void FirstDiagonalCheck_Should_Return_Null_If_Only_Middle_Middle_Tile_Is_Taken_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.HomeSideSign);

            FirstDiagonalCheck firstDiagonalCheck = new FirstDiagonalCheck();

            int? computerMove = firstDiagonalCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void FirstDiagonalCheck_Should_Return_Null_If_Only_Bottom_Left_Tile_Is_Taken_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);

            FirstDiagonalCheck firstDiagonalCheck = new FirstDiagonalCheck();

            int? computerMove = firstDiagonalCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }
    }
}