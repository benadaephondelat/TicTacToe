namespace TicTacToe.ComputerTests.Strategies.MainStrategy.Checks.PossibleWinCheck.Checks
{
    using Computer.Constants;
    using Computer.Models;
    using Computer.Strategies.MainStrategy.Checks.PossibleWinCheck.Checks;
    using DataMockHelper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TicTacToeCommon.Constants;
    
    [TestClass]
    public class FirstDiagonalCheckTests
    {
        private DataMockHelper dataLayerMockHelper;

        public FirstDiagonalCheckTests()
        {
            this.dataLayerMockHelper = new DataMockHelper();
        }

        [TestMethod]
        public void FirstDiagonalCheck_Should_Return_Top_Left_If_Bottom_Right_Is_Taken_And_All_Other_Are_Free()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomRightTile, ComputerConstants.HomeSideSign);

            FirstDiagonalCheck firstDiagonalCheck = new FirstDiagonalCheck(ComputerConstants.HomeSideSign);

            int? result = firstDiagonalCheck.GetMove(model.Tiles);

            Assert.IsNotNull(result);
            Assert.AreEqual(TileConstants.TopLeftTile, result);
        }

        [TestMethod]
        public void FirstDiagonalCheck_Should_Return_Bottom_Right_Tile_If_Middle_Middle_Is_Taken_And_All_Other_Tiles_Are_Free()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.HomeSideSign);

            FirstDiagonalCheck firstDiagonalCheck = new FirstDiagonalCheck(ComputerConstants.HomeSideSign);

            int? result = firstDiagonalCheck.GetMove(model.Tiles);

            Assert.IsNotNull(result);
            Assert.AreEqual(TileConstants.BottomRightTile, result);
        }

        [TestMethod]
        public void FirstDiagonalCheck_Should_Return_Middle_Middle_Tile_If_TopLeft_Is_Taken_And_All_Other_Tiles_Are_Free()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            FirstDiagonalCheck firstDiagonalCheck = new FirstDiagonalCheck(ComputerConstants.HomeSideSign);

            int? result = firstDiagonalCheck.GetMove(model.Tiles);

            Assert.IsNotNull(result);
            Assert.AreEqual(TileConstants.MiddleMiddleTile, result);
        }

        [TestMethod]
        public void FirstDiagonalCheck_Should_Return_Null_If_All_Tiles_Are_Empty_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            FirstDiagonalCheck firstDiagonalCheck = new FirstDiagonalCheck(ComputerConstants.HomeSideSign);

            int? result = firstDiagonalCheck.GetMove(model.Tiles);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void FirstDiagonalCheck_Should_Return_Null_If_TopLeft_And_Middle_Middle_Are_Taken()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            FirstDiagonalCheck firstDiagonalCheck = new FirstDiagonalCheck(ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);
            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.HomeSideSign);

            int? computerMove = firstDiagonalCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void FirstDiagonalCheck_Should_Return_Null_If_TopLeft_And_BottomRight_Are_Taken()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            FirstDiagonalCheck firstDiagonalCheck = new FirstDiagonalCheck(ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);
            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomRightTile, ComputerConstants.HomeSideSign);

            int? computerMove = firstDiagonalCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void FirstDiagonalCheck_Should_Return_Null_If_MiddleMiddle_And_TopLeft_Are_Taken()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            FirstDiagonalCheck firstDiagonalCheck = new FirstDiagonalCheck(ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.HomeSideSign);
            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            int? computerMove = firstDiagonalCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void FirstDiagonalCheck_Should_Return_Null_If_MiddleMiddle_And_BottomRight_Are_Taken()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            FirstDiagonalCheck firstDiagonalCheck = new FirstDiagonalCheck(ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.HomeSideSign);
            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomRightTile, ComputerConstants.HomeSideSign);

            int? computerMove = firstDiagonalCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }
    }
}