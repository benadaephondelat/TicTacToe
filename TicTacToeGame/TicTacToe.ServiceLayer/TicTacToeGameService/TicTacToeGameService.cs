namespace TicTacToe.ServiceLayer.TicTacToeGameService
{
    using System.Linq;
    using System.Collections.Generic;
    using Models;
    using DataLayer.Data;
    using TicTacToeService;
    using TicTacToeService.Factories.Game;
    using TicTacToeService.Factories.Game.Create;
    using TicTacToeService.Factories.Game.Read;
    using TicTacToeService.Factories.Game.Update;
    using Computer;
    using Computer.Models;
    using Models.Enums;

    public class TicTacToeGameService : ITicTacToeGameService
    {
        private readonly IServicesFactory serviceFactory;
        private readonly IComputer computer;

        public TicTacToeGameService(ITicTacToeData data, IComputer computer)
        {
            this.serviceFactory = new ServicesFactory(data);
            this.computer = computer;
        }

        public Game GetGameById(int gameId)
        {
            IGameFactory gameFactory = this.serviceFactory.GetGameFactory();

            IGameReader gameReader = gameFactory.GetGameReaderHelper();

            Game game = gameReader.GetGameById(gameId);

            return game;
        }

        public Game CreateNewGame(string homeSideUserName, string currentUserName)
        {
            IGameFactory gameFactory = this.serviceFactory.GetGameFactory();

            IGameCreator gameCreator = gameFactory.GetGameCreatorHelper();

            Game newGame = gameCreator.CreateNewHumanVsHumanGame(homeSideUserName, currentUserName);

            return newGame;
        }

        public Game CreateNewHumanVsComputerGame(string currentUserName, bool isHumanStartingFirst)
        {
            IGameFactory gameFactory = this.serviceFactory.GetGameFactory();

            IGameCreator gameCreator = gameFactory.GetGameCreatorHelper();

            Game newGame = gameCreator.CreateNewHumanVsComputerGame(currentUserName, isHumanStartingFirst);

            return newGame;
        }

        public Game RecreatePreviousGame(string currentUserName, GameMode gameMode)
        {
            IGameFactory gameFactory = this.serviceFactory.GetGameFactory();

            IGameCreator gameCreator = gameFactory.GetGameCreatorHelper();

            Game game = gameCreator.RecreatePreviousGameOfType(currentUserName, gameMode);

            return game;
        }

        public IEnumerable<Game> GetAllUnfinishedGames(string currentUsername, GameMode gameMode)
        {
            IGameFactory gameFactory = this.serviceFactory.GetGameFactory();

            IGameReader gameReader = gameFactory.GetGameReaderHelper();

            IEnumerable<Game> unfinishedGames = gameReader.GetAllUnfinishedGames(currentUsername, gameMode);

            return unfinishedGames;
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

        public void PlaceTurn(int gameId, int tileIndex, string currentUserName)
        {
            IGameFactory gameFactory = this.serviceFactory.GetGameFactory();

            IGameUpdator gameUpdator = gameFactory.GetGameUpdatorHelper();

            gameUpdator.PlaceTurn(gameId, tileIndex, currentUserName);
        }

        public int GetComputerMove(int gameId)
        {
            Game game = this.GetGameById(gameId);

            IComputerGameModel computerGame = this.CreateComputerGameModel(game);

            int tileIndex = this.computer.GetComputerMoveIndex(computerGame);

            return tileIndex;
        }

        /// <summary>
        /// Creates a ComputerGameModel from Game model
        /// </summary>
        /// <param name="game">Game</param>
        /// <returns>ComputerGameModel</returns>
        private IComputerGameModel CreateComputerGameModel(Game game)
        {
            ComputerGameModel result = new ComputerGameModel();

            result.HomesideUsername = game.ApplicationUser.UserName;
            result.AwaysideUsername = game.Oponent.UserName;
            result.TurnsCount = game.TurnsCount.Value;
            result.IsFinished = game.IsFinished;

            result.Tiles = game.Tiles.Select(x => new ComputerGameTileModel()
            {
                IsEmpty = x.IsEmpty,
                Value = x.Value
            }).ToList();

            return result;
        }
    }
}