namespace TicTacToe.ServiceLayerTests.MockHelpers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using DataLayer.Data;
    using DataLayer.Repository;
    using Models;
    using Moq;

    /// <summary>
    /// Generates a mock of the DataLayer
    /// </summary>
    public class DataLayerMockHelper
    {
        private List<ApplicationUser> Users { get; }

        private List<Game> Games { get; }

        private List<Tile> Tiles { get; }

        public DataLayerMockHelper()
        {
            this.Users = GetDefaultUsersList();
            this.Games = GetDefaultGamesList();
            this.Tiles = GetDefaultTilesList();
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
                    UserName = "georgi_iliev@yahoo.com"
                },
                new ApplicationUser()
                {
                    Id = "047e3484-b47a-47af-b384-cd6e99a3a6b8",
                    UserName = "the-other-guy@yahoo.com"
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
                this.CreateFinishedGame(),
                this.CreateSameUserInvalidGame()
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
                Tiles = this.GetDefaultTilesList()
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
                Tiles = this.GetDefaultTilesList()
            };

            return finishedGame;
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
                OponentId = "45897caa-c581-442d-a11a-7cf9b2375e13",
                TurnsCount = 1,
                GameName = "georgi_iliev@yahoo.com vs the-other-guy@yahoo.com",
                OponentName = "the-other-guy@yahoo.com",
                IsFinished = false,
                Tiles = this.GetDefaultTilesList()
            };

            return game;
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