namespace TicTacToe.ComputerTests.Strategies.StartingFirst
{
    using System.Reflection;
    using Computer;
    using Computer.Models;
    using TicTacToeCommon.Exceptions.Game;
    using Computer.Strategies.MainStrategy;
    using Computer.Strategies.StartingFirst;
    using Computer.Strategies.StartingFirst.TurnStrategies.FirstTurnStrategy;
    using Computer.Strategies.StartingFirst.TurnStrategies.SecondTurnStrategy;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using DataMockHelper;

    [TestClass]
    public class StartingFirstStrategyTests
    {
        private DataMockHelper dataLayerMockHelper;

        public StartingFirstStrategyTests()
        {
            this.dataLayerMockHelper = new DataMockHelper();
        }

        [TestMethod]
        public void StartingFirstComputerStrategy_Should_Choose_FirstTurnStrategy_If_The_Game_Turns_Count_Equals_1()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            StartingFirstComputerStrategy strat = new StartingFirstComputerStrategy(model);
            
            MethodInfo chooseTurnStrategyMethod = strat.GetType().GetMethod("ChooseTurnStrategy", BindingFlags.NonPublic | BindingFlags.Instance);

            var returnResult = chooseTurnStrategyMethod.Invoke(strat, null);

            Assert.IsTrue(returnResult is FirstTurnStrategy);
        }

        [TestMethod]
        public void StartingFirstComputerStrategy_Should_Choose_SecondTurnStrategy_If_The_Game_Turns_Count_Equals_3()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            model.TurnsCount = 3;

            StartingFirstComputerStrategy strat = new StartingFirstComputerStrategy(model);

            MethodInfo chooseTurnStrategyMethod = strat.GetType().GetMethod("ChooseTurnStrategy", BindingFlags.NonPublic | BindingFlags.Instance);

            var returnResult = chooseTurnStrategyMethod.Invoke(strat, null);

            Assert.IsTrue(returnResult is SecondTurnStrategy);
        }

        [TestMethod]
        public void StartingFirstComputerStrategy_Should_Choose_MainStrategy_If_The_Game_Turns_Count_Equals_5()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            model.TurnsCount = 5;

            StartingFirstComputerStrategy strat = new StartingFirstComputerStrategy(model);

            MethodInfo chooseTurnStrategyMethod = strat.GetType().GetMethod("ChooseTurnStrategy", BindingFlags.NonPublic | BindingFlags.Instance);

            var returnResult = chooseTurnStrategyMethod.Invoke(strat, null);

            Assert.IsTrue(returnResult is MainStrategy);
        }

        [TestMethod]
        public void StartingFirstComputerStrategy_Should_Choose_MainStrategy_If_The_Game_Turns_Count_Equals_7()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            model.TurnsCount = 7;

            StartingFirstComputerStrategy strat = new StartingFirstComputerStrategy(model);

            MethodInfo chooseTurnStrategyMethod = strat.GetType().GetMethod("ChooseTurnStrategy", BindingFlags.NonPublic | BindingFlags.Instance);

            var returnResult = chooseTurnStrategyMethod.Invoke(strat, null);

            Assert.IsTrue(returnResult is MainStrategy);
        }

        [TestMethod]
        public void StartingFirstComputerStrategy_Should_Choose_MainStrategy_If_The_Game_Turns_Count_Equals_9()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            model.TurnsCount = 9;

            StartingFirstComputerStrategy strat = new StartingFirstComputerStrategy(model);

            MethodInfo chooseTurnStrategyMethod = strat.GetType().GetMethod("ChooseTurnStrategy", BindingFlags.NonPublic | BindingFlags.Instance);

            var returnResult = chooseTurnStrategyMethod.Invoke(strat, null);

            Assert.IsTrue(returnResult is MainStrategy);
        }
    }
}