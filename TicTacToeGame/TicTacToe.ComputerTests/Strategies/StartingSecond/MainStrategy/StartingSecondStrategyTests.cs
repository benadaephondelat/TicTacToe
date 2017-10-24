namespace TicTacToe.ComputerTests.Strategies.StartingSecond.MainStrategy
{
    using System.Linq;
    using System.Reflection;
    using Computer.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using DataMockHelper;
    using Computer.Constants;
    using Computer.Strategies.StartingFirst.MainStrategy;
    using Computer.Strategies.MainStrategy.Checks.DiagonalsCheck;
    using Computer.Strategies.MainStrategy.Checks.PossibleWinCheck;
    using Computer.Strategies.StartingSecond.MainStrategy;
    using Computer.Strategies.MainStrategy.Checks.EdgesCheck;

    [TestClass]
    public class StartingSecondMainStrategyTests
    {
        private DataMockHelper dataLayerMockHelper;

        public StartingSecondMainStrategyTests()
        {
            this.dataLayerMockHelper = new DataMockHelper();
        }

        [TestMethod]
        public void StartingSecondMainStrategy_Should_Exist()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            StartingSecondMainStrategy strategy = new StartingSecondMainStrategy(model.Tiles, ComputerConstants.HomeSideSign);

            Assert.IsInstanceOfType(strategy, typeof(StartingSecondMainStrategy));
        }

        [TestMethod]
        public void StartingSecondMainStrategy_Should_Have_Protected_Method_Called_SetupChainOfResponsibility()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            StartingSecondMainStrategy strategy = new StartingSecondMainStrategy(model.Tiles, ComputerConstants.HomeSideSign);

            bool result = strategy.GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                                  .Any(m => m.Name == "SetupChainOfResponsibility");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void StartingSecondMainStrategy_SetupChainOfResponsibility_Method_Should_Not_Throw_Exception()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            StartingSecondMainStrategy strategy = new StartingSecondMainStrategy(model.Tiles, ComputerConstants.HomeSideSign);

            MethodInfo dynMethod = strategy.GetType()
                                           .GetMethod("SetupChainOfResponsibility", BindingFlags.Instance | BindingFlags.NonPublic);

            dynMethod.Invoke(strategy, new object[] { });

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void StartingSecondMainStrategy_SecondDiagonalCheck_Should_Have_EdgesCheck_As_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            StartingSecondMainStrategy strategy = new StartingSecondMainStrategy(model.Tiles, ComputerConstants.HomeSideSign);

            MethodInfo dynMethod = strategy.GetType()
                                           .GetMethod("SetupChainOfResponsibility", BindingFlags.Instance | BindingFlags.NonPublic);

            dynMethod.Invoke(strategy, new object[] { });

            var baseType = strategy.GetType().BaseType;

            var secondDiagonalCheck = baseType.GetField("secondDiagonalCheck", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(strategy);

            var secondDiagonal = secondDiagonalCheck as SecondDiagonalCheck;

            var successor = secondDiagonal.GetType().GetField("successor", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(secondDiagonal);

            Assert.IsTrue(successor is ClosestEdgeCheck);
        }
    }
}