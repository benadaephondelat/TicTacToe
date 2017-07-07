namespace ComputerVsComputerTests
{
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TicTacToe.Computer;
    using TicTacToe.ComputerTests.DataMockHelper;
    using TicTacToe.Computer.Models;
    using TicTacToe.Computer.Constants;
    using TicTacToeCommon.Constants;
    using TicTacToe.Models;

    [TestClass]
    public class SimulationTests
    {
        [Ignore]
        [TestMethod]
        public void SimulateGameBetweenTwoComputers()
        {
            DataMockHelper dataMockHelper = new DataMockHelper();

            bool success = true;

            Computer computer = new Computer();

            for (var i = 0; i < 5000; i++)
            {
                ComputerGameModel gameModel = dataMockHelper.CreateNewComputerVsHumanGame();

                for (var j = 0; j < 9; j++)
                {
                    if (j % 2 == 0)
                    {
                        gameModel.HomesideUsername = UserConstants.ComputerUsername;

                        int move = computer.GetComputerMoveIndex(gameModel);

                        gameModel.Tiles.ElementAt(move).IsEmpty = false;
                        gameModel.Tiles.ElementAt(move).Value = ComputerConstants.HomeSideSign;
                        gameModel.TurnsCount = gameModel.TurnsCount + 1;

                    }
                    else
                    {
                        gameModel.HomesideUsername = UserConstants.UserUsername;
              
                        int move = computer.GetComputerMoveIndex(gameModel);

                        gameModel.Tiles.ElementAt(move).IsEmpty = false;
                        gameModel.Tiles.ElementAt(move).Value = ComputerConstants.AwaySideSign;
                        gameModel.TurnsCount = gameModel.TurnsCount + 1;
                    }
                }

                List<Tile> gameTiles = new List<Tile>();

                int counter = 0;

                foreach (var tile in gameModel.Tiles)
                {
                    Tile currentTile = new Tile()
                    {
                        IsEmpty = tile.IsEmpty,
                        Value = tile.Value,
                        Id = counter
                    };

                    gameTiles.Add(currentTile);

                    counter++;
                }

                Game game = new Game()
                {
                    Tiles = gameTiles,
                    Id = 21,
                };

                var horizontalWin = this.HorizontalCheck(game);
                var verticalWin = this.VerticalCheck(game);
                var diagonalWin = this.DiagonalCheck(game);

                bool isDraw = horizontalWin == false && verticalWin == false && diagonalWin == false;

                if (isDraw)
                {
                    continue;
                }
                else
                {
                    Assert.Fail();
                }
            }

            Assert.IsTrue(true);
        }

        /// <summary>
        /// Compares all horizontal tiles to evaluate if they are the same.
        /// </summary>
        /// <param name="game">Game to check</param>
        private bool HorizontalCheck(Game game)
        {
            if (AreAllHorizontalTilesTheSameStartingFromTopLeft(game))
            {
                return true;
            }

            if (AreAllHorizontalTilesTheSameStartingFromMiddleLeft(game))
            {
                return true;
            }

            if (AreAllHorizontalTilesTheSameStartingFromBottomLeft(game))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if all horizontal tiles has the same value starting from the top-left tile
        /// </summary>
        /// <param name="game">Game to check</param>
        /// <returns>bool</returns>
        private bool AreAllHorizontalTilesTheSameStartingFromTopLeft(Game game)
        {
            if (string.IsNullOrWhiteSpace(game.Tiles.ElementAt(TileConstants.TopLeftTile).Value))
            {
                return false;
            }

            string topLeftTile = game.Tiles.ElementAt(TileConstants.TopLeftTile).Value;
            string topMiddleTile = game.Tiles.ElementAt(TileConstants.TopMiddleTile).Value;
            string topRightTile = game.Tiles.ElementAt(TileConstants.TopRightTile).Value;

            if (topLeftTile == topMiddleTile && topLeftTile == topRightTile)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if all horizontal tiles has the same value starting from the middle-left tile
        /// </summary>
        /// <param name="game">Game to check</param>
        /// <returns>bool</returns>
        private bool AreAllHorizontalTilesTheSameStartingFromMiddleLeft(Game game)
        {
            if (string.IsNullOrWhiteSpace(game.Tiles.ElementAt(TileConstants.MiddleLeftTile).Value))
            {
                return false;
            }

            string middleLeftTile = game.Tiles.ElementAt(TileConstants.MiddleLeftTile).Value;
            string middleMiddleTile = game.Tiles.ElementAt(TileConstants.MiddleMiddleTile).Value;
            string middleRightTile = game.Tiles.ElementAt(TileConstants.MiddleRightTile).Value;

            if (middleLeftTile == middleMiddleTile && middleLeftTile == middleRightTile)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if all horizontal tiles has the same value starting from the bottom-left tile
        /// </summary>
        /// <param name="game">Game to check</param>
        /// <returns>bool</returns>
        private bool AreAllHorizontalTilesTheSameStartingFromBottomLeft(Game game)
        {
            if (string.IsNullOrWhiteSpace(game.Tiles.ElementAt(TileConstants.BottomLeftTile).Value))
            {
                return false;
            }

            string bottomLeftTile = game.Tiles.ElementAt(TileConstants.BottomLeftTile).Value;
            string bottomMiddleTile = game.Tiles.ElementAt(TileConstants.BottomMiddleTile).Value;
            string bottomRightTile = game.Tiles.ElementAt(TileConstants.BottomRightTile).Value;

            if (bottomLeftTile == bottomMiddleTile && bottomLeftTile == bottomRightTile)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Compares all vertical tiles to evaluate if they are the same.
        /// </summary>
        /// <param name="game">Game to check</param>
        private bool VerticalCheck(Game game)
        {
            if (AreAllVerticalTilesTheSameStartingFromTopLeft(game))
            {
                return true;
            }

            if (AreAllVerticalTilesTheSameStartingFromTopMiddle(game))
            {
                return true;
            }

            if (AreAllVerticalTilesTheSameStartingFromTopRight(game))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if all vertical tiles has the same value starting from the top-left tile
        /// </summary>
        /// <param name="game">Game to check</param>
        /// <returns>bool</returns>
        private bool AreAllVerticalTilesTheSameStartingFromTopLeft(Game game)
        {
            if (string.IsNullOrWhiteSpace(game.Tiles.ElementAt(TileConstants.TopLeftTile).Value))
            {
                return false;
            }

            string topLeftTile = game.Tiles.ElementAt(TileConstants.TopLeftTile).Value;
            string middleLeftTile = game.Tiles.ElementAt(TileConstants.MiddleLeftTile).Value;
            string bottomLeftTile = game.Tiles.ElementAt(TileConstants.BottomLeftTile).Value;

            if (topLeftTile == middleLeftTile && topLeftTile == bottomLeftTile)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if all vertical tiles has the same value starting from the top-middle tile
        /// </summary>
        /// <param name="game">Game to check</param>
        /// <returns>bool</returns>
        private bool AreAllVerticalTilesTheSameStartingFromTopMiddle(Game game)
        {
            if (string.IsNullOrWhiteSpace(game.Tiles.ElementAt(TileConstants.TopMiddleTile).Value))
            {
                return false;
            }

            string topMiddle = game.Tiles.ElementAt(TileConstants.TopMiddleTile).Value;
            string middleMiddleTile = game.Tiles.ElementAt(TileConstants.MiddleMiddleTile).Value;
            string bottomMiddleTile = game.Tiles.ElementAt(TileConstants.BottomMiddleTile).Value;

            if (topMiddle == middleMiddleTile && topMiddle == bottomMiddleTile)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if all vertical tiles has the same value starting from the top-right tile
        /// </summary>
        /// <param name="game">Game to check</param>
        /// <returns>bool</returns>
        private bool AreAllVerticalTilesTheSameStartingFromTopRight(Game game)
        {
            if (string.IsNullOrWhiteSpace(game.Tiles.ElementAt(TileConstants.TopRightTile).Value))
            {
                return false;
            }

            string topRight = game.Tiles.ElementAt(TileConstants.TopRightTile).Value;
            string middleRight = game.Tiles.ElementAt(TileConstants.MiddleRightTile).Value;
            string bottomRightTile = game.Tiles.ElementAt(TileConstants.BottomRightTile).Value;

            if (topRight == middleRight && topRight == bottomRightTile)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Compares the two diagonals to evaluate if their values are the same.
        /// Calls SaveGameAsWon() if a winner is found.
        /// </summary>
        /// <param name="game">Game to check</param>
        private bool DiagonalCheck(Game game)
        {
            if (AreAllDiagonalTilesTheSameStartingFromTopLeft(game))
            {
                return true;
            }

            if (AreAllDiagonalTilesTheSameStartingFromTopRight(game))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if the diagonal tiles has the same value starting from the top-left tile
        /// </summary>
        /// <param name="game">Game to check</param>
        /// <returns>bool</returns>
        private bool AreAllDiagonalTilesTheSameStartingFromTopLeft(Game game)
        {
            if (string.IsNullOrWhiteSpace(game.Tiles.ElementAt(TileConstants.TopLeftTile).Value))
            {
                return false;
            }

            string topLeft = game.Tiles.ElementAt(TileConstants.TopLeftTile).Value;
            string middleMiddle = game.Tiles.ElementAt(TileConstants.MiddleMiddleTile).Value;
            string bottomRight = game.Tiles.ElementAt(TileConstants.BottomRightTile).Value;

            if (topLeft == middleMiddle && topLeft == bottomRight)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if the diagonal tiles has the same value starting from the top-right tile
        /// </summary>
        /// <param name="game">Game to check</param>
        /// <returns>bool</returns>
        private bool AreAllDiagonalTilesTheSameStartingFromTopRight(Game game)
        {
            if (string.IsNullOrWhiteSpace(game.Tiles.ElementAt(TileConstants.TopRightTile).Value))
            {
                return false;
            }

            string topRight = game.Tiles.ElementAt(TileConstants.TopRightTile).Value;
            string middleMiddle = game.Tiles.ElementAt(TileConstants.MiddleMiddleTile).Value;
            string bottomLeft = game.Tiles.ElementAt(TileConstants.BottomLeftTile).Value;

            if (topRight == middleMiddle && topRight == bottomLeft)
            {
                return true;
            }

            return false;
        }
    }
}
