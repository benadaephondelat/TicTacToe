namespace TicTacToe.ServiceLayer.TicTacToeGameService
{
    using System.Collections.Generic;
    using Models;
    using DataLayer.Data;
    using TicTacToeService.Factories.Game;
    using TicTacToeService.Factories.Game.Create;
    using TicTacToeService.Factories.Game.Read;
    using TicTacToeService.Factories.Game.Update;
    using TicTacToeService;

    public class TicTacToeGameService : ITicTacToeGameService
    {
        private readonly IServicesFactory serviceFactory;

        public TicTacToeGameService(ITicTacToeData data)
        {
            this.serviceFactory = new ServicesFactory(data);
        }

        public Game CreateNewHumanVsHumanGame(string homeSideUserName, string currentUserName)
        {
            IGameFactory gameFactory = this.serviceFactory.GetGameFactory();

            IGameCreator gameCreator = gameFactory.GetGameCreatorHelper();

            Game newGame = gameCreator.CreateNewHumanVsHumanGame(homeSideUserName, currentUserName);

            return newGame;
        }

        public void PlaceTurn(int gameId, int tileIndex, string currentUserName)
        {
            IGameFactory gameFactory = this.serviceFactory.GetGameFactory();

            IGameUpdator gameUpdator = gameFactory.GetGameUpdatorHelper();

            gameUpdator.PlaceTurn(gameId, tileIndex, currentUserName);
        }

        public Game GetGameById(int gameId)
        {
            IGameFactory gameFactory = this.serviceFactory.GetGameFactory();

            IGameReader gameReader = gameFactory.GetGameReaderHelper();

            Game game = gameReader.GetGameById(gameId);

            return game;
        }

        public bool IsGameFinished(int gameId)
        {
            IGameFactory gameFactory = this.serviceFactory.GetGameFactory();

            IGameReader gameReader = gameFactory.GetGameReaderHelper();

            bool isFinished = gameReader.IsGameFinished(gameId);

            return isFinished;
        }

        public void CheckGameForOutcome(int gameId)
        {
            IGameFactory gameFactory = this.serviceFactory.GetGameFactory();

            IGameUpdator gameUpdator = gameFactory.GetGameUpdatorHelper();

            gameUpdator.CheckGameForOutcome(gameId);
        }

        public Game RecreatePreviousGame(string currentUserName)
        {
            IGameFactory gameFactory = this.serviceFactory.GetGameFactory();

            IGameCreator gameCreator = gameFactory.GetGameCreatorHelper();

            Game game = gameCreator.RecreatePreviousGame(currentUserName);

            return game;
        }

        public IEnumerable<Game> GetAllUnfinishedGames(string currentUsername)
        {
            IGameFactory gameFactory = this.serviceFactory.GetGameFactory();

            IGameReader gameReader = gameFactory.GetGameReaderHelper();

            IEnumerable<Game> unfinishedGames = gameReader.GetAllUnfinishedGames(currentUsername);

            return unfinishedGames;
        }
    }
}