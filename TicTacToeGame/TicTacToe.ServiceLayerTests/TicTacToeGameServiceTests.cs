namespace TicTacToe.ServiceLayerTests
{
    using System;
    using System.Linq;
    using DataLayer.Data;
    using ServiceLayer.TicTacToeGameService;
    using Models;
    using Constants;
    using MockHelpers;
    using TicTacToeCommon.Exceptions.User;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using TicTacToeCommon.Exceptions.Game;

    [TestClass]
    public class TicTacToeGameServiceTests
    {
        private Mock<ITicTacToeData> dataLayerMock;
        private TicTacToeGameService gameService;

        [TestInitialize]
        public void SetUp()
        {
            DataLayerMockHelper mockHelper = new DataLayerMockHelper();

            this.dataLayerMock = mockHelper.SetupTicTacToeDataMock();

            this.gameService = new TicTacToeGameService(dataLayerMock.Object);
        }

        #region CreateNewHumanVsHumanGame

        [TestMethod]
        public void CreateNewHumanVsHumanGame_Should_Not_Throw_UserNotFoundException_When_Users_Are_Valid()
        {
            try
            {
                CreateNewHumanVsHumanGameWithTwoValidUsers();
            }
            catch (UserNotFoundException)
            {
                Assert.Fail();
            }

            Assert.IsTrue(true);
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotFoundException))]
        public void CreateNewHumanVsHumanGame_Should_Throw_UserNotFoundException_If_No_User_With_homeSideUserName_Is_Found()
        {
            gameService.CreateNewHumanVsHumanGame(MockConstants.UserId, MockConstants.InvalidUserId);
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotFoundException))]
        public void CreateNewHumanVsHumanGame_Should_Throw_UserNotFoundException_If_No_User_With_awaySideUserName_Is_Found()
        {
            gameService.CreateNewHumanVsHumanGame(MockConstants.InvalidUserId, MockConstants.OtherGuyId);
        }

        [TestMethod]
        public void CreateNewHumanVsHumanGame_Game_Should_Start_With_TurnsCount_Set_To_1()
        {
            Game game = CreateNewHumanVsHumanGameWithTwoValidUsers();

            var actualTurnsCount = game.TurnsCount;

            Assert.AreEqual(1, actualTurnsCount);
        }

        [TestMethod]
        public void CreateNewHumanVsHumanGame_Game_Should_Have_Two_Valid_Users()
        {
            Game game = gameService.CreateNewHumanVsHumanGame(MockConstants.UserName, MockConstants.OtherGuyUserName);

            bool isGameUserNull = game.ApplicationUser == null;
            Assert.IsFalse(isGameUserNull);

            bool isGameUserIdNullOrEmpty = string.IsNullOrWhiteSpace(game.ApplicationUserId);
            Assert.IsFalse(isGameUserIdNullOrEmpty);

            bool isGameOponentNull = game.Oponent == null;
            Assert.IsFalse(isGameOponentNull);

            bool isGameOponentIdNullOrEmpty = string.IsNullOrWhiteSpace(game.OponentId);
            Assert.IsFalse(isGameOponentIdNullOrEmpty);
        }

        [TestMethod]
        public void CreateNewHumanVsHumanGame_Game_Should_Set_The_User_From_homeSideUserName_As_Game_Owner()
        {
            Game game = gameService.CreateNewHumanVsHumanGame(MockConstants.UserName, MockConstants.OtherGuyUserName);

            Assert.AreEqual(MockConstants.UserName, game.ApplicationUser.UserName);
        }

        [TestMethod]
        public void CreateNewHumanVsHumanGame_Game_Should_Set_The_awaySideUserName_As_Oponent()
        {
            Game game = gameService.CreateNewHumanVsHumanGame(MockConstants.UserName, MockConstants.OtherGuyUserName);

            Assert.AreEqual(MockConstants.OtherGuyUserName, game.Oponent.UserName);
        }

        [TestMethod]
        public void CreateNewHumanVsHumanGame_Game_Name_Should_Be_HomeSideUsername_vs_AwaySideUsername()
        {
            Game game = CreateNewHumanVsHumanGameWithTwoValidUsers();

            string expectedGameName = MockConstants.UserName + " vs " + MockConstants.OtherGuyUserName;

            Assert.AreEqual(expectedGameName, game.GameName);
        }

        [TestMethod]
        public void CreateNewHumanVsHumanGame_Game_StartDate_Should_Be_Within_Ten_Seconds_Of_Creation()
        {
            DateTime expectedTime = DateTime.Now.AddSeconds(10);

            Game game = CreateNewHumanVsHumanGameWithTwoValidUsers();

            bool isWithinTenSeconds = game.StartDate <= expectedTime;

            Assert.IsTrue(isWithinTenSeconds); 
        }

        [TestMethod]
        public void CreateNewHumanVsHumanGame_Game_OponentName_Should_Be_Set_To_The_AwaySide_User_UserName()
        {
            Game game = gameService.CreateNewHumanVsHumanGame(MockConstants.UserName, MockConstants.OtherGuyUserName);

            Assert.AreEqual(MockConstants.OtherGuyUserName, game.OponentName);
        }

        [TestMethod]
        public void CreateNewHumanVsHumanGame_Game_Should_Have_9_Tiles()
        {
            Game game = CreateNewHumanVsHumanGameWithTwoValidUsers();

            Assert.AreEqual(9, game.Tiles.Count);
        }

        [TestMethod]
        public void CreateNewHumanVsHumanGame_Game_All_Tiles_IsEmpty_Property_Should_Be_Set_To_True()
        {
            Game game = CreateNewHumanVsHumanGameWithTwoValidUsers();

            int actualEmptyTilesCount = game.Tiles.Count(t => t.IsEmpty);

            Assert.AreEqual(9, actualEmptyTilesCount);
        }

        [TestMethod]
        public void CreateNewHumanVsHumanGame_Game_All_Tiles_Value_Property_Should_Be_Set_To_An_Empty_String()
        {
            Game game = CreateNewHumanVsHumanGameWithTwoValidUsers();

            int result = game.Tiles.Count(t => t.Value == string.Empty);

            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void CreateNewHumanVsHumanGame_Game_All_Tiles_Game_Property_Should_Be_Set_To_The_Same_Game()
        {
            Game game = CreateNewHumanVsHumanGameWithTwoValidUsers();

            int result = game.Tiles.Count(t => t.Game == game);

            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void CreateNewHumanVsHumanGame_Game_All_Tiles_GameId_Property_Should_Be_Set_To_The_Same_GameId()
        {
            Game game = CreateNewHumanVsHumanGameWithTwoValidUsers();

            int result = game.Tiles.Count(t => t.GameId == game.Id);

            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void CreateNewHumanVsHumanGame_Game_If_The_CurrentUser_Starts_First_The_Oponent_Should_Be_The_DefaultUser()
        {
            Game game = gameService.CreateNewHumanVsHumanGame(MockConstants.UserName, MockConstants.UserName);

            Assert.AreEqual(MockConstants.OtherGuyUserName, game.Oponent.UserName);
        }

        [TestMethod]
        public void CreateNewHumanVsHumanGame_Game_If_The_CurrentUser_Starts_Second_The_HomeSideUser_Should_Be_The_DefaultUser()
        {
            Game game = gameService.CreateNewHumanVsHumanGame(MockConstants.OtherGuyUserName, MockConstants.UserName);

            Assert.AreEqual(MockConstants.OtherGuyUserName, game.ApplicationUser.UserName);
        }

        [TestMethod]
        public void CreateNewHumanVsHumanGame_Game_Should_Be_Added_Once_To_Games_Repository()
        {
            var addGameCounter = 0;

            this.dataLayerMock.Setup(x => x.Games.Add(It.IsAny<Game>())).Callback(() => addGameCounter++);

            CreateNewHumanVsHumanGameWithTwoValidUsers();

            this.dataLayerMock.Verify(x => x.Games.Add(It.IsAny<Game>()), Times.Once());

            Assert.AreEqual(1, addGameCounter);
        }

        [TestMethod]
        public void CreateNewHumanVsHumanGame_Game_Should_Call_SaveChanges_Once()
        {
            var saveChangesCounter = 0;

            this.dataLayerMock.Setup(x => x.SaveChanges()).Callback(() => saveChangesCounter++);

            CreateNewHumanVsHumanGameWithTwoValidUsers();

            this.dataLayerMock.Verify(x => x.SaveChanges(), Times.Once());

            Assert.AreEqual(1, saveChangesCounter);
        }

        [TestMethod]
        public void CreateNewHumanVsHumanGame_Game_Should_Add_9_Tiles_To_Tile_Repository()
        {
            var addTIleCounter = 0;

            this.dataLayerMock.Setup(x => x.Tiles.Add(It.IsAny<Tile>())).Callback(() => addTIleCounter++);

            CreateNewHumanVsHumanGameWithTwoValidUsers();

            this.dataLayerMock.Verify(x => x.Tiles.Add(It.IsAny<Tile>()), Times.Exactly(9));

            Assert.AreEqual(9, addTIleCounter);
        }

        private Game CreateNewHumanVsHumanGameWithTwoValidUsers()
        {
            return gameService.CreateNewHumanVsHumanGame(MockConstants.UserName, MockConstants.OtherGuyUserName);
        }

        #endregion
    }
}