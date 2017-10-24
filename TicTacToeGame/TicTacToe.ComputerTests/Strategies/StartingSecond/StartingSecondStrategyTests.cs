namespace TicTacToe.ComputerTests.Strategies.StartingSecond
{
    using System.Reflection;
    using DataMockHelper;
    using Computer;
    using Computer.Models;
    using Computer.Strategies.StartingSecond;
    using Computer.Strategies.MainStrategy;
    using Computer.Strategies.StartingSecond.TurnStrategies.FirstTurnStrategy;
    using Computer.Strategies.StartingSecond.TurnStrategies.SecondTurnStrategy;
    using TicTacToeCommon.Exceptions.Game;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Computer.Strategies.StartingSecond.MainStrategy;

    [TestClass]
    public class StartingSecondStrategyTests
    {
        private DataMockHelper dataLayerMockHelper;

        public StartingSecondStrategyTests()
        {
            this.dataLayerMockHelper = new DataMockHelper();
        }

        [TestMethod]
        public void StartingSecondStrategy_Should_Choose_FirstTurnStrategy_If_The_Game_Turns_Count_Equals_2()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            model.TurnsCount = 2;

            StartingSecondComputerStrategy strat = new StartingSecondComputerStrategy(model);

            MethodInfo chooseTurnStrategyMethod = strat.GetType()
                                                       .GetMethod("ChooseTurnStrategy", BindingFlags.NonPublic | BindingFlags.Instance);

            var returnResult = chooseTurnStrategyMethod.Invoke(strat, new object[] { });

            Assert.IsTrue(returnResult is FirstTurnStrategy);
        }

        [TestMethod]
        public void StartingSecondStrategy_Should_Choose_SecondTurnStrategy_If_The_Game_Turns_Count_Equals_4()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            model.TurnsCount = 4;

            StartingSecondComputerStrategy strat = new StartingSecondComputerStrategy(model);

            MethodInfo chooseTurnStrategyMethod = strat.GetType()
                                                       .GetMethod("ChooseTurnStrategy", BindingFlags.NonPublic | BindingFlags.Instance);

            var returnResult = chooseTurnStrategyMethod.Invoke(strat, new object[] { });

            Assert.IsTrue(returnResult is SecondTurnStrategy);
        }

        [TestMethod]
        public void StartingSecondStrategy_Should_Choose_StartingSecondMainStrategy_If_The_Game_Turns_Count_Equals_6_8_Or_10()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            int turnsCount = 6;

            for (int i = 0; i < 3; i++, turnsCount += 2)
            {
                model.TurnsCount = turnsCount;

                StartingSecondComputerStrategy strat = new StartingSecondComputerStrategy(model);

                MethodInfo chooseTurnStrategyMethod = strat.GetType()
                                                           .GetMethod("ChooseTurnStrategy", BindingFlags.NonPublic | BindingFlags.Instance);

                var returnResult = chooseTurnStrategyMethod.Invoke(strat, new object[] { });

                Assert.IsTrue(returnResult is StartingSecondMainStrategy, "First Failed at Turns Count = " + turnsCount);
            }
        }
    }
}