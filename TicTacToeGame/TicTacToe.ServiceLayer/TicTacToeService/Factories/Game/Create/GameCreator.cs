namespace TicTacToe.ServiceLayer.TicTacToeService.Factories.Game.Create
{
    using System.Linq;

    using DataLayer.Data;
    using Models;
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

        public Game RecreatePreviousGame(string currentUserName)
        {
            RecreatePreviousGameHelper recreateHelper = new RecreatePreviousGameHelper(this.data);

            string previousGameHomeSide = recreateHelper.GetPreviousGameHomesideUsername(currentUserName);

            CreateNewHumanVsHumanGameHelper helper = new CreateNewHumanVsHumanGameHelper(this.data);

            Game game = helper.CreateNewHumanVsHumanGame(previousGameHomeSide, currentUserName);

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
    }
}