namespace TicTacToe.ComputerMinMax.Tests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ComputerTests.DataMockHelper;
    using Computer.Models;
    using ComputerMinMax;
    using TicTacToeCommon.Exceptions.Computer;

    [TestClass]
    public class MinMaxComputerTests
    {
        private DataMockHelper dataLayerMockHelper;

        public MinMaxComputerTests()
        {
            this.dataLayerMockHelper = new DataMockHelper();
        }
        
        [TestMethod]
        public void MinMaxComputer_Should_Have_Public_Method_Named_GetComputerMoveIndex()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            MinMaxComputer computer = new MinMaxComputer();

            bool result = computer.GetType()
                                  .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                                  .Any(m => m.Name == "GetComputerMoveIndex");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MinMaxComputer_GetComputerMoveIndex_Should_Return_Valid_Int_If_Model_Is_Valid()
        {
            try
            {
                ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

                MinMaxComputer computer = new MinMaxComputer();

                int computerMove = computer.GetComputerMoveIndex(model);
            }
            catch
            {
                Assert.Fail();
            }

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void MinMaxComputer_GetComputerMoveIndex_Method_Should_Return_Int32()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            MinMaxComputer computer = new MinMaxComputer();

            Type computerType = computer.GetType();

            MethodInfo method = computerType.GetTypeInfo()
                                            .DeclaredMethods.FirstOrDefault(m => m.Name == "GetComputerMoveIndex");

            Assert.IsNotNull(method);

            Assert.IsTrue(method.ToString().Contains("Int32"));
        }

        [TestMethod]
        public void MinMaxComputer_Should_Have_Private_Method_Named_GetComputerMove()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            MinMaxComputer computer = new MinMaxComputer();

            bool result = computer.GetType()
                                  .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                                  .Any(m => m.Name == "GetComputerMove");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MinMaxComputer_GetComputerMove_Method_Should_Return_Int32()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            MinMaxComputer computer = new MinMaxComputer();

            Type computerType = computer.GetType();

            MethodInfo method = computerType.GetTypeInfo().DeclaredMethods
                                            .FirstOrDefault(m => m.Name == "GetComputerMove");

            Assert.IsNotNull(method);

            Assert.IsTrue(method.ToString().Contains("Int32"));
        }

        [TestMethod]
        public void MinMaxComputer_Should_Have_Private_Method_Named_ValidateGame()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            MinMaxComputer computer = new MinMaxComputer();

            bool result = computer.GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                                            .Any(m => m.Name == "ValidateGame");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MinMaxComputer_ValidateGame_Method_Return_Type_Should_Be_Void()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            MinMaxComputer computer = new MinMaxComputer();

            Type computerType = computer.GetType();

            var method = computerType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                                     .FirstOrDefault(m => m.Name == "ValidateGame");

            Assert.IsNotNull(method);

            string returnTypeName = method.ReturnType.FullName;

            bool result = returnTypeName.ToLower().Contains("void");

            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ComputerException))]
        public void MinMaxComputer_ValidateGame_Method_Should_Throw_ComputerException_If_Game_Is_Finished()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            model.IsFinished = true;

            MinMaxComputer computer = new MinMaxComputer();

            computer.GetComputerMoveIndex(model);
        }

        [TestMethod]
        [ExpectedException(typeof(ComputerException))]
        public void MinMaxComputer_GetComputerMoveIndex_Should_Throw_ComputerException_If_All_Tiles_Are_Taken()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            var takenTiles = this.dataLayerMockHelper.GenerateDefaultTilesList();

            takenTiles.ForEach(x => { x.Value = "X"; x.IsEmpty = false; });

            model.Tiles = takenTiles;

            MinMaxComputer computer = new MinMaxComputer();

            computer.GetComputerMoveIndex(model);
        }
    }
}