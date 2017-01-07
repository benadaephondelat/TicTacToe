﻿namespace TicTacToe.Web.Tests.MockHelpers
{
    using System;
    using System.Web.Mvc;
    using System.Reflection;
    using System.Security.Principal;
    using System.Collections.Generic;
    using TicTacToe.Models;
    using ServiceLayer.TicTacToeGameService;
    using Constants;
    using FrameworkExtentions.Mappings;
    using Moq;

    /// <summary>
    /// Generates a mock of the ServiceLayer
    /// </summary>
    public class ServiceLayerMockHelper
    {
        private List<ApplicationUser> Users { get; }

        private List<Tile> DefaultTilesList { get; }

        private Game Game { get; }

        public ServiceLayerMockHelper()
        {
            this.Users = this.CreateDefaultUsersMock();
            this.DefaultTilesList = this.CreateDefaultTilesMock();
            this.Game = this.CreateNewGameMock();

            this.ConfigureAutoMapper();
        }

        /// <summary>
        /// Mocks the ITicTacToeGameService methods
        /// </summary>
        /// <returns>Mock<ITicTacToeGameService></ITicTacToeGameService></returns>
        public Mock<ITicTacToeGameService> SetupTicTacToeServiceMock()
        {
            Mock<ITicTacToeGameService> serviceMock = new Mock<ITicTacToeGameService>();

            serviceMock.Setup(p => p.CreateNewHumanVsHumanGame(MockConstants.UserId, MockConstants.OtherGuyId))
                       .Returns(this.Game);

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
                    Id = "applicationUserId",
                    UserName = "georgi_iliev@yahoo.com",
                    Email = "georgi_iliev@yahoo.com"
                },
                new ApplicationUser()
                {
                    Id = "oponentUserId",
                    UserName = "the-other-guy@yahoo.com",
                    Email = "the-other-guy@yahoo.com"
                }
            };

            return result;
        }

        /// <summary>
        /// Creates a list of 9 empty tiles
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

            return defaultTilesList;
        }

        /// <summary>
        /// Creates a new human vs human game 
        /// </summary>
        /// <returns>Game</returns>
        private Game CreateNewGameMock()
        {
            Game game = new Game()
            {
                Id = 1,
                StartDate = DateTime.Now,
                GameName = "MOCKED GAME",
                ApplicationUser = this.Users[0],
                ApplicationUserId = this.Users[0].Id,
                Oponent = this.Users[1],
                OponentId = this.Users[1].Id,
                OponentName = this.Users[1].UserName,
                TurnsCount = 1,
                Tiles = this.DefaultTilesList
            };

            return game;
        }
    }
}