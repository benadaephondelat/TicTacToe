namespace TicTacToe.ServiceLayer.TicTacToeGameService
{
    using Models;
    using TicTacToeCommon.Exceptions.User;

    public interface ITicTacToeGameService
    {
        /// <summary>
        /// Creates a new HumanVsHuman Game or throws exception
        /// </summary>
        /// <param name="homeSideUserName">Username of the user who will go first</param>
        /// <param name="currentUserName">Username of the current user</param>
        /// <exception cref="UserNotFoundException"></exception>
        /// <returns>Game</returns>
        Game CreateNewHumanVsHumanGame(string homeSideUserName, string currentUserName);
    }
}