namespace TicTacToe.ServiceLayer.TicTacToeService.Factories.Game.Create.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DataLayer.Data;
    using Models;
    using Models.Enums;
    using TicTacToeCommon.Exceptions.User;

    public class CreateNewHumanVsHumanGameHelper : GameCreator
    {
        public CreateNewHumanVsHumanGameHelper(ITicTacToeData data) : base(data)
        {
        }

        public new Game CreateNewHumanVsHumanGame(string homeSideUserName, string currentUserName)
        {
            ApplicationUser homeSideUser = base.GetUserByUsername(homeSideUserName);

            ApplicationUser awaySideUser = this.GetAwaySideUser(homeSideUserName, currentUserName);

            Game game = CreateNewHumanVsHumanGame(homeSideUser, awaySideUser);

            //TODO REFACTOR
            game.GameOwner = this.GetUserByUsername(currentUserName);
            game.GameOwnerId = game.GameOwner.Id;

            this.SaveChanges(game, currentUserName);

            return game;
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

            this.AddUsersToGame(homeSideUser, awaySideUser, game);

            this.AddInfoToGame(homeSideUser.UserName, awaySideUser.UserName, game);

            base.AddEmptyTilesToGame(game);

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
        private void AddInfoToGame(string homeSideUsername, string awaySideUsername, Game game)
        {
            game.GameState = GameState.NotFinished;
            game.StartDate = DateTime.Now;
            game.OponentName = awaySideUsername;
            game.GameName = homeSideUsername + " vs " + awaySideUsername;
        }
    }
}