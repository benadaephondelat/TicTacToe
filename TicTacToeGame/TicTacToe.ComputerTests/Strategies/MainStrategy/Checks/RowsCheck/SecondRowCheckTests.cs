namespace TicTacToe.ComputerTests.Strategies.MainStrategy.Checks.RowsCheck
{
    using Computer.Models;
    using Computer.Constants;
    using Computer.Strategies.MainStrategy.Checks.RowsCheck;
    using TicTacToeCommon.Constants;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using DataMockHelper;

    [TestClass]
    public class SecondRowCheckTests
    {
        private DataMockHelper dataLayerMockHelper;

        public SecondRowCheckTests()
        {
            this.dataLayerMockHelper = new DataMockHelper();
        }

        [TestMethod]
        public void SecondRowCheck_Should_Return_Middle_Right_Tile_If_MiddleLeft_And_MiddleMiddle_Tiles_Has_The_Same_Value()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.HomeSideSign);

            SecondRowCheck secondRowCheck = new SecondRowCheck();

            int? computerMove = secondRowCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.MiddleRightTile, computerMove);
        }

        [TestMethod]
        public void SecondRowCheck_Should_Return_Middle_Middle_Tile_If_MiddleLeft_And_MiddleRight_Tiles_Has_The_Same_Value()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleRightTile, ComputerConstants.HomeSideSign);

            SecondRowCheck secondRowCheck = new SecondRowCheck();

            int? computerMove = secondRowCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.MiddleMiddleTile, computerMove);
        }

        [TestMethod]
        public void SecondRowCheck_Should_Return_Middle_Left_Tile_If_Middle_Middle_And_Middle_Right_Tiles_Has_The_Same_Value()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleRightTile, ComputerConstants.HomeSideSign);

            SecondRowCheck secondRowCheck = new SecondRowCheck();

            int? computerMove = secondRowCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.MiddleLeftTile, computerMove);
        }

        [TestMethod]
        public void SecondRowCheck_Should_Return_Null_If_All_Tiles_Are_Empty_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            SecondRowCheck firstRowCheck = new SecondRowCheck();

            int? computerMove = firstRowCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void SecondRowCheck_Should_Return_Null_If_Only_Middle_Left_Tile_Is_Taken_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleLeftTile, ComputerConstants.HomeSideSign);

            SecondRowCheck secondRowCheck = new SecondRowCheck();

            int? computerMove = secondRowCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void SecondRowCheck_Should_Return_Null_If_Only_Middle_Middle_Tile_Is_Taken_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleMiddleTile, ComputerConstants.HomeSideSign);

            SecondRowCheck firstRowCheck = new SecondRowCheck();

            int? computerMove = firstRowCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void SecondRowCheck_Should_Return_Null_If_Only_Middle_Right_Tile_Is_Taken_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleRightTile, ComputerConstants.HomeSideSign);

            SecondRowCheck secondRowCheck = new SecondRowCheck();

            int? computerMove = secondRowCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }
    }
}