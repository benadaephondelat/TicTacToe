namespace TicTacToe.ServiceLayer.TicTacToeGameService
{
    using Models;
    using DataLayer.Data;

    using TicTacToe.ServiceLayer.TicTacToeService.Factories.Game;
    using TicTacToe.ServiceLayer.TicTacToeService.Factories.Game.CRUD;

    using TicTacToeService;

    public class TicTacToeGameService : ITicTacToeGameService
    {
        private readonly IServicesAbstractFactory serviceFactory;

        public TicTacToeGameService(ITicTacToeData data)
        {
            this.serviceFactory = new ServicesAbstractFactory(data);
        }

        public Game CreateNewHumanVsHumanGame(string homeSideUserName, string currentUserName)
        {
            GameFactory gameFactory = this.serviceFactory.GetGameFactory();

            GameCreator gameCreatorHelper = gameFactory.GetGameCreatorHelper();

            Game newGame = gameCreatorHelper.CreateNewHumanVsHumanGame(homeSideUserName, currentUserName);

            return newGame;
        }
    }
}