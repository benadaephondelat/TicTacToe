namespace TicTacToe.ComputerTests.Strategies.MainStrategy.Checks.PossibleWinCheck.Checks
{
    using Computer.Constants;
    using Computer.Models;
    using Computer.Strategies.MainStrategy.Checks.PossibleWinCheck.Checks;
    using DataMockHelper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TicTacToeCommon.Constants;
    
    [TestClass]
    public class FirstColumnCheckTests
    {
        private DataMockHelper dataLayerMockHelper;

        public FirstColumnCheckTests()
        {
            this.dataLayerMockHelper = new DataMockHelper();
        }

        [TestMethod]
        public void FirstColumnCheck_Should_Return_Bottom_Left_If_MiddleLeft_Is_Taken_And_All_Other_Are_Free()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleLeftTile, ComputerConstants.HomeSideSign);

            FirstColumnCheck firstColumnCheck = new FirstColumnCheck(ComputerConstants.HomeSideSign);

            int? result = firstColumnCheck.GetMove(model.Tiles);

            Assert.IsNotNull(result);
            Assert.AreEqual(TileConstants.BottomLeftTile, result);
        }

        [TestMethod]
        public void FirstColumnCheck_Should_Return_Top_Left_Tile_If_BottomLeft_Is_Taken_And_All_Other_Tiles_Are_Free()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);

            FirstColumnCheck firstColumnCheck = new FirstColumnCheck(ComputerConstants.HomeSideSign);

            int? result = firstColumnCheck.GetMove(model.Tiles);

            Assert.IsNotNull(result);
            Assert.AreEqual(TileConstants.TopLeftTile, result);
        }

        [TestMethod]
        public void FirstColumnCheck_Should_Return_Middle_Left_Tile_If_TopLeft_Is_Taken_And_All_Other_Tiles_Are_Free()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            FirstColumnCheck firstColumnCheck = new FirstColumnCheck(ComputerConstants.HomeSideSign);

            int? result = firstColumnCheck.GetMove(model.Tiles);

            Assert.IsNotNull(result);
            Assert.AreEqual(TileConstants.MiddleLeftTile, result);
        }

        [TestMethod]
        public void FirstColumnCheck_Should_Return_Null_If_All_Tiles_Are_Empty_And_There_Is_No_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            FirstColumnCheck firstColumnCheck = new FirstColumnCheck(ComputerConstants.HomeSideSign);

            int? result = firstColumnCheck.GetMove(model.Tiles);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void FirstColumnCheck_Should_Return_Null_If_TopLeft_And_MiddleLeft_Are_Taken()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            FirstColumnCheck firstColumnCheck = new FirstColumnCheck(ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);
            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleLeftTile, ComputerConstants.HomeSideSign);

            int? computerMove = firstColumnCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void FirstColumnCheck_Should_Return_Null_If_TopLeft_And_BottomLeft_Are_Taken()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            FirstColumnCheck firstColumnCheck = new FirstColumnCheck(ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);
            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);

            int? computerMove = firstColumnCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void FirstColumnCheck_Should_Return_Null_If_MiddleLeft_And_TopLeft_Are_Taken()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            FirstColumnCheck firstColumnCheck = new FirstColumnCheck(ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleLeftTile, ComputerConstants.HomeSideSign);
            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            int? computerMove = firstColumnCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void FirstColumnCheck_Should_Return_Null_If_MiddleLeft_And_BottomLeft_Are_Taken()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            FirstColumnCheck firstColumnCheck = new FirstColumnCheck(ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.MiddleLeftTile, ComputerConstants.HomeSideSign);
            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);

            int? computerMove = firstColumnCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }
    }
}