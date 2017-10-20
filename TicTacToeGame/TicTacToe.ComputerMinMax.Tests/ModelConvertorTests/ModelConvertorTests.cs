namespace TicTacToe.ComputerMinMax.ModelConvertorTests.Tests
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ComputerTests.DataMockHelper;
    using Computer.Models;
    using ComputerImplementation.Enums;
    using TicTacToeCommon.Constants;
    using TicTacToeCommon.Exceptions.Computer;

    [TestClass]
    public class ModelConvertorTests
    {
        private const string X = "X";
        private const string O = "O";
        private const string EMPTY = "";

        private DataMockHelper dataLayerMockHelper;

        public ModelConvertorTests()
        {
            this.dataLayerMockHelper = new DataMockHelper();
        }

        #region ConvertGameTilesToCellValueMatrix

        [TestMethod]
        public void ConvertGameTilesToCellValueMatrix_Should_Convert_9_Empty_IComputerGameTileModel_To_Cell_Value_Matrix_That_Represents_Empty_Game()
        {
            IEnumerable<IComputerGameTileModel> emptyGame = this.dataLayerMockHelper.CreateNewComputerVsHumanGame().Tiles;

            CellValue[,] gameBoard = ModelConvertor.ModelConvertor.ConvertGameTilesToCellValueMatrix(emptyGame);

            Assert.AreEqual(CellValue.BLANK.ToString(), gameBoard[0, 0].ToString());
            Assert.AreEqual(CellValue.BLANK.ToString(), gameBoard[0, 1].ToString());
            Assert.AreEqual(CellValue.BLANK.ToString(), gameBoard[0, 2].ToString());

            Assert.AreEqual(CellValue.BLANK.ToString(), gameBoard[1, 0].ToString());
            Assert.AreEqual(CellValue.BLANK.ToString(), gameBoard[1, 1].ToString());
            Assert.AreEqual(CellValue.BLANK.ToString(), gameBoard[1, 2].ToString());

            Assert.AreEqual(CellValue.BLANK.ToString(), gameBoard[2, 0].ToString());
            Assert.AreEqual(CellValue.BLANK.ToString(), gameBoard[2, 1].ToString());
            Assert.AreEqual(CellValue.BLANK.ToString(), gameBoard[2, 2].ToString());
        }

        [TestMethod]
        public void ConvertGameTilesToCellValueMatrix_If_Top_Left_Is_Empty_Should_Return_Top_Left_Cell_Value_BLANK()
        {
            IEnumerable<IComputerGameTileModel> emptyGame = this.dataLayerMockHelper.CreateNewComputerVsHumanGame().Tiles;

            CellValue[,] gameBoard = ModelConvertor.ModelConvertor.ConvertGameTilesToCellValueMatrix(emptyGame);

            Assert.AreEqual(CellValue.BLANK.ToString(), gameBoard[0, 0].ToString());
        }

        [TestMethod]
        public void ConvertGameTilesToCellValueMatrix_If_Top_Left_Is_X_Should_Return_Top_Left_X()
        {
            IEnumerable<IComputerGameTileModel> emptyGame = this.dataLayerMockHelper.CreateNewComputerVsHumanGame().Tiles;

            this.dataLayerMockHelper.SetTileValue(emptyGame, TileConstants.TopLeftTile, X);

            CellValue[,] gameBoard = ModelConvertor.ModelConvertor.ConvertGameTilesToCellValueMatrix(emptyGame);

            Assert.AreEqual(CellValue.X.ToString(), gameBoard[0, 0].ToString());
        }

        [TestMethod]
        public void ConvertGameTilesToCellValueMatrix_If_Top_Left_Is_O_Should_Return_Top_Left_O()
        {
            IEnumerable<IComputerGameTileModel> emptyGame = this.dataLayerMockHelper.CreateNewComputerVsHumanGame().Tiles;

            this.dataLayerMockHelper.SetTileValue(emptyGame, TileConstants.TopLeftTile, O);

            CellValue[,] gameBoard = ModelConvertor.ModelConvertor.ConvertGameTilesToCellValueMatrix(emptyGame);

            Assert.AreEqual(CellValue.O.ToString(), gameBoard[0, 0].ToString());
        }

        [TestMethod]
        public void ConvertGameTilesToCellValueMatrix_If_Top_Middle_Is_Empty_Should_Return_Top_Middle_Cell_Value_BLANK()
        {
            IEnumerable<IComputerGameTileModel> emptyGame = this.dataLayerMockHelper.CreateNewComputerVsHumanGame().Tiles;

            CellValue[,] gameBoard = ModelConvertor.ModelConvertor.ConvertGameTilesToCellValueMatrix(emptyGame);

            Assert.AreEqual(CellValue.BLANK.ToString(), gameBoard[0, 1].ToString());
        }

        [TestMethod]
        public void ConvertGameTilesToCellValueMatrix_If_Top_Middle_Is_X_Should_Return_Top_Middle_X()
        {
            IEnumerable<IComputerGameTileModel> emptyGame = this.dataLayerMockHelper.CreateNewComputerVsHumanGame().Tiles;

            this.dataLayerMockHelper.SetTileValue(emptyGame, TileConstants.TopMiddleTile, X);

            CellValue[,] gameBoard = ModelConvertor.ModelConvertor.ConvertGameTilesToCellValueMatrix(emptyGame);

            Assert.AreEqual(CellValue.X.ToString(), gameBoard[0, 1].ToString());
        }

        [TestMethod]
        public void ConvertGameTilesToCellValueMatrix_If_Top_Middle_Is_O_Should_Return_Top_Middle_O()
        {
            IEnumerable<IComputerGameTileModel> emptyGame = this.dataLayerMockHelper.CreateNewComputerVsHumanGame().Tiles;

            this.dataLayerMockHelper.SetTileValue(emptyGame, TileConstants.TopMiddleTile, O);

            CellValue[,] gameBoard = ModelConvertor.ModelConvertor.ConvertGameTilesToCellValueMatrix(emptyGame);

            Assert.AreEqual(CellValue.O.ToString(), gameBoard[0, 1].ToString());
        }

        [TestMethod]
        public void ConvertGameTilesToCellValueMatrix_If_Top_Right_Is_Empty_Should_Return_Top_Right_Cell_Value_BLANK()
        {
            IEnumerable<IComputerGameTileModel> emptyGame = this.dataLayerMockHelper.CreateNewComputerVsHumanGame().Tiles;

            CellValue[,] gameBoard = ModelConvertor.ModelConvertor.ConvertGameTilesToCellValueMatrix(emptyGame);

            Assert.AreEqual(CellValue.BLANK.ToString(), gameBoard[0, 2].ToString());
        }

        [TestMethod]
        public void ConvertGameTilesToCellValueMatrix_If_Top_Right_Is_X_Should_Return_Top_Right_X()
        {
            IEnumerable<IComputerGameTileModel> emptyGame = this.dataLayerMockHelper.CreateNewComputerVsHumanGame().Tiles;

            this.dataLayerMockHelper.SetTileValue(emptyGame, TileConstants.TopRightTile, X);

            CellValue[,] gameBoard = ModelConvertor.ModelConvertor.ConvertGameTilesToCellValueMatrix(emptyGame);

            Assert.AreEqual(CellValue.X.ToString(), gameBoard[0, 2].ToString());
        }

        [TestMethod]
        public void ConvertGameTilesToCellValueMatrix_If_Top_Right_Is_O_Should_Return_Top_Right_O()
        {
            IEnumerable<IComputerGameTileModel> emptyGame = this.dataLayerMockHelper.CreateNewComputerVsHumanGame().Tiles;

            this.dataLayerMockHelper.SetTileValue(emptyGame, TileConstants.TopRightTile, O);

            CellValue[,] gameBoard = ModelConvertor.ModelConvertor.ConvertGameTilesToCellValueMatrix(emptyGame);

            Assert.AreEqual(CellValue.O.ToString(), gameBoard[0, 2].ToString());
        }

        [TestMethod]
        public void ConvertGameTilesToCellValueMatrix_If_Middle_Left_Is_Empty_Should_Return_Middle_Left_Cell_Value_BLANK()
        {
            IEnumerable<IComputerGameTileModel> emptyGame = this.dataLayerMockHelper.CreateNewComputerVsHumanGame().Tiles;

            CellValue[,] gameBoard = ModelConvertor.ModelConvertor.ConvertGameTilesToCellValueMatrix(emptyGame);

            Assert.AreEqual(CellValue.BLANK.ToString(), gameBoard[1, 0].ToString());
        }

        [TestMethod]
        public void ConvertGameTilesToCellValueMatrix_If_Middle_Left_Is_X_Should_Return_Middle_Left_X()
        {
            IEnumerable<IComputerGameTileModel> emptyGame = this.dataLayerMockHelper.CreateNewComputerVsHumanGame().Tiles;

            this.dataLayerMockHelper.SetTileValue(emptyGame, TileConstants.MiddleLeftTile, X);

            CellValue[,] gameBoard = ModelConvertor.ModelConvertor.ConvertGameTilesToCellValueMatrix(emptyGame);

            Assert.AreEqual(CellValue.X.ToString(), gameBoard[1, 0].ToString());
        }

        [TestMethod]
        public void ConvertGameTilesToCellValueMatrix_If_Middle_Left_Is_O_Should_Return_Middle_Left_O()
        {
            IEnumerable<IComputerGameTileModel> emptyGame = this.dataLayerMockHelper.CreateNewComputerVsHumanGame().Tiles;

            this.dataLayerMockHelper.SetTileValue(emptyGame, TileConstants.MiddleLeftTile, O);

            CellValue[,] gameBoard = ModelConvertor.ModelConvertor.ConvertGameTilesToCellValueMatrix(emptyGame);

            Assert.AreEqual(CellValue.O.ToString(), gameBoard[1, 0].ToString());
        }

        [TestMethod]
        public void ConvertGameTilesToCellValueMatrix_If_Middle_Middle_Is_Empty_Should_Return_Middle_Middle_Cell_Value_BLANK()
        {
            IEnumerable<IComputerGameTileModel> emptyGame = this.dataLayerMockHelper.CreateNewComputerVsHumanGame().Tiles;

            CellValue[,] gameBoard = ModelConvertor.ModelConvertor.ConvertGameTilesToCellValueMatrix(emptyGame);

            Assert.AreEqual(CellValue.BLANK.ToString(), gameBoard[1, 1].ToString());
        }

        [TestMethod]
        public void ConvertGameTilesToCellValueMatrix_If_Middle_Middle_Is_X_Should_Return_Middle_Middle_X()
        {
            IEnumerable<IComputerGameTileModel> emptyGame = this.dataLayerMockHelper.CreateNewComputerVsHumanGame().Tiles;

            this.dataLayerMockHelper.SetTileValue(emptyGame, TileConstants.MiddleMiddleTile, X);

            CellValue[,] gameBoard = ModelConvertor.ModelConvertor.ConvertGameTilesToCellValueMatrix(emptyGame);

            Assert.AreEqual(CellValue.X.ToString(), gameBoard[1, 1].ToString());
        }

        [TestMethod]
        public void ConvertGameTilesToCellValueMatrix_If_Middle_Middle_Is_O_Should_Return_Middle_Middle_O()
        {
            IEnumerable<IComputerGameTileModel> emptyGame = this.dataLayerMockHelper.CreateNewComputerVsHumanGame().Tiles;

            this.dataLayerMockHelper.SetTileValue(emptyGame, TileConstants.MiddleMiddleTile, O);

            CellValue[,] gameBoard = ModelConvertor.ModelConvertor.ConvertGameTilesToCellValueMatrix(emptyGame);

            Assert.AreEqual(CellValue.O.ToString(), gameBoard[1, 1].ToString());
        }

        [TestMethod]
        public void ConvertGameTilesToCellValueMatrix_If_Middle_Right_Is_Empty_Should_Return_Middle_Right_Cell_Value_BLANK()
        {
            IEnumerable<IComputerGameTileModel> emptyGame = this.dataLayerMockHelper.CreateNewComputerVsHumanGame().Tiles;

            CellValue[,] gameBoard = ModelConvertor.ModelConvertor.ConvertGameTilesToCellValueMatrix(emptyGame);

            Assert.AreEqual(CellValue.BLANK.ToString(), gameBoard[1, 2].ToString());
        }

        [TestMethod]
        public void ConvertGameTilesToCellValueMatrix_If_Middle_Right_Is_X_Should_Return_Middle_Right_X()
        {
            IEnumerable<IComputerGameTileModel> emptyGame = this.dataLayerMockHelper.CreateNewComputerVsHumanGame().Tiles;

            this.dataLayerMockHelper.SetTileValue(emptyGame, TileConstants.MiddleRightTile, X);

            CellValue[,] gameBoard = ModelConvertor.ModelConvertor.ConvertGameTilesToCellValueMatrix(emptyGame);

            Assert.AreEqual(CellValue.X.ToString(), gameBoard[1, 2].ToString());
        }

        [TestMethod]
        public void ConvertGameTilesToCellValueMatrix_If_Middle_Right_Is_O_Should_Return_Middle_Right_O()
        {
            IEnumerable<IComputerGameTileModel> emptyGame = this.dataLayerMockHelper.CreateNewComputerVsHumanGame().Tiles;

            this.dataLayerMockHelper.SetTileValue(emptyGame, TileConstants.MiddleRightTile, O);

            CellValue[,] gameBoard = ModelConvertor.ModelConvertor.ConvertGameTilesToCellValueMatrix(emptyGame);

            Assert.AreEqual(CellValue.O.ToString(), gameBoard[1, 2].ToString());
        }

        [TestMethod]
        public void ConvertGameTilesToCellValueMatrix_If_Bottom_Left_Is_Empty_Should_Return_Bottom_Left_Cell_Value_BLANK()
        {
            IEnumerable<IComputerGameTileModel> emptyGame = this.dataLayerMockHelper.CreateNewComputerVsHumanGame().Tiles;

            CellValue[,] gameBoard = ModelConvertor.ModelConvertor.ConvertGameTilesToCellValueMatrix(emptyGame);

            Assert.AreEqual(CellValue.BLANK.ToString(), gameBoard[2, 0].ToString());
        }

        [TestMethod]
        public void ConvertGameTilesToCellValueMatrix_If_Bottom_Left_Is_X_Should_Return_Bottom_Left_X()
        {
            IEnumerable<IComputerGameTileModel> emptyGame = this.dataLayerMockHelper.CreateNewComputerVsHumanGame().Tiles;

            this.dataLayerMockHelper.SetTileValue(emptyGame, TileConstants.BottomLeftTile, X);

            CellValue[,] gameBoard = ModelConvertor.ModelConvertor.ConvertGameTilesToCellValueMatrix(emptyGame);

            Assert.AreEqual(CellValue.X.ToString(), gameBoard[2, 0].ToString());
        }

        [TestMethod]
        public void ConvertGameTilesToCellValueMatrix_If_Bottom_Left_Is_O_Should_Return_Bottom_Left_O()
        {
            IEnumerable<IComputerGameTileModel> emptyGame = this.dataLayerMockHelper.CreateNewComputerVsHumanGame().Tiles;

            this.dataLayerMockHelper.SetTileValue(emptyGame, TileConstants.BottomLeftTile, O);

            CellValue[,] gameBoard = ModelConvertor.ModelConvertor.ConvertGameTilesToCellValueMatrix(emptyGame);

            Assert.AreEqual(CellValue.O.ToString(), gameBoard[2, 0].ToString());
        }

        [TestMethod]
        public void ConvertGameTilesToCellValueMatrix_If_Bottom_Middle_Is_Empty_Should_Return_Bottom_Middle_Cell_Value_BLANK()
        {
            IEnumerable<IComputerGameTileModel> emptyGame = this.dataLayerMockHelper.CreateNewComputerVsHumanGame().Tiles;

            CellValue[,] gameBoard = ModelConvertor.ModelConvertor.ConvertGameTilesToCellValueMatrix(emptyGame);

            Assert.AreEqual(CellValue.BLANK.ToString(), gameBoard[2, 1].ToString());
        }

        [TestMethod]
        public void ConvertGameTilesToCellValueMatrix_If_Bottom_Middle_Is_X_Should_Return_Bottom_Middle_X()
        {
            IEnumerable<IComputerGameTileModel> emptyGame = this.dataLayerMockHelper.CreateNewComputerVsHumanGame().Tiles;

            this.dataLayerMockHelper.SetTileValue(emptyGame, TileConstants.BottomMiddleTile, X);

            CellValue[,] gameBoard = ModelConvertor.ModelConvertor.ConvertGameTilesToCellValueMatrix(emptyGame);

            Assert.AreEqual(CellValue.X.ToString(), gameBoard[2, 1].ToString());
        }

        [TestMethod]
        public void ConvertGameTilesToCellValueMatrix_If_Bottom_Middle_Is_O_Should_Return_Bottom_Middle_O()
        {
            IEnumerable<IComputerGameTileModel> emptyGame = this.dataLayerMockHelper.CreateNewComputerVsHumanGame().Tiles;

            this.dataLayerMockHelper.SetTileValue(emptyGame, TileConstants.BottomMiddleTile, O);

            CellValue[,] gameBoard = ModelConvertor.ModelConvertor.ConvertGameTilesToCellValueMatrix(emptyGame);

            Assert.AreEqual(CellValue.O.ToString(), gameBoard[2, 1].ToString());
        }

        [TestMethod]
        public void ConvertGameTilesToCellValueMatrix_If_Bottom_Right_Is_Empty_Should_Return_Bottom_Right_Cell_Value_BLANK()
        {
            IEnumerable<IComputerGameTileModel> emptyGame = this.dataLayerMockHelper.CreateNewComputerVsHumanGame().Tiles;

            CellValue[,] gameBoard = ModelConvertor.ModelConvertor.ConvertGameTilesToCellValueMatrix(emptyGame);

            Assert.AreEqual(CellValue.BLANK.ToString(), gameBoard[2, 2].ToString());
        }

        [TestMethod]
        public void ConvertGameTilesToCellValueMatrix_If_Bottom_Right_Is_X_Should_Return_Bottom_Right_X()
        {
            IEnumerable<IComputerGameTileModel> emptyGame = this.dataLayerMockHelper.CreateNewComputerVsHumanGame().Tiles;

            this.dataLayerMockHelper.SetTileValue(emptyGame, TileConstants.BottomRightTile, X);

            CellValue[,] gameBoard = ModelConvertor.ModelConvertor.ConvertGameTilesToCellValueMatrix(emptyGame);

            Assert.AreEqual(CellValue.X.ToString(), gameBoard[2, 2].ToString());
        }

        [TestMethod]
        public void ConvertGameTilesToCellValueMatrix_If_Bottom_Right_Is_O_Should_Return_Bottom_Right_O()
        {
            IEnumerable<IComputerGameTileModel> emptyGame = this.dataLayerMockHelper.CreateNewComputerVsHumanGame().Tiles;

            this.dataLayerMockHelper.SetTileValue(emptyGame, TileConstants.BottomRightTile, O);

            CellValue[,] gameBoard = ModelConvertor.ModelConvertor.ConvertGameTilesToCellValueMatrix(emptyGame);

            Assert.AreEqual(CellValue.O.ToString(), gameBoard[2, 2].ToString());
        }

        #endregion

        #region GetCurrentPlayerCellValueSign

        [TestMethod]
        public void GetCurrentPlayerCellValueSign_Should_Return_Cell_Value_X_If_Turns_Count_Is_Odd_Number()
        {
            int[] oddTurns = new int[] { 1, 3, 5, 7 };

            foreach (var oddTurn in oddTurns)
            {
                CellValue playerSign = ModelConvertor.ModelConvertor.GetCurrentPlayerCellValueSign(oddTurn);

                Assert.AreEqual(CellValue.X.ToString(), playerSign.ToString());
            }
        }

        [TestMethod]
        public void GetCurrentPlayerCellValueSign_Should_Return_Cell_Value_O_If_Turns_Count_Is_An_Even_Number()
        {
            int[] evenTurns = new int[] { 2, 4, 6, 8 };

            foreach (var evenTurn in evenTurns)
            {
                CellValue playerSign = ModelConvertor.ModelConvertor.GetCurrentPlayerCellValueSign(evenTurn);

                Assert.AreEqual(CellValue.O.ToString(), playerSign.ToString());
            }
        }

        #endregion

        #region ConvertArrayToIndex

        [TestMethod]
        public void ConvertArrayToIndex_Should_Return_0_If_The_Result_Is_Top_Left()
        {
            int[] array = new int[3]
            {
               666, 0, 0
            };

            int index = ModelConvertor.ModelConvertor.ConvertArrayToIndex(array);

            Assert.AreEqual(TileConstants.TopLeftTile, index);
        }

        [TestMethod]
        public void ConvertArrayToIndex_Should_Return_1_If_The_Result_Is_Top_Middle()
        {
            int[] array = new int[3]
            {
               666, 0, 1
            };

            int index = ModelConvertor.ModelConvertor.ConvertArrayToIndex(array);

            Assert.AreEqual(TileConstants.TopMiddleTile, index);
        }

        [TestMethod]
        public void ConvertArrayToIndex_Should_Return_2_If_The_Result_Is_Top_Right()
        {
            int[] array = new int[3]
            {
               666, 0, 2
            };

            int index = ModelConvertor.ModelConvertor.ConvertArrayToIndex(array);

            Assert.AreEqual(TileConstants.TopRightTile, index);
        }

        [TestMethod]
        public void ConvertArrayToIndex_Should_Return_3_If_The_Result_Is_Middle_Left()
        {
            int[] array = new int[3]
            {
               666, 1, 0
            };

            int index = ModelConvertor.ModelConvertor.ConvertArrayToIndex(array);

            Assert.AreEqual(TileConstants.MiddleLeftTile, index);
        }

        [TestMethod]
        public void ConvertArrayToIndex_Should_Return_4_If_The_Result_Is_Middle_Middle()
        {
            int[] array = new int[3]
            {
               666, 1, 1
            };

            int index = ModelConvertor.ModelConvertor.ConvertArrayToIndex(array);

            Assert.AreEqual(TileConstants.MiddleMiddleTile, index);
        }

        [TestMethod]
        public void ConvertArrayToIndex_Should_Return_5_If_The_Result_Is_Middle_Right()
        {
            int[] array = new int[3]
            {
               666, 1, 2
            };

            int index = ModelConvertor.ModelConvertor.ConvertArrayToIndex(array);

            Assert.AreEqual(TileConstants.MiddleRightTile, index);
        }

        [TestMethod]
        public void ConvertArrayToIndex_Should_Return_6_If_The_Result_Is_Bottom_Left()
        {
            int[] array = new int[3]
            {
               666, 2, 0
            };

            int index = ModelConvertor.ModelConvertor.ConvertArrayToIndex(array);

            Assert.AreEqual(TileConstants.BottomLeftTile, index);
        }

        [TestMethod]
        public void ConvertArrayToIndex_Should_Return_7_If_The_Result_Is_Bottom_Middle()
        {
            int[] array = new int[3]
            {
               666, 2, 1
            };

            int index = ModelConvertor.ModelConvertor.ConvertArrayToIndex(array);

            Assert.AreEqual(TileConstants.BottomMiddleTile, index);
        }

        [TestMethod]
        public void ConvertArrayToIndex_Should_Return_8_If_The_Result_Is_Bottom_Right()
        {
            int[] array = new int[3]
            {
               666, 2, 2
            };

            int index = ModelConvertor.ModelConvertor.ConvertArrayToIndex(array);

            Assert.AreEqual(TileConstants.BottomRightTile, index);
        }

        [TestMethod]
        [ExpectedException(typeof(ComputerException))]
        public void ConvertArrayToIndex_Should_Throw_ComputerException_If_Row_Is_Negative_Number()
        {
            int[] array = new int[3]
            {
               666, -1, 2
            };

            int index = ModelConvertor.ModelConvertor.ConvertArrayToIndex(array);
        }

        [TestMethod]
        [ExpectedException(typeof(ComputerException))]
        public void ConvertArrayToIndex_Should_Throw_ComputerException_If_Row_Is_Bigger_Than_2()
        {
            int[] array = new int[3]
            {
               666, 3, 2
            };

            int index = ModelConvertor.ModelConvertor.ConvertArrayToIndex(array);
        }

        [TestMethod]
        [ExpectedException(typeof(ComputerException))]
        public void ConvertArrayToIndex_Should_Throw_ComputerException_If_Col_Is_Negative_Number()
        {
            int[] array = new int[3]
            {
               666, 2, -1
            };

            int index = ModelConvertor.ModelConvertor.ConvertArrayToIndex(array);
        }

        [TestMethod]
        [ExpectedException(typeof(ComputerException))]
        public void ConvertArrayToIndex_Should_Throw_ComputerException_If_Col_Is_Bigger_Than_2_Number()
        {
            int[] array = new int[3]
            {
               666, 2, 3
            };

            int index = ModelConvertor.ModelConvertor.ConvertArrayToIndex(array);
        }

        #endregion
    }
}