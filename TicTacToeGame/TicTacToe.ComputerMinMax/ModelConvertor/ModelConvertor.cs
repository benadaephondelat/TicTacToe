namespace TicTacToe.ComputerMinMax.ModelConvertor
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Computer.Models;
    using ComputerImplementation.Enums;
    using TicTacToeCommon.Exceptions.Computer;

    /// <summary>
    /// Contains methods that helps with the convertion of IComputerGameModel to
    /// the Models used in the MinMaxImplementation class
    /// </summary>
    public static class ModelConvertor
    {
        /// <summary>
        /// Converts IEnumerable<IComputerGameTileModel> to CellValue matrix to be used by MinMaxImplementation
        /// </summary>
        /// <param name="tiles">IEnumerable<IComputerGameTileModel></IComputerGameTileModel></param>
        /// <returns>CellValue[,]</returns>
        public static CellValue[,] ConvertGameTilesToCellValueMatrix(IEnumerable<IComputerGameTileModel> tiles)
        {
            CellValue[,] currentGameBoardState = new CellValue[3, 3];

            for (var i = 0; i < tiles.Count(); i++)
            {
                CellValue cellValue = ConvertTileValueToCellValue(tiles.ElementAt(i));

                ApplyCellValueToTheGameBoard(currentGameBoardState, i, cellValue);
            }

            return currentGameBoardState;
        }

        /// <summary>
        /// Returns the player sign based on the Game.TurnsCount
        /// </summary>
        /// <param name="currentTurnCount">current turns count</param>
        /// <returns>CellValue</returns>
        public static CellValue GetCurrentPlayerCellValueSign(int currentTurnCount)
        {
            if (currentTurnCount % 2 == 0)
            {
                return CellValue.O;
            }

            return CellValue.X;
        }

        /// <summary>
        /// Converts the results return by the ComputerMinMaxImplementation result to an index[0-8]
        /// </summary>
        /// <param name="result">int[]</param>
        /// <returns>int</returns>
        public static int ConvertArrayToIndex(int[] result)
        {
            int position = 0;

            if (result[1] == 0)
            {
                position = GetFirstColumnIndex(result);

                return position;
            }
            else if (result[1] == 1)
            {
                position = GetSecondColumnIndex(result);

                return position;
            }
            else if (result[1] == 2)
            {
                position = GetThirdColumnIndex(result);

                return position;
            }

            throw new ComputerException("MinMax result can not be converted to index");
        }

        /// <summary>
        /// Returns the first column's index
        /// </summary>
        /// <param name="result">int[,]</param>
        /// <returns>int</returns>
        private static int GetFirstColumnIndex(int[] result)
        {
            if (result[2] == 0)
            {
                return 0;
            }
            else if (result[2] == 1)
            {
                return 1;
            }
            else
            {
                return 2;
            }

            throw new ComputerException("MinMax result can not be converted to index");
        }

        /// <summary>
        /// Returns the second column's index
        /// </summary>
        /// <param name="result">int[,]</param>
        /// <returns>int</returns>
        private static int GetSecondColumnIndex(int[] result)
        {
            if (result[2] == 0)
            {
                return 3;
            }
            else if (result[2] == 1)
            {
                return 4;
            }
            else
            {
                return 5;
            }

            throw new ComputerException("MinMax result can not be converted to index");
        }

        /// <summary>
        /// Returns the third column's index
        /// </summary>
        /// <param name="result">int[,]</param>
        /// <returns>int</returns>
        private static int GetThirdColumnIndex(int[] result)
        {
            if (result[2] == 0)
            {
                return 6;
            }
            else if (result[2] == 1)
            {
                return 7;
            }
            else if (result[2] == 2)
            {
                return 8;
            }

            throw new ComputerException("MinMax result can not be converted to index");
        }

        /// <summary>
        /// Converts the current Tile.Value to CellValue
        /// </summary>
        /// <param name="tile">Tile to take value from</param>
        /// <returns>CellValue</returns>
        private static CellValue ConvertTileValueToCellValue(IComputerGameTileModel tile)
        {
            CellValue cellValue = CellValue.BLANK;

            if (tile.Value == "X")
            {
                cellValue = CellValue.X;
            }
            else if (tile.Value == "O")
            {
                cellValue = CellValue.O;
            }

            return cellValue;
        }

        /// <summary>
        /// Applies the cell value to the appropriate cell in the game board
        /// </summary>
        /// <param name="gameBoardState">CellValue[,] gameBoard to apply cell value to</param>
        /// <param name="i">current index</param>
        /// <param name="cellValue">cuttent cell value to apply</param>
        private static void ApplyCellValueToTheGameBoard(CellValue[,] gameBoardState, int i, CellValue cellValue)
        {
            switch (i)
            {
                case 0:
                    gameBoardState[0, 0] = cellValue;
                    break;

                case 1:
                    gameBoardState[0, 1] = cellValue;
                    break;

                case 2:
                    gameBoardState[0, 2] = cellValue;
                    break;

                case 3:
                    gameBoardState[1, 0] = cellValue;
                    break;

                case 4:
                    gameBoardState[1, 1] = cellValue;
                    break;

                case 5:
                    gameBoardState[1, 2] = cellValue;
                    break;

                case 6:
                    gameBoardState[2, 0] = cellValue;
                    break;

                case 7:
                    gameBoardState[2, 1] = cellValue;
                    break;

                case 8:
                    gameBoardState[2, 2] = cellValue;
                    break;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}