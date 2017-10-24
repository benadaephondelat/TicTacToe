namespace TicTacToe.ServiceLayerTests.MockHelpers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using DataLayer.Data;
    using DataLayer.Repository;
    using Models;
    using Models.Enums;
    using Moq;
    using TicTacToeCommon.Constants;

    /// <summary>
    /// Generates a mock of the DataLayer
    /// </summary>
    public class DataLayerMockHelper
    {
        private const int HumanPlayerIndex = 0;

        private const int OtherHumanPlayerIndex = 1;

        private const int HumanPlayerWithoutGamesIndex = 2;

        private const int ComputerPlayerIndex = 3;

        private const int OtherComputerPlayerIndex = 4;

        private List<ApplicationUser> Users { get; }

        private List<Game> Games { get; }

        private List<Tile> Tiles { get; }

        public DataLayerMockHelper()
        {
            this.Games = this.GetDefaultGamesList();
            this.Users = this.GetDefaultUsersList();
            this.Tiles = this.GetDefaultTilesList();
        }

        /// <summary>
        /// Creates a mock of the DataLayer and it's repositories
        /// </summary>
        /// <returns>Mock ITicTacToeData</returns>
        public Mock<ITicTacToeData> SetupTicTacToeDataMock()
        {
            Mock<ITicTacToeData> ticTacToeDataMock = new Mock<ITicTacToeData>();

            AddApplicationUserRepoMock(ticTacToeDataMock);

            AddGameRepoMock(ticTacToeDataMock);

            AddTileRepoMock(ticTacToeDataMock);

            return ticTacToeDataMock;
        }

        /// <summary>
        /// Inserts mocked ApplicationUser repository to the DataLayer mock 
        /// </summary>
        /// <param name="ticTacToeDataMock">DataLayer mock</param>
        private void AddApplicationUserRepoMock(Mock<ITicTacToeData> ticTacToeDataMock)
        {
            IGenericRepository<ApplicationUser> applicationUserRepoMock = SetupApplicationUserRepoMock();

            ticTacToeDataMock.Setup(p => p.Users).Returns(applicationUserRepoMock);
        }

        /// <summary>
        /// Generates a mock of the ApplicationUser repository.
        /// </summary>
        /// <returns>IGenericRepository ApplicationUser</returns>
        private IGenericRepository<ApplicationUser> SetupApplicationUserRepoMock()
        {
            Mock<IGenericRepository<ApplicationUser>> userRepoMock = new Mock<IGenericRepository<ApplicationUser>>();

            userRepoMock.Setup(prop => prop.All()).Returns(this.Users.AsQueryable());

            return userRepoMock.Object;
        }

        /// <summary>
        /// Inserts mocked Game repository to the DataLayer mock 
        /// </summary>
        /// <param name="ticTacToeDataMock">DataLayer mock</param>
        private void AddGameRepoMock(Mock<ITicTacToeData> ticTacToeDataMock)
        {
            IGenericRepository<Game> gameRepoMock = SetupGameRepoMock();

            ticTacToeDataMock.Setup(p => p.Games).Returns(gameRepoMock);
        }

        /// <summary>
        /// Generates a mock of the Game repository.
        /// </summary>
        /// <returns>IGenericRepository Game</returns>
        private IGenericRepository<Game> SetupGameRepoMock()
        {
            Mock<IGenericRepository<Game>> gameRepoMock = new Mock<IGenericRepository<Game>>();

            gameRepoMock.Setup(prop => prop.All()).Returns(this.Games.AsQueryable());

            return gameRepoMock.Object;
        }

        /// <summary>
        /// Inserts mocked Tile repository to the DataLayer mock 
        /// </summary>
        /// <param name="ticTacToeDataMock">DataLayer mock</param>        
        private void AddTileRepoMock(Mock<ITicTacToeData> ticTacToeDataMock)
        {
            IGenericRepository<Tile> tileRepoMock = SetupTileRepoMock();

            ticTacToeDataMock.Setup(p => p.Tiles).Returns(tileRepoMock);
        }

        /// <summary>
        /// Generates a mock of the Tile repository.
        /// </summary>
        /// <returns>IGenericRepository Tile</returns>
        private IGenericRepository<Tile> SetupTileRepoMock()
        {
            Mock<IGenericRepository<Tile>> tileRepoMock = new Mock<IGenericRepository<Tile>>();

            tileRepoMock.Setup(prop => prop.All()).Returns(this.Tiles.AsQueryable());

            return tileRepoMock.Object;
        }

        /// <summary>
        /// Returns a list of fake users.
        /// </summary>
        /// <returns>List ApplicationUser</returns>
        private List<ApplicationUser> GetDefaultUsersList()
        {
            List<ApplicationUser> usersList = new List<ApplicationUser>()
            {
                new ApplicationUser()
                {
                    Id = "45897caa-c581-442d-a11a-7cf9b2375e13",
                    UserName = "georgi_iliev@yahoo.com",
                    Games = GetDefaultGamesList()
                },
                new ApplicationUser()
                {
                    Id = "047e3484-b47a-47af-b384-cd6e99a3a6b8",
                    UserName = "the-other-guy@yahoo.com",
                    Games = GetDefaultGamesList()
                },
                new ApplicationUser()
                {
                    Id = "132e3484-b47a-47af-b384-cd6e99a3a6123",
                    UserName = "new-user-without-games@yahoo.com",
                    Games = new List<Game>()
                },
                new ApplicationUser()
                {
                    Id = "computer-id",
                    UserName = "computer@yahoo.com",
                    Games = GetDefaultGamesList(),
                },
                new ApplicationUser()
                {
                    Id = "other-computer-id",
                    UserName = "other-computer@yahoo.com",
                    Games = GetDefaultGamesList()
                }
            };

            return usersList;
        }

        /// <summary>
        /// Returns a list of fake games.
        /// </summary>
        /// <returns>List Game</returns>
        private List<Game> GetDefaultGamesList()
        {
            List<Game> gamesList = new List<Game>()
            {
                this.CreateNewHumanVsHumanGameMock(),
                this.CreateSameUserInvalidGame(),
                this.CreateFinishedGame(),
                this.CreateLastFinishedGame(),
                this.CreateNewHumanVsComputerGame(),
                this.CreateFinishedHumanVsComputerGame(),
                this.CreateNewComputerVsHumanGame(),
                this.CreateFinishedComputerVsHumanGame(),
                this.CreateNewHumanVsOtherComputerGame(),
                this.CreateNewOtherComputerVsHumanGame(),
                this.CreateComputerVsHumanGameWhereComputerUserIsNotPresent()
            };

            return gamesList;
        }

        /// <summary>
        /// Creates a mock of game
        /// Same user is both the homeside and the awayside.
        /// </summary>
        /// <returns>Game</returns>
        private Game CreateSameUserInvalidGame()
        {
            Game game = new Game()
            {
                Id = 3,
                StartDate = DateTime.Now,
                ApplicationUser = new ApplicationUser()
                {
                    Id = "45897caa-c581-442d-a11a-7cf9b2375e13",
                    UserName = "georgi_iliev@yahoo.com"
                },
                ApplicationUserId = "45897caa-c581-442d-a11a-7cf9b2375e13",
                Oponent = new ApplicationUser()
                {
                    Id = "45897caa-c581-442d-a11a-7cf9b2375e13",
                    UserName = "georgi_iliev@yahoo.com"
                },
                OponentId = "45897caa-c581-442d-a11a-7cf9b2375e13",
                TurnsCount = 0,
                GameName = "georgi_iliev@yahoo.com vs the-other-guy@yahoo.com",
                OponentName = "the-other-guy@yahoo.com",
                IsFinished = false,
                GameState = GameState.NotFinished,
                Tiles = this.GetDefaultTilesList(),
                GameOwner = new ApplicationUser()
                {
                    Id = "45897caa-c581-442d-a11a-7cf9b2375e13",
                    UserName = "georgi_iliev@yahoo.com"
                },
                GameOwnerId = "45897caa-c581-442d-a11a-7cf9b2375e13"
            };

            return game;
        }

        /// <summary>
        /// Creates a mock of a finished game.
        /// </summary>
        /// <returns>Game</returns>
        private Game CreateFinishedGame()
        {
            Game finishedGame = new Game()
            {
                Id = 2,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMinutes(1),
                ApplicationUser = new ApplicationUser()
                {
                    Id = "45897caa-c581-442d-a11a-7cf9b2375e13",
                    UserName = "georgi_iliev@yahoo.com"
                },
                ApplicationUserId = "45897caa-c581-442d-a11a-7cf9b2375e13",
                Oponent = new ApplicationUser()
                {
                    Id = "047e3484-b47a-47af-b384-cd6e99a3a6b8",
                    UserName = "the-other-guy@yahoo.com"
                },
                OponentId = "45897caa-c581-442d-a11a-7cf9b2375e13",
                TurnsCount = 9,
                GameName = "georgi_iliev@yahoo.com vs the-other-guy@yahoo.com",
                OponentName = "the-other-guy@yahoo.com",
                IsFinished = true,
                GameState = GameState.Won,
                Tiles = this.GetHomesideUserEarlyWinTilesList(),
                GameOwner = new ApplicationUser()
                {
                    Id = "45897caa-c581-442d-a11a-7cf9b2375e13",
                    UserName = "georgi_iliev@yahoo.com"
                },
                GameOwnerId = "45897caa-c581-442d-a11a-7cf9b2375e13"
            };

            return finishedGame;
        }

        /// <summary>
        /// Creates a mock of a finished game that is played after the first finished game.
        /// </summary>
        /// <returns>Game</returns>
        private Game CreateLastFinishedGame()
        {
            Game finishedGame = new Game()
            {
                Id = 7,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMinutes(2),
                ApplicationUser = new ApplicationUser()
                {
                    Id = "45897caa-c581-442d-a11a-7cf9b2375e13",
                    UserName = "georgi_iliev@yahoo.com"
                },
                ApplicationUserId = "45897caa-c581-442d-a11a-7cf9b2375e13",
                Oponent = new ApplicationUser()
                {
                    Id = "047e3484-b47a-47af-b384-cd6e99a3a6b8",
                    UserName = "the-other-guy@yahoo.com"
                },
                OponentId = "45897caa-c581-442d-a11a-7cf9b2375e13",
                TurnsCount = 9,
                GameName = "georgi_iliev@yahoo.com vs the-other-guy@yahoo.com",
                OponentName = "the-other-guy@yahoo.com",
                IsFinished = true,
                GameState = GameState.Won,
                Tiles = this.GetHomesideUserEarlyWinTilesList(),
                GameOwner = new ApplicationUser()
                {
                    Id = "45897caa-c581-442d-a11a-7cf9b2375e13",
                    UserName = "georgi_iliev@yahoo.com"
                },
                GameOwnerId = "45897caa-c581-442d-a11a-7cf9b2375e13"
            };

            return finishedGame;
        }

        /// <summary>
        /// Creates a mock of a new human vs computer game.
        /// </summary>
        /// <returns>Game</returns>
        private Game CreateNewHumanVsComputerGame()
        {
            Game newHumanVsComputerGame = new Game()
            {
                Id = 8,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMinutes(2),
                ApplicationUser = new ApplicationUser()
                {
                    Id = UserConstants.UserId,
                    UserName = UserConstants.UserUsername
                },
                ApplicationUserId = UserConstants.UserId,
                Oponent = new ApplicationUser()
                {
                    Id = UserConstants.ComputerId,
                    UserName = UserConstants.ComputerUsername
                },
                OponentId = UserConstants.OtherComputerId,
                TurnsCount = 1,
                GameName = UserConstants.UserUsername + " vs " + UserConstants.OtherComputerUsername,
                OponentName = UserConstants.ComputerUsername,
                IsFinished = false,
                GameState = GameState.NotFinished,
                GameMode = GameMode.HumanVsComputer,
                Tiles = this.GetDefaultTilesList(),
                GameOwner = new ApplicationUser()
                {
                    Id = "45897caa-c581-442d-a11a-7cf9b2375e13",
                    UserName = "georgi_iliev@yahoo.com"
                },
                GameOwnerId = "45897caa-c581-442d-a11a-7cf9b2375e13"
            };

            return newHumanVsComputerGame;
        }

        /// <summary>
        /// Creates a mock of a finished human vs computer game.
        /// </summary>
        /// <returns>Game</returns>
        private Game CreateFinishedHumanVsComputerGame()
        {
            Game finishedHumanVsComputerGame = new Game()
            {
                Id = 9,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMinutes(2),
                ApplicationUser = new ApplicationUser()
                {
                    Id = UserConstants.UserId,
                    UserName = UserConstants.UserUsername
                },
                ApplicationUserId = UserConstants.UserId,
                Oponent = new ApplicationUser()
                {
                    Id = UserConstants.ComputerId,
                    UserName = UserConstants.ComputerUsername
                },
                OponentId = UserConstants.OtherComputerId,
                TurnsCount = 9,
                GameName = UserConstants.UserUsername + " vs " + UserConstants.OtherComputerUsername,
                OponentName = UserConstants.ComputerUsername,
                IsFinished = true,
                GameState = GameState.Won,
                GameMode = GameMode.HumanVsComputer,
                Tiles = this.GenerateHomesideUserEarlyWinTiles(),
                GameOwner = new ApplicationUser()
                {
                    Id = "45897caa-c581-442d-a11a-7cf9b2375e13",
                    UserName = "georgi_iliev@yahoo.com"
                },
                GameOwnerId = "45897caa-c581-442d-a11a-7cf9b2375e13"
            };

            return finishedHumanVsComputerGame;
        }

        /// <summary>
        /// Creates a mock of a new computer vs human game.
        /// </summary>
        /// <returns>Game</returns>
        private Game CreateNewComputerVsHumanGame()
        {
            Game newComputerVsHumanGame = new Game()
            {
                Id = 10,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMinutes(2),
                ApplicationUser = new ApplicationUser()
                {
                    Id = UserConstants.ComputerId,
                    UserName = UserConstants.ComputerUsername
                },
                ApplicationUserId = UserConstants.ComputerId,
                Oponent = new ApplicationUser()
                {
                    Id = UserConstants.UserId,
                    UserName = UserConstants.UserUsername
                },
                OponentId = UserConstants.UserId,
                TurnsCount = 1,
                GameName = UserConstants.ComputerUsername + " vs " + UserConstants.UserUsername,
                OponentName = UserConstants.UserUsername,
                IsFinished = false,
                GameState = GameState.NotFinished,
                GameMode = GameMode.HumanVsComputer,
                Tiles = this.GetDefaultTilesList(),
                GameOwner = new ApplicationUser()
                {
                    Id = "45897caa-c581-442d-a11a-7cf9b2375e13",
                    UserName = "georgi_iliev@yahoo.com"
                },
                GameOwnerId = "45897caa-c581-442d-a11a-7cf9b2375e13"
            };

            return newComputerVsHumanGame;
        }

        /// <summary>
        /// Creates a mock of a new other computer vs human game.
        /// </summary>
        /// <returns>Game</returns>
        private Game CreateNewOtherComputerVsHumanGame()
        {
            Game newOtherComputerVsHumanGame = new Game()
            {
                Id = 11,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMinutes(2),
                ApplicationUser = new ApplicationUser()
                {
                    Id = UserConstants.OtherComputerId,
                    UserName = UserConstants.OtherComputerUsername
                },
                ApplicationUserId = UserConstants.OtherComputerId,
                Oponent = new ApplicationUser()
                {
                    Id = UserConstants.UserId,
                    UserName = UserConstants.UserUsername
                },
                OponentId = UserConstants.UserId,
                TurnsCount = 1,
                GameName = UserConstants.OtherComputerUsername + " vs " + UserConstants.UserUsername,
                OponentName = UserConstants.UserUsername,
                IsFinished = false,
                GameState = GameState.NotFinished,
                GameMode = GameMode.HumanVsComputer,
                Tiles = this.GetDefaultTilesList(),
                GameOwner = new ApplicationUser()
                {
                    Id = "45897caa-c581-442d-a11a-7cf9b2375e13",
                    UserName = "georgi_iliev@yahoo.com"
                },
                GameOwnerId = "45897caa-c581-442d-a11a-7cf9b2375e13"
            };

            return newOtherComputerVsHumanGame;
        }

        /// <summary>
        /// Creates a mock of a new human vs other computer game.
        /// </summary>
        /// <returns>Game</returns>
        private Game CreateNewHumanVsOtherComputerGame()
        {
            Game newOtherComputerVsHumanGame = new Game()
            {
                Id = 12,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMinutes(2),
                ApplicationUser = new ApplicationUser()
                {
                    Id = UserConstants.UserId,
                    UserName = UserConstants.UserUsername
                },
                ApplicationUserId = UserConstants.UserId,
                Oponent = new ApplicationUser()
                {
                    Id = UserConstants.OtherComputerId,
                    UserName = UserConstants.OtherComputerUsername
                },
                OponentId = UserConstants.OtherComputerId,
                TurnsCount = 1,
                GameName = UserConstants.UserUsername + " vs " + UserConstants.OtherComputerUsername,
                OponentName = UserConstants.OtherComputerUsername,
                IsFinished = false,
                GameState = GameState.NotFinished,
                GameMode = GameMode.HumanVsComputer,
                Tiles = this.GetDefaultTilesList(),
                GameOwner = new ApplicationUser()
                {
                    Id = "45897caa-c581-442d-a11a-7cf9b2375e13",
                    UserName = "georgi_iliev@yahoo.com"
                },
                GameOwnerId = "45897caa-c581-442d-a11a-7cf9b2375e13"
            };

            return newOtherComputerVsHumanGame;
        }

        private Game CreateFinishedComputerVsHumanGame()
        {
            Game finishedComputerVsHumanGame = new Game()
            {
                Id = 8,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMinutes(2),
                ApplicationUser = new ApplicationUser()
                {
                    Id = UserConstants.ComputerId,
                    UserName = UserConstants.ComputerUsername
                },
                ApplicationUserId = UserConstants.ComputerId,
                Oponent = new ApplicationUser()
                {
                    Id = UserConstants.UserId,
                    UserName = UserConstants.UserUsername
                },
                OponentId = UserConstants.UserId,
                TurnsCount = 9,
                GameName = UserConstants.ComputerUsername + " vs " + UserConstants.UserUsername,
                OponentName = UserConstants.UserUsername,
                IsFinished = true,
                GameState = GameState.Won,
                GameMode = GameMode.HumanVsComputer,
                Tiles = this.GenerateHomesideUserEarlyWinTiles(),
                GameOwner = new ApplicationUser()
                {
                    Id = "45897caa-c581-442d-a11a-7cf9b2375e13",
                    UserName = "georgi_iliev@yahoo.com"
                },
                GameOwnerId = "45897caa-c581-442d-a11a-7cf9b2375e13"
            };

            return finishedComputerVsHumanGame;
        }

        /// <summary>
        /// Creates a mock of a new human vs human game.
        /// </summary>
        /// <returns>Game</returns>
        private Game CreateNewHumanVsHumanGameMock()
        {
            Game game = new Game()
            {
                Id = 1,
                StartDate = DateTime.Now,
                ApplicationUser = new ApplicationUser()
                {
                    Id = "45897caa-c581-442d-a11a-7cf9b2375e13",
                    UserName = "georgi_iliev@yahoo.com"
                },
                ApplicationUserId = "45897caa-c581-442d-a11a-7cf9b2375e13",
                Oponent = new ApplicationUser()
                {
                    Id = "047e3484-b47a-47af-b384-cd6e99a3a6b8",
                    UserName = "the-other-guy@yahoo.com"
                },
                OponentId = "047e3484-b47a-47af-b384-cd6e99a3a6b8",
                TurnsCount = 1,
                GameName = "georgi_iliev@yahoo.com vs the-other-guy@yahoo.com",
                OponentName = "the-other-guy@yahoo.com",
                IsFinished = false,
                Tiles = this.GetDefaultTilesList(),
                GameState = GameState.NotFinished,
                GameOwner = new ApplicationUser()
                {
                    Id = "45897caa-c581-442d-a11a-7cf9b2375e13",
                    UserName = "georgi_iliev@yahoo.com"
                },
                GameOwnerId = "45897caa-c581-442d-a11a-7cf9b2375e13"
            };

            return game;
        }

        private Game CreateComputerVsHumanGameWhereComputerUserIsNotPresent()
        {
            Game game = new Game()
            {
                Id = 14,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMinutes(2),
                ApplicationUser = new ApplicationUser()
                {
                    Id = UserConstants.UserId,
                    UserName = UserConstants.UserUsername
                },
                ApplicationUserId = UserConstants.UserId,
                Oponent = new ApplicationUser()
                {
                    Id = UserConstants.UserId,
                    UserName = UserConstants.UserUsername
                },
                OponentId = UserConstants.UserId,
                TurnsCount = 1,
                GameName = UserConstants.UserUsername + " vs " + UserConstants.UserUsername,
                OponentName = UserConstants.UserUsername,
                IsFinished = false,
                GameState = GameState.NotFinished,
                GameMode = GameMode.HumanVsComputer,
                Tiles = this.GetDefaultTilesList(),
                GameOwner = new ApplicationUser()
                {
                    Id = "45897caa-c581-442d-a11a-7cf9b2375e13",
                    UserName = "georgi_iliev@yahoo.com"
                },
                GameOwnerId = "45897caa-c581-442d-a11a-7cf9b2375e13"
            };

            return game;
        }

        /// <summary>
        /// Return a list of ti
        /// </summary>
        /// <returns>List<Tile></Tile></returns>
        private List<Tile> GetHomesideUserEarlyWinTilesList()
        {
            List<Tile> defaultTilesList = GenerateHomesideUserEarlyWinTiles();

            return defaultTilesList;
        }

        /// <summary>
        /// Creates a list of tiles
        /// </summary>
        /// <returns>List Tile</returns>
        private List<Tile> GenerateHomesideUserEarlyWinTiles()
        {
            List<Tile> result = GenerateDefaultTilesList();

            result.ElementAt(0).Value = "X";
            result.ElementAt(1).Value = "X";
            result.ElementAt(2).Value = "X";
            result.ElementAt(3).Value = "O";
            result.ElementAt(4).Value = "O";

            return result;
        }

        /// <summary>
        /// Return a list of fake tiles.
        /// </summary>
        /// <returns>List<Tile></Tile></returns>
        private List<Tile> GetDefaultTilesList()
        {
            List<Tile> defaultTilesList = GenerateDefaultTilesList();

            return defaultTilesList;
        }

        /// <summary>
        /// Creates a list of 9 empty fake tiles
        /// </summary>
        /// <returns>List Tile</returns>
        private List<Tile> GenerateDefaultTilesList()
        {
            List<Tile> defaultTilesList = new List<Tile>();

            for (var i = 1; i < 10; i++)
            {
                Tile tile = new Tile() { GameId = 1, Id = i, IsEmpty = true, Value = string.Empty };

                defaultTilesList.Add(tile);
            }

            return defaultTilesList;
        }
    }
}