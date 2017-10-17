namespace TicTacToe.ServiceLayer.TicTacToeService.Factories.Game.Create
{
    using System.Linq;
    using System.Collections.Generic;
    using DataLayer.Data;
    using Models;
    using Models.Enums;
    using Helpers;
    using TicTacToeCommon.Exceptions.User;

    public class GameCreator : IGameCreator
    {
        protected readonly ITicTacToeData data;

        public GameCreator(ITicTacToeData data)
        {
            this.data = data;
        }

        public Game CreateNewHumanVsHumanGame(string homeSideUserName, string currentUserName)
        {
            CreateNewHumanVsHumanGameHelper helper = new CreateNewHumanVsHumanGameHelper(this.data);

            Game game = helper.CreateNewHumanVsHumanGame(homeSideUserName, currentUserName);

            return game;
        }

        public Game CreateNewHumanVsComputerGame(string currentUserName, string computerUsername, bool isHumanStartingFirst)
        {
            CreateNewHumanVsComputerGameHelper helper = new CreateNewHumanVsComputerGameHelper(this.data);

            Game game = helper.CreateNewHumanVsComputerGame(currentUserName, computerUsername, isHumanStartingFirst);

            return game;
        }

        public Game CreateNewComputerVsComputerGame(string currentUserName)
        {
            CreateNewComputerVsComputerHelper helper = new CreateNewComputerVsComputerHelper(this.data);

            Game game = helper.CreateNewComputerVsComputerGame(currentUserName);

            return game;
        }

        public Game RecreatePreviousGameOfType(string currentUserName, GameMode gameMode)
        {
            RecreatePreviousGameHelper recreateHelper = new RecreatePreviousGameHelper(this.data);

            Game game = recreateHelper.RecreatePreviousGameOfType(currentUserName, gameMode);

            return game;
        }

        /// <summary>
        /// Returns a user by username or throws exception
        /// </summary>
        /// <param name="homeSideUsername">username of the target</param>
        /// <exception cref="UserNotFoundException"></exception>
        /// <returns>ApplicationUser</returns>
        protected ApplicationUser GetUserByUsername(string homeSideUsername)
        {
            ApplicationUser user = this.data.Users.All().FirstOrDefault(u => u.UserName == homeSideUsername);

            this.IfUserIsNullThrowException(user);

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
        /// Adds 9 empty tiles to a Game
        /// </summary>
        /// <param name="game">Game</param>
        protected void AddEmptyTilesToGame(Game game)
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
        protected void SaveChanges(Game game, string currentUserName)
        {
            ApplicationUser user = this.GetUserByUsername(currentUserName);

            user.Games.Add(game);

            this.data.Games.Add(game);

            this.data.SaveChanges();
        }
    }
}