namespace TicTacToe.ComputerTests
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Computer;
    using Computer.Models;
    using Computer.Constants;
    using Computer.Strategies;
    using Computer.StrategyChooser;
    using TicTacToeCommon.Constants;
    using TicTacToeCommon.Exceptions.Game;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ComputerTests
    {
        #region StrategyChooser

        [TestMethod]
        public void StrategyChooser_If_Computer_Is_Starting_First_Choose_StartingFirstStrategy()
        {
            ComputerGameModel game = this.CreateNewComputerVsHumanGame();

            ComputerStrategy strategy = StrategyChooser.GetComputerStrategy(game);

            Assert.IsTrue(strategy is StartingFirstStrategy);
        }

        [TestMethod]
        public void StrategyChooser_If_Computer_Is_Starting_Second_Choose_StartingSecondStrategy()
        {
            ComputerGameModel game = this.CreateNewHumanVsComputerGame();

            ComputerStrategy strategy = StrategyChooser.GetComputerStrategy(game);

            Assert.IsTrue(strategy is StartingSecondStrategy);
        }

        #endregion

        #region StartingFirstStrategy

        [TestMethod]
        [ExpectedException(typeof(GameIsFinishedException))]
        public void StartingFirstStrategy_Should_Throw_GameIsFinished_Exception_If_Game_Is_Finished()
        {
            ComputerGameModel model = this.CreateNewComputerVsHumanFinishedGame();

            Computer computer = new Computer(model);

            int computerMove = computer.GetComputerMove();
        }

        [TestMethod]
        public void StartingFirstStrategy_First_Turn_Choose_The_Center_Tile()
        {
            ComputerGameModel model = this.CreateNewComputerVsHumanGame();

            Computer computer = new Computer(model);

            int computerMove = computer.GetComputerMove();

            Assert.AreEqual(TileConstants.MiddleMiddleTile, computerMove);
        }

        [TestMethod]
        public void StartingFirstStrategy_Second_Turn_If_Edges_Are_Empty_Choose_One_Of_Them()
        {
            for (var i = 0; i < 1000000; i++)
            {
                ComputerGameModel model = this.CreateComputerVsHumanSecondTurnGame(TileConstants.TopMiddleTile);

                Computer computer = new Computer(model);

                int computerMove = computer.GetComputerMove();

                bool isTopLeft = computerMove == TileConstants.TopLeftTile;

                bool isTopRight = computerMove == TileConstants.TopRightTile;

                bool isBottomLeft = computerMove == TileConstants.BottomLeftTile;

                bool isBottomRight = computerMove == TileConstants.BottomRightTile;

                bool hasComputerChosenAnEdge = isTopLeft == true || isTopRight == true ||
                                               isBottomLeft == true || isBottomRight == true;

                Assert.IsTrue(hasComputerChosenAnEdge);
            }
        }

        [TestMethod]
        public void StartingFirstStrategy_Second_Turn_If_Player_Chose_TopLeft_Computer_Must_Choose_TopRight_Or_BottomLeft()
        {
            for (int i = 0; i < 1000000; i++)
            {
                ComputerGameModel model = this.CreateComputerVsHumanSecondTurnGame(TileConstants.TopLeftTile);

                Computer computer = new Computer(model);

                int computerMove = computer.GetComputerMove();

                Assert.IsTrue(computerMove == TileConstants.TopRightTile || computerMove == TileConstants.BottomLeftTile);
            }
        }

        [TestMethod]
        public void StartingFirstStrategy_Second_Turn_If_Player_Chose_TopRight_Computer_Must_Choose_TopLeft_Or_BottomRight()
        {
            for (int i = 0; i < 1000000; i++)
            {
                ComputerGameModel model = this.CreateComputerVsHumanSecondTurnGame(TileConstants.TopRightTile);

                Computer computer = new Computer(model);

                int computerMove = computer.GetComputerMove();

                Assert.IsTrue(computerMove == TileConstants.TopLeftTile || computerMove == TileConstants.BottomRightTile);
            }
        }

        [TestMethod]
        public void StartingFirstStrategy_Second_Turn_If_Player_Chose_BottomLeft_Computer_Must_Choose_TopLeft_Or_BottomRight()
        {
            for (int i = 0; i < 1000000; i++)
            {
                ComputerGameModel model = this.CreateComputerVsHumanSecondTurnGame(TileConstants.BottomLeftTile);

                Computer computer = new Computer(model);

                int computerMove = computer.GetComputerMove();

                Assert.IsTrue(computerMove == TileConstants.TopLeftTile || computerMove == TileConstants.BottomRightTile);
            }
        }

        [TestMethod]
        public void StartingFirstStrategy_Second_Turn_If_Player_Chose_BottomRight_Computer_Must_Choose_BottomLeft_Or_TopRight()
        {
            for (int i = 0; i < 1000000; i++)
            {
                ComputerGameModel model = this.CreateComputerVsHumanSecondTurnGame(TileConstants.BottomRightTile);

                Computer computer = new Computer(model);

                int computerMove = computer.GetComputerMove();

                Assert.IsTrue(computerMove == TileConstants.BottomLeftTile || computerMove == TileConstants.TopRightTile);
            }
        }

        #endregion

        #region StartingSecondStrategy

        [TestMethod]
        [ExpectedException(typeof(GameIsFinishedException))]
        public void StartingSecondStrategy_Should_Throw_GameIsFinished_Exception_If_Game_Is_Finished()
        {
            ComputerGameModel model = this.CreateNewHumanVsComputerFinishedGame();

            Computer computer = new Computer(model);

            int computerMove = computer.GetComputerMove();
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void StartingSecondStrategy_Should_Throw_NotImplementedException_If_Used()
        {
            ComputerGameModel model = this.CreateNewHumanVsComputerGame();

            Computer computer = new Computer(model);

            int computerMove = computer.GetComputerMove();
        }

        #endregion

        /// <summary>
        /// Creates a new computer vs human game
        /// </summary>
        /// <returns>ComputerGameModel</returns>
        private ComputerGameModel CreateNewComputerVsHumanGame()
        {
            ComputerGameModel model = new ComputerGameModel();

            model.HomesideUsername = UserConstants.ComputerUsername;
            model.AwaysideUsername = UserConstants.UserUsername;
            model.TurnsCount = 1;
            model.IsFinished = false;

            return model;
        }

        /// <summary>
        /// Creates a new human vs computer game
        /// </summary>
        /// <returns>ComputerGameModel</returns>
        private ComputerGameModel CreateNewHumanVsComputerGame()
        {
            ComputerGameModel model = new ComputerGameModel();

            model.HomesideUsername = UserConstants.UserUsername;
            model.AwaysideUsername = UserConstants.ComputerUsername;
            model.TurnsCount = 1;
            model.IsFinished = false;

            return model;
        }

        /// <summary>
        /// Creates a finished computer vs human game 
        /// </summary>
        /// <returns>ComputerGameModel</returns>
        private ComputerGameModel CreateNewComputerVsHumanFinishedGame()
        {
            ComputerGameModel model = new ComputerGameModel();

            model.HomesideUsername = UserConstants.ComputerUsername;
            model.AwaysideUsername = UserConstants.UserUsername;
            model.TurnsCount = 9;
            model.IsFinished = true;

            return model;
        }

        /// <summary>
        /// Creates a finished human vs computer game 
        /// </summary>
        /// <returns>ComputerGameModel</returns>
        private ComputerGameModel CreateNewHumanVsComputerFinishedGame()
        {
            ComputerGameModel model = new ComputerGameModel();

            model.HomesideUsername = UserConstants.UserUsername;
            model.AwaysideUsername = UserConstants.ComputerUsername;
            model.TurnsCount = 9;
            model.IsFinished = true;

            return model;
        }

        /// <summary>
        /// Creates computer vs human game starting from the 3rd turn
        /// </summary>
        /// <param name="humanPlayerTurnTileIndex">Human player's turn</param>
        /// <returns>ComputerGameModel</returns>
        private ComputerGameModel CreateComputerVsHumanSecondTurnGame(int humanPlayerTurnTileIndex)
        {
            ComputerGameModel model = new ComputerGameModel();

            model.HomesideUsername = UserConstants.ComputerUsername;
            model.AwaysideUsername = UserConstants.UserUsername;
            model.TurnsCount = 3;
            model.IsFinished = false;
            model.Tiles = this.GenerateDefaultTilesList();

            model.Tiles.ElementAt(ComputerConstants.CenterPosition).IsEmpty = false;
            model.Tiles.ElementAt(ComputerConstants.CenterPosition).Value = ComputerConstants.HomeSideSign;

            model.Tiles.ElementAt(humanPlayerTurnTileIndex).IsEmpty = false;
            model.Tiles.ElementAt(humanPlayerTurnTileIndex).Value = ComputerConstants.AwaySideSign;

            return model;
        }

        /// <summary>
        /// Creates a list of 9 empty fake tiles
        /// </summary>
        /// <returns>List Tile</returns>
        private List<ComputerGameTileModel> GenerateDefaultTilesList()
        {
            List<ComputerGameTileModel> defaultTilesList = new List<ComputerGameTileModel>();

            for (var i = 1; i < 10; i++)
            {
                ComputerGameTileModel tile = new ComputerGameTileModel() { IsEmpty = true, Value = string.Empty };

                defaultTilesList.Add(tile);
            }

            return defaultTilesList;
        }
    }
}