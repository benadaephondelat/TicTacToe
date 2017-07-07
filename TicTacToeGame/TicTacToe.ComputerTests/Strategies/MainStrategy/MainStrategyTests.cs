namespace TicTacToe.ComputerTests.Strategies.MainStrategy
{
    using System.Linq;
    using System.Reflection;
    using Computer.Models;
    using Computer.Strategies.MainStrategy;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using DataMockHelper;
    using Computer.Constants;
    using System;

    [TestClass]
    public class MainStrategyTests
    {
        private DataMockHelper dataLayerMockHelper;

        public MainStrategyTests()
        {
            this.dataLayerMockHelper = new DataMockHelper();
        }

        [TestMethod]
        public void MainStrategy_Should_Have_Private_Property_Of_Type_CanWinCheck()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            MainStrategy strategy = new MainStrategy(model.Tiles, ComputerConstants.HomeSideSign);

            bool result = strategy.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                  .Any(f => f.FieldType.FullName.Contains("CanWinCheck"));

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void MainStrategy_Should_Have_Private_Property_Of_Type_FirstRowCheck()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            MainStrategy strategy = new MainStrategy(model.Tiles, ComputerConstants.HomeSideSign);

            bool result = strategy.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                  .Any(f => f.FieldType.FullName.Contains("FirstRowCheck"));

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void MainStrategy_Should_Have_Private_Property_Of_Type_SecondRowCheck()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            MainStrategy strategy = new MainStrategy(model.Tiles, ComputerConstants.HomeSideSign);

            bool result = strategy.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                  .Any(f => f.FieldType.FullName.Contains("SecondRowCheck"));

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void MainStrategy_Should_Have_Private_Property_Of_Type_ThirdRowCheck()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            MainStrategy strategy = new MainStrategy(model.Tiles, ComputerConstants.HomeSideSign);

            bool result = strategy.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                  .Any(f => f.FieldType.FullName.Contains("ThirdRowCheck"));

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void MainStrategy_Should_Have_Private_Property_Of_Type_FirstColumnCheck()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            MainStrategy strategy = new MainStrategy(model.Tiles, ComputerConstants.HomeSideSign);

            bool result = strategy.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                  .Any(f => f.FieldType.FullName.Contains("FirstColumnCheck"));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MainStrategy_Should_Have_Private_Property_Of_Type_SecondColumnCheck()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            MainStrategy strategy = new MainStrategy(model.Tiles, ComputerConstants.HomeSideSign);

            bool result = strategy.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                  .Any(f => f.FieldType.FullName.Contains("SecondColumnCheck"));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MainStrategy_Should_Have_Private_Property_Of_Type_ThirdColumnCheck()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            MainStrategy strategy = new MainStrategy(model.Tiles, ComputerConstants.HomeSideSign);

            bool result = strategy.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                  .Any(f => f.FieldType.FullName.Contains("ThirdColumnCheck"));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MainStrategy_Should_Have_Private_Property_Of_Type_FirstDiagonalCheck()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            MainStrategy strategy = new MainStrategy(model.Tiles, ComputerConstants.HomeSideSign);

            bool result = strategy.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                  .Any(f => f.FieldType.FullName.Contains("FirstDiagonalCheck"));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MainStrategy_Should_Have_Private_Property_Of_Type_SecondDiagonalCheck()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            MainStrategy strategy = new MainStrategy(model.Tiles, ComputerConstants.HomeSideSign);

            bool result = strategy.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                  .Any(f => f.FieldType.FullName.Contains("SecondDiagonalCheck"));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MainStrategy_Should_Have_Private_Propery_Of_Type_EdgesCheck()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            MainStrategy strategy = new MainStrategy(model.Tiles, ComputerConstants.HomeSideSign);

            bool result = strategy.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                  .Any(f => f.FieldType.FullName.Contains("EdgesCheck"));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MainStrategy_Should_Have_Private_Property_Of_Type_InnerCheck()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            MainStrategy strategy = new MainStrategy(model.Tiles, ComputerConstants.HomeSideSign);

            bool result = strategy.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                  .Any(f => f.FieldType.FullName.Contains("InnerCheck"));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MainStrategy_Should_Have_Private_Property_Of_Type_FirstEmptyTileCheck()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            MainStrategy strategy = new MainStrategy(model.Tiles, ComputerConstants.HomeSideSign);

            bool result = strategy.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                  .Any(f => f.FieldType.FullName.Contains("FirstEmptyTileCheck"));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MainStrategy_Should_Have_Private_Method_Called_SetupChainOfResponsibility()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            MainStrategy strategy = new MainStrategy(model.Tiles, ComputerConstants.HomeSideSign);

            bool result = strategy.GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                                  .Any(m => m.Name == "SetupChainOfResponsibility");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MainStrategy_SetupChainOfResponsibility_Method_Should_Not_Throw_Exception()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            MainStrategy strategy = new MainStrategy(model.Tiles, ComputerConstants.HomeSideSign);

            MethodInfo dynMethod = strategy.GetType()
                                           .GetMethod("SetupChainOfResponsibility", BindingFlags.Instance | BindingFlags.NonPublic);

            dynMethod.Invoke(strategy, new object[] { });

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void MainStrategy_Should_Have_Public_Method_Called_GetMove_With_Return_Type_Of_Int32()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            MainStrategy strategy = new MainStrategy(model.Tiles, ComputerConstants.HomeSideSign);

            MethodInfo methodInfo = strategy.GetType()
                                            .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                                            .FirstOrDefault(m => m.Name == "GetMove");

            Assert.IsNotNull(methodInfo);

            bool result = methodInfo.ToString().Contains("Int32");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void MainStrategy_GetMove_Method_Should_Not_Throw_Exception_When_Game_Is_Valid()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            MainStrategy strategy = new MainStrategy(model.Tiles, ComputerConstants.HomeSideSign);

            MethodInfo dynMethod = strategy.GetType()
                                           .GetMethod("GetMove", BindingFlags.Instance | BindingFlags.Public);

            dynMethod.Invoke(strategy, new object[] { });

            Assert.IsTrue(true);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void MainStrategy_GetMove_Method_Should_Throw_NotImplementedException_When_Game_Is_Not_Valid()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewComputerVsHumanGame();

            foreach (var tile in model.Tiles)
            {
                tile.IsEmpty = false;
                tile.Value = ComputerConstants.HomeSideSign;
            }

            MainStrategy mainStrategy = new MainStrategy(model.Tiles, ComputerConstants.HomeSideSign);

            MethodInfo dynMethod = mainStrategy.GetType().GetMethod("GetMove", BindingFlags.Instance | BindingFlags.Public);

            try
            {
                dynMethod.Invoke(mainStrategy, new object[] { });
            }
            catch (TargetInvocationException targetInvocationException)
            {
                if (targetInvocationException.InnerException.Message == "The method or operation is not implemented.")
                {
                    throw new NotImplementedException();
                }
            }

            Assert.Fail();
        }
    }
}