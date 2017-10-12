namespace TicTacToe.ComputerTests.Strategies.MainStrategy.Checks.PossibleWinCheck.Checks
{
    using Computer.Constants;
    using Computer.Models;
    using Computer.Strategies.MainStrategy.Checks.PossibleWinCheck.Checks;
    using DataMockHelper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TicTacToeCommon.Constants;

    [TestClass]
    public class ThirdColumnCheckTests
    {
        private DataMockHelper dataLayerMockHelper;

        public ThirdColumnCheckTests()
        {
            this.dataLayerMockHelper = new DataMockHelper();
        }

        [TestMethod]
        public void ThirdColumnCheck_Should_Return_Top_Right_If_Bottom_Right_Is_Taken_And_All_Other_Are_Free()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomRightTile, ComputerConstants.HomeSideSign);

            ThirdColumnCheck thirdColumnCheck = new ThirdColumnCheck(ComputerConstants.HomeSideSign);

            int? result = thirdColumnCheck.GetMove(model.Tiles);

            Assert.IsNotNull(result);
            Assert.AreEqual(TileConstants.TopRightTile, result);
        }

        [TestMethod]
        public void ThirdColumnCheck_Should_Return_Bottom_Right_Tile_If_Middle_Right_Is_Taken_And_All_Other_Tiles_Are_Free()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleRightTile, ComputerConstants.HomeSideSign);

            ThirdColumnCheck thirdColumnCheck = new ThirdColumnCheck(ComputerConstants.HomeSideSign);

            int? result = thirdColumnCheck.GetMove(model.Tiles);

            Assert.IsNotNull(result);
            Assert.AreEqual(TileConstants.BottomRightTile, result);
        }

        [TestMethod]
        public void ThirdColumnCheck_Should_Return_Middle_Right_Tile_If_Top_Right_Is_Taken_And_All_Other_Tiles_Are_Free()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            ThirdColumnCheck thirdColumnCheck = new ThirdColumnCheck(ComputerConstants.HomeSideSign);

            int? result = thirdColumnCheck.GetMove(model.Tiles);

            Assert.IsNotNull(result);
            Assert.AreEqual(TileConstants.MiddleRightTile, result);
        }

        [TestMethod]
        public void ThirdColumnCheck_Should_Return_Null_If_All_Tiles_Are_Empty_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            ThirdColumnCheck thirdColumnCheck = new ThirdColumnCheck(ComputerConstants.HomeSideSign);

            int? result = thirdColumnCheck.GetMove(model.Tiles);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void ThirdColumnCheck_Should_Return_Null_If_Top_Right_And_Middle_Right_Are_Taken()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            ThirdColumnCheck thirdColumnCheck = new ThirdColumnCheck(ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);
            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleRightTile, ComputerConstants.HomeSideSign);

            int? computerMove = thirdColumnCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void ThirdColumnCheck_Should_Return_Null_If_Top_Right_And_Bottom_Bottom_Right_Are_Taken()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            ThirdColumnCheck thirdColumnCheck = new ThirdColumnCheck(ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);
            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomRightTile, ComputerConstants.HomeSideSign);

            int? computerMove = thirdColumnCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void ThirdColumnCheck_Should_Return_Null_If_Middle_Right_Bottom_Right_Are_Taken()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            ThirdColumnCheck thirdColumnCheck = new ThirdColumnCheck(ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleRightTile, ComputerConstants.HomeSideSign);
            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomRightTile, ComputerConstants.HomeSideSign);

            int? computerMove = thirdColumnCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void ThirdColumnCheck_Should_Return_Null_If_Middle_Right_And_Top_Right_Are_Taken()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            ThirdColumnCheck thirdColumnCheck = new ThirdColumnCheck(ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleRightTile, ComputerConstants.HomeSideSign);
            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            int? computerMove = thirdColumnCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }
    }
}