namespace TicTacToe.ServiceLayer.TicTacToeService.Factories.Game.Create
{
    using Models;

    public interface IGameCreator
    {
        Game CreateNewHumanVsHumanGame(string homeSideUserName, string currentUserName);
    }
}