namespace TicTacToe.ComputerTests.Strategies.MainStrategy.Checks.PossibleWinCheck.Checks
{
    using Computer.Constants;
    using Computer.Models;
    using Computer.Strategies.MainStrategy.Checks.PossibleWinCheck.Checks;
    using DataMockHelper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TicTacToeCommon.Constants;

    [TestClass]
    public class ThirdRowCheckTests
    {
        private DataMockHelper dataLayerMockHelper;

        public ThirdRowCheckTests()
        {
            this.dataLayerMockHelper = new DataMockHelper();
        }

        [TestMethod]
        public void ThirdRowCheck_Should_Return_Bottom_Left_If_BottomRight_Is_Taken_And_All_Other_Are_Free()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomRightTile, ComputerConstants.HomeSideSign);

            ThirdRowCheck thirdRowCheck = new ThirdRowCheck(ComputerConstants.HomeSideSign);

            int? result = thirdRowCheck.GetMove(model.Tiles);

            Assert.IsNotNull(result);
            Assert.AreEqual(TileConstants.BottomLeftTile, result);
        }

        [TestMethod]
        public void ThirdRowCheck_Should_Return_Bottom_Right_Tile_If_BottomMiddle_Is_Taken_And_All_Other_Tiles_Are_Free()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomMiddleTile, ComputerConstants.HomeSideSign);

            ThirdRowCheck thirdRowCheck = new ThirdRowCheck(ComputerConstants.HomeSideSign);

            int? result = thirdRowCheck.GetMove(model.Tiles);

            Assert.IsNotNull(result);
            Assert.AreEqual(TileConstants.BottomRightTile, result);
        }

        [TestMethod]
        public void ThirdRowCheck_Should_Return_Bottom_Left_Tile_If_Bottom_Right_Is_Taken_And_All_Other_Tiles_Are_Free()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomRightTile, ComputerConstants.HomeSideSign);

            ThirdRowCheck thirdRowCheck = new ThirdRowCheck(ComputerConstants.HomeSideSign);

            int? result = thirdRowCheck.GetMove(model.Tiles);

            Assert.IsNotNull(result);
            Assert.AreEqual(TileConstants.BottomLeftTile, result);
        }

        [TestMethod]
        public void ThirdRowCheck_Should_Return_Null_If_All_Tiles_Are_Empty_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            ThirdRowCheck thirdRowCheck = new ThirdRowCheck(ComputerConstants.HomeSideSign);

            int? computerMove = thirdRowCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void ThirdRowCheck_Should_Return_Null_If_BottomLeft_And_BottomMiddle_Are_Taken()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            ThirdRowCheck thirdRowCheck = new ThirdRowCheck(ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);
            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomMiddleTile, ComputerConstants.HomeSideSign);

            int? computerMove = thirdRowCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void ThirdRowCheck_Should_Return_Null_If_BottomLeft_And_BottomRight_Are_Taken()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            ThirdRowCheck thirdRowCheck = new ThirdRowCheck(ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);
            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomRightTile, ComputerConstants.HomeSideSign);

            int? computerMove = thirdRowCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void ThirdRowCheck_Should_Return_Null_If_BottomMiddle_And_BottomLeft_Are_Taken()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            ThirdRowCheck thirdRowCheck = new ThirdRowCheck(ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomMiddleTile, ComputerConstants.HomeSideSign);
            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);

            int? computerMove = thirdRowCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void ThirdRowCheck_Should_Return_Null_If_BottomMiddle_And_BottomRight_Are_Taken()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            ThirdRowCheck thirdRowCheck = new ThirdRowCheck(ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomMiddleTile, ComputerConstants.HomeSideSign);
            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomRightTile, ComputerConstants.HomeSideSign);

            int? computerMove = thirdRowCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }
    }
}