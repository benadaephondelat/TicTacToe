namespace TicTacToe.ServiceLayer.TicTacToeService.Factories.Game.Read
{
    using Models;

    public interface IGameReader
    {
        Game GetGameById(int gameId);

        bool IsGameFinished(int gameId);
    }
}