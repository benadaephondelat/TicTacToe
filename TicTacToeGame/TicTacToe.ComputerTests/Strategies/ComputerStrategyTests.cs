namespace TicTacToe.ComputerTests.Strategies
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Computer;
    using Computer.Models;
    using Computer.Strategies;
    using Computer.Strategies.StartingFirst;
    using TicTacToeCommon.Exceptions.Game;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using DataMockHelper;

    [TestClass]
    public class ComputerStrategyTests
    {
        private DataMockHelper dataLayerMockHelper;

        public ComputerStrategyTests()
        {
            this.dataLayerMockHelper = new DataMockHelper();
        }

        [TestMethod]
        public void ComputerStrategy_Must_Have_Abstract_Method_Named_GetComputerMove()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            StartingFirstComputerStrategy startingFirstStrategy = new StartingFirstComputerStrategy(model);

            bool result = startingFirstStrategy.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public)
                                               .Any(m => m.Name == "GetComputerMove");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ComputerStrategy_GetComputerMove_Method_Should_Have_Return_Type_Of_Int32()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            StartingFirstComputerStrategy startingFirstStrategy = new StartingFirstComputerStrategy(model);

            Type controllerType = startingFirstStrategy.GetType();

            var method = controllerType.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                                       .FirstOrDefault(m => m.Name == "GetComputerMove");

            Assert.IsNotNull(method);

            string returnTypeName = method.ReturnType.FullName;

            bool result = returnTypeName.ToLower().Contains("int");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ComputerStrategy_Should_Have_Method_Named_ValidateGame()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            StartingFirstComputerStrategy startingFirstStrategy = new StartingFirstComputerStrategy(model);

            bool result = startingFirstStrategy.GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                                               .Any(m => m.Name == "ValidateGame");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ComputerStrategy_ValidateGame_Method_Return_Type_Should_Be_Void()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            StartingFirstComputerStrategy startingFirstStrategy = new StartingFirstComputerStrategy(model);

            Type controllerType = startingFirstStrategy.GetType();

            var method = controllerType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                                       .FirstOrDefault(m => m.Name == "ValidateGame");

            Assert.IsNotNull(method);

            string returnTypeName = method.ReturnType.FullName;

            bool result = returnTypeName.ToLower().Contains("void");

            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(GameIsFinishedException))]
        public void ComputerStrategy_ValidateGame_Method_Should_Throw_Game_Is_Finished_Exception_If_Game_Is_Finished()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            model.IsFinished = true;

            StartingFirstComputerStrategy startingFirstStrategy = new StartingFirstComputerStrategy(model);
        }

        [TestMethod]
        [ExpectedException(typeof(GameIsFinishedException))]
        public void ComputerStrategy_ValidateGame_Method_Should_Throw_Game_Is_Finished_Exception_If_All_Tiles_Are_Taken()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            var takenTiles = this.dataLayerMockHelper.GenerateDefaultTilesList();

            takenTiles.ForEach(x => { x.Value = "X"; x.IsEmpty = false; });

            model.Tiles = takenTiles;

            StartingFirstComputerStrategy startingFirstStrategy = new StartingFirstComputerStrategy(model);
        }
    }
}