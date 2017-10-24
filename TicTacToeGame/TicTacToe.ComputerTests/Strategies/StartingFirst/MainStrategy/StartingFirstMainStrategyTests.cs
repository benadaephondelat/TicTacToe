namespace TicTacToe.ComputerTests.Strategies.StartingFirst.MainStrategy
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

    [TestClass]
    public class StartingFirstMainStrategyTests
    {
        private DataMockHelper dataLayerMockHelper;

        public StartingFirstMainStrategyTests()
        {
            this.dataLayerMockHelper = new DataMockHelper();
        }

        [TestMethod]
        public void StartingFirstMainStrategy_Should_Exist()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            StartingFirstMainStrategy strategy = new StartingFirstMainStrategy(model.Tiles, ComputerConstants.HomeSideSign);

            Assert.IsInstanceOfType(strategy, typeof(StartingFirstMainStrategy));
        }

        [TestMethod]
        public void StartingFirstMainStrategy_Should_Have_Protected_Method_Called_SetupChainOfResponsibility()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            StartingFirstMainStrategy strategy = new StartingFirstMainStrategy(model.Tiles, ComputerConstants.HomeSideSign);

            bool result = strategy.GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                                  .Any(m => m.Name == "SetupChainOfResponsibility");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void StartingFirstMainStrategy_SetupChainOfResponsibility_Method_Should_Not_Throw_Exception()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            StartingFirstMainStrategy strategy = new StartingFirstMainStrategy(model.Tiles, ComputerConstants.HomeSideSign);

            MethodInfo dynMethod = strategy.GetType()
                                           .GetMethod("SetupChainOfResponsibility", BindingFlags.Instance | BindingFlags.NonPublic);

            dynMethod.Invoke(strategy, new object[] { });

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void StartingFirstMainStrategy_SecondDiagonalCheck_Should_Have_PossibleWinCheck_As_Successor()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            StartingFirstMainStrategy strategy = new StartingFirstMainStrategy(model.Tiles, ComputerConstants.HomeSideSign);

            MethodInfo dynMethod = strategy.GetType()
                                           .GetMethod("SetupChainOfResponsibility", BindingFlags.Instance | BindingFlags.NonPublic);

            dynMethod.Invoke(strategy, new object[] { });

            var baseType = strategy.GetType().BaseType;

            var secondDiagonalCheck = baseType.GetField("secondDiagonalCheck", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(strategy);

            var secondDiagonal = secondDiagonalCheck as SecondDiagonalCheck;

            var successor = secondDiagonal.GetType().GetField("successor", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(secondDiagonal);

            Assert.IsTrue(successor is PossibleWinCheck);
        }
    }
}