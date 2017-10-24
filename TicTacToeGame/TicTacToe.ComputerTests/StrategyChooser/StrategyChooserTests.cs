namespace TicTacToe.ComputerTests.StrategyChooser
{
    using Computer.Models;
    using Computer.Strategies;
    using Computer.Strategies.StartingFirst;
    using Computer.Strategies.StartingSecond;
    using Computer.StrategyChooser;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using DataMockHelper;

    [TestClass]
    public class StrategyChooserTests
    {
        private DataMockHelper dataLayerMockHelper;

        public StrategyChooserTests()
        {
            this.dataLayerMockHelper = new DataMockHelper();
        }

        [TestMethod]
        public void StrategyChooser_If_Game_Turns_Count_Is_Odd_Number_Choose_StartingFirstStrategy()
        {
            ComputerGameModel game = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            game.TurnsCount = 1;

            StrategyChooser strategyChooser = new StrategyChooser();

            ComputerStrategy strategy = strategyChooser.GetComputerStrategy(game);

            Assert.IsTrue(strategy is StartingFirstComputerStrategy);
        }

        [TestMethod]
        public void StrategyChooser_If_Game_Turns_Count_Is_Even_Number_Choose_StartingSecondStrategy()
        {
            ComputerGameModel game = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            game.TurnsCount = 2;

            StrategyChooser strategyChooser = new StrategyChooser();

            ComputerStrategy strategy = strategyChooser.GetComputerStrategy(game);

            Assert.IsTrue(strategy is StartingSecondComputerStrategy);
        }
    }
}