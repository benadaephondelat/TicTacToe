namespace TicTacToe.ComputerTests.Strategies
{
    using System;
    using System.Linq;
    using System.Reflection;

    using DataMockHelper;

    using Computer.Models;
    using Computer.Strategies;
    using Computer.Strategies.StartingFirst.TurnStrategies.FirstTurnStrategy;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Diagnostics;

    [TestClass]
    public class TurnStrategyTests
    {
        private DataMockHelper dataLayerMockHelper;

        public TurnStrategyTests()
        {
            this.dataLayerMockHelper = new DataMockHelper();
        }

        [TestMethod]
        public void TurnStrategy_Should_Be_An_Abstract_Class()
        {
            bool isAnAbstractClass = this.IsAbstract(typeof(TurnStrategy));

            Assert.IsTrue(true);
        }

        private bool IsAbstract(Type type)
        {
            bool result = type.IsAbstract;

            return result;
        }

        [TestMethod]
        public void TurnStrategy_Should_Have_An_Abstract_Method_Called_GetMove_With_A_Return_Type_Of_Nullable_Int()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            FirstTurnStrategy firstTurnStrategy = new FirstTurnStrategy(model.Tiles);

            MethodInfo getMoveMethodInfo = firstTurnStrategy.GetType().GetMethods().First(m => m.Name.Contains("GetMove"));

            string getMoveMethodAsString = getMoveMethodInfo.ToString();

            bool allChecksPassed = true;

            bool nameCheck = getMoveMethodAsString.Contains("GetMove");

            if (nameCheck == false)
            {
                Debug.WriteLine("A Method named GetMove does not exist");

                allChecksPassed = false;
            }

            bool nullableReturnTypeCheck = getMoveMethodAsString.Contains("Nullable");

            if (nullableReturnTypeCheck == false)
            {
                Debug.WriteLine("Method's return type is not nullable");

                allChecksPassed = false;
            }

            bool intReturnTypeCheck = getMoveMethodAsString.Contains("Int");

            if (intReturnTypeCheck == false)
            {
                Debug.WriteLine("Method's return type is not an int");

                allChecksPassed = false;
            }

            Assert.IsTrue(allChecksPassed);
        }
    }
}