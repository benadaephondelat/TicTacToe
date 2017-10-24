namespace TicTacToe.ServiceLayer.TicTacToeGameService
{
    using System.Linq;
    using System.Collections.Generic;
    using Models;
    using TicTacToeService;
    using TicTacToeService.Factories.Game;
    using TicTacToeService.Factories.Game.Create;
    using TicTacToeService.Factories.Game.Read;
    using TicTacToeService.Factories.Game.Update;
    using Models.Enums;
    using ComputerChooser.Interfaces;
    using Computer.Models;
    using Computer.Interfaces;
    using DataLayer.Data;
    using Interfaces;
    using TicTacToeCommon.Constants;
    using TicTacToeCommon.Exceptions.User;

    public class TicTacToeGameService : ITicTacToeGameService
    {
        private readonly IServicesFactory serviceFactory;
        private readonly IGameFactory gameFactory;
        private readonly IComputerChooser computerChooser;

        public TicTacToeGameService(ITicTacToeData data, IComputerChooser computerChooser)
        {
            this.serviceFactory = new ServicesFactory(data);
            this.gameFactory = this.serviceFactory.GetGameFactory();
            this.computerChooser = computerChooser;
        }

        public Game GetGameById(int gameId)
        {
            IGameReader gameReader = this.gameFactory.GetGameReaderHelper();

            Game game = gameReader.GetGameById(gameId);

            return game;
        }

        public Game CreateNewGame(string homeSideUserName, string currentUserName)
        {
            IGameCreator gameCreator = this.gameFactory.GetGameCreatorHelper();

            Game newGame = gameCreator.CreateNewHumanVsHumanGame(homeSideUserName, currentUserName);

            return newGame;
        }

        public Game CreateNewHumanVsComputerGame(string currentUserName, string computerUserName, bool isHumanStartingFirst)
        {
            IGameCreator gameCreator = this.gameFactory.GetGameCreatorHelper();

            Game newGame = gameCreator.CreateNewHumanVsComputerGame(currentUserName, computerUserName, isHumanStartingFirst);

            return newGame;
        }

        public Game CreateNewComputerVsComputerGame(string currentUserName, string startingFirstComputerName, string startingSecondComputerName)
        {
            IGameCreator gameCreator = this.gameFactory.GetGameCreatorHelper();

            Game newGame = gameCreator.CreateNewComputerVsComputerGame(currentUserName, startingFirstComputerName, startingSecondComputerName);

            return newGame;
        }

        public Game RecreatePreviousGame(string currentUserName, GameMode gameMode)
        {
            IGameCreator gameCreator = this.gameFactory.GetGameCreatorHelper();

            Game game = gameCreator.RecreatePreviousGameOfType(currentUserName, gameMode);

            return game;
        }

        public IEnumerable<Game> GetAllUnfinishedGames(string currentUsername, GameMode gameMode)
        {
            IGameReader gameReader = this.gameFactory.GetGameReaderHelper();

            IEnumerable<Game> unfinishedGames = gameReader.GetAllUnfinishedGames(currentUsername, gameMode);

            return unfinishedGames;
        }

        public bool IsGameFinished(int gameId)
        {
            IGameReader gameReader = this.gameFactory.GetGameReaderHelper();

            bool isFinished = gameReader.IsGameFinished(gameId);

            return isFinished;
        }

        public void CheckGameForOutcome(int gameId)
        {
            IGameUpdator gameUpdator = this.gameFactory.GetGameUpdatorHelper();

            gameUpdator.CheckGameForOutcome(gameId);
        }

        public void PlaceTurn(int gameId, int tileIndex, string currentUserName)
        {
            IGameUpdator gameUpdator = this.gameFactory.GetGameUpdatorHelper();

            gameUpdator.PlaceTurn(gameId, tileIndex, currentUserName);
        }

        //TODO EXTRACT LOGIC INTO CLASS AND TEST IT!
        public int GetComputerMove(int gameId)
        {
            Game game = this.GetGameById(gameId);

            IComputerGameModel computerGame = this.CreateComputerGameModel(game);

            string computerName = this.GetComputerName(game, game.ApplicationUser.UserName, game.Oponent.UserName);

            IComputer computer = this.computerChooser.GetComputerByName(computerName);

            int tileIndex = computer.GetComputerMoveIndex(computerGame);

            return tileIndex;
        }
        
        /// <summary>
        /// Returns the computer's name
        /// </summary>
        /// <param name="game">Game to check</param>
        /// <param name="gameStartingFirstUsername">Game.ApplicationUser.UserName</param>
        /// <param name="gameOponentUsername">Game.Oponent.UserName</param>
        /// <returns>string</returns>
        private string GetComputerName(Game game, string gameStartingFirstUsername, string gameOponentUsername)
        {
            if (game.GameMode == GameMode.HumanVsComputer)
            {
                return this.GetHumanVsComputerGameModeComputerName(gameStartingFirstUsername, gameOponentUsername);
            }
            else if (game.GameMode == GameMode.ComputerVsComputer)
            {
                return this.GetComputerVsComputerGameModeComputerName(game.TurnsCount, gameStartingFirstUsername, gameOponentUsername);
            }
            else
            {
                throw new UserNotAuthorizedException();
            }
        }

        private string GetHumanVsComputerGameModeComputerName(string gameStartingFirstUsername, string gameOponentUsername)
        {
            if (gameStartingFirstUsername == UserConstants.ComputerUsername || gameOponentUsername == UserConstants.ComputerUsername)
            {
                return UserConstants.ComputerUsername;
            }
            else if (gameStartingFirstUsername == UserConstants.OtherComputerUsername || gameOponentUsername == UserConstants.OtherComputerUsername)
            {
                return UserConstants.OtherComputerUsername;
            }
            else
            {
                throw new UserNotAuthorizedException();
            }
        }

        private string GetComputerVsComputerGameModeComputerName(int? gameTurnsCount, string startingFirstComputer, string startingSecondComputer)
        {
            if (gameTurnsCount % 1 == 0)
            {
                return startingFirstComputer;
            }
            else
            {
                return startingSecondComputer;
            }
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