namespace TicTacToe.ServiceLayerTests
{
    using System;
    using System.Linq;
    using DataLayer.Data;
    using ServiceLayer.TicTacToeGameService;
    using Models;
    using Models.Enums;
    using Constants;
    using MockHelpers;
    using TicTacToeCommon.Exceptions.User;
    using TicTacToeCommon.Exceptions.Tile;
    using TicTacToeCommon.Exceptions.Game;
    using Moq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void CreateNewHumanVsHumanGame_Game_If_The_CurrentUser_Starts_First_The_Oponent_Should_Be_The_DefaultUser
            ()
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

        [TestMethod]
        public void CreateNewHumanVsHumanGame_Game_Should_Add_Game_To_User_Games_Collection()
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
            return gameService.CreateNewHumanVsHumanGame(MockConstants.UserName, MockConstants.OtherGuyUserName);
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

        #region CheckGameForOutcome

        [TestMethod]
        [ExpectedException(typeof(GameNotFoundException))]
        public void CheckGameForWinner_Should_Throw_GameNotFoundException_If_GameId_Is_Not_In_The_Database()
        {
            int gameId = MockConstants.InvalidGameId;

            this.gameService.CheckGameForOutcome(gameId);
        }

        [TestMethod]
        [ExpectedException(typeof(GameIsFinishedException))]
        public void CheckGameForWinner_Should_Throw_GameIsFinishedException_If_Game_Is_Finished()
        {
            int gameId = MockConstants.FinishedGameIndex;

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

        #region IsGameFinished

        [TestMethod]
        [ExpectedException(typeof(GameNotFoundException))]
        public void IsGameFinished_Should_Throw_GameNotFoundException_If_Id_Is_Invalid()
        {
            this.gameService.GetGameById(MockConstants.InvalidGameId);
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

        #region RecreatePreviousGame

        [TestMethod]
        [ExpectedException(typeof(UserNotFoundException))]
        public void ReplayGame_Should_Throw_Exception_If_There_Is_No_Such_User_In_The_Database()
        {
            this.gameService.RecreatePreviousGame(MockConstants.InvalidUsername);
        }

        [TestMethod]
        [ExpectedException(typeof(GameNotFoundException))]
        public void ReplayGame_Should_Throw_Exception_If_The_User_Did_Not_Played_Any_Games()
        {
            this.gameService.RecreatePreviousGame(MockConstants.NewUserWithoutGamesUsername);
        }

        [TestMethod]
        public void ReplayGame_Should_Return_Game_That_Is_Not_Null()
        {
            Game game = this.gameService.RecreatePreviousGame(MockConstants.UserName);

            Assert.IsNotNull(game);
        }

        [TestMethod]
        public void ReplayGame_Should_Return_New_Game()
        {
            Game game = this.gameService.RecreatePreviousGame(MockConstants.UserName);

            Assert.IsFalse(game.IsFinished);
            Assert.IsNull(game.EndDate);
            Assert.AreEqual(9, game.Tiles.Count(t => t.IsEmpty));
            Assert.IsTrue(string.IsNullOrWhiteSpace(game.WinnerId));
        }

        [TestMethod]
        public void ReplayGame_Should_Return_New_Game_Where_The_Homeside_Is_The_Current_User()
        {
            Game game = this.gameService.RecreatePreviousGame(MockConstants.UserName);

            Assert.AreEqual(MockConstants.UserName, game.ApplicationUser.UserName);
        }

        #endregion
    }
}