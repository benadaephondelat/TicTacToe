namespace TicTacToe.Web.Tests.MockHelpers
{
    using System;
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

        private Game ComputerVsComputerNewGameMock { get; }

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

        public ComputerVsComputerServiceLayerMockHelper()
        {
            this.EmptyTilesList = this.CreateEmptyTilesMock();
            this.ComputerVsComputerNewGameMock = this.CreateNewComputerVsComputerGameMock();

            this.ConfigureAutoMapper();
        }

        /// <summary>
        /// Mocks all needed methods of ITicTacToeGameService
        /// </summary>
        /// <returns>Mock<ITicTacToeGameService></ITicTacToeGameService></returns>
        public Mock<ITicTacToeGameService> SetupTicTacToeServiceMock()
        {
            Mock<ITicTacToeGameService> serviceMock = new Mock<ITicTacToeGameService>();

            serviceMock.Setup(p => p.CreateNewComputerVsComputerGame(MockConstants.UserEmail))
                       .Returns(this.ComputerVsComputerNewGameMock);
            
            serviceMock.Setup(p => p.GetGameById(1)).Returns(this.ComputerVsComputerNewGameMock);

            serviceMock.Setup(p => p.GetComputerMove(1))
                       .Returns(4);

            serviceMock.Setup(p => p.PlaceTurn(1, 4, MockConstants.ComputerEmail));
            
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
        /// Creates a new computer vs computer game
        /// </summary>
        /// <returns>Game</returns>
        private Game CreateNewComputerVsComputerGameMock()
        {
            Game game = new Game()
            {
                Id = 1,
                StartDate = DateTime.Now,
                GameName = MockConstants.ComputerUsername + " vs " + MockConstants.OtherComputerUsername,
                ApplicationUser = this.ApplicationUser,
                ApplicationUserId = this.ApplicationUser.Id,
                Oponent = this.ComputerUser,
                OponentId = this.ComputerUser.Id,
                OponentName = this.ComputerUser.UserName,
                TurnsCount = 1,
                Tiles = this.EmptyTilesList,
                GameMode = GameMode.ComputerVsComputer
            };

            return game;
        }
    }
}