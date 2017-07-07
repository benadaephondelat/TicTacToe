namespace TicTacToe.ComputerTests.Strategies.MainStrategy.Checks.ColumnsCheck
{
    using Computer.Models;
    using Computer.Constants;
    using Computer.Strategies.MainStrategy.Checks.ColumnsCheck;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TicTacToeCommon.Constants;
    using DataMockHelper;

    [TestClass]
    public class SecondColumnCheckTests
    {
        private DataMockHelper dataLayerMockHelper;

        public SecondColumnCheckTests()
        {
            this.dataLayerMockHelper = new DataMockHelper();
        }

        [TestMethod]
        public void SecondColumnCheck_Should_Return_Top_Middle_Tile_If_Middle_Middle_And_Bottom_Middle_Tiles_Has_The_Same_Value()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomMiddleTile, ComputerConstants.HomeSideSign);

            SecondColumnCheck secondColumnCheck = new SecondColumnCheck();

            int? computerMove = secondColumnCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.TopMiddleTile, computerMove);
        }

        [TestMethod]
        public void SecondColumnCheck_Should_Return_Middle_Middle_Tile_If_Top_Middle_And_Bottom_Middle_Tiles_Has_The_Same_Value()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopMiddleTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomMiddleTile, ComputerConstants.HomeSideSign);

            SecondColumnCheck secondColumnCheck = new SecondColumnCheck();

            int? computerMove = secondColumnCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.MiddleMiddleTile, computerMove);
        }

        [TestMethod]
        public void SecondColumnCheck_Should_Return_Bottom_Middle_Tile_If_Top_Middle_And_Middle_Middle_Tiles_Has_The_Same_Value()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopMiddleTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.HomeSideSign);

            SecondColumnCheck secondColumnCheck = new SecondColumnCheck();

            int? computerMove = secondColumnCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.BottomMiddleTile, computerMove);
        }

        [TestMethod]
        public void SecondColumnCheck_Should_Return_Null_If_All_Tiles_Are_Empty_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            SecondColumnCheck secondColumnCheck = new SecondColumnCheck();

            int? computerMove = secondColumnCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void SecondColumnCheck_Should_Return_Null_If_Only_Top_Middle_Tile_Is_Taken_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopMiddleTile, ComputerConstants.HomeSideSign);

            SecondColumnCheck secondColumnCheck = new SecondColumnCheck();

            int? computerMove = secondColumnCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void SecondColumnCheck_Should_Return_Null_If_Only_Middle_Middle_Tile_Is_Taken_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.HomeSideSign);

            SecondColumnCheck secondColumnCheck = new SecondColumnCheck();

            int? computerMove = secondColumnCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void SecondColumnCheck_Should_Return_Null_If_Only_Bottom_Middle_Tile_Is_Taken_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomMiddleTile, ComputerConstants.HomeSideSign);

            SecondColumnCheck secondColumnCheck = new SecondColumnCheck();

            int? computerMove = secondColumnCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }
    }
}