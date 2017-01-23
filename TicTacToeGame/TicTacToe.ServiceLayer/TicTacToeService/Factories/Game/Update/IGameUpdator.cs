namespace TicTacToe.ServiceLayer.TicTacToeService.Factories.Game.Update
{
    public interface IGameUpdator
    {
        void PlaceTurn(int gameId, int tileIndex, string currentUserName);

        void CheckGameForOutcome(int gameId);
    }
}