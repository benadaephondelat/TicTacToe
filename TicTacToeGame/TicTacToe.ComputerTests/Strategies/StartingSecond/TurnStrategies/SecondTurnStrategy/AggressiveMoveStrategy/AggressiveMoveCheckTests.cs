namespace TicTacToe.ComputerTests.Strategies.StartingSecond.TurnStrategies.SecondTurnStrategy.AggressiveMoveStrategy
{
    using System.Linq;
    using System.Reflection;

    using DataMockHelper;
    using TicTacToeCommon.Constants;

    using Computer.Models;
    using Computer.Constants;
    using Computer.Strategies.StartingSecond.TurnStrategies.SecondTurnStrategy.AggressiveMoveStrategy;
    using Computer.Strategies.StartingSecond.TurnStrategies.SecondTurnStrategy.AggressiveMoveStrategy.Checks.KnightMoveCheck;
    using Computer.Strategies.StartingSecond.TurnStrategies.SecondTurnStrategy.AggressiveMoveStrategy.Checks.RhombusMoveCheck;
    using Computer.Strategies.StartingSecond.TurnStrategies.SecondTurnStrategy.AggressiveMoveStrategy.Checks.TwoEdgesMoveCheck;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AggressiveMoveCheckTests
    {
        private DataMockHelper dataLayerMockHelper;

        public AggressiveMoveCheckTests()
        {
            this.dataLayerMockHelper = new DataMockHelper();
        }

        [TestMethod]
        public void It_Should_Have_Private_Property_Of_Type_KnightMoveCheck()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            AggressiveMoveCheck aggresiveMoveCheck = new AggressiveMoveCheck(model.Tiles);

            bool result = aggresiveMoveCheck.GetType()
                                            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                            .Any(f => f.FieldType.FullName.Contains("KnightMoveCheck"));

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void KnightMoveCheck_Successor_Should_Be_RhombusMoveCheck()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            this.SimulateNoneAggressiveMove(model);

            AggressiveMoveCheck aggresiveMoveCheck = new AggressiveMoveCheck(model.Tiles);

            int? move = aggresiveMoveCheck.GetMove();

            FieldInfo knightMoveCheckFieldInfo = aggresiveMoveCheck.GetType()
                                                          .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                                          .First(f => f.FieldType.FullName.Contains("KnightMoveCheck"));

            Assert.IsNotNull(knightMoveCheckFieldInfo, "A property of type KnightMoveCheck was not found");

            var knightMovePropertyCandidate = knightMoveCheckFieldInfo.GetValue(aggresiveMoveCheck);

            var knightMoveCheck = knightMovePropertyCandidate as KnightMoveCheck;

            Assert.IsNotNull(knightMoveCheck, "knightMoveProperty is not an instance of KnightMoveCheck");

            var parentClassProperty = knightMoveCheck.GetType()
                                                     .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                                     .First(f => f.FieldType.FullName.Contains("AgressiveMoveResponsibility"));

            var successor = parentClassProperty.GetValue(knightMoveCheck);

            Assert.IsTrue(successor is RhombusMoveCheck);
        }

        [TestMethod]
        public void It_Should_Have_Private_Property_Of_Type_RhombusMoveCheck()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            AggressiveMoveCheck aggresiveMoveCheck = new AggressiveMoveCheck(model.Tiles);

            bool result = aggresiveMoveCheck.GetType()
                                            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                            .Any(f => f.FieldType.FullName.Contains("RhombusMoveCheck"));

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void RhombusMoveCheck_Successor_Should_Be_TwoEdgesMoveCheck()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            this.SimulateNoneAggressiveMove(model);

            AggressiveMoveCheck aggresiveMoveCheck = new AggressiveMoveCheck(model.Tiles);

            int? move = aggresiveMoveCheck.GetMove();

            FieldInfo rhombusCheckFieldInfo = aggresiveMoveCheck.GetType()
                                                                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                                                .First(f => f.FieldType.FullName.Contains("RhombusMoveCheck"));

            Assert.IsNotNull(rhombusCheckFieldInfo, "A property of type RhombusMoveCheck was not found");

            var twoEdgesPropertyCandidate = rhombusCheckFieldInfo.GetValue(aggresiveMoveCheck);

            var rhombusMoveCheck = twoEdgesPropertyCandidate as RhombusMoveCheck;

            Assert.IsNotNull(rhombusMoveCheck, "rhombusMoveCheck is not an instance of RhombusMoveCheck");

            var parentClassProperty = rhombusMoveCheck.GetType()
                                                      .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                                      .First(f => f.FieldType.FullName.Contains("AgressiveMoveResponsibility"));

            var successor = parentClassProperty.GetValue(rhombusMoveCheck);

            Assert.IsTrue(successor is TwoEdgesMoveCheck);
        }

        [TestMethod]
        public void It_Should_Have_Private_Property_Of_Type_TwoEdgesMoveCheck()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            AggressiveMoveCheck aggresiveMoveCheck = new AggressiveMoveCheck(model.Tiles);

            bool result = aggresiveMoveCheck.GetType()
                                            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                            .Any(f => f.FieldType.FullName.Contains("TwoEdgesMoveCheck"));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TwoEdgesMoveCheck_Successor_Should_Be_Null()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            this.SimulateNoneAggressiveMove(model);

            AggressiveMoveCheck aggresiveMoveCheck = new AggressiveMoveCheck(model.Tiles);

            int? move = aggresiveMoveCheck.GetMove();

            FieldInfo twoEdgesCheckCheckFieldInfo = aggresiveMoveCheck.GetType()
                                                                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                                                .First(f => f.FieldType.FullName.Contains("TwoEdgesMoveCheck"));

            Assert.IsNotNull(twoEdgesCheckCheckFieldInfo, "A property of type TwoEdgesMoveCheck was not found");

            var twoEdgesPropertyCandidate = twoEdgesCheckCheckFieldInfo.GetValue(aggresiveMoveCheck);

            var twoEdgesCheck = twoEdgesPropertyCandidate as TwoEdgesMoveCheck;

            Assert.IsNotNull(twoEdgesCheck, "twoEdgesCheck is not an instance of TwoEdgesMoveCheck");

            var parentClassProperty = twoEdgesCheck.GetType()
                                                   .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                                   .First(f => f.FieldType.FullName.Contains("AgressiveMoveResponsibility"));

            var successor = parentClassProperty.GetValue(twoEdgesCheck);

            Assert.IsNull(successor);
        }

        [TestMethod]
        public void It_Should_Have_Protected_Property_Of_Type_IEnumerable_Of_ComputerGameTileModel()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            AggressiveMoveCheck aggresiveMoveCheck = new AggressiveMoveCheck(model.Tiles);

            bool result = aggresiveMoveCheck.GetType()
                                            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                            .Any(f => f.FieldType.FullName.Contains("IEnumerable") &&
                                                      f.FieldType.FullName.Contains("ComputerGameTileModel"));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void It_Should_Have_Private_Method_Called_SetupChainOfResponsibility()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            this.SimulateNoneAggressiveMove(model);

            AggressiveMoveCheck aggresiveMoveCheck = new AggressiveMoveCheck(model.Tiles);

            bool result = aggresiveMoveCheck.GetType()
                                            .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                                            .Any(f => f.Name.Contains("SetupChainOfResponsibility"));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SetupChainOfResponsibility_Should_Not_Throw_Exception_When_Invoked()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            this.SimulateNoneAggressiveMove(model);

            AggressiveMoveCheck aggresiveMoveCheck = new AggressiveMoveCheck(model.Tiles);

            aggresiveMoveCheck.GetType()
                              .GetMethod("SetupChainOfResponsibility", BindingFlags.Instance | BindingFlags.NonPublic)
                              .Invoke(aggresiveMoveCheck, new object[] { });

            Assert.IsTrue(true);
        }

        /// <summary>
        /// Knight Move Sanity Check
        /// </summary>
        [TestMethod]
        public void GetMove_Should_Return_BottomLeft_If_The_Oponent_Has_Placed_On_BottomMiddle_And_TopLeft_Tiles()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            //TODO use dataLayerMockHelper.SetTileValue()
            model.Tiles.ElementAt(TileConstants.BottomMiddleTile).IsEmpty = false;
            model.Tiles.ElementAt(TileConstants.BottomMiddleTile).Value = ComputerConstants.HomeSideSign;

            model.Tiles.ElementAt(TileConstants.MiddleMiddleTile).IsEmpty = false;
            model.Tiles.ElementAt(TileConstants.MiddleMiddleTile).Value = ComputerConstants.AwaySideSign;

            model.Tiles.ElementAt(TileConstants.TopLeftTile).IsEmpty = false;
            model.Tiles.ElementAt(TileConstants.TopLeftTile).Value = ComputerConstants.HomeSideSign;

            AggressiveMoveCheck aggresiveMoveCheck = new AggressiveMoveCheck(model.Tiles);

            MethodInfo getMove = aggresiveMoveCheck.GetType()
                                                   .GetMethod("GetMove", BindingFlags.Instance | BindingFlags.Public);

            object actualResult = getMove.Invoke(aggresiveMoveCheck, new object[] { });

            Assert.IsTrue(actualResult is int, "GetMove() result should be in");

            int result = int.Parse(actualResult.ToString());

            Assert.AreEqual(TileConstants.BottomLeftTile, result);
        }

        /// <summary>
        /// Rhombus Move Sanity Check
        /// </summary>
        [TestMethod]
        public void GetMove_Should_Return_TopLeft_Tile_If_The_Oponent_Has_Placed_On_TopMiddle_And_MiddleLeft_Tiles()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            model.Tiles.ElementAt(TileConstants.TopMiddleTile).IsEmpty = false;
            model.Tiles.ElementAt(TileConstants.TopMiddleTile).Value = ComputerConstants.HomeSideSign;

            model.Tiles.ElementAt(TileConstants.MiddleMiddleTile).IsEmpty = false;
            model.Tiles.ElementAt(TileConstants.MiddleMiddleTile).Value = ComputerConstants.AwaySideSign;

            model.Tiles.ElementAt(TileConstants.MiddleLeftTile).IsEmpty = false;
            model.Tiles.ElementAt(TileConstants.MiddleLeftTile).Value = ComputerConstants.HomeSideSign;

            AggressiveMoveCheck aggresiveMoveCheck = new AggressiveMoveCheck(model.Tiles);

            MethodInfo getMove = aggresiveMoveCheck.GetType()
                                                   .GetMethod("GetMove", BindingFlags.Instance | BindingFlags.Public);

            object actualResult = getMove.Invoke(aggresiveMoveCheck, new object[] { });

            Assert.IsTrue(actualResult is int, "GetMove() result should be in");

            int result = int.Parse(actualResult.ToString());

            Assert.AreEqual(TileConstants.TopLeftTile, result);
        }

        /// <summary>
        /// Two Edges Move Sanity Check
        /// </summary>
        [TestMethod]
        public void GetMove_Should_Return_MiddleLeft_Tile_If_The_Oponent_Has_Placed_On_TopLeft_And_BottomLeft_Tiles()
        {
            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            model.Tiles.ElementAt(TileConstants.TopLeftTile).IsEmpty = false;
            model.Tiles.ElementAt(TileConstants.TopLeftTile).Value = ComputerConstants.HomeSideSign;

            model.Tiles.ElementAt(TileConstants.MiddleMiddleTile).IsEmpty = false;
            model.Tiles.ElementAt(TileConstants.MiddleMiddleTile).Value = ComputerConstants.AwaySideSign;

            model.Tiles.ElementAt(TileConstants.BottomLeftTile).IsEmpty = false;
            model.Tiles.ElementAt(TileConstants.BottomLeftTile).Value = ComputerConstants.HomeSideSign;

            AggressiveMoveCheck aggresiveMoveCheck = new AggressiveMoveCheck(model.Tiles);

            MethodInfo getMove = aggresiveMoveCheck.GetType()
                                                   .GetMethod("GetMove", BindingFlags.Instance | BindingFlags.Public);

            object actualResult = getMove.Invoke(aggresiveMoveCheck, new object[] { });

            Assert.IsTrue(actualResult is int, "GetMove() result should be in");

            int result = int.Parse(actualResult.ToString());

            Assert.AreEqual(TileConstants.MiddleLeftTile, result);
        }

        [TestMethod]
        public void GetMove_Should_Return_Null_If_The_Oponent_Has_Not_Made_An_Aggressive_Move()
        {
            string methodName = "GetMove";

            ComputerGameModel model = this.dataLayerMockHelper.CreateNewHumanVsComputerGame();

            this.SimulateNoneAggressiveMove(model);

            AggressiveMoveCheck aggresiveMoveCheck = new AggressiveMoveCheck(model.Tiles);

            MethodInfo result = aggresiveMoveCheck.GetType()
                                                  .GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public);

            object actualResult = result.Invoke(aggresiveMoveCheck, new object[] { });

            Assert.IsNull(actualResult);
        }

        private void SimulateNoneAggressiveMove(ComputerGameModel model)
        {
            model.TurnsCount = 4;

            model.Tiles.ElementAt(TileConstants.TopLeftTile).Value = ComputerConstants.HomeSideSign;
            model.Tiles.ElementAt(TileConstants.TopLeftTile).IsEmpty = false;

            model.Tiles.ElementAt(TileConstants.MiddleMiddleTile).Value = ComputerConstants.AwaySideSign;
            model.Tiles.ElementAt(TileConstants.MiddleMiddleTile).IsEmpty = false;

            model.Tiles.ElementAt(TileConstants.TopMiddleTile).Value = ComputerConstants.HomeSideSign;
            model.Tiles.ElementAt(TileConstants.TopMiddleTile).IsEmpty = false;
        }
    }
}