namespace TicTacToe.ServiceLayer.TicTacToeService.Factories.Game.Read
{
    using System.Collections.Generic;
    using Models;
    using Models.Enums;

    public interface IGameReader
    {
        Game GetGameById(int gameId);

        bool IsGameFinished(int gameId);

        IEnumerable<Game> GetAllUnfinishedGames(string currentUsername, GameMode gameMode);
    }
}