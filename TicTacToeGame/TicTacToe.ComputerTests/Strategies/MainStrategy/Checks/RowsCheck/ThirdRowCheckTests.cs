namespace TicTacToe.ComputerTests.Strategies.MainStrategy.Checks.RowsCheck
{
    using Computer.Models;
    using Computer.Constants;
    using Computer.Strategies.MainStrategy.Checks.RowsCheck;
    using TicTacToeCommon.Constants;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using DataMockHelper;

    [TestClass]
    public class ThirdRowCheckTests
    {
        private DataMockHelper dataLayerMockHelper;

        public ThirdRowCheckTests()
        {
            this.dataLayerMockHelper = new DataMockHelper();
        }

        [TestMethod]
        public void ThirdRowCheck_Should_Return_Bottom_Right_Tile_If_Bottom_Left_And_Bottom_Middle_Tiles_Has_The_Same_Value()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomMiddleTile, ComputerConstants.HomeSideSign);

            ThirdRowCheck thirdRowCheck = new ThirdRowCheck();

            int? computerMove = thirdRowCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.BottomRightTile, computerMove);
        }

        [TestMethod]
        public void ThirdRowCheck_Should_Return_Bottom_Middle_Tile_If_Bottom_Left_And_Bottom_Right_Tiles_Has_The_Same_Value()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomRightTile, ComputerConstants.HomeSideSign);

            ThirdRowCheck thirdRowCheck = new ThirdRowCheck();

            int? computerMove = thirdRowCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.BottomMiddleTile, computerMove);
        }

        [TestMethod]
        public void ThirdRowCheck_Should_Return_Bottom_Left_Tile_If_Bottom_Middle_And_Bottom_Right_Tiles_Has_The_Same_Value()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomMiddleTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomRightTile, ComputerConstants.HomeSideSign);

            ThirdRowCheck thirdRowCheck = new ThirdRowCheck();

            int? computerMove = thirdRowCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.BottomLeftTile, computerMove);
        }

        [TestMethod]
        public void ThirdRowCheck_Should_Return_Null_If_All_Tiles_Are_Empty_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            ThirdRowCheck thirdRowCheck = new ThirdRowCheck();

            int? computerMove = thirdRowCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void ThirdRowCheck_Should_Return_Null_If_Only_Bottom_Left_Tile_Is_Taken_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);

            ThirdRowCheck thirdRowCheck = new ThirdRowCheck();

            int? computerMove = thirdRowCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void ThirdRowCheck_Should_Return_Null_If_Only_Bottom_Middle_Tile_Is_Taken_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomMiddleTile, ComputerConstants.HomeSideSign);

            ThirdRowCheck thirdRowCheck = new ThirdRowCheck();

            int? computerMove = thirdRowCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void ThirdRowCheck_Should_Return_Null_If_Only_Bottom_Right_Tile_Is_Taken_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomRightTile, ComputerConstants.HomeSideSign);

            ThirdRowCheck thirdRowCheck = new ThirdRowCheck();

            int? computerMove = thirdRowCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }
    }
}