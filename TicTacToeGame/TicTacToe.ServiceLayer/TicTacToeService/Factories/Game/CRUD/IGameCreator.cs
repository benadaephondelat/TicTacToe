namespace TicTacToe.ServiceLayer.TicTacToeService.Factories.Game.CRUD
{
    using Models;

    public interface IGameCreator
    {
        Game CreateNewHumanVsHumanGame(string homeSideUserName, string currentUserName);
    }
}