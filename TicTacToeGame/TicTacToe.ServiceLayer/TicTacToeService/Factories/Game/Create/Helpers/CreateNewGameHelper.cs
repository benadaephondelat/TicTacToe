namespace TicTacToe.ServiceLayer.TicTacToeService.Factories.Game.Create.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DataLayer.Data;
    using Models;
    using Models.Enums;
    using TicTacToeCommon.Exceptions.User;

    public class CreateNewGameHelper : GameCreator
    {
        public CreateNewGameHelper(ITicTacToeData data) : base(data)
        {
        }

        public new Game CreateNewGame(string homeSideUserName, string currentUserName, GameMode gameMode)
        {
            ApplicationUser homeSideUser = this.GetUserByUsername(homeSideUserName);

            ApplicationUser awaySideUser = this.GetAwaySideUser(homeSideUserName, currentUserName, gameMode);

            Game game = this.CreateNewGame(homeSideUser, awaySideUser, gameMode);
            
            this.SaveChanges(game, currentUserName);

            return game;
        }

        /// <summary>
        /// Determines the game's oponent based on who goes first
        /// </summary>
        /// <param name="homeSideUserName">user to go first</param>
        /// <param name="currentUserName">current user</param>
        /// <returns>ApplicationUser</returns>
        private ApplicationUser GetAwaySideUser(string homeSideUserName, string currentUserName, GameMode gameMode)
        {
            if (this.CurrentUserIsStartingFirst(homeSideUserName, currentUserName))
            {
                if (gameMode == GameMode.HumanVsHuman)
                {
                    return GetUserByUsername("the-other-guy@yahoo.com");
                }
                else
                {
                    return GetUserByUsername("computer@yahoo.com");
                }
            }

            return this.GetUserByUsername(currentUserName);
        }

        /// <summary>
        /// Checks if the homeSideUser and currentUser are the same user
        /// </summary>
        /// <param name="homeSideUserName">user to go first</param>
        /// <param name="currentUserName">current user</param>
        /// <returns>bool</returns>
        private bool CurrentUserIsStartingFirst(string homeSideUserName, string currentUserName)
        {
            bool result = homeSideUserName == currentUserName;

            return result;
        }

        /// <summary>
        /// Creates a new HumanVsHuman Game by ading users, general game info and empty tiles to the Game.
        /// </summary>
        /// <exception cref="UserNotFoundException"></exception>
        /// <param name="homeSideUser">Homeside user</param>
        /// <param name="awaySideUser">Awayside user</param>
        /// <param name="gameMode">Game mode</param>
        /// <returns>Game</returns>
        private Game CreateNewGame(ApplicationUser homeSideUser, ApplicationUser awaySideUser, GameMode gameMode)
        {
            Game game = new Game() { TurnsCount = 1 };

            this.AddUsersToGame(homeSideUser, awaySideUser, game);

            this.AddInfoToGame(homeSideUser.UserName, awaySideUser.UserName, game, gameMode);

            this.AddEmptyTilesToGame(game);

            return game;
        }

        /// <summary>
        /// Sets the Game's ApplicationUser and Oponent properties to the respective users
        /// </summary>
        /// <param name="homeSideUser">User to be set as an ApplicationUser</param>
        /// <param name="awaySideUser">User to be set as an Oponent</param>
        /// <param name="game">Game</param>
        private void AddUsersToGame(ApplicationUser homeSideUser, ApplicationUser awaySideUser, Game game)
        {
            game.ApplicationUser = homeSideUser;
            game.ApplicationUserId = homeSideUser.Id;

            game.Oponent = awaySideUser;
            game.OponentId = awaySideUser.Id;
        }

        /// <summary>
        /// Sets the Game's general info properties. GameState, StartDate, GameName etc...
        /// </summary>
        private void AddInfoToGame(string homeSideUsername, string awaySideUsername, Game game, GameMode gameMode)
        {
            game.GameMode = gameMode;
            game.GameState = GameState.NotFinished;
            game.StartDate = DateTime.Now;
            game.OponentName = awaySideUsername;
            game.GameName = homeSideUsername + " vs " + awaySideUsername;
        }

        /// <summary>
        /// Adds 9 empty tiles to a Game
        /// </summary>
        /// <param name="game">Game</param>
        private void AddEmptyTilesToGame(Game game)
        {
            List<Tile> emptyTilesList = new List<Tile>();

            for (var i = 0; i < 9; i++)
            {
                Tile tile = CreateEmptyTile(game);

                data.Tiles.Add(tile);

                emptyTilesList.Add(tile);
            }

            game.Tiles = emptyTilesList;
        }

        /// <summary>
        /// Creates an empty Tile
        /// </summary>
        /// <param name="game">Tiles's game</param>
        /// <returns>Tile</returns>
        private Tile CreateEmptyTile(Game game)
        {
            Tile emptyTile = new Tile()
            {
                Game = game,
                GameId = game.Id,
                IsEmpty = true,
                Value = string.Empty
            };

            return emptyTile;
        }

        /// <summary>
        /// Updated the DB
        /// </summary>
        /// <param name="game">Game to add</param>
        /// <param name="currentUserName">Username of the current user</param>
        private void SaveChanges(Game game, string currentUserName)
        {
            ApplicationUser user = GetUserByUsername(currentUserName);

            user.Games.Add(game);

            this.data.Games.Add(game);

            this.data.SaveChanges();
        }
    }
}