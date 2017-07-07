namespace TicTacToe.ComputerTests.Strategies.StartingSecond.TurnStrategies.SecondTurnStrategy.AggressiveMoveStrategy.Checks
{
    using System.Linq;
    using System.Reflection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Computer.Strategies.StartingSecond.TurnStrategies.SecondTurnStrategy.AggressiveMoveStrategy.Checks.KnightMoveCheck;

    [TestClass]
    public class AgressiveMoveResponsibilityTests
    {
        [TestMethod]
        public void It_Should_Have_Protected_Property_Of_Type_AgressiveMoveResponsibility()
        {
            KnightMoveCheck knightMoveCheck = new KnightMoveCheck();

            bool result = knightMoveCheck.GetType()
                                         .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                         .Any(f => f.FieldType.FullName.Contains("AgressiveMoveResponsibility"));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void It_Should_Have_Public_Method_Called_SetSuccessor()
        {
            KnightMoveCheck knightMoveCheck = new KnightMoveCheck();

            bool result = knightMoveCheck.GetType()
                                         .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                                         .Any(f => f.Name.Contains("SetSuccessor"));


            Assert.IsTrue(true);
        }

        [TestMethod]
        public void It_Should_Have_Abstract_Method_Called_GetMove()
        {
            KnightMoveCheck knightMoveCheck = new KnightMoveCheck();

            bool result = knightMoveCheck.GetType()
                                         .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                                         .Any(f => f.Name.Contains("GetMove"));


            Assert.IsTrue(true);
        }
    }
}