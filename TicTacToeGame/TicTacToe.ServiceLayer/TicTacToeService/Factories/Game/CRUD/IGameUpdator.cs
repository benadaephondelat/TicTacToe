namespace TicTacToe.ServiceLayer.TicTacToeService.Factories.Game.CRUD
{
    public interface IGameUpdator
    {
        void PlaceTurn(int gameId, int tileIndex, string currentUserName);
    }
}