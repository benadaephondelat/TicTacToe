namespace TicTacToe.ServiceLayer.TicTacToeService.Factories.Game.Update.Helpers
{
    using System;
    using System.Linq;
    using Models;
    using Models.Enums;
    using DataLayer.Data;
    using TicTacToeCommon.Exceptions.Game;
    using TicTacToeCommon.Exceptions.Tile;

    using static TicTacToeCommon.Constants.GameConstants;
    using static TicTacToeCommon.Constants.TileConstants;

    public class CheckGameForOutcomeHelper : GameUpdator
    {
        public CheckGameForOutcomeHelper(ITicTacToeData data) : base(data)
        {
        }

        public new void CheckGameForOutcome(int gameId)
        {
            Game game = this.GetGameById(gameId);
            
            if (TooEarlyInTheGame(game))
            {
                return;
            }

            if (game.IsFinished)
            {
                throw new GameIsFinishedException();
            }

            this.HorizontalCheck(game);
            this.VerticalCheck(game);
            this.DiagonalCheck(game);

            if (DrawConditionsAreMet(game))
            {
                this.SaveGameAsDraw(game);
            }
        }

        /// <summary>
        /// Checks if the current turn count is lower than earliest possible win turn count
        /// </summary>
        /// <param name="game"></param>
        /// <returns>bool</returns>
        private bool TooEarlyInTheGame(Game game)
        {
            if (game.TurnsCount < EarliestPossibleWinTurnsCount)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Compares all horizontal tiles to evaluate if they are the same.
        /// Calls SaveGameAsWon() if a winner is found.
        /// </summary>
        /// <param name="game">Game to check</param>
        private void HorizontalCheck(Game game)
        {
            if (game.IsFinished)
            {
                return;
            }

            if (AreAllHorizontalTilesTheSameStartingFromTopLeft(game))
            {
                this.SaveGameAsWon(game, game.Tiles.ElementAt(TopLeftTile).Value);

                return;
            }

            if (AreAllHorizontalTilesTheSameStartingFromMiddleLeft(game))
            {
                this.SaveGameAsWon(game, game.Tiles.ElementAt(MiddleLeftTile).Value);

                return;
            }

            if (AreAllHorizontalTilesTheSameStartingFromBottomLeft(game))
            {
                this.SaveGameAsWon(game, game.Tiles.ElementAt(BottomLeftTile).Value);

                return;
            }
        }

        /// <summary>
        /// Checks if all horizontal tiles has the same value starting from the top-left tile
        /// </summary>
        /// <param name="game">Game to check</param>
        /// <returns>bool</returns>
        private bool AreAllHorizontalTilesTheSameStartingFromTopLeft(Game game)
        {
            if (string.IsNullOrWhiteSpace(game.Tiles.ElementAt(TopLeftTile).Value))
            {
                return false;
            }

            string topLeftTile = game.Tiles.ElementAt(TopLeftTile).Value;
            string topMiddleTile = game.Tiles.ElementAt(TopMiddleTile).Value;
            string topRightTile = game.Tiles.ElementAt(TopRightTile).Value;

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
            if (string.IsNullOrWhiteSpace(game.Tiles.ElementAt(MiddleLeftTile).Value))
            {
                return false;
            }

            string middleLeftTile = game.Tiles.ElementAt(MiddleLeftTile).Value;
            string middleMiddleTile = game.Tiles.ElementAt(MiddleMiddleTile).Value;
            string middleRightTile = game.Tiles.ElementAt(MiddleRightTile).Value;

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
            if (string.IsNullOrWhiteSpace(game.Tiles.ElementAt(BottomLeftTile).Value))
            {
                return false;
            }

            string bottomLeftTile = game.Tiles.ElementAt(BottomLeftTile).Value;
            string bottomMiddleTile = game.Tiles.ElementAt(BottomMiddleTile).Value;
            string bottomRightTile = game.Tiles.ElementAt(BottomRightTile).Value;

            if (bottomLeftTile == bottomMiddleTile && bottomLeftTile == bottomRightTile)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Compares all vertical tiles to evaluate if they are the same.
        /// Calls SaveGameAsWon() if a winner is found.
        /// </summary>
        /// <param name="game">Game to check</param>
        private void VerticalCheck(Game game)
        {
            if (game.IsFinished)
            {
                return;
            }

            if (AreAllVerticalTilesTheSameStartingFromTopLeft(game))
            {
                this.SaveGameAsWon(game, game.Tiles.ElementAt(TopLeftTile).Value);

                return;
            }

            if (AreAllVerticalTilesTheSameStartingFromTopMiddle(game))
            {
                this.SaveGameAsWon(game, game.Tiles.ElementAt(TopMiddleTile).Value);

                return;
            }

            if (AreAllVerticalTilesTheSameStartingFromTopRight(game))
            {
                this.SaveGameAsWon(game, game.Tiles.ElementAt(TopRightTile).Value);

                return;
            }
        }

        /// <summary>
        /// Checks if all vertical tiles has the same value starting from the top-left tile
        /// </summary>
        /// <param name="game">Game to check</param>
        /// <returns>bool</returns>
        private bool AreAllVerticalTilesTheSameStartingFromTopLeft(Game game)
        {
            if (string.IsNullOrWhiteSpace(game.Tiles.ElementAt(TopLeftTile).Value))
            {
                return false;
            }

            string topLeftTile = game.Tiles.ElementAt(TopLeftTile).Value;
            string middleLeftTile = game.Tiles.ElementAt(MiddleLeftTile).Value;
            string bottomLeftTile = game.Tiles.ElementAt(BottomLeftTile).Value;

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
            if (string.IsNullOrWhiteSpace(game.Tiles.ElementAt(TopMiddleTile).Value))
            {
                return false;
            }

            string topMiddle = game.Tiles.ElementAt(TopMiddleTile).Value;
            string middleMiddleTile = game.Tiles.ElementAt(MiddleMiddleTile).Value;
            string bottomMiddleTile = game.Tiles.ElementAt(BottomMiddleTile).Value;

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
            if (string.IsNullOrWhiteSpace(game.Tiles.ElementAt(TopRightTile).Value))
            {
                return false;
            }

            string topRight = game.Tiles.ElementAt(TopRightTile).Value;
            string middleRight = game.Tiles.ElementAt(MiddleRightTile).Value;
            string bottomRightTile = game.Tiles.ElementAt(BottomRightTile).Value;

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
        private void DiagonalCheck(Game game)
        {
            if (game.IsFinished)
            {
                return;
            }

            if (AreAllDiagonalTilesTheSameStartingFromTopLeft(game))
            {
                this.SaveGameAsWon(game, game.Tiles.ElementAt(TopLeftTile).Value);

                return;
            }

            if (AreAllDiagonalTilesTheSameStartingFromTopRight(game))
            {
                this.SaveGameAsWon(game, game.Tiles.ElementAt(TopRightTile).Value);

                return;
            }
        }

        /// <summary>
        /// Checks if the diagonal tiles has the same value starting from the top-left tile
        /// </summary>
        /// <param name="game">Game to check</param>
        /// <returns>bool</returns>
        private bool AreAllDiagonalTilesTheSameStartingFromTopLeft(Game game)
        {
            if (string.IsNullOrWhiteSpace(game.Tiles.ElementAt(TopLeftTile).Value))
            {
                return false;
            }

            string topLeft = game.Tiles.ElementAt(TopLeftTile).Value;
            string middleMiddle = game.Tiles.ElementAt(MiddleMiddleTile).Value;
            string bottomRight = game.Tiles.ElementAt(BottomRightTile).Value;

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
            if (string.IsNullOrWhiteSpace(game.Tiles.ElementAt(TopRightTile).Value))
            {
                return false;
            }

            string topRight = game.Tiles.ElementAt(TopRightTile).Value;
            string middleMiddle = game.Tiles.ElementAt(MiddleMiddleTile).Value;
            string bottomLeft = game.Tiles.ElementAt(BottomLeftTile).Value;

            if (topRight == middleMiddle && topRight == bottomLeft)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if it's the last turn and the game does not have a winner 
        /// </summary>
        /// <param name="game">Game</param>
        /// <returns>bool</returns>
        private bool DrawConditionsAreMet(Game game)
        {
            if (game.IsFinished == false && game.TurnsCount == LastTurnCount)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Sets a Game's properties to reflect a draw game and saves changes to the database.
        /// </summary>
        /// <param name="game">Game</param>
        private void SaveGameAsDraw(Game game)
        {
            game.IsFinished = true;
            game.EndDate = DateTime.Now;
            game.GameState = GameState.Draw;

            this.UpdateGamesRepositoryAndSaveChanges(game);
        }

        /// <summary>
        /// Sets a Game's properties to reflect a won game and saves changes to the database.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="tileValue"></param>
        private void SaveGameAsWon(Game game, string tileValue)
        {
            game.IsFinished = true;
            game.EndDate = DateTime.Now;
            game.GameState = GameState.Won;
            this.SetGameWinnerIdBasedOnTileValue(game, tileValue);

            this.UpdateGamesRepositoryAndSaveChanges(game);
        }

        /// <summary>
        /// If tile value equals X set the game.WinnerId to the home-side user
        /// else it sets the winnerId to the away-side user.
        /// </summary>
        /// <param name="game">Game</param>
        /// <param name="tileValue">Tile value</param>
        /// <exception cref="TileValidationException">Thrown when the tile value's sign is not expected</exception>
        private void SetGameWinnerIdBasedOnTileValue(Game game, string tileValue)
        {
            if (tileValue == HomeUserTileSign)
            {
                game.WinnerId = game.ApplicationUserId;
            }
            else
            {
                game.WinnerId = game.OponentId;
            }
        }

        /// <summary>
        /// Updates a Game in the Game repository and call SaveChanges
        /// </summary>
        /// <param name="game">Game</param>
        private void UpdateGamesRepositoryAndSaveChanges(Game game)
        {
            this.data.Games.Update(game);
            this.data.SaveChanges();
        }
    }
}