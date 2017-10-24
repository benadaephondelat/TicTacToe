namespace TicTacToe.ServiceLayer.TicTacToeService.Factories.Game.Create
{
    using Models;
    using Models.Enums;

    public interface IGameCreator
    {
        Game CreateNewHumanVsHumanGame(string homeSideUserName, string currentUserName);

        Game CreateNewHumanVsComputerGame(string currentUserName, string computerUsername, bool isHumanStartingFirst);

        Game CreateNewComputerVsComputerGame(string currentUserName, string startingFirstComputerName, string startingSecondComputerName);

        Game RecreatePreviousGameOfType(string currentUserName, GameMode gameMode);
    }
}