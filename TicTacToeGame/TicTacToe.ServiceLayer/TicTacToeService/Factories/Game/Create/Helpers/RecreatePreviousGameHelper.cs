namespace TicTacToe.ServiceLayer.TicTacToeService.Factories.Game.Create.Helpers
{
    using System;
    using Models;
    using DataLayer.Data;
    using LinqExtentions;
    using TicTacToeCommon.Exceptions.Game;
    using TicTacToeCommon.Exceptions.User;
    using Models.Enums;
    using TicTacToeCommon.Constants;

    public class RecreatePreviousGameHelper : GameCreator
    {
        public RecreatePreviousGameHelper(ITicTacToeData data) : base(data)
        {
        }

        public Game RecreatePreviousGameOfType(string currentUserName, GameMode gameMode)
        {
            Game previousGame = this.GetUserLastFinishedGameOfGivenType(currentUserName, gameMode);

            string previousGameHomeSide = previousGame.ApplicationUser.UserName;

            if (gameMode == GameMode.HumanVsHuman)
            {
                return base.CreateNewHumanVsHumanGame(currentUserName, previousGameHomeSide);
            }
            else if (gameMode == GameMode.HumanVsComputer)
            {
                bool isHumanPlayerStartingFirst = previousGameHomeSide != UserConstants.ComputerUsername && previousGameHomeSide != UserConstants.OtherComputerUsername;

                string computerName = isHumanPlayerStartingFirst ? previousGame.Oponent.UserName : previousGame.ApplicationUser.UserName;

                return base.CreateNewHumanVsComputerGame(currentUserName, computerName, isHumanPlayerStartingFirst);
            }
            else if (gameMode == GameMode.ComputerVsComputer)
            {
                return base.CreateNewComputerVsComputerGame(currentUserName, previousGame.ApplicationUser.UserName, previousGame.Oponent.UserName);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        
        /// <summary>
        /// Returns the the last finished game of a given type or throws exception
        /// </summary>
        /// <param name="currentUsername">Username of the User</param>
        /// <param name="gameMode">Game's GameMode</param>
        /// <exception cref="UserNotFoundException"></exception>
        /// <exception cref="GameNotFoundException"></exception>
        /// <returns>Game</returns>
        private Game GetUserLastFinishedGameOfGivenType(string currentUsername, GameMode gameMode)
        {
            ApplicationUser user = this.GetUserByUsername(currentUsername);

            Game lastGame = this.GetUserLastFinishedGameOfType(user, gameMode);

            return lastGame;
        }

        /// <summary>
        /// Returns the user's last finished game.
        /// </summary>
        /// <param name="user">User's games to check</param>
        /// <param name="gameMode">Game's GameMode</param>
        /// <exception cref="GameNotFoundException"></exception>
        /// <returns>string</returns>
        private Game GetUserLastFinishedGameOfType(ApplicationUser user, GameMode gameMode)
        {
            Game lastGame = user.Games.GetLastFinishedGame(gameMode);

            if (lastGame == null)
            {
                throw new GameNotFoundException();
            }
            
            return lastGame;
        }
    }
}