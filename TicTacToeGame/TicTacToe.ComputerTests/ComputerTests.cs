namespace TicTacToe.ComputerTests
{
    using System;
    using Computer;
    using Computer.Models;
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
        public void StartingFirstStrategy_If_First_Turn_Choose_The_Center_Tile()
        {
            ComputerGameModel model = this.CreateNewComputerVsHumanGame();

            Computer computer = new Computer(model);

            int computerMove = computer.GetComputerMove();

            Assert.AreEqual(TileConstants.MiddleMiddleTile, computerMove);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void StartingFirstStrategy_If_Not_First_Turn_Should_Throw_NotImplementedException()
        {
            ComputerGameModel model = this.CreateNewComputerVsHumanGame();

            model.TurnsCount = 5;

            Computer computer = new Computer(model);

            int computerMove = computer.GetComputerMove();
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
    }
}