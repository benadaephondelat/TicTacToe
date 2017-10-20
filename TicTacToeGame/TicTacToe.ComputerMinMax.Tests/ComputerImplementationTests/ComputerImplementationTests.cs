namespace TicTacToe.ComputerMinMax.ComputerImplementationTests.Tests
{
    using System.Linq;
    using Computer.Models;
    using ComputerImplementation.Enums;
    using ComputerTests.DataMockHelper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TicTacToeCommon.Constants;

    [TestClass]
    public class ComputerImplementationTests
    {
        private DataMockHelper dataLayerMockHelper;

        public ComputerImplementationTests()
        {
            this.dataLayerMockHelper = new DataMockHelper();
        }

        #region Starting First

        [TestMethod]
        public void Starting_First_MiniMax_Should_Return_Valid_Move_On_The_First_Move()
        {
            IComputerGameModel game = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            int computerMove = this.GetComputerMove(game, CellValue.X);

            bool isInRange = computerMove >= 0 && computerMove <= 8;

            Assert.IsTrue(isInRange);
        }

        [TestMethod]
        public void Starting_First_MiniMax_Should_Return_Valid_Move_On_The_Second_Move()
        {
            IComputerGameModel game = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            int[] previousMoves = new int[] { TileConstants.BottomLeftTile, TileConstants.MiddleMiddleTile };

            this.MakeMoves(ref game, previousMoves);

            int computerMove = this.GetComputerMove(game, CellValue.X);
            
            bool isNotOverlappingWithBoard = this.IsComputerMoveUnique(computerMove, previousMoves);

            Assert.IsTrue(isNotOverlappingWithBoard);

            bool isInRange = computerMove >= 0 && computerMove <= 8;

            Assert.IsTrue(isInRange);
        }

        [TestMethod]
        public void Starting_First_MiniMax_Should_Return_Valid_Move_On_The_Third_Move()
        {
            IComputerGameModel game = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            int[] previousMoves = new int[]
            {
                TileConstants.BottomLeftTile,
                TileConstants.MiddleMiddleTile,
                TileConstants.TopLeftTile,
                TileConstants.MiddleLeftTile
            };

            this.MakeMoves(ref game, previousMoves);

            int computerMove = this.GetComputerMove(game, CellValue.X);

            bool isNotOverlappingWithBoard = this.IsComputerMoveUnique(computerMove, previousMoves);

            Assert.IsTrue(isNotOverlappingWithBoard);

            bool isInRange = computerMove >= 0 && computerMove <= 8;

            Assert.IsTrue(isInRange);
        }

        [TestMethod]
        public void Starting_First_MiniMax_Should_Return_Valid_Move_On_The_Fourth_Move()
        {
            IComputerGameModel game = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            int[] currentlyPlayedMoves = new int[]
            {
                TileConstants.BottomLeftTile,
                TileConstants.MiddleMiddleTile,
                TileConstants.TopLeftTile,
                TileConstants.MiddleLeftTile,
                TileConstants.MiddleRightTile,
                TileConstants.TopMiddleTile
            };

            this.MakeMoves(ref game, currentlyPlayedMoves);

            int computerMove = this.GetComputerMove(game, CellValue.X);
            
            bool isNotOverlappingWithBoard = this.IsComputerMoveUnique(computerMove, currentlyPlayedMoves);

            Assert.IsTrue(isNotOverlappingWithBoard);

            bool isInRange = computerMove >= 0 && computerMove <= 8;

            Assert.IsTrue(isInRange);
        }
        
        [TestMethod]
        public void Starting_First_MiniMax_Should_Return_Valid_Move_On_The_Fifth_Move()
        {
            IComputerGameModel game = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            int[] currentlyPlayedMoves = new int[]
            {
                TileConstants.BottomLeftTile,
                TileConstants.MiddleMiddleTile,
                TileConstants.TopLeftTile,
                TileConstants.MiddleLeftTile,
                TileConstants.MiddleRightTile,
                TileConstants.TopMiddleTile,
                TileConstants.BottomMiddleTile,
                TileConstants.BottomRightTile
            };

            this.MakeMoves(ref game, currentlyPlayedMoves);

            int computerMove = this.GetComputerMove(game, CellValue.X);
            
            bool isNotOverlappingWithBoard = this.IsComputerMoveUnique(computerMove, currentlyPlayedMoves);

            Assert.IsTrue(isNotOverlappingWithBoard);

            bool isInRange = computerMove >= 0 && computerMove <= 8;

            Assert.IsTrue(isInRange);
        }

        #endregion

        #region Starting Second

        [TestMethod]
        public void Starting_Second_MiniMax_Should_Return_Valid_Move_On_The_First_Move()
        {
            IComputerGameModel game = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            int[] previousMoves = new int[] { TileConstants.MiddleMiddleTile };

            this.MakeMoves(ref game, previousMoves);

            int computerMove = this.GetComputerMove(game, CellValue.O);

            bool isNotOverlappingWithBoard = this.IsComputerMoveUnique(computerMove, previousMoves);

            Assert.IsTrue(isNotOverlappingWithBoard);

            bool isInRange = computerMove >= 0 && computerMove <= 8;

            Assert.IsTrue(isInRange);
        }

        [TestMethod]
        public void Starting_Second_MiniMax_Should_Return_Valid_Move_On_The_Second_Move()
        {
            IComputerGameModel game = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            int[] previousMoves = new int[]
            {
                TileConstants.MiddleMiddleTile,
                TileConstants.TopLeftTile,
                TileConstants.TopRightTile
            };

            this.MakeMoves(ref game, previousMoves);

            int computerMove = this.GetComputerMove(game, CellValue.O);

            bool isNotOverlappingWithBoard = this.IsComputerMoveUnique(computerMove, previousMoves);

            Assert.IsTrue(isNotOverlappingWithBoard);

            bool isInRange = computerMove >= 0 && computerMove <= 8;

            Assert.IsTrue(isInRange);
        }

        [TestMethod]
        public void Starting_Second_MiniMax_Should_Return_Valid_Move_On_The_Third_Move()
        {
            IComputerGameModel game = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            int[] previousMoves = new int[]
            {
                TileConstants.MiddleMiddleTile,
                TileConstants.TopLeftTile,
                TileConstants.TopRightTile,
                TileConstants.BottomLeftTile,
                TileConstants.MiddleLeftTile
            };

            this.MakeMoves(ref game, previousMoves);

            int computerMove = this.GetComputerMove(game, CellValue.O);

            bool isNotOverlappingWithBoard = this.IsComputerMoveUnique(computerMove, previousMoves);

            Assert.IsTrue(isNotOverlappingWithBoard);

            bool isInRange = computerMove >= 0 && computerMove <= 8;

            Assert.IsTrue(isInRange);
        }

        [TestMethod]
        public void Starting_Second_MiniMax_Should_Return_Valid_Move_On_The_Fourth_Move()
        {
            IComputerGameModel game = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            int[] previousMoves = new int[]
            {
                TileConstants.MiddleMiddleTile,
                TileConstants.TopLeftTile,
                TileConstants.TopRightTile,
                TileConstants.BottomLeftTile,
                TileConstants.MiddleLeftTile,
                TileConstants.MiddleRightTile
            };

            this.MakeMoves(ref game, previousMoves);

            int computerMove = this.GetComputerMove(game, CellValue.O);

            bool isNotOverlappingWithBoard = this.IsComputerMoveUnique(computerMove, previousMoves);

            Assert.IsTrue(isNotOverlappingWithBoard);

            bool isInRange = computerMove >= 0 && computerMove <= 8;

            Assert.IsTrue(isInRange);
        }

        #endregion

        /// <summary>
        /// Places moves on a borad
        /// </summary>
        /// <param name="model">game to place turns to</param>
        /// <param name="moves">turn to make</param>
        private void MakeMoves(ref IComputerGameModel model, int[] moves)
        {
            for (int i = 0; i < moves.Length; i++)
            {
                if (i % 2 == 0)
                {
                    this.dataLayerMockHelper.SetTileValue(model.Tiles, moves[i], "X");
                }
                else
                {
                    this.dataLayerMockHelper.SetTileValue(model.Tiles, moves[i], "O");
                }
            }

            model.TurnsCount = moves.Length;
        }

        /// <summary>
        /// Returns the MinMax computer move based on the current game's state
        /// </summary>
        /// <param name="game">Current game's state</param>
        /// <param name="currentPlayerSign">Sign of the current player</param>
        /// <returns>int</returns>
        private int GetComputerMove(IComputerGameModel game, CellValue currentPlayerSign)
        {
            CellValue[,] gameBoardState = ModelConvertor.ModelConvertor.ConvertGameTilesToCellValueMatrix(game.Tiles);

            MinMaxComputerImplementation computer = new MinMaxComputerImplementation(gameBoardState);

            int[] result = computer.MiniMax(8, currentPlayerSign, int.MinValue, int.MaxValue);

            int computerMove = ModelConvertor.ModelConvertor.ConvertArrayToIndex(result);

            return computerMove;
        }

        /// <summary>
        /// Checks if a number is not found in an array of numbers
        /// </summary>
        /// <param name="computerMove">number to check</param>
        /// <param name="previousMoves">numbers to check against</param>
        /// <returns>bool</returns>
        private bool IsComputerMoveUnique(int computerMove, int[] previousMoves)
        {
            bool isUnique = previousMoves.Contains(computerMove) == false;

            return isUnique;
        }
    }
}