namespace TicTacToe.ServiceLayer.TicTacToeService.Factories.Game.CRUD
{
    using Models;

    public interface IGameReader
    {
        Game GetGameById(int gameId);
    }
}