﻿namespace TicTacToe.ServiceLayerTests
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Computer;
    using Models;
    using Models.Enums;
    using MockHelpers;
    using Constants;
    using DataLayer.Data;
    using ServiceLayer.TicTacToeGameService;
    using TicTacToeCommon.Exceptions.User;
    using TicTacToeCommon.Exceptions.Tile;
    using TicTacToeCommon.Exceptions.Game;

    using Moq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ComputerChooser.Interfaces;
    using ComputerChooser;
    using ComputerMinMax;
    using TicTacToeCommon.Exceptions.Computer;

    [TestClass]
    public class TicTacToeGameServiceTests
    {
        private Mock<ITicTacToeData> dataLayerMock;

        private TicTacToeGameService gameService;

        private IComputerChooser computerChooser;

        [TestInitialize]
        public void SetUp()
        {
            DataLayerMockHelper mockHelper = new DataLayerMockHelper();

            this.dataLayerMock = mockHelper.SetupTicTacToeDataMock();

            this.computerChooser = new ComputerChooser(new Computer(), new MinMaxComputer());

            this.gameService = new TicTacToeGameService(dataLayerMock.Object, this.computerChooser);
        }

        #region GetGameById

        [TestMethod]
        [ExpectedException(typeof(GameNotFoundException))]
        public void GetGameById_Should_Throw_GameNotFoundException_If_No_Such_Game_Exists()
        {
            this.gameService.GetGameById(MockConstants.InvalidGameId);
        }

        [TestMethod]
        public void GetGameById_Should_Return_Valid_Game_If_Input_Is_Correct()
        {
            Game game = this.gameService.GetGameById(1);

            Assert.IsNotNull(game);
        }

        #endregion

        #region CreateNewGame

        [TestMethod]
        public void CreateNewGame_Should_Not_Throw_UserNotFoundException_When_Users_Are_Valid()
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
        public void CreateNewGame_Should_Throw_UserNotFoundException_If_No_User_With_homeSideUserName_Is_Found()
        {
            gameService.CreateNewGame(MockConstants.UserId, MockConstants.InvalidUserId);
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotFoundException))]
        public void CreateNewGame_Should_Throw_UserNotFoundException_If_No_User_With_awaySideUserName_Is_Found()
        {
            gameService.CreateNewGame(MockConstants.InvalidUserId, MockConstants.OtherGuyId);
        }

        [TestMethod]
        public void CreateNewGame_Game_Should_Set_GameMode_To_HumanVsHuman()
        {
            Game game = CreateNewHumanVsHumanGameWithTwoValidUsers();

            string actualGameMode = game.GameMode.ToString();

            Assert.AreEqual(GameMode.HumanVsHuman.ToString(), actualGameMode);
        }

        [TestMethod]
        public void CreateNewGame_Game_Should_Start_With_TurnsCount_Set_To_1()
        {
            Game game = CreateNewHumanVsHumanGameWithTwoValidUsers();

            var actualTurnsCount = game.TurnsCount;

            Assert.AreEqual(1, actualTurnsCount);
        }

        [TestMethod]
        public void CreateNewGame_Game_Should_Have_Two_Valid_Users()
        {
            Game game = gameService.CreateNewGame(MockConstants.UserName, MockConstants.OtherGuyUserName);

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
        public void CreateNewGame_Game_Should_Set_The_User_From_HomeSideUserName_As_Game_Owner()
        {
            Game game = gameService.CreateNewGame(MockConstants.UserName, MockConstants.OtherGuyUserName);

            Assert.AreEqual(MockConstants.UserName, game.ApplicationUser.UserName);
        }

        [TestMethod]
        public void CreateNewGame_Game_Should_Set_The_AwaySideUserName_As_Oponent()
        {
            Game game = gameService.CreateNewGame(MockConstants.UserName, MockConstants.OtherGuyUserName);

            Assert.AreEqual(MockConstants.OtherGuyUserName, game.Oponent.UserName);
        }

        [TestMethod]
        public void CreateNewGame_Game_Name_Should_Be_HomeSideUsername_vs_AwaySideUsername()
        {
            Game game = CreateNewHumanVsHumanGameWithTwoValidUsers();

            string expectedGameName = MockConstants.UserName + " vs " + MockConstants.OtherGuyUserName;

            Assert.AreEqual(expectedGameName, game.GameName);
        }

        [TestMethod]
        public void CreateNewGame_Game_StartDate_Should_Be_Within_Ten_Seconds_Of_Creation()
        {
            DateTime expectedTime = DateTime.Now.AddSeconds(10);

            Game game = CreateNewHumanVsHumanGameWithTwoValidUsers();

            bool isWithinTenSeconds = game.StartDate <= expectedTime;

            Assert.IsTrue(isWithinTenSeconds);
        }

        [TestMethod]
        public void CreateNewGame_Game_OponentName_Should_Be_Set_To_The_AwaySide_User_UserName()
        {
            Game game = gameService.CreateNewGame(MockConstants.UserName, MockConstants.OtherGuyUserName);

            Assert.AreEqual(MockConstants.OtherGuyUserName, game.OponentName);
        }

        [TestMethod]
        public void CreateNewGame_Game_Should_Have_9_Tiles()
        {
            Game game = CreateNewHumanVsHumanGameWithTwoValidUsers();

            Assert.AreEqual(9, game.Tiles.Count);
        }

        [TestMethod]
        public void CreateNewGame_Game_All_Tiles_IsEmpty_Property_Should_Be_Set_To_True()
        {
            Game game = CreateNewHumanVsHumanGameWithTwoValidUsers();

            int actualEmptyTilesCount = game.Tiles.Count(t => t.IsEmpty);

            Assert.AreEqual(9, actualEmptyTilesCount);
        }

        [TestMethod]
        public void CreateNewGame_Game_All_Tiles_Value_Property_Should_Be_Set_To_An_Empty_String()
        {
            Game game = CreateNewHumanVsHumanGameWithTwoValidUsers();

            int result = game.Tiles.Count(t => t.Value == string.Empty);

            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void CreateNewGame_Game_All_Tiles_Game_Property_Should_Be_Set_To_The_Same_Game()
        {
            Game game = CreateNewHumanVsHumanGameWithTwoValidUsers();

            int result = game.Tiles.Count(t => t.Game == game);

            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void CreateNewGame_Game_All_Tiles_GameId_Property_Should_Be_Set_To_The_Same_GameId()
        {
            Game game = CreateNewHumanVsHumanGameWithTwoValidUsers();

            int result = game.Tiles.Count(t => t.GameId == game.Id);

            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void CreateNewGame_Game_If_The_CurrentUser_Starts_First_The_Oponent_Should_Be_The_DefaultUser()
        {
            Game game = gameService.CreateNewGame(MockConstants.UserName, MockConstants.UserName);

            Assert.AreEqual(MockConstants.OtherGuyUserName, game.Oponent.UserName);
        }

        [TestMethod]
        public void CreateNewGame_Game_If_The_CurrentUser_Starts_Second_The_HomeSideUser_Should_Be_The_DefaultUser()
        {
            Game game = gameService.CreateNewGame(MockConstants.OtherGuyUserName, MockConstants.UserName);

            Assert.AreEqual(MockConstants.OtherGuyUserName, game.ApplicationUser.UserName);
        }

        [TestMethod]
        public void CreateNewGame_Game_Should_Be_Added_Once_To_Games_Repository()
        {
            var addGameCounter = 0;

            this.dataLayerMock.Setup(x => x.Games.Add(It.IsAny<Game>())).Callback(() => addGameCounter++);

            CreateNewHumanVsHumanGameWithTwoValidUsers();

            this.dataLayerMock.Verify(x => x.Games.Add(It.IsAny<Game>()), Times.Once());

            Assert.AreEqual(1, addGameCounter);
        }

        [TestMethod]
        public void CreateNewGame_Game_Should_Call_SaveChanges_Once()
        {
            var saveChangesCounter = 0;

            this.dataLayerMock.Setup(x => x.SaveChanges()).Callback(() => saveChangesCounter++);

            CreateNewHumanVsHumanGameWithTwoValidUsers();

            this.dataLayerMock.Verify(x => x.SaveChanges(), Times.Once());

            Assert.AreEqual(1, saveChangesCounter);
        }

        [TestMethod]
        public void CreateNewGame_Game_Should_Add_9_Tiles_To_Tile_Repository()
        {
            var addTIleCounter = 0;

            this.dataLayerMock.Setup(x => x.Tiles.Add(It.IsAny<Tile>())).Callback(() => addTIleCounter++);

            CreateNewHumanVsHumanGameWithTwoValidUsers();

            this.dataLayerMock.Verify(x => x.Tiles.Add(It.IsAny<Tile>()), Times.Exactly(9));

            Assert.AreEqual(9, addTIleCounter);
        }

        [TestMethod]
        public void CreateNewGame_Game_Should_Add_Game_To_User_Games_Collection()
        {
            Game game = CreateNewHumanVsHumanGameWithTwoValidUsers();

            Assert.IsTrue(game.ApplicationUser.Games.Any());
        }

        /// <summary>
        /// Creates a new human vs human game with the current user serving as homeside.
        /// </summary>
        /// <returns>Game</returns>
        private Game CreateNewHumanVsHumanGameWithTwoValidUsers()
        {
            return gameService.CreateNewGame(MockConstants.UserName, MockConstants.OtherGuyUserName);
        }

        #endregion

        #region CreateNewHummanVsComputerGame

        [TestMethod]
        public void CreateNewComputerVsHumanGame_Should_Not_Throw_UserNotFoundException_When_User_Is_Valid()
        {
            try
            {
                CreateValidNewHumanVsComputerGame();
            }
            catch (UserNotFoundException)
            {
                Assert.Fail();
            }

            Assert.IsTrue(true);
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotFoundException))]
        public void CreateNewHumanVsComputerGame_Should_Throw_UserNotFoundException_If_No_User_With_currentUsername_Is_Found()
        {
            gameService.CreateNewHumanVsComputerGame(MockConstants.InvalidUsername, MockConstants.ComputerUserName, true);
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotFoundException))]
        public void CreateNewHumanVsComputerGame_Should_Throw_UserNotFoundException_If_No_User_With_computerUsername_Is_Found()
        {
            gameService.CreateNewHumanVsComputerGame(MockConstants.UserName, MockConstants.InvalidUsername, true);
        }

        [TestMethod]
        public void CreateNewHumanVsComputerGame_Game_Should_Set_GameMode_To_HumanVsComputer()
        {
            Game game = CreateValidNewHumanVsComputerGame();

            string actualGameMode = game.GameMode.ToString();

            Assert.AreEqual(GameMode.HumanVsComputer.ToString(), actualGameMode);
        }

        [TestMethod]
        public void CreateNewHumanVsComputerGame_Game_Should_Set_Game_Is_Finished_To_False()
        {
            Game game = CreateValidNewHumanVsComputerGame();

            Assert.IsFalse(game.IsFinished);
        }

        [TestMethod]
        public void CreateNewHumanVsComputerGame_Game_Should_Set_Game_State_To_Not_Finished()
        {
            Game game = CreateValidNewHumanVsComputerGame();

            Assert.AreEqual(GameState.NotFinished, game.GameState);
        }

        [TestMethod]
        public void CreateNewHumanVsComputerGame_Game_Should_Start_With_TurnsCount_Set_To_1()
        {
            Game game = CreateValidNewHumanVsComputerGame();

            var actualTurnsCount = game.TurnsCount;

            Assert.AreEqual(1, actualTurnsCount);
        }

        [TestMethod]
        public void CreateNewHumanVsComputerGame_Game_Should_Have_Two_Valid_Users()
        {
            Game game = gameService.CreateNewHumanVsComputerGame(MockConstants.UserName, MockConstants.OtherComputerUserName, true);

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
        public void CreateNewHumanVsComputerGame_Game_Should_Set_The_Human_User_As_Game_Owner_If_Human_Is_First()
        {
            Game game = gameService.CreateNewHumanVsComputerGame(MockConstants.UserName, MockConstants.OtherComputerUserName, true);

            Assert.AreEqual(MockConstants.UserName, game.ApplicationUser.UserName);
        }

        [TestMethod]
        public void CreateNewHumanVsComputerGame_Game_Should_Set_The_Human_User_As_Game_Oponent_If_Human_Is_Second()
        {
            Game game = gameService.CreateNewHumanVsComputerGame(MockConstants.UserName, MockConstants.OtherComputerUserName, false);

            Assert.AreEqual(MockConstants.UserName, game.Oponent.UserName);
        }

        [TestMethod]
        public void CreateNewHumanVsComputerGame_Game_Name_Should_Be_HomeSideUsername_vs_AwaySideUsername()
        {
            Game game = CreateValidNewHumanVsComputerGame();

            string expectedGameName = MockConstants.UserName + " vs " + MockConstants.ComputerUserName;

            Assert.AreEqual(expectedGameName, game.GameName);
        }

        [TestMethod]
        public void CreateNewHumanVsComputerGame_Game_StartDate_Should_Be_Within_Ten_Seconds_Of_Creation()
        {
            DateTime expectedTime = DateTime.Now.AddSeconds(10);

            Game game = CreateValidNewHumanVsComputerGame();

            bool isWithinTenSeconds = game.StartDate <= expectedTime;

            Assert.IsTrue(isWithinTenSeconds);
        }

        [TestMethod]
        public void CreateNewHumanVsComputerGame_Game_OponentName_Should_Be_The_Computer_If_Human_Is_First()
        {
            Game game = gameService.CreateNewHumanVsComputerGame(MockConstants.UserName, MockConstants.ComputerUserName, true);

            Assert.AreEqual(MockConstants.ComputerUserName, game.OponentName);
        }

        [TestMethod]
        public void CreateNewHumanVsComputerGame_Game_OponentName_Should_Be_The_Human_If_The_Computer_Is_First()
        {
            Game game = gameService.CreateNewHumanVsComputerGame(MockConstants.UserName, MockConstants.ComputerUserName, false);

            Assert.AreEqual(MockConstants.UserName, game.OponentName);
        }

        [TestMethod]
        public void CreateNewHumanVsComputerGame_Game_Should_Have_9_Tiles()
        {
            Game game = CreateValidNewHumanVsComputerGame();

            Assert.AreEqual(9, game.Tiles.Count);
        }

        [TestMethod]
        public void CreateNewHumanVsComputerGame_Game_All_Tiles_IsEmpty_Property_Should_Be_Set_To_True()
        {
            Game game = CreateValidNewHumanVsComputerGame();

            int actualEmptyTilesCount = game.Tiles.Count(t => t.IsEmpty);

            Assert.AreEqual(9, actualEmptyTilesCount);
        }

        [TestMethod]
        public void CreateNewHumanVsComputerGame_Game_All_Tiles_Value_Property_Should_Be_Set_To_An_Empty_String()
        {
            Game game = CreateValidNewHumanVsComputerGame();

            int result = game.Tiles.Count(t => t.Value == string.Empty);

            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void CreateNewHumanVsComputerGame_Game_All_Tiles_Game_Property_Should_Be_Set_To_The_Same_Game()
        {
            Game game = CreateValidNewHumanVsComputerGame();

            int result = game.Tiles.Count(t => t.Game == game);

            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void CreateNewHumanVsComputerGame_Game_All_Tiles_GameId_Property_Should_Be_Set_To_The_Same_GameId()
        {
            Game game = CreateValidNewHumanVsComputerGame();

            int result = game.Tiles.Count(t => t.GameId == game.Id);

            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void CreateNewHumanVsComputerGame_Game_If_The_Human_Starts_First_The_Oponent_Should_Be_The_Computer()
        {
            Game game = gameService.CreateNewHumanVsComputerGame(MockConstants.UserName, MockConstants.ComputerUserName, true);

            Assert.AreEqual(MockConstants.ComputerUserName, game.Oponent.UserName);
        }

        [TestMethod]
        public void CreateNewHumanVsComputerGame_Game_If_The_Human_Starts_Second_The_HomeSideUser_Should_Be_The_Computer()
        {
            Game game = gameService.CreateNewHumanVsComputerGame(MockConstants.UserName, MockConstants.ComputerUserName, false);

            Assert.AreEqual(MockConstants.ComputerUserName, game.ApplicationUser.UserName);
        }

        [TestMethod]
        public void CreateNewHumanVsComputerGame_Game_Should_Add_The_First_Computer_As_Game_Owner_To_The_New_Game()
        {
            Game game = gameService.CreateNewHumanVsComputerGame(MockConstants.UserName, MockConstants.ComputerUserName, false);

            Assert.AreEqual(MockConstants.ComputerUserName, game.ApplicationUser.UserName);
        }

        [TestMethod]
        public void CreateNewHumanVsComputerGame_Game_Should_Add_The_First_Computer_As_Game_Opponent_To_The_New_Game()
        {
            Game game = gameService.CreateNewHumanVsComputerGame(MockConstants.UserName, MockConstants.ComputerUserName, true);

            Assert.AreEqual(MockConstants.ComputerUserName, game.Oponent.UserName);
        }

        [TestMethod]
        public void CreateNewHumanVsComputerGame_Game_Should_Add_The_Second_Computer_As_Game_Owner_To_The_New_Game()
        {
            Game game = gameService.CreateNewHumanVsComputerGame(MockConstants.UserName, MockConstants.OtherComputerUserName, false);

            Assert.AreEqual(MockConstants.OtherComputerUserName, game.ApplicationUser.UserName);
        }

        [TestMethod]
        public void CreateNewHumanVsComputerGame_Game_Should_Add_The_Second_Computer_As_Oponent_Owner_To_The_New_Game()
        {
            Game game = gameService.CreateNewHumanVsComputerGame(MockConstants.UserName, MockConstants.OtherComputerUserName, true);

            Assert.AreEqual(MockConstants.OtherComputerUserName, game.Oponent.UserName);
        }

        [TestMethod]
        public void CreateNewHumanVsComputerGame_Game_Should_Be_Added_Once_To_Games_Repository()
        {
            var addGameCounter = 0;

            this.dataLayerMock.Setup(x => x.Games.Add(It.IsAny<Game>())).Callback(() => addGameCounter++);

            CreateValidNewHumanVsComputerGame();

            this.dataLayerMock.Verify(x => x.Games.Add(It.IsAny<Game>()), Times.Once());

            Assert.AreEqual(1, addGameCounter);
        }

        [TestMethod]
        public void CreateNewHumanVsComputerGame_Game_Should_Call_SaveChanges_Once()
        {
            var saveChangesCounter = 0;

            this.dataLayerMock.Setup(x => x.SaveChanges()).Callback(() => saveChangesCounter++);

            CreateValidNewHumanVsComputerGame();

            this.dataLayerMock.Verify(x => x.SaveChanges(), Times.Once());

            Assert.AreEqual(1, saveChangesCounter);
        }

        [TestMethod]
        public void CreateNewHumanVsComputerGame_Game_Should_Add_9_Tiles_To_Tile_Repository()
        {
            var addTIleCounter = 0;

            this.dataLayerMock.Setup(x => x.Tiles.Add(It.IsAny<Tile>())).Callback(() => addTIleCounter++);

            CreateValidNewHumanVsComputerGame();

            this.dataLayerMock.Verify(x => x.Tiles.Add(It.IsAny<Tile>()), Times.Exactly(9));

            Assert.AreEqual(9, addTIleCounter);
        }

        [TestMethod]
        public void CreateNewHumanVsComputerGame_Game_Should_Add_Game_To_User_Games_Collection()
        {
            Game game = CreateValidNewHumanVsComputerGame();

            Assert.IsTrue(game.ApplicationUser.Games.Any());
        }

        /// <summary>
        /// Creates a new human vs computer game with the current user serving as homeside.
        /// </summary>
        /// <returns>Game</returns>
        private Game CreateValidNewHumanVsComputerGame()
        {
            return gameService.CreateNewHumanVsComputerGame(MockConstants.UserName, MockConstants.ComputerUserName, true);
        }

        #endregion

        #region CreateNewComputerVsComputerGame

        [TestMethod]
        public void CreateNewComputerVsComputerGame_Should_Not_Throw_UserNotFoundException_When_User_Is_Valid()
        {
            try
            {
                this.CreateValidNewComputerVsComputerGame();
            }
            catch (UserNotFoundException)
            {
                Assert.Fail();
            }

            Assert.IsTrue(true);
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotFoundException))]
        public void CreateNewComputerVsComputerGame_Should_Throw_UserNotFoundException_If_No_User_With_currentUserName_Is_Found()
        {
            gameService.CreateNewComputerVsComputerGame(MockConstants.InvalidUsername, MockConstants.ComputerUserName, MockConstants.OtherComputerUserName);
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotFoundException))]
        public void CreateNewComputerVsComputerGame_Should_Throw_UserNotFoundException_If_No_User_With_startingFirstComputerUsername_Is_Found()
        {
            gameService.CreateNewComputerVsComputerGame(MockConstants.UserName, MockConstants.InvalidUsername, MockConstants.OtherComputerUserName);
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotFoundException))]
        public void CreateNewComputerVsComputerGame_Should_Throw_UserNotFoundException_If_No_User_With_startingSecondComputerUsername_Is_Found()
        {
            gameService.CreateNewComputerVsComputerGame(MockConstants.UserName, MockConstants.ComputerUserName, MockConstants.InvalidUsername);
        }

        [TestMethod]
        public void CreateNewComputerVsComputerGame_Game_Should_Set_GameMode_To_ComputerVsComputer()
        {
            Game game = CreateValidNewComputerVsComputerGame();

            string actualGameMode = game.GameMode.ToString();

            Assert.AreEqual(GameMode.ComputerVsComputer.ToString(), actualGameMode);
        }

        [TestMethod]
        public void CreateNewComputerVsComputerGame_Game_Should_Set_Game_Is_Finished_To_False()
        {
            Game game = CreateValidNewComputerVsComputerGame();

            Assert.IsFalse(game.IsFinished);
        }

        [TestMethod]
        public void CreateNewComputerVsComputerGame_Game_Should_Set_GameState_To_NotFinished()
        {
            Game game = CreateValidNewComputerVsComputerGame();

            Assert.AreEqual(GameState.NotFinished.ToString(), game.GameState.ToString());
        }

        [TestMethod]
        public void CreateNewComputerVsComputerGame_Game_Should_Start_With_TurnsCount_Set_To_1()
        {
            Game game = CreateValidNewComputerVsComputerGame();

            var actualTurnsCount = game.TurnsCount;

            Assert.AreEqual(1, actualTurnsCount);
        }

        [TestMethod]
        public void CreateNewComputerVsComputerGame_Game_Should_Have_3_Valid_Users()
        {
            Game game = gameService.CreateNewComputerVsComputerGame(MockConstants.UserName, MockConstants.ComputerUserName, MockConstants.OtherComputerUserName);

            bool isGameUserNull = game.ApplicationUser == null;
            Assert.IsFalse(isGameUserNull);

            bool isGameUserIdNullOrEmpty = string.IsNullOrWhiteSpace(game.ApplicationUserId);
            Assert.IsFalse(isGameUserIdNullOrEmpty);

            bool isGameOponentNull = game.Oponent == null;
            Assert.IsFalse(isGameOponentNull);

            bool isGameOponentIdNullOrEmpty = string.IsNullOrWhiteSpace(game.OponentId);
            Assert.IsFalse(isGameOponentIdNullOrEmpty);

            bool isGameOwnerNull = game.GameOwner == null;
            Assert.IsFalse(isGameOwnerNull);

            bool isGameOwnerIdNullOrEmpty = string.IsNullOrWhiteSpace(game.GameOwnerId);
            Assert.IsFalse(isGameOwnerIdNullOrEmpty);
        }

        [TestMethod]
        public void CreateNewComputerVsComputerGame_Game_Should_Set_The_Human_User_As_Game_Owner()
        {
            Game game = gameService.CreateNewComputerVsComputerGame(MockConstants.UserName, MockConstants.ComputerUserName, MockConstants.OtherComputerUserName);

            Assert.AreEqual(MockConstants.UserName, game.GameOwner.UserName);
        }

        [TestMethod]
        public void CreateNewComputerVsComputerGame_Game_Name_Should_Be_HomeSideUsername_vs_AwaySideUsername()
        {
            Game game = CreateValidNewComputerVsComputerGame();

            string expectedGameName = MockConstants.ComputerUserName + " vs " + MockConstants.OtherComputerUserName;

            Assert.AreEqual(expectedGameName, game.GameName);
        }

        [TestMethod]
        public void CreateNewComputerVsComputerGame_Game_StartDate_Should_Be_Within_Ten_Seconds_Of_Creation()
        {
            DateTime expectedTime = DateTime.Now.AddSeconds(10);

            Game game = CreateValidNewComputerVsComputerGame();

            bool isWithinTenSeconds = game.StartDate <= expectedTime;

            Assert.IsTrue(isWithinTenSeconds);
        }

        [TestMethod]
        public void CreateNewComputerVsComputerGame_Game_Should_Have_9_Tiles()
        {
            Game game = CreateValidNewComputerVsComputerGame();

            Assert.AreEqual(9, game.Tiles.Count);
        }

        [TestMethod]
        public void CreateNewComputerVsComputerGame_Game_All_Tiles_IsEmpty_Property_Should_Be_Set_To_True()
        {
            Game game = CreateValidNewComputerVsComputerGame();

            int actualEmptyTilesCount = game.Tiles.Count(t => t.IsEmpty);

            Assert.AreEqual(9, actualEmptyTilesCount);
        }

        [TestMethod]
        public void CreateNewComputerVsComputerGame_Game_All_Tiles_Value_Property_Should_Be_Set_To_An_Empty_String()
        {
            Game game = CreateValidNewComputerVsComputerGame();

            int result = game.Tiles.Count(t => t.Value == string.Empty);

            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void CreateNewComputerVsComputerGame_Game_All_Tiles_Game_Property_Should_Be_Set_To_The_Same_Game()
        {
            Game game = CreateValidNewComputerVsComputerGame();

            int result = game.Tiles.Count(t => t.Game == game);

            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void CreateNewComputerVsComputerGame_Game_All_Tiles_GameId_Property_Should_Be_Set_To_The_Same_GameId()
        {
            Game game = CreateValidNewComputerVsComputerGame();

            int result = game.Tiles.Count(t => t.GameId == game.Id);

            Assert.AreEqual(9, result);
        }
        
        [TestMethod]
        public void CreateNewComputerVsComputerGame_Game_Should_Be_Added_Once_To_Games_Repository()
        {
            var addGameCounter = 0;

            this.dataLayerMock.Setup(x => x.Games.Add(It.IsAny<Game>())).Callback(() => addGameCounter++);

            CreateValidNewComputerVsComputerGame();

            this.dataLayerMock.Verify(x => x.Games.Add(It.IsAny<Game>()), Times.Once());

            Assert.AreEqual(1, addGameCounter);
        }

        [TestMethod]
        public void CreateNewComputerVsComputerGame_Game_Should_Call_SaveChanges_Once()
        {
            var saveChangesCounter = 0;

            this.dataLayerMock.Setup(x => x.SaveChanges()).Callback(() => saveChangesCounter++);

            CreateValidNewComputerVsComputerGame();

            this.dataLayerMock.Verify(x => x.SaveChanges(), Times.Once());

            Assert.AreEqual(1, saveChangesCounter);
        }

        [TestMethod]
        public void CreateNewComputerVsComputerGame_Game_Should_Add_9_Tiles_To_Tile_Repository()
        {
            var addTIleCounter = 0;

            this.dataLayerMock.Setup(x => x.Tiles.Add(It.IsAny<Tile>())).Callback(() => addTIleCounter++);

            CreateValidNewComputerVsComputerGame();

            this.dataLayerMock.Verify(x => x.Tiles.Add(It.IsAny<Tile>()), Times.Exactly(9));

            Assert.AreEqual(9, addTIleCounter);
        }

        [TestMethod]
        public void CreateNewComputerVsComputerGame_Game_Should_Add_Game_To_User_Games_Collection()
        {
            Game game = CreateValidNewComputerVsComputerGame();

            Assert.IsTrue(game.GameOwner.Games.Any());
        }

        /// <summary>
        /// Creates a new computer vs computer game with the current user serving as game owner.
        /// </summary>
        /// <returns>Game</returns>
        private Game CreateValidNewComputerVsComputerGame()
        {
            return gameService.CreateNewComputerVsComputerGame(MockConstants.UserName, MockConstants.ComputerUserName, MockConstants.OtherComputerUserName);
        }

        #endregion

        #region RecreatePreviousGame

        [TestMethod]
        [ExpectedException(typeof(UserNotFoundException))]
        public void RecreatePreviousGame_Should_Throw_Exception_If_There_Is_No_Such_User_In_The_Database()
        {
            this.gameService.RecreatePreviousGame(MockConstants.InvalidUsername, GameMode.HumanVsHuman);
        }

        [TestMethod]
        [ExpectedException(typeof(GameNotFoundException))]
        public void RecreatePreviousGame_Should_Throw_Exception_If_The_User_Did_Not_Played_Any_Games()
        {
            this.gameService.RecreatePreviousGame(MockConstants.NewUserWithoutGamesUsername, GameMode.HumanVsHuman);
        }

        [TestMethod]
        public void RecreatePreviousGame_Should_Accept_Two_Parameters()
        {
            ParameterInfo[] methodParameters = this.gameService.GetType().GetMethod("RecreatePreviousGame").GetParameters();

            int parametersCount = methodParameters.Count();

            Assert.AreEqual(2, parametersCount);
        }

        [TestMethod]
        public void RecreatePreviousGame_Should_Accept_String_As_First_Parameter()
        {
            ParameterInfo[] methodParameters = this.gameService.GetType().GetMethod("RecreatePreviousGame").GetParameters();

            bool isFirstParameterString = methodParameters[0].ParameterType.Name == "String";

            Assert.IsTrue(isFirstParameterString);
        }
        
        [TestMethod]
        public void RecreatePreviousGame_Should_Accept_Enum_Named_GameMode_As_Second_Parameter()
        {
            ParameterInfo[] methodParameters = this.gameService.GetType().GetMethod("RecreatePreviousGame").GetParameters();

            bool isSecondParameterNamedGameMode = methodParameters[1].ParameterType.FullName.Contains("GameMode");

            Assert.IsTrue(isSecondParameterNamedGameMode);

            bool isSecondParameterEnum = methodParameters[1].ParameterType.FullName.Contains("Enum");

            Assert.IsTrue(isSecondParameterEnum);
        }

        [TestMethod]
        public void RecreatePreviousGame_Should_Return_Game_That_Is_Not_Null()
        {
            Game game = this.gameService.RecreatePreviousGame(MockConstants.UserName, GameMode.HumanVsHuman);

            Assert.IsNotNull(game);
        }

        [TestMethod]
        public void RecreatePreviousGame_Should_Return_New_HumanVsHuman_Game_When_Game_Mode_Is_HumanVsHuman()
        {
            Game game = this.gameService.RecreatePreviousGame(MockConstants.UserName, GameMode.HumanVsHuman);

            Assert.IsFalse(game.IsFinished);
            Assert.IsNull(game.EndDate);
            Assert.AreEqual(9, game.Tiles.Count(t => t.IsEmpty));
            Assert.IsTrue(string.IsNullOrWhiteSpace(game.WinnerId));
            Assert.AreEqual(GameMode.HumanVsHuman, game.GameMode);
        }

        [TestMethod]
        public void RecreatePreviousGame_Should_Return_New_HumanVsComputer_Game_When_Game_Mode_Is_HumanVsComputer()
        {
            Game game = this.gameService.RecreatePreviousGame(MockConstants.UserName, GameMode.HumanVsComputer);

            Assert.IsFalse(game.IsFinished);
            Assert.IsNull(game.EndDate);
            Assert.AreEqual(9, game.Tiles.Count(t => t.IsEmpty));
            Assert.IsTrue(string.IsNullOrWhiteSpace(game.WinnerId));
            Assert.AreEqual(GameMode.HumanVsComputer, game.GameMode);
        }

        [TestMethod]
        public void RecreatePreviousGame_Should_Return_New_HumanVsComputer_Game_With_Human_Starting_First_When_The_Human_Was_Starting_First()
        {
            Game game = this.gameService.RecreatePreviousGame(MockConstants.UserName, GameMode.HumanVsComputer);

            Assert.AreEqual(MockConstants.UserName, game.ApplicationUser.UserName);
        }

        [TestMethod]
        public void RecreatePreviousGame_Should_Return_New_HumanVsComputer_Game_With_Human_Starting_Second_When_The_Human_Was_Starting_Second()
        {
            Game game = this.gameService.RecreatePreviousGame(MockConstants.ComputerUserName, GameMode.HumanVsComputer);

            Assert.AreEqual(MockConstants.ComputerUserName, game.Oponent.UserName);
        }

        #endregion

        #region GetAllUnfinishedGames

        [TestMethod]
        [ExpectedException(typeof(UserNotFoundException))]
        public void GetAllUnfinishedGames_Should_Throw_UserNotFoundException_If_No_User_Exists_In_The_Database()
        {
            gameService.GetAllUnfinishedGames(MockConstants.InvalidUsername, GameMode.HumanVsHuman);
        }

        [TestMethod]
        public void GetAllUnfinishedGames_Should_Accept_Two_Parameters()
        {
            ParameterInfo[] methodParameters = this.gameService.GetType().GetMethod("GetAllUnfinishedGames").GetParameters();

            int parametersCount = methodParameters.Count();

            Assert.AreEqual(2, parametersCount);
        }

        [TestMethod]
        public void GetAllUnfinishedGames_Should_Accept_String_As_First_Parameter()
        {
            ParameterInfo[] methodParameters = this.gameService.GetType().GetMethod("GetAllUnfinishedGames").GetParameters();

            bool isFirstParameterString = methodParameters[0].ParameterType.Name == "String";

            Assert.IsTrue(isFirstParameterString);
        }

        [TestMethod]
        public void GetAllUnfinishedGames_Should_Accept_Enum_Named_GameMode_As_Second_Parameter()
        {
            ParameterInfo[] methodParameters = this.gameService.GetType().GetMethod("GetAllUnfinishedGames").GetParameters();

            bool isSecondParameterNamedGameMode = methodParameters[1].ParameterType.FullName.Contains("GameMode");

            Assert.IsTrue(isSecondParameterNamedGameMode);

            bool isSecondParameterEnum = methodParameters[1].ParameterType.FullName.Contains("Enum");

            Assert.IsTrue(isSecondParameterEnum);
        }

        [TestMethod]
        public void GetAllUnfinishedGames_Should_Return_2_Finished_HumanVsHuman_Games()
        {
            var result = gameService.GetAllUnfinishedGames(MockConstants.UserName, GameMode.HumanVsHuman);

            var test = result.Count();

            Assert.AreEqual(2, result.Count());

            Assert.IsFalse(result.ToList().Any(g => g.IsFinished));
        }

        [TestMethod]
        public void GetAllUnfinishedGames_Should_Return_5_Finished_HumanVsComputer_Games()
        {
            var result = gameService.GetAllUnfinishedGames(MockConstants.UserName, GameMode.HumanVsComputer);

            var test = result.Count();

            Assert.AreEqual(5, result.Count());

            Assert.IsFalse(result.ToList().Any(g => g.IsFinished));
        }

        [TestMethod]
        public void GetAllUnfinishedGames_Should_Return_Zero_Games_If_The_User_Has_No_Games()
        {
            var result = gameService.GetAllUnfinishedGames(MockConstants.NewUserWithoutGamesUsername, GameMode.HumanVsHuman);

            Assert.AreEqual(0, result.Count());
        }

        #endregion

        #region IsGameFinished

        [TestMethod]
        [ExpectedException(typeof(GameNotFoundException))]
        public void IsGameFinished_Should_Throw_GameNotFoundException_If_No_Such_Game_Exists()
        {
            this.gameService.IsGameFinished(MockConstants.InvalidGameId);
        }

        [TestMethod]
        public void IsGameFinished_Should_Return_True_If_Game_Is_Finished()
        {
            bool result = this.gameService.IsGameFinished(MockConstants.FinishedGameIndex);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsGameFinished_Should_Return_False_If_Game_Is_Not_Finished()
        {
            bool result = this.gameService.IsGameFinished(MockConstants.NewGameIndex);

            Assert.IsFalse(result);
        }

        #endregion

        #region CheckGameForOutcome

        [TestMethod]
        [ExpectedException(typeof(GameNotFoundException))]
        public void CheckGameForWinner_Should_Throw_GameNotFoundException_If_GameId_Is_Not_In_The_Database()
        {
            int gameId = MockConstants.InvalidGameId;

            this.gameService.CheckGameForOutcome(gameId);
        }

        [TestMethod]
        public void CheckGameForWinner_Should_Not_Check_For_Winner_If_Game_Turns_Count_Is_Less_Than_5()
        {
            Game game = this.gameService.GetGameById(MockConstants.NewGameIndex);

            this.gameService.CheckGameForOutcome(game.Id);

            Assert.AreEqual(GameState.NotFinished, game.GameState);
            Assert.AreEqual(false, game.IsFinished);
            Assert.AreEqual(null, game.EndDate);
            Assert.IsTrue(string.IsNullOrWhiteSpace(game.WinnerId));
        }

        [TestMethod]
        public void CheckGameForWinner_Should_Set_Game_IsFinished_Property_To_True_If_There_Is_A_Winner()
        {
            Game game = this.gameService.GetGameById(MockConstants.NewGameIndex);

            this.SimulateGameWonByTheHomesideUser(game);

            this.gameService.CheckGameForOutcome(game.Id);

            Assert.IsTrue(game.IsFinished);
        }

        [TestMethod]
        public void CheckGameForWinner_Should_Set_Game_EndDate_Property_If_There_Is_A_Winner()
        {
            Game game = this.gameService.GetGameById(MockConstants.NewGameIndex);

            this.SimulateGameWonByTheHomesideUser(game);

            this.gameService.CheckGameForOutcome(game.Id);

            Assert.IsNotNull(game.EndDate);
        }

        [TestMethod]
        public void CheckGameForWinner_Should_Set_GameState_Property_To_Won_If_There_Is_A_Winner()
        {
            Game game = this.gameService.GetGameById(MockConstants.NewGameIndex);

            this.SimulateGameWonByTheHomesideUser(game);

            this.gameService.CheckGameForOutcome(game.Id);

            Assert.AreEqual(GameState.Won, game.GameState);
        }

        [TestMethod]
        public void CheckGameForWinner_Should_Set_Game_WinnerId_Property_To_Be_The_HomeSideUserId_If_The_HomeSideUser_Has_Won()
        {
            Game game = this.gameService.GetGameById(MockConstants.NewGameIndex);

            this.SimulateGameWonByTheHomesideUser(game);

            this.gameService.CheckGameForOutcome(game.Id);

            Assert.AreEqual(MockConstants.UserId, game.WinnerId);
        }

        [TestMethod]
        public void CheckGameForWinner_Should_Set_Game_WinnerId_Property_To_Be_The_AwaySideUserId_If_The_AwaySideUser_Has_Won()
        {
            Game game = this.gameService.GetGameById(MockConstants.NewGameIndex);

            this.gameService.PlaceTurn(game.Id, MockConstants.MiddleLeftTileIndex, MockConstants.UserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.TopLeftTileIndex, MockConstants.OtherGuyUserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.MiddleRightTileIndex, MockConstants.UserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.TopMiddleTileIndex, MockConstants.OtherGuyUserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.BottomLeftTileIndex, MockConstants.UserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.TopRightTileIndex, MockConstants.OtherGuyUserName);

            this.gameService.CheckGameForOutcome(game.Id);

            Assert.AreEqual(MockConstants.OtherGuyId, game.WinnerId);
        }

        [TestMethod]
        public void CheckGameForWinner_Should_Set_Game_GameState_Property_To_Draw_If_TheGame_Is_A_Draw()
        {
            Game game = this.gameService.GetGameById(MockConstants.NewGameIndex);

            this.SimulateDrawGame(game);

            this.gameService.CheckGameForOutcome(game.Id);

            Assert.AreEqual(GameState.Draw, game.GameState);
        }

        [TestMethod]
        public void CheckGameForWinner_Should_Set_Game_IsFinished_Property_To_True_If_TheGame_Is_A_Draw()
        {
            Game game = this.gameService.GetGameById(MockConstants.NewGameIndex);

            this.SimulateDrawGame(game);

            this.gameService.CheckGameForOutcome(game.Id);

            Assert.IsTrue(game.IsFinished);
        }

        [TestMethod]
        public void CheckGameForWinner_Should_Set_Game_EndDate_Property_If_TheGame_Is_A_Draw()
        {
            Game game = this.gameService.GetGameById(MockConstants.NewGameIndex);

            this.SimulateDrawGame(game);

            this.gameService.CheckGameForOutcome(game.Id);

            Assert.IsNotNull(game.EndDate);
        }

        [TestMethod]
        public void CheckGameForWinner_Should_Not_Set_Game_WinnerId_Property_If_TheGame_Is_A_Draw()
        {
            Game game = this.gameService.GetGameById(MockConstants.NewGameIndex);

            this.SimulateDrawGame(game);

            this.gameService.CheckGameForOutcome(game.Id);

            Assert.IsTrue(string.IsNullOrWhiteSpace(game.WinnerId));
        }

        [TestMethod]
        public void CheckGameForWinner_Should_Not_Set_Game_Finished_Properties_If_TheGame_Is_Not_Finished()
        {
            Game game = this.gameService.GetGameById(MockConstants.NewGameIndex);

            this.gameService.PlaceTurn(game.Id, MockConstants.TopLeftTileIndex, MockConstants.UserName);

            this.gameService.CheckGameForOutcome(game.Id);

            Assert.IsFalse(game.IsFinished);
            Assert.AreEqual(GameState.NotFinished, game.GameState);
            Assert.IsNull(game.EndDate);
            Assert.IsTrue(string.IsNullOrWhiteSpace(game.WinnerId));
        }

        [TestMethod]
        public void CheckGameForWinner_Should_Set_Game_Win_Properties_If_Horizontal_Tiles_Are_Equal_Starting_From_Top_Left()
        {
            Game game = this.gameService.GetGameById(MockConstants.NewGameIndex);

            this.gameService.PlaceTurn(game.Id, MockConstants.TopLeftTileIndex, MockConstants.UserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.BottomLeftTileIndex, MockConstants.OtherGuyUserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.TopMiddleTileIndex, MockConstants.UserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.BottomRightTileIndex, MockConstants.OtherGuyUserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.TopRightTileIndex, MockConstants.UserName);

            this.gameService.CheckGameForOutcome(game.Id);

            Assert.IsTrue(game.IsFinished);
            Assert.AreEqual(GameState.Won, game.GameState);
            Assert.IsNotNull(game.EndDate);
            Assert.IsFalse(string.IsNullOrWhiteSpace(game.WinnerId));
        }

        [TestMethod]
        public void CheckGameForWinner_Should_Set_Game_Win_Properties_If_Horizontal_Tiles_Are_Equal_Starting_From_Middle_Left()
        {
            Game game = this.gameService.GetGameById(MockConstants.NewGameIndex);

            this.gameService.PlaceTurn(game.Id, MockConstants.MiddleLeftTileIndex, MockConstants.UserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.BottomLeftTileIndex, MockConstants.OtherGuyUserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.MiddleMiddleTileIndex, MockConstants.UserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.BottomRightTileIndex, MockConstants.OtherGuyUserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.MiddleRightTileIndex, MockConstants.UserName);

            this.gameService.CheckGameForOutcome(game.Id);

            Assert.IsTrue(game.IsFinished);
            Assert.AreEqual(GameState.Won, game.GameState);
            Assert.IsNotNull(game.EndDate);
            Assert.IsFalse(string.IsNullOrWhiteSpace(game.WinnerId));
        }

        [TestMethod]
        public void CheckGameForWinner_Should_Set_Game_Win_Properties_If_Horizontal_Tiles_Are_Equal_Starting_From_Bottom_Left()
        {
            Game game = this.gameService.GetGameById(MockConstants.NewGameIndex);

            this.gameService.PlaceTurn(game.Id, MockConstants.BottomLeftTileIndex, MockConstants.UserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.TopLeftTileIndex, MockConstants.OtherGuyUserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.BottomMiddleTileIndex, MockConstants.UserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.TopRightTileIndex, MockConstants.OtherGuyUserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.BottomRightTileIndex, MockConstants.UserName);

            this.gameService.CheckGameForOutcome(game.Id);

            Assert.IsTrue(game.IsFinished);
            Assert.AreEqual(GameState.Won, game.GameState);
            Assert.IsNotNull(game.EndDate);
            Assert.IsFalse(string.IsNullOrWhiteSpace(game.WinnerId));
        }

        [TestMethod]
        public void CheckGameForWinner_Should_Set_Game_Win_Properties_If_Vertical_Tiles_Are_Equal_Starting_From_Top_Left()
        {
            Game game = this.gameService.GetGameById(MockConstants.NewGameIndex);

            this.gameService.PlaceTurn(game.Id, MockConstants.TopLeftTileIndex, MockConstants.UserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.MiddleMiddleTileIndex, MockConstants.OtherGuyUserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.MiddleLeftTileIndex, MockConstants.UserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.MiddleRightTileIndex, MockConstants.OtherGuyUserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.BottomLeftTileIndex, MockConstants.UserName);

            this.gameService.CheckGameForOutcome(game.Id);

            Assert.IsTrue(game.IsFinished);
            Assert.AreEqual(GameState.Won, game.GameState);
            Assert.IsNotNull(game.EndDate);
            Assert.IsFalse(string.IsNullOrWhiteSpace(game.WinnerId));
        }

        [TestMethod]
        public void CheckGameForWinner_Should_Set_Game_Win_Properties_If_Vertical_Tiles_Are_Equal_Starting_From_Top_Middle()
        {
            Game game = this.gameService.GetGameById(MockConstants.NewGameIndex);

            this.gameService.PlaceTurn(game.Id, MockConstants.TopMiddleTileIndex, MockConstants.UserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.TopLeftTileIndex, MockConstants.OtherGuyUserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.MiddleMiddleTileIndex, MockConstants.UserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.MiddleRightTileIndex, MockConstants.OtherGuyUserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.BottomMiddleTileIndex, MockConstants.UserName);

            this.gameService.CheckGameForOutcome(game.Id);

            Assert.IsTrue(game.IsFinished);
            Assert.AreEqual(GameState.Won, game.GameState);
            Assert.IsNotNull(game.EndDate);
            Assert.IsFalse(string.IsNullOrWhiteSpace(game.WinnerId));
        }

        [TestMethod]
        public void CheckGameForWinner_Should_Set_Game_Win_Properties_If_Vertical_Tiles_Are_Equal_Starting_From_Top_Right()
        {
            Game game = this.gameService.GetGameById(MockConstants.NewGameIndex);

            this.gameService.PlaceTurn(game.Id, MockConstants.TopRightTileIndex, MockConstants.UserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.TopLeftTileIndex, MockConstants.OtherGuyUserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.MiddleRightTileIndex, MockConstants.UserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.MiddleLeftTileIndex, MockConstants.OtherGuyUserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.BottomRightTileIndex, MockConstants.UserName);

            this.gameService.CheckGameForOutcome(game.Id);

            Assert.IsTrue(game.IsFinished);
            Assert.AreEqual(GameState.Won, game.GameState);
            Assert.IsNotNull(game.EndDate);
            Assert.IsFalse(string.IsNullOrWhiteSpace(game.WinnerId));
        }

        [TestMethod]
        public void CheckGameForWinner_Should_Set_Game_Win_Properties_If_Diagonal_Tiles_Are_Equal_Starting_From_Top_Left()
        {
            Game game = this.gameService.GetGameById(MockConstants.NewGameIndex);

            this.gameService.PlaceTurn(game.Id, MockConstants.TopLeftTileIndex, MockConstants.UserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.BottomLeftTileIndex, MockConstants.OtherGuyUserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.MiddleMiddleTileIndex, MockConstants.UserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.MiddleLeftTileIndex, MockConstants.OtherGuyUserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.BottomRightTileIndex, MockConstants.UserName);

            this.gameService.CheckGameForOutcome(game.Id);

            Assert.IsTrue(game.IsFinished);
            Assert.AreEqual(GameState.Won, game.GameState);
            Assert.IsNotNull(game.EndDate);
            Assert.IsFalse(string.IsNullOrWhiteSpace(game.WinnerId));
        }

        [TestMethod]
        public void CheckGameForWinner_Should_Set_Game_Win_Properties_If_Diagonal_Tiles_Are_Equal_Starting_From_Top_Right()
        {
            Game game = this.gameService.GetGameById(MockConstants.NewGameIndex);

            this.gameService.PlaceTurn(game.Id, MockConstants.TopRightTileIndex, MockConstants.UserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.TopLeftTileIndex, MockConstants.OtherGuyUserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.MiddleMiddleTileIndex, MockConstants.UserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.MiddleLeftTileIndex, MockConstants.OtherGuyUserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.BottomLeftTileIndex, MockConstants.UserName);

            this.gameService.CheckGameForOutcome(game.Id);

            Assert.IsTrue(game.IsFinished);
            Assert.AreEqual(GameState.Won, game.GameState);
            Assert.IsNotNull(game.EndDate);
            Assert.IsFalse(string.IsNullOrWhiteSpace(game.WinnerId));
        }

        /// <summary>
        /// Simulates a game won by the homeside user
        /// </summary>
        /// <param name="game">Game</param>
        private void SimulateGameWonByTheHomesideUser(Game game)
        {
            this.gameService.PlaceTurn(game.Id, MockConstants.TopLeftTileIndex, MockConstants.UserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.BottomRightTileIndex, MockConstants.OtherGuyUserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.TopMiddleTileIndex, MockConstants.UserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.BottomLeftTileIndex, MockConstants.OtherGuyUserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.TopRightTileIndex, MockConstants.UserName);
        }

        /// <summary>
        /// Simulates a draw game
        /// </summary>
        /// <param name="game">Game</param>
        private void SimulateDrawGame(Game game)
        {
            this.gameService.PlaceTurn(game.Id, MockConstants.TopLeftTileIndex, MockConstants.UserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.TopRightTileIndex, MockConstants.OtherGuyUserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.BottomLeftTileIndex, MockConstants.UserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.BottomRightTileIndex, MockConstants.OtherGuyUserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.MiddleRightTileIndex, MockConstants.UserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.MiddleLeftTileIndex, MockConstants.OtherGuyUserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.TopMiddleTileIndex, MockConstants.UserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.MiddleMiddleTileIndex, MockConstants.OtherGuyUserName);

            this.gameService.PlaceTurn(game.Id, MockConstants.BottomMiddleTileIndex, MockConstants.UserName);
        }

        #endregion

        #region PlaceTurn

        [TestMethod]
        [ExpectedException(typeof(GameNotFoundException))]
        public void PlaceTurn_Should_Throw_GameNotFoundException_If_GameId_Is_Not_In_The_Database()
        {
            string username = MockConstants.UserName;
            int gameId = MockConstants.InvalidGameId;
            int tileIndex = MockConstants.ZeroTileIndex;

            this.gameService.PlaceTurn(gameId, tileIndex, username);
        }

        [TestMethod]
        [ExpectedException(typeof(GameIsFinishedException))]
        public void PlaceTurn_Should_Throw_GameIsFinishedException_If_Game_Is_Already_Finished()
        {
            this.gameService.PlaceTurn(MockConstants.FinishedGameIndex, 0, MockConstants.UserName);
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotAuthorizedException))]
        public void PlaceTurn_Should_Throw_UserNotAuthorized_If_CurrentUser_Is_Not_Part_Of_The_Game()
        {
            this.gameService.PlaceTurn(MockConstants.SameOponentGameIndex, 0, "alibaba@yahoo.com");
        }

        [TestMethod]
        [ExpectedException(typeof(TileValidationException))]
        public void PlaceTurn_Should_Throw_TileValidationException_If_Tile_Index_Is_Not_In_Valid_Range()
        {
            this.gameService.PlaceTurn(MockConstants.NewGameIndex, 9, MockConstants.UserName);
        }

        [TestMethod]
        [ExpectedException(typeof(TileValidationException))]
        public void PlaceTurn_Should_Throw_TileValidationException_If_Tile_Is_Not_Empty()
        {
            this.gameService.PlaceTurn(MockConstants.NewGameIndex, 0, MockConstants.UserName);

            this.gameService.PlaceTurn(MockConstants.NewGameIndex, 0, MockConstants.UserName);
        }

        [TestMethod]
        public void PlaceTurn_Should_Set_Tile_Value_To_X_If_The_Current_Turn_Is_Even_Number()
        {
            for (var i = 0; i < 9; i++)
            {
                this.gameService.PlaceTurn(MockConstants.NewGameIndex, i, MockConstants.UserName);
            }

            Game game = this.gameService.GetGameById(MockConstants.NewGameIndex);

            int evenNumbersCount = 0;
            int assertionsCount = 0;

            for (var i = 0; i < game.Tiles.Count; i++)
            {
                if (IsOddNumber(i) == false)
                {
                    evenNumbersCount++;

                    string tileValue = game.Tiles.ElementAt(i).Value;

                    if (tileValue == "X")
                    {
                        assertionsCount++;
                    }
                }
            }

            Assert.AreEqual(evenNumbersCount, assertionsCount);
        }

        [TestMethod]
        public void PlaceTurn_Should_Set_Tile_Value_To_O_If_The_Current_Turn_Is_Odd_Number()
        {
            for (var i = 0; i < 9; i++)
            {
                this.gameService.PlaceTurn(MockConstants.NewGameIndex, i, MockConstants.UserName);
            }

            Game game = this.gameService.GetGameById(MockConstants.NewGameIndex);

            int oddNUmbersCount = 0;
            int assertionsCount = 0;

            for (var i = 0; i < game.Tiles.Count; i++)
            {
                if (IsOddNumber(i))
                {
                    oddNUmbersCount++;

                    string tileValue = game.Tiles.ElementAt(i).Value;

                    if (tileValue == "O")
                    {
                        assertionsCount++;
                    }
                }
            }

            Assert.AreEqual(oddNUmbersCount, assertionsCount);
        }

        [TestMethod]
        public void PlaceTurn_Should_Set_Tile_IsEmpty_Property_To_False()
        {
            for (var i = 1; i < 9; i++)
            {
                this.gameService.PlaceTurn(MockConstants.NewGameIndex, i, MockConstants.UserName);
            }

            Game game = this.gameService.GetGameById(MockConstants.NewGameIndex);

            bool areAllTilesSet = game.Tiles.ToList().Any(t => t.IsEmpty == true);

            Assert.IsTrue(areAllTilesSet);
        }

        [TestMethod]
        public void PlaceTurn_Should_Increment_Game_Turns_Count_By_One()
        {
            var actualCount = 1;
            for (var i = 0; i < 9; i++)
            {
                actualCount++;
                this.gameService.PlaceTurn(MockConstants.NewGameIndex, i, MockConstants.UserName);
            }

            Game game = this.gameService.GetGameById(MockConstants.NewGameIndex);

            Assert.AreEqual(actualCount, game.TurnsCount);
        }

        [TestMethod]
        public void PlaceTurn_Should_Call_Tiles_Repository_Update_Method_Once()
        {
            var updateTilesCounter = 0;

            this.dataLayerMock.Setup(x => x.Tiles.Update(It.IsAny<Tile>())).Callback(() => updateTilesCounter++);

            this.gameService.PlaceTurn(MockConstants.NewGameIndex, MockConstants.ZeroTileIndex, MockConstants.UserName);

            this.dataLayerMock.Verify(x => x.Tiles.Update(It.IsAny<Tile>()), Times.Once());

            Assert.AreEqual(1, updateTilesCounter);
        }

        [TestMethod]
        public void PlaceTurn_Should_Call_SaveChanges_Method_Once()
        {
            var saveChangesCount = 0;

            this.dataLayerMock.Setup(x => x.SaveChanges()).Callback(() => saveChangesCount++);

            this.gameService.PlaceTurn(MockConstants.NewGameIndex, MockConstants.ZeroTileIndex, MockConstants.UserName);

            this.dataLayerMock.Verify(x => x.SaveChanges(), Times.Once());

            Assert.AreEqual(1, saveChangesCount);
        }

        /// <summary>
        /// Checks if an integer is a odd number.
        /// </summary>
        /// <param name="turnsCount">integer to check</param>
        /// <returns>bool</returns>
        private bool IsOddNumber(int turnsCount)
        {
            return turnsCount % 2 != 0;
        }

        #endregion

        #region GetComputerMove

        [TestMethod]
        [ExpectedException(typeof(GameNotFoundException))]
        public void GetComputerMove_Should_Throw_GameNotFoundException_If_No_Such_Game_Exists()
        {
            gameService.GetComputerMove(MockConstants.InvalidGameId);
        }

        [TestMethod]
        [ExpectedException(typeof(ComputerException))]
        public void GetComputerMove_Should_Throw_ComputerException_If_Game_IsFinished()
        {
            gameService.GetComputerMove(9);
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotAuthorizedException))]
        public void GetComputerMove_Should_Throw_UserNotAuthorizedException_If_GameMode_Is_Not_ComputerVsComputer()
        {
            gameService.GetComputerMove(MockConstants.NewGameIndex);
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotAuthorizedException))]
        public void GetComputerMove_Should_Throw_UserNotAuthorizedException_If_GameMode_Is_Not_HumanVsComputer()
        {
            gameService.GetComputerMove(MockConstants.NewGameIndex);
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotAuthorizedException))]
        public void GetComputerMove_Should_Throw_UserNotAuthorizedException_If_No_Computer_Is_Present_In_The_Game()
        {
            gameService.GetComputerMove(14);
        }

        [TestMethod]
        public void GetComputerMove_Should_Return_Valid_Int_As_Result()
        {
            var result = gameService.GetComputerMove(8);

            Assert.IsNotNull(result);

            Assert.IsTrue(result >= 0 && result <= 8);
        }

        #endregion
    }
}