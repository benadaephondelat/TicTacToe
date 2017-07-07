namespace TicTacToe.ComputerTests.Strategies.MainStrategy.Checks.RowsCheck
{
    using Computer.Models;
    using Computer.Constants;
    using Computer.Strategies.MainStrategy.Checks.RowsCheck;
    using TicTacToeCommon.Constants;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using DataMockHelper;

    [TestClass]
    public class FirstRowCheckTests
    {
        private DataMockHelper dataLayerMockHelper;

        public FirstRowCheckTests()
        {
            this.dataLayerMockHelper = new DataMockHelper();
        }

        [TestMethod]
        public void FirstRowCheck_Should_Return_Top_Right_Tile_If_TopLeft_And_TopMiddle_Tiles_Has_The_Same_Value()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopMiddleTile, ComputerConstants.HomeSideSign);

            FirstRowCheck firstRowCheck = new FirstRowCheck();

            int? computerMove = firstRowCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.TopRightTile, computerMove); 
        }

        [TestMethod]
        public void FirstRowCheck_Should_Return_Top_Middle_Tile_If_TopLeft_And_TopRight_Tiles_Has_The_Same_Value()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            FirstRowCheck firstRowCheck = new FirstRowCheck();

            int? computerMove = firstRowCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.TopMiddleTile, computerMove);
        }

        [TestMethod]
        public void FirstRowCheck_Should_Return_Top_Left_Tile_If_TopMiddle_And_TopRight_Tiles_Has_The_Same_Value()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopMiddleTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            FirstRowCheck firstRowCheck = new FirstRowCheck();

            int? computerMove = firstRowCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.TopLeftTile, computerMove);
        }

        [TestMethod]
        public void FirstRowCheck_Should_Return_Null_If_All_Tiles_Are_Empty_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            FirstRowCheck firstRowCheck = new FirstRowCheck();

            int? computerMove = firstRowCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void FirstRowCheck_Should_Return_Null_If_Only_TopLeft_Tile_Is_Taken_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            FirstRowCheck firstRowCheck = new FirstRowCheck();

            int? computerMove = firstRowCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void FirstRowCheck_Should_Return_Null_If_Only_TopMiddle_Tile_Is_Taken_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopMiddleTile, ComputerConstants.HomeSideSign);

            FirstRowCheck firstRowCheck = new FirstRowCheck();

            int? computerMove = firstRowCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void FirstRowCheck_Should_Return_Null_If_Only_TopRight_Tile_Is_Taken_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            FirstRowCheck firstRowCheck = new FirstRowCheck();

            int? computerMove = firstRowCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }
    }
}