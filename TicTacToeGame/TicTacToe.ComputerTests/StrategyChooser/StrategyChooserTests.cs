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
        public void StrategyChooser_If_Computer_Is_Starting_First_Choose_StartingFirstStrategy()
        {
            ComputerGameModel game = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            StrategyChooser strategyChooser = new StrategyChooser();

            ComputerStrategy strategy = strategyChooser.GetComputerStrategy(game);

            Assert.IsTrue(strategy is StartingFirstComputerStrategy);
        }

        [TestMethod]
        public void StrategyChooser_If_Computer_Is_Starting_Second_Choose_StartingSecondStrategy()
        {
            ComputerGameModel game = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            StrategyChooser strategyChooser = new StrategyChooser();

            ComputerStrategy strategy = strategyChooser.GetComputerStrategy(game);

            Assert.IsTrue(strategy is StartingSecondComputerStrategy);
        }
    }
}