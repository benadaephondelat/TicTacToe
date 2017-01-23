namespace TicTacToe.ServiceLayer.TicTacToeService.Factories.Game.Create
{
    using DataLayer.Data;
    using Models;
    using Helpers;

    public class GameCreator : IGameCreator
    {
        protected readonly ITicTacToeData data;

        public GameCreator(ITicTacToeData data)
        {
            this.data = data;
        }

        public Game CreateNewHumanVsHumanGame(string homeSideUserName, string currentUserName)
        {
            CreateNewHumanVsHumanGameHelper helper = new CreateNewHumanVsHumanGameHelper(this.data);

            Game game = helper.CreateNewHumanVsHumanGame(homeSideUserName, currentUserName);

            return game;
        }
    }
}