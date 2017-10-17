namespace TicTacToe.Web.Tests.MockHelpers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Reflection;
    using System.Security.Principal;
    using System.Collections.Generic;
    using TicTacToe.Models;
    using Constants;
    using FrameworkExtentions.Mappings;
    using Moq;
    using TicTacToeCommon.Constants;
    using TicTacToe.Models.Enums;
    using ServiceLayer.Interfaces;

    /// <summary>
    /// Generates a mock of the ServiceLayer
    /// </summary>
    public class HumanVsComputerServiceLayerMockHelper
    {
        private const int ComputerUserIndex = 0;

        private const int HumanUserIndex = 1;

        private const int OtherComputerIndex = 2;

        private List<ApplicationUser> GameParticipants { get; }

        private List<Tile> DefaultTilesList { get; }

        private List<Tile> EmptyTilesList { get; }

        private Game ComputerVsHumanNewGameMock { get; }

        private Game HumanVsComputerNewGameMock { get; }

        private Game HumanVsComputerFinishedGameMock { get; }

        private Game HumanVsOtherComputerNewGameMock { get; }

        private Game OtherComputerVsHumanNewGameMock { get; }

        public HumanVsComputerServiceLayerMockHelper()
        {
            this.GameParticipants = this.CreateDefaultUsersMock();
            this.DefaultTilesList = this.CreateDefaultTilesMock();
            this.EmptyTilesList = this.CreateEmptyTilesMock();
            this.ComputerVsHumanNewGameMock = this.CreateNewComputerVsHumanGameMock();
            this.HumanVsComputerNewGameMock = this.CreateNewHumanVsComputerGameMock();
            this.HumanVsComputerFinishedGameMock = this.CreateNewComputerVsHumanFinishedGameMock();
            this.HumanVsOtherComputerNewGameMock = this.CreateNewHumanVsOtherComputerGameMock();
            this.OtherComputerVsHumanNewGameMock = this.CreateNewOtherComputerVsHumanGameMock();

            this.ConfigureAutoMapper();
        }

        /// <summary>
        /// Mocks all needed methods of ITicTacToeGameService
        /// </summary>
        /// <returns>Mock<ITicTacToeGameService></ITicTacToeGameService></returns>
        public Mock<ITicTacToeGameService> SetupTicTacToeServiceMock()
        {
            Mock<ITicTacToeGameService> serviceMock = new Mock<ITicTacToeGameService>();

            serviceMock.Setup(p => p.CreateNewGame(MockConstants.ComputerEmail, MockConstants.UserEmail))
                       .Returns(this.ComputerVsHumanNewGameMock);

            serviceMock.Setup(p => p.CreateNewGame(MockConstants.UserEmail, MockConstants.UserEmail))
                       .Returns(this.HumanVsComputerNewGameMock);

            serviceMock.Setup(p => p.CreateNewHumanVsComputerGame(MockConstants.UserEmail, MockConstants.ComputerEmail, true))
                       .Returns(this.HumanVsComputerNewGameMock);

            serviceMock.Setup(p => p.CreateNewHumanVsComputerGame(MockConstants.UserEmail, MockConstants.ComputerEmail, false))
                       .Returns(this.ComputerVsHumanNewGameMock);

            serviceMock.Setup(p => p.CreateNewHumanVsComputerGame(MockConstants.UserEmail, MockConstants.OtherComputerUsername, true))
                       .Returns(this.HumanVsOtherComputerNewGameMock);

            serviceMock.Setup(p => p.CreateNewHumanVsComputerGame(MockConstants.UserEmail, MockConstants.OtherComputerUsername, false))
                       .Returns(this.OtherComputerVsHumanNewGameMock);

            serviceMock.Setup(p => p.RecreatePreviousGame(MockConstants.UserEmail, GameMode.HumanVsComputer))
                       .Returns(this.HumanVsComputerNewGameMock);

            serviceMock.Setup(p => p.GetGameById(1)).Returns(this.ComputerVsHumanNewGameMock);

            serviceMock.Setup(p => p.GetGameById(2)).Returns(this.HumanVsComputerNewGameMock);

            serviceMock.Setup(p => p.GetGameById(3)).Returns(this.HumanVsComputerFinishedGameMock);

            serviceMock.Setup(p => p.GetGameById(4)).Returns(this.HumanVsOtherComputerNewGameMock);

            serviceMock.Setup(p => p.GetGameById(5)).Returns(this.OtherComputerVsHumanNewGameMock);

            serviceMock.Setup(p => p.GetComputerMove(1))
                       .Returns(4);

            serviceMock.Setup(p => p.PlaceTurn(1, 4, MockConstants.ComputerEmail));

            serviceMock.Setup(p => p.GetAllUnfinishedGames("georgi_iliev@yahoo.com", GameMode.HumanVsComputer))
                       .Returns(new List<Game>() { this.HumanVsComputerFinishedGameMock });

            return serviceMock;
        }

        /// <summary>
        /// Mocks HttpContext and Identity
        /// </summary>
        /// <returns>Mock<ControllerContext></ControllerContext></returns>
        public Mock<ControllerContext> SetupControllerContextMock()
        {
            Mock<ControllerContext> mockContext = new Mock<ControllerContext>();

            mockContext.SetupGet(p => p.HttpContext.User.Identity.IsAuthenticated).Returns(true);
            mockContext.SetupGet(p => p.HttpContext.User.Identity.Name).Returns(MockConstants.UserEmail);
            mockContext.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);

            Mock<IPrincipal> mockPrincipal = new Mock<IPrincipal>();
            mockPrincipal.Setup(p => p.Identity.Name).Returns(MockConstants.UserEmail);
            mockPrincipal.Setup(p => p.Identity.IsAuthenticated).Returns(true);

            return mockContext;
        }

        /// <summary>
        /// Triggers automapper self-configuration from the TicTacToe.Web assembly
        /// </summary>
        private void ConfigureAutoMapper()
        {
            Assembly webAssembly = Assembly.Load("TicTacToe.Web");

            List<Assembly> executingAssembly = new List<Assembly>
            {
                webAssembly
            };

            AutoMapperConfig autoMapperConfig = new AutoMapperConfig(executingAssembly);

            autoMapperConfig.LoadMappings();
        }

        /// <summary>
        /// Creates a list of two predefined users.
        /// </summary>
        /// <returns>List<ApplicationUser></ApplicationUser></returns>
        private List<ApplicationUser> CreateDefaultUsersMock()
        {
            List<ApplicationUser> result = new List<ApplicationUser>()
            {
                new ApplicationUser()
                {
                    Id = UserConstants.ComputerId,
                    UserName = UserConstants.ComputerUsername,
                    Email = UserConstants.ComputerEmail
                },
                new ApplicationUser()
                {
                    Id = UserConstants.UserId,
                    UserName = UserConstants.UserUsername,
                    Email = UserConstants.UserUsername
                },
                new ApplicationUser()
                {
                    Id = UserConstants.OtherComputerId,
                    UserName = UserConstants.OtherComputerUsername,
                    Email = UserConstants.OtherComputerEmail
                }
            };

            return result;
        }

        /// <summary>
        /// Creates a list of 8 empty tiles and Center is taken
        /// </summary>
        /// <returns>List<Tile></Tile></returns>
        private List<Tile> CreateDefaultTilesMock()
        {
            List<Tile> defaultTilesList = new List<Tile>();

            for (var i = 1; i < 10; i++)
            {
                Tile tile = new Tile()
                {
                    Id = i,
                    GameId = 1,
                    IsEmpty = true,
                    Value = string.Empty
                };

                defaultTilesList.Add(tile);
            }

            defaultTilesList.ElementAt(4).IsEmpty = false;
            defaultTilesList.ElementAt(4).Value = "X";

            return defaultTilesList;
        }

        /// <summary>
        /// Creates a list of 9 empty tiles and Center is taken
        /// </summary>
        /// <returns>List<Tile></Tile></returns>
        private List<Tile> CreateEmptyTilesMock()
        {
            List<Tile> defaultTilesList = new List<Tile>();

            for (var i = 1; i < 10; i++)
            {
                Tile tile = new Tile()
                {
                    Id = i,
                    GameId = 1,
                    IsEmpty = true,
                    Value = string.Empty
                };

                defaultTilesList.Add(tile);
            }

            return defaultTilesList;
        }

        /// <summary>
        /// Creates a new computer vs human game
        /// </summary>
        /// <returns>Game</returns>
        private Game CreateNewComputerVsHumanGameMock()
        {
            Game game = new Game()
            {
                Id = 1,
                StartDate = DateTime.Now,
                GameName = this.GameParticipants[0].UserName + " vs " + this.GameParticipants[1].UserName,
                ApplicationUser = this.GameParticipants[0],
                ApplicationUserId = this.GameParticipants[0].Id,
                Oponent = this.GameParticipants[1],
                OponentId = this.GameParticipants[1].Id,
                OponentName = this.GameParticipants[1].UserName,
                TurnsCount = 2,
                Tiles = this.DefaultTilesList
            };

            return game;
        }

        /// <summary>
        /// Creates a new human vs computer game
        /// </summary>
        /// <returns>Game</returns>
        private Game CreateNewHumanVsComputerGameMock()
        {
            Game game = new Game()
            {
                Id = 2,
                StartDate = DateTime.Now,
                GameName = this.GameParticipants[1].UserName + " vs " + this.GameParticipants[0].UserName,
                ApplicationUser = this.GameParticipants[1],
                ApplicationUserId = this.GameParticipants[1].Id,
                Oponent = this.GameParticipants[0],
                OponentId = this.GameParticipants[0].Id,
                OponentName = this.GameParticipants[0].UserName,
                TurnsCount = 1,
                Tiles = this.EmptyTilesList
            };

            return game;
        }

        /// <summary>
        /// Creates a new computer vs human finished game
        /// </summary>
        /// <returns>Game</returns>
        private Game CreateNewComputerVsHumanFinishedGameMock()
        {
            Game game = new Game()
            {
                Id = 3,
                StartDate = DateTime.Now,
                GameName = this.GameParticipants[0].UserName + " vs " + this.GameParticipants[1].UserName,
                ApplicationUser = this.GameParticipants[0],
                ApplicationUserId = this.GameParticipants[0].Id,
                Oponent = this.GameParticipants[1],
                OponentId = this.GameParticipants[1].Id,
                OponentName = this.GameParticipants[1].UserName,
                Tiles = this.DefaultTilesList,
                TurnsCount = 9,
                IsFinished = true,
            };

            return game;
        }

        /// <summary>
        /// Creates a new human vs other computer game
        /// </summary>
        /// <returns>Game</returns>
        private Game CreateNewHumanVsOtherComputerGameMock()
        {
            Game game = new Game()
            {
                Id = 4,
                StartDate = DateTime.Now,
                GameName = UserConstants.UserUsername + " vs " + UserConstants.OtherComputerUsername,
                ApplicationUser = this.GameParticipants[HumanUserIndex],
                ApplicationUserId = this.GameParticipants[HumanUserIndex].Id,
                Oponent = this.GameParticipants[OtherComputerIndex],
                OponentId = this.GameParticipants[OtherComputerIndex].Id,
                OponentName = this.GameParticipants[OtherComputerIndex].UserName,
                TurnsCount = 1,
                Tiles = this.EmptyTilesList
            };

            return game;
        }

        /// <summary>
        /// Creates a new other computer vs human
        /// </summary>
        /// <returns>Game</returns>
        private Game CreateNewOtherComputerVsHumanGameMock()
        {
            Game game = new Game()
            {
                Id = 5,
                StartDate = DateTime.Now,
                GameName = UserConstants.OtherComputerUsername + " vs " + UserConstants.UserUsername,
                ApplicationUser = this.GameParticipants[OtherComputerIndex],
                ApplicationUserId = this.GameParticipants[OtherComputerIndex].Id,
                Oponent = this.GameParticipants[HumanUserIndex],
                OponentId = this.GameParticipants[HumanUserIndex].Id,
                OponentName = this.GameParticipants[HumanUserIndex].UserName,
                TurnsCount = 2,
                Tiles = this.DefaultTilesList
            };

            return game;
        }
    }
}