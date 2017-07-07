namespace TicTacToe.ComputerTests
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Computer;
    using Computer.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ComputerTests
    {
        private DataMockHelper.DataMockHelper dataLayerMockHelper;

        public ComputerTests()
        {
            this.dataLayerMockHelper = new DataMockHelper.DataMockHelper();
        }

        [TestMethod]
        public void Computer_Should_Have_Private_Property_Of_ComputerStrategy_Type()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            Computer computer = new Computer();

            bool result = computer.GetType()
                                  .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                  .Any(f => f.FieldType.FullName.Contains("ComputerStrategy"));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Computer_Should_Have_Public_Method_Named_GetComputerMove()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            Computer computer = new Computer();

            bool result = computer.GetType()
                                  .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                                  .Any(m => m.Name == "GetComputerMoveIndex");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Computer_GetComputerMove_Method_Should_Return_Int32()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            Computer computer = new Computer();

            Type controllerType = computer.GetType();

            MethodInfo method = controllerType.GetTypeInfo().DeclaredMethods.FirstOrDefault(m => m.Name == "GetComputerMoveIndex");

            Assert.IsNotNull(method);

            Assert.IsTrue(method.ToString().Contains("Int32"));
        }
    }
}