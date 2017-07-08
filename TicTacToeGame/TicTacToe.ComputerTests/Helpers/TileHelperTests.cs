namespace TicTacToe.ComputerTests.Helpers
{
    using System.Collections.Generic;
    using Computer.Helpers;
    using Computer.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Computer.Exceptions;

    [TestClass]
    public class TileHelperTests
    {
        private List<ComputerGameTileModel> gameTiles = new List<ComputerGameTileModel>();

        [TestMethod]
        public void GetTileByIndex_Should_Not_Throw_Exception_If_Index_Is_Valid()
        {
            this.PopulateGameTiles();

            for (int i = 0; i < 9; i++)
            {
                IComputerGameTileModel tile = TileHelper.GetTileByIndex(this.gameTiles, i);
            }

            Assert.IsTrue(true);
        }

        [TestMethod]
        [ExpectedException(typeof(ComputerException))]
        public void GetTileByIndex_Should_Throw_ComputerException_If_Tiles_Collection_Is_Null()
        {
            this.gameTiles = null;

            IComputerGameTileModel tile = TileHelper.GetTileByIndex(this.gameTiles, 2);
        }


        [TestMethod]
        [ExpectedException(typeof(ComputerException))]
        public void GetTileByIndex_Should_Throw_ComputerException_If_Tile_Index_Is_Not_In_Range()
        {
            this.gameTiles = null;

            IComputerGameTileModel tile = TileHelper.GetTileByIndex(this.gameTiles, 10);
        }

        [TestMethod]
        public void BothTilesAreTheSame_Should_Return_True_If_They_Are_The_Same()
        {
            bool result = TileHelper.BothTilesAreTheSame("X", "X");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void BothTilesAreTheSame_Should_Return_False_If_They_Are_Not_The_Same()
        {
            bool result = TileHelper.BothTilesAreTheSame("X", "O");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TileIsEmpty_Should_Return_True_If_Tile_Is_Empty()
        {
            bool result = TileHelper.TileIsEmpty(string.Empty);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TileIsEmpty_Should_Return_False_If_Tile_Is_Not_Empty()
        {
            bool result = TileHelper.TileIsEmpty("X");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TileIsNotEmpty_Should_Return_True_If_Tile_Is_Not_Empty()
        {
            bool result = TileHelper.TileIsNotEmpty("X");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TileIsNotEmpty_Should_Return_False_If_Tile_Is_Empty()
        {
            bool result = TileHelper.TileIsNotEmpty(string.Empty);

            Assert.IsFalse(result);
        }

        private void PopulateGameTiles()
        {
            string tileValue = string.Empty;

            for (var i = 0; i < 9; i++)
            {
                if (i % 2 == 0)
                {
                    tileValue = "X";
                }
                else
                {
                    tileValue = "O";
                }

                this.gameTiles.Add(new ComputerGameTileModel() { IsEmpty = false, Value = tileValue });
            }
        }
    }
}