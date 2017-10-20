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
    }
}