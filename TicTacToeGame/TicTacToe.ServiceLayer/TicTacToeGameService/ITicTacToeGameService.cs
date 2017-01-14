namespace TicTacToe.ServiceLayer.TicTacToeGameService
{
    using Models;

    using TicTacToeCommon.Exceptions.Game;
    using TicTacToeCommon.Exceptions.Tile;
    using TicTacToeCommon.Exceptions.User;

    public interface ITicTacToeGameService
    {
        /// <summary>
        /// Creates a new HumanVsHuman Game or throws exception
        /// </summary>
        /// <param name="homeSideUserName">The user who will go first</param>
        /// <param name="currentUserName">The username of the current user</param>
        /// <exception cref="UserNotFoundException"></exception>
        /// <returns>Game</returns>
        Game CreateNewHumanVsHumanGame(string homeSideUserName, string currentUserName);

        /// <summary>
        /// Places a turn on a Game or throws exception
        /// </summary>
        /// <param name="gameId">id of the game</param>
        /// <param name="tileIndex">tile index</param>
        /// <param name="currentUserName">user attempting the operation</param>
        /// <exception cref="GameNotFoundException"></exception>
        /// <exception cref="GameIsFinishedException"></exception>
        /// <exception cref="TileValidationException"></exception>
        /// <exception cref="UserNotAuthorizedException"></exception>
        void PlaceTurn(int gameId, int tileIndex, string currentUserName);

        /// <summary>
        /// Returns a Game by Id or throws exception
        /// </summary>
        /// <param name="gameId">id of the game</param>
        /// <exception cref="GameNotFoundException"></exception>
        /// <returns>Game</returns>
        Game GetGameById(int gameId);
    }
}