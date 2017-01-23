namespace TicTacToe.ServiceLayer.TicTacToeService.Factories.Game.Update.Helpers
{
    using System.Linq;
    using Models;
    using DataLayer.Data;
    using TicTacToeCommon.Exceptions.Game;
    using TicTacToeCommon.Exceptions.Tile;
    using TicTacToeCommon.Exceptions.User;

    public class PlaceTurnHelper : GameUpdator
    {
        public PlaceTurnHelper(ITicTacToeData data) : base(data)
        {
        }

        public new void PlaceTurn(int gameId, int tileIndex, string currentUserName)
        {
            Game game = this.GetGameById(gameId);
            this.ValidateGame(game, currentUserName);

            Tile tile = this.GetTileByIndex(game, tileIndex);
            this.ValidateTile(tile);

            this.UpdateTurnsCount(game);
            this.SetTileValue(game, tile);

            this.SavePlaceTurnChanges(tile, game);
        }

        /// <summary>
        /// Validates a Game
        /// </summary>
        /// <param name="game">Game to validate</param>
        /// <param name="currentUsername">Current user attempting the operation</param>
        /// <exception cref="GameIsFinishedException"></exception>
        /// <exception cref="UserNotAuthorizedException"></exception>
        private void ValidateGame(Game game, string currentUsername)
        {
            if (GameIsFinished(game))
            {
                throw new GameIsFinishedException();
            }

            if (UserIsNotPartOfTheGame(game, currentUsername))
            {
                throw new UserNotAuthorizedException();
            }
        }

        /// <summary>
        /// Checks if a Game.IsFinished property is true
        /// </summary>
        /// <param name="game">Game to checl</param>
        /// <returns>bool</returns>
        private bool GameIsFinished(Game game)
        {
            if (game.IsFinished)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if the current user is part of the game.
        /// </summary>
        /// <param name="game">Game</param>
        /// <param name="currentUsername">Username of the current user</param>
        /// <returns>bool</returns>
        private bool UserIsNotPartOfTheGame(Game game, string currentUsername)
        {
            string homeUser = game.ApplicationUser.UserName;
            string awayUser = game.Oponent.UserName;

            if (UserIsNotHomeside(homeUser, currentUsername) && UserIsNotAwayside(awayUser, currentUsername))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if the current username is not the same as the game's oponent username
        /// </summary>
        /// <param name="oponentUsername">username of the game's oponent</param>
        /// <param name="currentUsername">username of the current user</param>
        /// <returns>bool</returns>
        private bool UserIsNotAwayside(string oponentUsername, string currentUsername)
        {
            if (oponentUsername == currentUsername)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if the current username is not the same as the game's homeside username
        /// </summary>
        /// <param name="homesideUsername">username of the game's owner</param>
        /// <param name="currentUsername">username of the current user</param>
        /// <returns>bool</returns>
        private bool UserIsNotHomeside(string homesideUsername, string currentUsername)
        {
            if (homesideUsername == currentUsername)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Returns a Game's tile by tile index or throws exception.
        /// </summary>
        /// <param name="game">Game</param>
        /// <param name="tileIndex">Index of the tile</param>
        /// <exception cref="TileValidationException"></exception>
        /// <returns>Tile</returns>
        private Tile GetTileByIndex(Game game, int tileIndex)
        {
            if (TileIndexIsInvalid(tileIndex))
            {
                throw new TileValidationException("Invalid tile index");
            }

            Tile tile = game.Tiles.ElementAt(tileIndex);

            return tile;
        }

        /// <summary>
        /// Checks if tile index is between 0 and 8
        /// </summary>
        /// <param name="tileIndex">tile index</param>
        /// <returns>bool</returns>
        private bool TileIndexIsInvalid(int tileIndex)
        {
            if (tileIndex < 0 || tileIndex > 8)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Validates the Tile entity
        /// </summary>
        /// <param name="tile">Tile</param>
        private void ValidateTile(Tile tile)
        {
            if (TileIsNotEmpty(tile.IsEmpty))
            {
                throw new TileValidationException("Tile is not empty");
            }
        }

        /// <summary>
        /// Cheks if a Tile.IsEmpty property is set to false
        /// </summary>
        /// <param name="isEmpty">isEmpty property</param>
        /// <returns>bool</returns>
        private bool TileIsNotEmpty(bool isEmpty)
        {
            if (isEmpty == false)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Increments a Game's turn count by one.
        /// </summary>
        /// <param name="game">Game</param>
        private void UpdateTurnsCount(Game game)
        {
            game.TurnsCount++;
        }

        /// <summary>
        /// Sets a tile value based on the Game's turn count.
        /// </summary>
        /// <param name="game">Game</param>
        /// <param name="tile">Tile</param>
        private void SetTileValue(Game game, Tile tile)
        {
            if (GameTurnsCountIsOddNumber(game.TurnsCount.Value))
            {
                tile.Value = "O";
            }
            else
            {
                tile.Value = "X";
            }

            tile.IsEmpty = false;
        }

        /// <summary>
        /// Checks if the current turn is an odd number
        /// </summary>
        /// <param name="turnsCount">current turn count</param>
        /// <returns>bool</returns>
        private bool GameTurnsCountIsOddNumber(int turnsCount)
        {
            return turnsCount % 2 != 0;
        }

        /// <summary>
        /// Updates Tiles and Games Repositories and call SaveChanges
        /// </summary>
        /// <param name="tile">Tile</param>
        /// <param name="game">Game</param>
        private void SavePlaceTurnChanges(Tile tile, Game game)
        {
            this.data.Tiles.Update(tile);
            this.data.Games.Update(game);

            this.data.SaveChanges();
        }
    }
}