namespace TicTacToe.ServiceLayer.TicTacToeService.Factories.Game.CRUD
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DataLayer.Data;
    using Models;
    using TicTacToeCommon.Exceptions.User;

    public class GameCreator : IGameCreator
    {
        private readonly ITicTacToeData data;

        public GameCreator(ITicTacToeData data)
        {
            this.data = data;
        }

        public Game CreateNewHumanVsHumanGame(string homeSideUserName, string currentUserName)
        {
            ApplicationUser homeSideUser = GetUserByUsername(homeSideUserName);

            ApplicationUser awaySideUser = GetAwaySideUser(homeSideUserName, currentUserName);

            Game game = CreateNewHumanVsHumanGame(homeSideUser, awaySideUser);

            AddGameToRepositoryAndSaveChanges(game);

            return game;
        }

        /// <summary>
        /// Returns a user by username or throws exception
        /// </summary>
        /// <param name="homeSideUsername">username of the target</param>
        /// <exception cref="UserNotFoundException"></exception>
        /// <returns>ApplicationUser</returns>
        private ApplicationUser GetUserByUsername(string homeSideUsername)
        {
            ApplicationUser user = this.data.Users.All().FirstOrDefault(u => u.UserName == homeSideUsername);

            IfUserIsNullThrowException(user);

            return user;
        }
        
        /// <summary>
        /// If the ApplicatioUser is null throw UserNotFound exception
        /// </summary>
        /// <param name="user">User to check</param>
        private void IfUserIsNullThrowException(ApplicationUser user)
        {
            if (user == null)
            {
                throw new UserNotFoundException();
            }
        }

        /// <summary>
        /// Determines the game's oponent based on who goes first
        /// </summary>
        /// <param name="homeSideUserName">user to go first</param>
        /// <param name="currentUserName">current user</param>
        /// <returns>ApplicationUser</returns>
        private ApplicationUser GetAwaySideUser(string homeSideUserName, string currentUserName)
        {
            if (CurrentUserIsStartingFirst(homeSideUserName, currentUserName))
            {
                return GetUserByUsername("the-other-guy@yahoo.com");
            }

            return GetUserByUsername(currentUserName);
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
        /// <param name="homeSideUser"></param>
        /// <param name="awaySideUser"></param>
        /// <returns>Game</returns>
        private Game CreateNewHumanVsHumanGame(ApplicationUser homeSideUser, ApplicationUser awaySideUser)
        {
            Game game = new Game() { TurnsCount = 1 };

            AddUsersToGame(homeSideUser, awaySideUser, game);

            AddInfoToGame(homeSideUser.UserName, awaySideUser.UserName, game);

            AddEmptyTilesToGame(game);

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
        /// Sets the Game's general info properties. StartDate, GameName etc...
        /// </summary>
        private void AddInfoToGame(string homeSideUsername, string awaySideUsername, Game game)
        {
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
        /// Adds a Game to the the Games Repository and Saves Changes to the DB
        /// </summary>
        /// <param name="game">Game to add</param>
        private void AddGameToRepositoryAndSaveChanges(Game game)
        {
            data.Games.Add(game);
            data.SaveChanges();
        }
    }
}