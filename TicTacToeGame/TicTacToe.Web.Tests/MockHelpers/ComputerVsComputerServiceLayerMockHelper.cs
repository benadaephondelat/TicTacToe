namespace TicTacToe.Web.Tests.MockHelpers
{
    using System;
    using System.Linq;
    using System.Security.Principal;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Web.Mvc;
    using TicTacToe.Models;
    using TicTacToe.Models.Enums;
    using ServiceLayer.TicTacToeGameService;
    using Constants;
    using Moq;
    using FrameworkExtentions.Mappings;
    using ServiceLayer.Interfaces;

    public class ComputerVsComputerServiceLayerMockHelper
    {
        private List<Tile> EmptyTilesList { get; }

        private Game ComputerVsOtherComputerNewGameMock { get; }

        private Game OtherComputerVsComputerNewGameMock { get; }

        private Game ComputerVsOtherComputerFinishedGameMock { get; }

        private ApplicationUser ApplicationUser = new ApplicationUser()
        {
            Id = MockConstants.UserId,
            UserName = MockConstants.UserEmail,
            Email = MockConstants.UserUsername
        };

        private ApplicationUser ComputerUser = new ApplicationUser()
        {
            Id = MockConstants.ComputerId,
            UserName = MockConstants.ComputerUsername,
            Email = MockConstants.ComputerEmail
        };

        private ApplicationUser OtherComputerUser = new ApplicationUser()
        {
            Id = MockConstants.OtherComputerId,
            UserName = MockConstants.OtherComputerUsername,
            Email = MockConstants.OtherComputerEmail
        };

        public ComputerVsComputerServiceLayerMockHelper()
        {
            this.EmptyTilesList = this.CreateEmptyTilesMock();
            this.ComputerVsOtherComputerNewGameMock = this.CreateNewComputerVsOtherComputerGameMock();
            this.OtherComputerVsComputerNewGameMock = this.CreateNewOtherComputerVsComputerGameMock();
            this.ComputerVsOtherComputerFinishedGameMock = this.CreateComputerVsOtherComputerFinishedGameMock();

            this.ConfigureAutoMapper();
        }

        /// <summary>
        /// Mocks all needed methods of ITicTacToeGameService
        /// </summary>
        /// <returns>Mock<ITicTacToeGameService></ITicTacToeGameService></returns>
        public Mock<ITicTacToeGameService> SetupTicTacToeServiceMock()
        {
            Mock<ITicTacToeGameService> serviceMock = new Mock<ITicTacToeGameService>();

            serviceMock.Setup(p => p.CreateNewComputerVsComputerGame(MockConstants.UserEmail, MockConstants.ComputerUsername, MockConstants.OtherComputerUsername))
                       .Returns(this.ComputerVsOtherComputerNewGameMock);

            serviceMock.Setup(p => p.GetGameById(1)).Returns(this.ComputerVsOtherComputerNewGameMock);

            serviceMock.Setup(p => p.CreateNewComputerVsComputerGame(MockConstants.UserEmail, MockConstants.OtherComputerUsername, MockConstants.ComputerUsername))
                       .Returns(this.OtherComputerVsComputerNewGameMock);

            serviceMock.Setup(p => p.GetGameById(2)).Returns(this.OtherComputerVsComputerNewGameMock);

            serviceMock.Setup(p => p.GetGameById(3)).Returns(this.ComputerVsOtherComputerFinishedGameMock);

            serviceMock.Setup(p => p.GetComputerMove(1)).Returns(4);

            serviceMock.Setup(p => p.GetComputerMove(2)).Returns(6);

            serviceMock.Setup(p => p.PlaceTurn(1, 4, MockConstants.UserUsername))
                       .Callback(() => this.PlaceTurnOnNewComputerVsOtherComputerGame());

            serviceMock.Setup(p => p.PlaceTurn(2, 6, MockConstants.UserUsername))
                       .Callback(() => this.PlaceTurnOnNewOtherComputerVsComputerGame());

            serviceMock.Setup(p => p.RecreatePreviousGame(MockConstants.UserEmail, GameMode.ComputerVsComputer))
                       .Returns(this.ComputerVsOtherComputerNewGameMock);

            serviceMock.Setup(p => p.GetAllUnfinishedGames(MockConstants.UserEmail, GameMode.ComputerVsComputer))
                       .Returns(new List<Game>() { this.ComputerVsOtherComputerNewGameMock });

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
        /// Creates a new computer vs other computer game
        /// </summary>
        /// <returns>Game</returns>
        private Game CreateNewComputerVsOtherComputerGameMock()
        {
            Game game = new Game()
            {
                Id = 1,
                StartDate = DateTime.Now,
                GameName = MockConstants.ComputerUsername + " vs " + MockConstants.OtherComputerUsername,
                ApplicationUser = this.ComputerUser,
                ApplicationUserId = this.ComputerUser.Id,
                Oponent = this.OtherComputerUser,
                OponentId = this.OtherComputerUser.Id,
                OponentName = this.OtherComputerUser.UserName,
                TurnsCount = 1,
                Tiles = this.EmptyTilesList,
                GameMode = GameMode.ComputerVsComputer,
                GameOwner = this.ApplicationUser,
                GameOwnerId = this.ApplicationUser.Id
            };

            return game;
        }

        /// <summary>
        /// Creates a new computer vs other computer game
        /// </summary>
        /// <returns>Game</returns>
        private Game CreateNewOtherComputerVsComputerGameMock()
        {
            Game game = new Game()
            {
                Id = 2,
                StartDate = DateTime.Now,
                GameName = MockConstants.OtherComputerUsername + " vs " + MockConstants.ComputerUsername,
                ApplicationUser = this.OtherComputerUser,
                ApplicationUserId = this.OtherComputerUser.Id,
                Oponent = this.ComputerUser,
                OponentId = this.ComputerUser.Id,
                OponentName = this.ComputerUser.UserName,
                TurnsCount = 1,
                Tiles = this.EmptyTilesList,
                GameMode = GameMode.ComputerVsComputer,
                GameOwner = this.ApplicationUser,
                GameOwnerId = this.ApplicationUser.Id
            };

            return game;
        }

        /// <summary>
        /// Creates a new computer vs other computer finished game
        /// </summary>
        /// <returns>Game</returns>
        private Game CreateComputerVsOtherComputerFinishedGameMock()
        {
            Game game = new Game()
            {
                Id = 2,
                StartDate = DateTime.Now,
                GameName = MockConstants.OtherComputerUsername + " vs " + MockConstants.ComputerUsername,
                ApplicationUser = this.OtherComputerUser,
                ApplicationUserId = this.OtherComputerUser.Id,
                Oponent = this.ComputerUser,
                OponentId = this.ComputerUser.Id,
                OponentName = this.ComputerUser.UserName,
                TurnsCount = 9,
                Tiles = this.EmptyTilesList,
                GameMode = GameMode.ComputerVsComputer,
                GameOwner = this.ApplicationUser,
                GameOwnerId = this.ApplicationUser.Id,
                IsFinished = true,
                GameState = GameState.Draw
            };

            return game;
        }

        /// <summary>
        /// Places a turn on the NewOtherComputerVsComputerGame
        /// </summary>
        private void PlaceTurnOnNewOtherComputerVsComputerGame()
        {
            this.OtherComputerVsComputerNewGameMock.TurnsCount = 2;
            this.OtherComputerVsComputerNewGameMock.Tiles.ElementAt(6).IsEmpty = false;
            this.OtherComputerVsComputerNewGameMock.Tiles.ElementAt(6).Value = "X";
        }

        /// <summary>
        /// Places a turn on the NewComputerVsOtherComputerGame
        /// </summary>
        private void PlaceTurnOnNewComputerVsOtherComputerGame()
        {
            this.ComputerVsOtherComputerNewGameMock.TurnsCount = 2;
            this.ComputerVsOtherComputerNewGameMock.Tiles.ElementAt(4).IsEmpty = false;
            this.ComputerVsOtherComputerNewGameMock.Tiles.ElementAt(4).Value = "X";
        }
    }
}