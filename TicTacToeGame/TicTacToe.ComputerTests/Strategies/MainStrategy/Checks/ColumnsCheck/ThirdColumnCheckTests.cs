namespace TicTacToe.ComputerTests.Strategies.MainStrategy.Checks.ColumnsCheck
{
    using Computer.Constants;
    using Computer.Models;
    using Computer.Strategies.MainStrategy.Checks.ColumnsCheck;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TicTacToeCommon.Constants;
    using DataMockHelper;

    [TestClass]
    public class ThirdColumnCheckTests
    {
        private DataMockHelper dataLayerMockHelper;

        public ThirdColumnCheckTests()
        {
            this.dataLayerMockHelper = new DataMockHelper();
        }

        [TestMethod]
        public void ThirdColumnCheck_Should_Return_Top_Right_Tile_If_Middle_Right_And_Bottom_Right_Tiles_Has_The_Same_Value()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleRightTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomRightTile, ComputerConstants.HomeSideSign);

            ThirdColumnCheck thirdColumnCheck = new ThirdColumnCheck();

            int? computerMove = thirdColumnCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.TopRightTile, computerMove);
        }

        [TestMethod]
        public void ThirdColumnCheck_Should_Return_Middle_Right_Tile_If_Top_Right_And_Bottom_Right_Tiles_Has_The_Same_Value()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomRightTile, ComputerConstants.HomeSideSign);

            ThirdColumnCheck thirdColumnCheck = new ThirdColumnCheck();

            int? computerMove = thirdColumnCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.MiddleRightTile, computerMove);
        }

        [TestMethod]
        public void ThirdColumnCheck_Should_Return_Bottom_Right_Tile_If_Top_Right_And_Middle_Right_Tiles_Has_The_Same_Value()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleRightTile, ComputerConstants.HomeSideSign);

            ThirdColumnCheck thirdColumnCheck = new ThirdColumnCheck();

            int? computerMove = thirdColumnCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.BottomRightTile, computerMove);
        }

        [TestMethod]
        public void ThirdColumnCheck_Should_Return_Null_If_All_Tiles_Are_Empty_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            ThirdColumnCheck thirdColumnCheck = new ThirdColumnCheck();

            int? computerMove = thirdColumnCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void ThirdColumnCheck_Should_Return_Null_If_Only_Top_Right_Tile_Is_Taken_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            ThirdColumnCheck thirdColumnCheck = new ThirdColumnCheck();

            int? computerMove = thirdColumnCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void ThirdColumnCheck_Should_Return_Null_If_Only_Middle_Right_Tile_Is_Taken_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleRightTile, ComputerConstants.HomeSideSign);

            ThirdColumnCheck thirdColumnCheck = new ThirdColumnCheck();

            int? computerMove = thirdColumnCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void ThirdColumnCheck_Should_Return_Null_If_Only_Bottom_Right_Tile_Is_Taken_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomRightTile, ComputerConstants.HomeSideSign);

            ThirdColumnCheck thirdColumnCheck = new ThirdColumnCheck();

            int? computerMove = thirdColumnCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }
    }
}