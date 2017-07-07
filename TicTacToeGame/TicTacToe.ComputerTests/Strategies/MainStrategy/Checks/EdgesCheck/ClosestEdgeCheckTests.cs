namespace TicTacToe.ComputerTests.Strategies.MainStrategy.Checks.EdgesCheck
{
    using Computer.Models;
    using Computer.Constants;
    using Computer.Strategies.MainStrategy.Checks.EdgesCheck;
    using TicTacToeCommon.Constants;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using DataMockHelper;

    [TestClass]
    public class ClosestEdgeCheckTests
    {
        private DataMockHelper dataLayerMockHelper;

        public ClosestEdgeCheckTests()
        {
            this.dataLayerMockHelper = new DataMockHelper();
        }

        [TestMethod]
        public void ClosestEdgeCheck_Should_Return_Null_If_All_Edges_Are_Empty()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            ClosestEdgeCheck closestEdgeCheck = new ClosestEdgeCheck();

            int? computerMove = closestEdgeCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void ClosestEdgeCheck_Shoult_Return_Null_If_All_Edges_Are_Not_Empty()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.AwaySideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomRightTile, ComputerConstants.AwaySideSign);

            ClosestEdgeCheck closestEdgeCheck = new ClosestEdgeCheck();

            int? computerMove = closestEdgeCheck.GetMove(model.Tiles);

            Assert.IsNull(computerMove);
        }

        [TestMethod]
        public void TopLeftCheck_TopLeft_Tile_Is_Taken_And_TopRight_Tile_Is_Empty_Choose_TopRight()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            ClosestEdgeCheck closestEdgeCheck = new ClosestEdgeCheck();

            int? computerMove = closestEdgeCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.TopRightTile, computerMove);
        }

        [TestMethod]
        public void TopLeftCheck_TopLeft_And_TopRight_Tiles_Are_Taken_Return_BottomLeft_If_Free()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            ClosestEdgeCheck closestEdgeCheck = new ClosestEdgeCheck();

            int? computerMove = closestEdgeCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.BottomLeftTile, computerMove);
        }

        [TestMethod]
        public void TopRightCheck_TopRight_Tile_Is_Taken_And_TopLeft_Tile_Is_Empty_Choose_TopLeft()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            ClosestEdgeCheck closestEdgeCheck = new ClosestEdgeCheck();

            int? computerMove = closestEdgeCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.TopLeftTile, computerMove);
        }

        [TestMethod]
        public void TopRightCheck_TopRight_TopLeft_And_BottomLeft_Tiles_Are_Taken_Return_BottomRight_If_Free()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);

            ClosestEdgeCheck closestEdgeCheck = new ClosestEdgeCheck();

            int? computerMove = closestEdgeCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.BottomRightTile, computerMove);
        }

        [TestMethod]
        public void BottomLeftCheck_BottomLeft_Tile_Is_Taken_And_TopLeft_Tile_Is_Empty_Choose_TopLeft()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);

            ClosestEdgeCheck closestEdgeCheck = new ClosestEdgeCheck();

            int? computerMove = closestEdgeCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.TopLeftTile, computerMove);
        }

        [TestMethod]
        public void BottomLeftCheck_BottomLeft_TopLeft_And_TopLeft_Tiles_Are_Taken_Return_BottomRight_If_Free()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            ClosestEdgeCheck closestEdgeCheck = new ClosestEdgeCheck();

            int? computerMove = closestEdgeCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.BottomRightTile, computerMove);
        }

        [TestMethod]
        public void BottomRightCheck_BottomRight_Tile_Is_Taken_And_TopRight_Tile_Is_Empty_Choose_TopRight()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomRightTile, ComputerConstants.HomeSideSign);

            ClosestEdgeCheck closestEdgeCheck = new ClosestEdgeCheck();

            int? computerMove = closestEdgeCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.TopRightTile, computerMove);
        }

        [TestMethod]
        public void BottomRightCheck_BottomRight_TopLeft_And_TopRight_Tiles_Are_Taken_Return_BottomLeft_If_Free()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.BottomRightTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopLeftTile, ComputerConstants.HomeSideSign);

            this.dataLayerMockHelper.SetTileValue(model.Tiles, TileConstants.TopRightTile, ComputerConstants.HomeSideSign);

            ClosestEdgeCheck closestEdgeCheck = new ClosestEdgeCheck();

            int? computerMove = closestEdgeCheck.GetMove(model.Tiles);

            Assert.AreEqual(TileConstants.BottomLeftTile, computerMove);
        }
    }
}