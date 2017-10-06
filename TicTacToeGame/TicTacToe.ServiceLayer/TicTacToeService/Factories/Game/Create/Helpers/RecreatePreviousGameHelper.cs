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
            string previousGameHomeSide = this.GetPreviousGameHomesideUsername(currentUserName, gameMode);

            if (gameMode == GameMode.HumanVsHuman)
            {
                return base.CreateNewHumanVsHumanGame(currentUserName, previousGameHomeSide);
            }
            else if (gameMode == GameMode.HumanVsComputer)
            {
                bool isHumanPlayerStartingFirst = previousGameHomeSide != UserConstants.ComputerUsername;

                return base.CreateNewHumanVsComputerGame(currentUserName, isHumanPlayerStartingFirst);
            }
            else
            {
                throw new NotImplementedException("Recreate game for Computer vs Computer game mode is not implemented yet.");
            }
        }
        
        /// <summary>
        /// Returns the homeside username of the last game that a user played or throws exception.
        /// </summary>
        /// <param name="currentUsername">Username of the User</param>
        /// <param name="gameMode">Game's GameMode</param>
        /// <exception cref="UserNotFoundException"></exception>
        /// <exception cref="GameNotFoundException"></exception>
        /// <returns>string</returns>
        private string GetPreviousGameHomesideUsername(string currentUsername, GameMode gameMode)
        {
            ApplicationUser user = this.GetUserByUsername(currentUsername);

            Game lastGame = this.GetUserLastFinishedGameOfType(user, gameMode);

            string previousGameHomeSide = lastGame.ApplicationUser.UserName;

            return previousGameHomeSide;
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