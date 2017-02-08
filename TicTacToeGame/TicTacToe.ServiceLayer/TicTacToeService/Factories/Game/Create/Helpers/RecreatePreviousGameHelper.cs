namespace TicTacToe.ServiceLayer.TicTacToeService.Factories.Game.Create.Helpers
{
    using Models;
    using DataLayer.Data;
    using LinqExtentions;
    using TicTacToeCommon.Exceptions.Game;
    using TicTacToeCommon.Exceptions.User;

    public class RecreatePreviousGameHelper : GameCreator
    {
        public RecreatePreviousGameHelper(ITicTacToeData data) : base(data)
        {
        }

        /// <summary>
        /// Returns the homeside username of the last game that a user played or throws exception.
        /// </summary>
        /// <param name="currentUsername">Username of the User</param>
        /// <exception cref="UserNotFoundException"></exception>
        /// <exception cref="GameNotFoundException"></exception>
        /// <returns>string</returns>
        public string GetPreviousGameHomesideUsername(string currentUsername)
        {
            ApplicationUser user = this.GetUserByUsername(currentUsername);

            Game lastGame = GetUserLastFinishedGame(user);

            string previousGameHomeSide = lastGame.ApplicationUser.UserName;

            return previousGameHomeSide;
        }

        /// <summary>
        /// Returns the user's last finished game.
        /// </summary>
        /// <param name="user">User's games to check</param>
        /// <exception cref="GameNotFoundException"></exception>
        /// <returns>string</returns>
        private Game GetUserLastFinishedGame(ApplicationUser user)
        {
            Game lastGame = user.Games.GetLastFinishedGame();

            if (lastGame == null)
            {
                throw new GameNotFoundException();
            }
            
            return lastGame;
        }
    }
}