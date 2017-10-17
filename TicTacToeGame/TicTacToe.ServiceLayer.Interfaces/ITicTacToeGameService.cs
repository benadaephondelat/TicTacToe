namespace TicTacToe.ServiceLayer.Interfaces
{
    using System.Collections;
    using System.Collections.Generic;
    using TicTacToeCommon.Exceptions.Game;
    using TicTacToeCommon.Exceptions.Tile;
    using TicTacToeCommon.Exceptions.User;
    using Models;
    using Models.Enums;

    public interface ITicTacToeGameService
    {
        /// <summary>
        /// Creates a new HumanVsHuman Game or throws exception
        /// </summary>
        /// <param name="homeSideUserName">The user who will go first</param>
        /// <param name="currentUserName">The username of the current user</param>
        /// <exception cref="UserNotFoundException"></exception>
        /// <returns>Game</returns>
        Game CreateNewGame(string homeSideUserName, string currentUserName);

        /// <summary>
        /// Creates a new HumanVsHuman Game or throws exception
        /// </summary>
        /// <param name="currentUserName">The username of the current user</param>
        /// <param name="computerUserName">The username of the computer</param>
        /// <param name="isHumanStartingFirst">Indicates whether the human is starting first</param>
        /// <exception cref="UserNotFoundException"></exception>
        /// <returns>Game</returns>
        Game CreateNewHumanVsComputerGame(string currentUserName, string computerUserName, bool isHumanStartingFirst);

        /// <summary>
        /// Creates a new Computer vs Computer Game or throws exception
        /// </summary>
        /// <param name="currentUserName">The username of the current user</param>
        /// <exception cref="UserNotFoundException"></exception>
        /// <returns>Game</returns>
        Game CreateNewComputerVsComputerGame(string currentUserName);

        /// <summary>
        /// Returns the computer's chosen tile index or throws exception
        /// </summary>
        /// <param name="gameId">Game.Id</param>
        /// <exception cref="GameNotFoundException"></exception>
        /// <exception cref="GameIsFinishedException"></exception>
        /// <returns>int</returns>
        int GetComputerMove(int gameId);

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

        /// <summary>
        /// Checks if a Game is finished or throws exception.
        /// </summary>
        /// <param name="gameId">id of the game</param>
        /// <exception cref="GameNotFoundException"></exception>
        /// <returns>Game</returns>
        bool IsGameFinished(int gameId);

        /// <summary>
        /// Checks a Game for a winner or throws exception.
        /// Modifies a Game's properties to reflect the outcome of the current game.
        /// </summary>
        /// <param name="gameId">id of the game</param>
        /// <exception cref="GameNotFoundException"></exception>
        /// <exception cref="GameIsFinishedException"></exception>
        void CheckGameForOutcome(int gameId);

        /// <summary>
        /// Creates a Game that is a copy of the current user's last finished game or throws exception.
        /// </summary>
        /// <param name="currentUserName">Username of the current user</param>
        /// <param name="gameMode">Game's GameMode</param>
        /// <exception cref="UserNotFoundException"></exception>
        /// <exception cref="GameNotFoundException"></exception>
        /// <returns>Game</returns>
        Game RecreatePreviousGame(string currentUserName, GameMode gameMode);

        /// <summary>
        /// Returns all user's games of a certain GameMode that are not finished or throws exception.
        /// </summary>
        /// <param name="currentUsername">Username of the current user</param>
        /// <param name="gameMode">Games's GameMode</param>
        /// <exception cref="UserNotFoundException"></exception>
        /// <returns>IEnumerable<Game></Game></returns>
        IEnumerable<Game> GetAllUnfinishedGames(string currentUsername, GameMode gameMode);
    }
}