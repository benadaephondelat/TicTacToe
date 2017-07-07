namespace TicTacToe.ComputerTests.Strategies.MainStrategy.Checks.ColumnsCheck
{
    using Computer.Constants;
    using Computer.Models;
    using Computer.Strategies.MainStrategy.Checks.ColumnsCheck;
    using TicTacToeCommon.Constants;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using DataMockHelper;

    [TestClass]
    public class FirstColumnCheckTests
    {
        private DataMockHelper dataLayerMockHelper;

        public FirstColumnCheckTests()
        {
            this.dataLayerMockHelper = new DataMockHelper();
        }

        [TestMethod]
        public void FirstColumnCheck_Should_Return_Top_Left_Tile_If_Middle_Left_And_Bottom_Left_Tiles_Has_The_Same_Value()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);

            FirstColumnCheck firstColumnCheck = new FirstColumnCheck();

            int? computerMove = firstColumnCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.TopLeftTile, computerMove);
        }

        [TestMethod]
        public void FirstColumnCheck_Should_Return_Middle_Left_Tile_If_Top_Left_And_Bottom_Left_Tiles_Has_The_Same_Value()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);

            FirstColumnCheck firstColumnCheck = new FirstColumnCheck();

            int? computerMove = firstColumnCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.MiddleLeftTile, computerMove);
        }

        [TestMethod]
        public void FirstColumnCheck_Should_Return_Bottom_Left_Tile_If_Top_Left_And_Middle_Left_Tiles_Has_The_Same_Value()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleLeftTile, ComputerConstants.HomeSideSign);

            FirstColumnCheck firstColumnCheck = new FirstColumnCheck();

            int? computerMove = firstColumnCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.BottomLeftTile, computerMove);
        }

        [TestMethod]
        public void FirstColumnCheck_Should_Return_Null_If_All_Tiles_Are_Empty_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            FirstColumnCheck firstColumnCheck = new FirstColumnCheck();

            int? computerMove = firstColumnCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void FirstColumnCheck_Should_Return_Null_If_Only_TopLeft_Tile_Is_Taken_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            FirstColumnCheck firstColumnCheck = new FirstColumnCheck();

            int? computerMove = firstColumnCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void FirstColumnCheck_Should_Return_Null_If_Only_Middle_Left_Tile_Is_Taken_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleLeftTile, ComputerConstants.HomeSideSign);

            FirstColumnCheck firstColumnCheck = new FirstColumnCheck();

            int? computerMove = firstColumnCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void FirstColumnCheck_Should_Return_Null_If_Only_Bottom_Left_Tile_Is_Taken_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);

            FirstColumnCheck firstColumnCheck = new FirstColumnCheck();

            int? computerMove = firstColumnCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }
    }
}