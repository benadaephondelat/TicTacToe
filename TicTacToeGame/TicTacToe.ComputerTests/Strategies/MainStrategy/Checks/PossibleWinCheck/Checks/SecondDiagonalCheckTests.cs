namespace TicTacToe.ComputerTests.Strategies.MainStrategy.Checks.PossibleWinCheck.Checks
{
    using Computer.Constants;
    using Computer.Models;
    using Computer.Strategies.MainStrategy.Checks.PossibleWinCheck.Checks;
    using DataMockHelper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TicTacToeCommon.Constants;

    [TestClass]
    public class SecondDiagonalCheckTests
    {
        private DataMockHelper dataLayerMockHelper;

        public SecondDiagonalCheckTests()
        {
            this.dataLayerMockHelper = new DataMockHelper();
        }

        [TestMethod]
        public void SecondDiagonalCheck_Should_Return_Top_Right_If_Bottom_Bottom_Left_Is_Taken_And_All_Other_Are_Free()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);

            SecondDiagonalCheck secondDiagonalCheck = new SecondDiagonalCheck(ComputerConstants.HomeSideSign);

            int? result = secondDiagonalCheck.GetMove(model.Tiles);

            Assert.IsNotNull(result);
            Assert.AreEqual(TileConstants.TopRightTile, result);
        }

        [TestMethod]
        public void SecondDiagonalCheck_Should_Return_Bottom_Left_Tile_If_Middle_Middle_Is_Taken_And_All_Other_Tiles_Are_Free()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.HomeSideSign);

            SecondDiagonalCheck secondDiagonalCheck = new SecondDiagonalCheck(ComputerConstants.HomeSideSign);

            int? result = secondDiagonalCheck.GetMove(model.Tiles);

            Assert.IsNotNull(result);
            Assert.AreEqual(TileConstants.BottomLeftTile, result);
        }

        [TestMethod]
        public void SecondDiagonalCheck_Should_Return_Middle_Middle_Tile_If_TopRight_Is_Taken_And_All_Other_Tiles_Are_Free()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            SecondDiagonalCheck secondDiagonalCheck = new SecondDiagonalCheck(ComputerConstants.HomeSideSign);

            int? result = secondDiagonalCheck.GetMove(model.Tiles);

            Assert.IsNotNull(result);
            Assert.AreEqual(TileConstants.MiddleMiddleTile, result);
        }

        [TestMethod]
        public void SecondDiagonalCheck_Should_Return_Null_If_All_Tiles_Are_Empty_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            SecondDiagonalCheck secondDiagonalCheck = new SecondDiagonalCheck(ComputerConstants.HomeSideSign);

            int? result = secondDiagonalCheck.GetMove(model.Tiles);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void SecondDiagonalCheck_Should_Return_Null_If_TopRight_And_Middle_Middle_Are_Taken()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            SecondDiagonalCheck secondDiagonalCheck = new SecondDiagonalCheck(ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);
            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.HomeSideSign);

            int? computerMove = secondDiagonalCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void SecondDiagonalCheck_Should_Return_Null_If_TopRight_And_BottomLeft_Are_Taken()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            SecondDiagonalCheck secondDiagonalCheck = new SecondDiagonalCheck(ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);
            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);

            int? computerMove = secondDiagonalCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void SecondDiagonalCheck_Should_Return_Null_If_MiddleMiddle_And_TopRight_Are_Taken()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            SecondDiagonalCheck secondDiagonalCheck = new SecondDiagonalCheck(ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.HomeSideSign);
            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            int? computerMove = secondDiagonalCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void SecondDiagonalCheck_Should_Return_Null_If_MiddleMiddle_And_BottomLeft_Are_Taken()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            SecondDiagonalCheck secondDiagonalCheck = new SecondDiagonalCheck(ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.HomeSideSign);
            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);

            int? computerMove = secondDiagonalCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }
    }
}