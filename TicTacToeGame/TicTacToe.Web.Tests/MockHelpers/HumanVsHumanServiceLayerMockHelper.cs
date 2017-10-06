namespace TicTacToe.Web.Tests.MockHelpers
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
    using TicTacToe.Models.Enums;
    using TicTacToeCommon.Constants;

    /// <summary>
    /// Generates a mock of the ServiceLayer
    /// </summary>
    public class HumanVsHumanServiceLayerMockHelper
    {
        private List<ApplicationUser> Users { get; }

        private List<Tile> DefaultTilesList { get; }

        private Game NewHumanVsHumanGame { get; }

        private Game NewHumanVsComputerGame { get; }

        private Game FinishedGame { get; }

        public HumanVsHumanServiceLayerMockHelper()
        {
            this.Users = this.CreateDefaultUsersMock();
            this.DefaultTilesList = this.CreateDefaultTilesMock();
            this.NewHumanVsHumanGame = this.CreateNewHumanVsHumanGameMock();
            this.NewHumanVsComputerGame = this.CreateNewHumanVsComputerGameMock();
            this.FinishedGame = this.CreateFinishGameMock();

            this.ConfigureAutoMapper();
        }

        /// <summary>
        /// Mocks all methods ITicTacToeGameService
        /// </summary>
        /// <returns>Mock<ITicTacToeGameService></ITicTacToeGameService></returns>
        public Mock<ITicTacToeGameService> SetupTicTacToeServiceMock()
        {
            Mock<ITicTacToeGameService> serviceMock = new Mock<ITicTacToeGameService>();

            serviceMock.Setup(p => p.CreateNewGame(MockConstants.UserEmail, MockConstants.OtherGuyEmail))
                       .Returns(this.NewHumanVsHumanGame);

            serviceMock.Setup(p => p.CreateNewGame(MockConstants.OtherGuyEmail, MockConstants.UserEmail))
                       .Returns(this.NewHumanVsHumanGame);

            serviceMock.Setup(p => p.PlaceTurn(1, 0, "georgi_iliev@yahoo.com"));

            serviceMock.Setup(p => p.RecreatePreviousGame(MockConstants.UserEmail, GameMode.HumanVsHuman))
                       .Returns(this.NewHumanVsHumanGame);

            serviceMock.Setup(p => p.GetGameById(1)).Returns(this.NewHumanVsHumanGame);

            serviceMock.Setup(p => p.GetGameById(2)).Returns(this.FinishedGame);

            serviceMock.Setup(p => p.GetAllUnfinishedGames("georgi_iliev@yahoo.com", GameMode.HumanVsHuman))
                       .Returns(new List<Game>() { this.FinishedGame });

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
                    Id = UserConstants.UserId,
                    UserName = UserConstants.UserUsername,
                    Email = UserConstants.UserEmail
                },
                new ApplicationUser()
                {
                    Id = UserConstants.OtherGuyId,
                    UserName = UserConstants.OtherGuyUsername,
                    Email = UserConstants.OtherGuyEmail
                },
                new ApplicationUser()
                {
                    Id = UserConstants.ComputerId,
                    UserName = UserConstants.ComputerUsername,
                    Email = UserConstants.ComputerEmail
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
        private Game CreateNewHumanVsHumanGameMock()
        {
            Game game = new Game()
            {
                Id = 1,
                StartDate = DateTime.Now,
                GameName = "MOCKED HUMAN VS HUMAN GAME",
                ApplicationUser = this.Users[0],
                ApplicationUserId = this.Users[0].Id,
                Oponent = this.Users[1],
                OponentId = this.Users[1].Id,
                OponentName = this.Users[1].UserName,
                TurnsCount = 1,
                Tiles = this.DefaultTilesList,
                GameMode = GameMode.HumanVsHuman
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
                Id = 1,
                StartDate = DateTime.Now,
                GameName = "MOCKED HUMAN VS COMPUTER GAME",
                ApplicationUser = this.Users[0],
                ApplicationUserId = this.Users[0].Id,
                Oponent = this.Users[2],
                OponentId = this.Users[2].Id,
                OponentName = this.Users[2].UserName,
                TurnsCount = 1,
                Tiles = this.DefaultTilesList,
                GameMode = GameMode.HumanVsComputer
            };

            return game;
        }

        /// <summary>
        /// Creates a finished human vs human game 
        /// </summary>
        /// <returns>Game</returns>
        private Game CreateFinishGameMock()
        {
            Game game = new Game()
            {
                Id = 2,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                GameName = "MOCKED FINISHED HUMAN VS HUMAN GAME",
                ApplicationUser = this.Users[0],
                ApplicationUserId = this.Users[0].Id,
                Oponent = this.Users[1],
                OponentId = this.Users[1].Id,
                OponentName = this.Users[1].UserName,
                TurnsCount = 2,
                WinnerId = this.Users[1].UserName,
                IsFinished = true,
                Tiles = this.DefaultTilesList,
                GameMode = GameMode.HumanVsHuman
            };

            return game;
        }
    }
}