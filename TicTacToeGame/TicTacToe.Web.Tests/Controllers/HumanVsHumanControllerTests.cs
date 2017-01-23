namespace TicTacToe.Web.Tests.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Reflection;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MockHelpers;
    using Web.Controllers;
    using Web.Controllers.Constants;
    using ServiceLayer.TicTacToeGameService;
    using Moq;
    using Models.Game.ViewModels;
    using Constants;
    using Models.Game.InputModels;
    using Models.HumanVsHuman.PlaceTurn.InputModels;

    [TestClass]
    public class HumanVsHumanControllerTests
    {
        private ServiceLayerMockHelper mockHelper;

        [TestInitialize]
        public void Setup()
        {
            this.mockHelper = new ServiceLayerMockHelper();
        }

        #region Controller Tests

        [TestMethod]
        public void HumanVsHuman_Controller_Should_Exist()
        {
            HumanVsHumanController controller = this.CreateHumanVsHumanControllerMock();

            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void HumanVsHuman_Controller_Should_Have_Empty_Constructor()
        {
            HumanVsHumanController controller = new HumanVsHumanController();

            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void HumanVsHuman_Controller_Should_Have_Private_Property_Named_TicTacToeGameService()
        {
            HumanVsHumanController controller = this.CreateHumanVsHumanControllerMock();

            bool result = controller.GetType()
                                    .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                                    .Any(field => field.Name == "ticTacToeGameService");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void HumanVsHuman_Controller_Should_Have_Private_Method_Named_CurrentUserName()
        {
            HumanVsHumanController controller = this.CreateHumanVsHumanControllerMock();

            bool result = controller.GetType()
                                    .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                                    .Any(field => field.Name == "CurrentUserName");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void HumanVsHuman_Controller_Should_Have_Public_Property_Named_GetCurrentUserName()
        {
            HumanVsHumanController controller = this.CreateHumanVsHumanControllerMock();

            bool result = controller.GetType()
                                    .GetFields(BindingFlags.Instance | BindingFlags.Public)
                                    .Any(field => field.Name == "GetCurrentUserName");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void HumanVsHuman_Controller_Should_Have_PrivateMethod_Named_CurrentUserName()
        {
            var privateObject = new PrivateObject(this.CreateHumanVsHumanControllerMock());

            var result = (string)privateObject.Invoke("CurrentUserName");

            Assert.IsNull(result);
        }
        
        #endregion

        #region NewGame Tests

        [TestMethod]
        public void NewGame_Action_Should_Exist()
        {
            HumanVsHumanController controller = this.CreateHumanVsHumanControllerMock();

            Assert.AreEqual("NewGame", nameof(controller.NewGame));

            ActionResult newGameAsActionResult = controller.NewGame();

            Assert.IsNotNull(newGameAsActionResult);
        }

        [TestMethod]
        public void NewGame_Should_Return_View()
        {
            HumanVsHumanController controller = this.CreateHumanVsHumanControllerMock();

            ActionResult actionResult = controller.NewGame();

            Assert.IsInstanceOfType(actionResult, typeof(ViewResult));
        }

        [TestMethod]
        public void NewGame_Should_Return_View_Named_NewGame()
        {
            HumanVsHumanController controller = this.CreateHumanVsHumanControllerMock();

            ActionResult actionResult = controller.NewGame();

            ViewResult result = actionResult as ViewResult;

            Assert.IsNotNull(result);

            string expectedPartialViewName = "NewGame";

            Assert.AreEqual(expectedPartialViewName, result.ViewName);
        }

        [TestMethod]
        public void NewGame_Should_Pass_NewHumanVsHumanGameInputModel_To_The_View()
        {
            HumanVsHumanController controller = this.CreateHumanVsHumanControllerMock();

            ActionResult actionResult = controller.NewGame();

            ViewResult result = actionResult as ViewResult;

            Assert.IsNotNull(result);

            NewHumanVsHumanGameInputModel model = (NewHumanVsHumanGameInputModel)result.ViewData.Model;

            Assert.IsInstanceOfType(model, typeof(NewHumanVsHumanGameInputModel));
        }

        [TestMethod]
        public void NewHumanVsHumanGameInputModel_Should_Have_Property_Named_Players()
        {
            HumanVsHumanController controller = this.CreateHumanVsHumanControllerMock();

            ActionResult actionResult = controller.NewGame();

            ViewResult result = actionResult as ViewResult;

            Assert.IsNotNull(result);

            NewHumanVsHumanGameInputModel model = result.ViewData.Model as NewHumanVsHumanGameInputModel;

            Assert.IsNotNull(model);

            Assert.IsNotNull(model.Players);
        }

        [TestMethod]
        public void NewGameInputModel_Players_Property_Should_Be_A_List_Of_Strings()
        {
            HumanVsHumanController controller = this.CreateHumanVsHumanControllerMock();

            ActionResult actionResult = controller.NewGame();

            ViewResult result = actionResult as ViewResult;

            Assert.IsNotNull(result);

            NewHumanVsHumanGameInputModel model = (NewHumanVsHumanGameInputModel)result.ViewData.Model;

            Assert.IsInstanceOfType(model.Players, typeof(List<string>));
        }

        [TestMethod]
        public void NewGameInputModel_Players_Property_Should_Be_A_List_With_Two_Strings()
        {
            HumanVsHumanController controller = this.CreateHumanVsHumanControllerMock();

            ActionResult actionResult = controller.NewGame();

            ViewResult result = actionResult as ViewResult;

            Assert.IsNotNull(result);

            NewHumanVsHumanGameInputModel model = (NewHumanVsHumanGameInputModel)result.ViewData.Model;

            Assert.AreEqual(2, model.Players.Count);
        }

        [TestMethod]
        public void NewGameInputModel_Players_Property_Should_Contain_Valid_String_As_First_Parameter()
        {
            HumanVsHumanController controller = this.CreateHumanVsHumanControllerMock();

            ActionResult actionResult = controller.NewGame();

            ViewResult result = actionResult as ViewResult;

            Assert.IsNotNull(result);

            NewHumanVsHumanGameInputModel model = (NewHumanVsHumanGameInputModel)result.ViewData.Model;

            bool isNotValidString = string.IsNullOrWhiteSpace(model.Players[0]);

            Assert.IsFalse(isNotValidString);
        }

        [TestMethod]
        public void NewGameInputModel_Players_Property_Should_Contain_The_Default_HumanVsHuman_Oponent_Username_As_Second_Parameter()
        {
            HumanVsHumanController controller = this.CreateHumanVsHumanControllerMock();

            ActionResult actionResult = controller.NewGame();

            ViewResult result = actionResult as ViewResult;

            Assert.IsNotNull(result);

            NewHumanVsHumanGameInputModel model = (NewHumanVsHumanGameInputModel)result.ViewData.Model;

            Assert.AreEqual("the-other-guy@yahoo.com", model.Players[1]);
        }

        [TestMethod]
        public void NewGame_Post_Should_Exist_And_Accept_NewHumanVsHumanGameInputModel_As_A_Parameter()
        {
            HumanVsHumanController controller = this.CreateHumanVsHumanControllerMock();

            Type controllerType = controller.GetType();

            int methodsCount = controllerType.GetTypeInfo()
                                             .DeclaredMethods
                                             .Count(m => m.Name.Contains(nameof(controller.NewGame)) &&
                                                         m.ToString().Contains(nameof(NewHumanVsHumanGameInputModel)));

            Assert.AreEqual(1, methodsCount);
        }

        [TestMethod]
        public void NewGame_Post_Should_Return_PartialView()
        {
            HumanVsHumanController controller = this.CreateHumanVsHumanControllerMock();

            NewHumanVsHumanGameInputModel model = new NewHumanVsHumanGameInputModel()
            {
                Players = new List<string>()
                {
                    HumanVsHumanConstants.HumanVsHumanOponentUserId,
                }
            };

            ActionResult actionResult = controller.NewGame(model);

            Assert.IsInstanceOfType(actionResult, typeof(PartialViewResult));
        }

        [TestMethod]
        public void NewGame_Post_Should_Return_PartialView_Named__HumanVsHumanGame()
        {
            HumanVsHumanController controller = this.CreateHumanVsHumanControllerMock();

            NewHumanVsHumanGameInputModel model = new NewHumanVsHumanGameInputModel();

            model.Players = new List<string>()
            {
                HumanVsHumanConstants.HumanVsHumanOponentUserId,
            };

            ActionResult actionResult = controller.NewGame(model);
            
            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            string actualPartialViewName = partialViewResult.ViewName;

            Assert.AreEqual("_HumanVsHumanGame", actualPartialViewName);
        }

        [TestMethod]
        public void NewGame_Post_Should_Return_HumanVsHumanGameViewModel_As_Model_To_The_View()
        {
            HumanVsHumanController controller = this.CreateHumanVsHumanControllerMock();

            NewHumanVsHumanGameInputModel model = new NewHumanVsHumanGameInputModel();

            model.Players = new List<string>()
            {
                HumanVsHumanConstants.HumanVsHumanOponentUserId,
            };

            ActionResult actionResult = controller.NewGame(model);

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            bool isCastValidCast = partialViewResult.Model is HumanVsHumanGameViewModel;

            Assert.IsTrue(isCastValidCast);
        }

        [TestMethod]
        public void NewGame_Post_HumanVsHumanGameViewModel_Properties_Should_Not_Be_Null()
        {
            HumanVsHumanController controller = this.CreateHumanVsHumanControllerMock();

            NewHumanVsHumanGameInputModel model = new NewHumanVsHumanGameInputModel();

            model.Players = new List<string>()
            {
                HumanVsHumanConstants.HumanVsHumanOponentUserId,
            };

            ActionResult actionResult = controller.NewGame(model);

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            HumanVsHumanGameViewModel result = partialViewResult.Model as HumanVsHumanGameViewModel;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.GameInfo);
            Assert.IsNotNull(result.GameTiles);
        }

        [TestMethod]
        public void NewGame_Post_HumanVsHumanGameViewModel_Should_Contain_9_Empty_Tiles()
        {
            HumanVsHumanController controller = this.CreateHumanVsHumanControllerMock();

            NewHumanVsHumanGameInputModel model = new NewHumanVsHumanGameInputModel();

            model.Players = new List<string>()
            {
                HumanVsHumanConstants.HumanVsHumanOponentUserId,
            };

            ActionResult actionResult = controller.NewGame(model);

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            HumanVsHumanGameViewModel result = partialViewResult.Model as HumanVsHumanGameViewModel;

            Assert.IsNotNull(result);

            Assert.AreEqual(9, result.GameTiles.Count());
            Assert.AreEqual(9, result.GameTiles.Count(t => t.IsEmpty));
        }

        [TestMethod]
        public void NewGame_Post_HumanVsHumanGameViewModel_Every_Tile_Should_Be_Empty()
        {
            HumanVsHumanController controller = this.CreateHumanVsHumanControllerMock();

            NewHumanVsHumanGameInputModel model = new NewHumanVsHumanGameInputModel
            {
                Players = new List<string>()
                {
                    HumanVsHumanConstants.HumanVsHumanOponentUserId,
                }
            };

            ActionResult actionResult = controller.NewGame(model);

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            HumanVsHumanGameViewModel result = partialViewResult.Model as HumanVsHumanGameViewModel;

            Assert.IsNotNull(result);

            int count = result.GameTiles.Count(t => t.IsEmpty && string.IsNullOrWhiteSpace(t.Value));

            Assert.AreEqual(9, count);
        }
        
        #endregion

        #region PlaceTurn Tests

        [TestMethod]
        public void PlaceTurn_Action_Should_Exist()
        {
            HumanVsHumanController controller = this.CreateHumanVsHumanControllerMock();

            PlaceTurnInputModel model = new PlaceTurnInputModel() { GameId = 1, TileIndex = 0 };

            Assert.IsNotNull(controller.PlaceTurn(model));
        }

        [TestMethod]
        public void PlaceTurn_Action_Should_Accept_PlaceTurnInputModel_As_Parameter()
        {
            HumanVsHumanController controller = this.CreateHumanVsHumanControllerMock();

            Type controllerType = controller.GetType();

            int methodsCount = controllerType.GetTypeInfo()
                                             .DeclaredMethods
                                             .Count(m => m.Name.Contains(nameof(controller.PlaceTurn)) &&
                                                         m.ToString().Contains("PlaceTurnInputModel"));

            Assert.AreEqual(1, methodsCount);
        }

        [TestMethod]
        public void PlaceTurn_Action_PlaceTurnInputModel_Should_Contain_Property_Named_GameId()
        {
            PlaceTurnInputModel model = new PlaceTurnInputModel();

            Assert.IsNotNull(model.GameId);
        }

        [TestMethod]
        public void PlaceTurn_Action_PlaceTurnInputModel_GameId_Property_Should_Be_An_Int()
        {
            PlaceTurnInputModel model = new PlaceTurnInputModel() { GameId = 5 };

            Assert.AreEqual(5, model.GameId);
        }

        [TestMethod]
        public void PlaceTurn_Action_PlaceTurnInputModel_Should_Contain_Property_Named_TileIndex()
        {
            PlaceTurnInputModel model = new PlaceTurnInputModel();

            Assert.IsNotNull(model.TileIndex);
        }

        [TestMethod]
        public void PlaceTurn_Action_PlaceTurnInputModel_TileIndex_Property_Should_Be_An_Int()
        {
            PlaceTurnInputModel model = new PlaceTurnInputModel() { GameId = 5, TileIndex = 0 };

            Assert.AreEqual(0, model.TileIndex);
        }

        [TestMethod]
        public void PlaceTurn_Should_Return_PartialView()
        {
            HumanVsHumanController controller = this.CreateHumanVsHumanControllerMock();

            PlaceTurnInputModel model = new PlaceTurnInputModel() { GameId = 1, TileIndex = 0 };

            ActionResult actionResult = controller.PlaceTurn(model);

            Assert.IsInstanceOfType(actionResult, typeof(PartialViewResult));
        }

        [TestMethod]
        public void PlaceTurn_Should_Return_PartialView_Named__HumanVsHumanGame()
        {
            HumanVsHumanController controller = this.CreateHumanVsHumanControllerMock();

            PlaceTurnInputModel model = new PlaceTurnInputModel() { GameId = 1, TileIndex = 0 };

            ActionResult actionResult = controller.PlaceTurn(model);

            PartialViewResult result = actionResult as PartialViewResult;

            Assert.IsNotNull(result);

            Assert.AreEqual("_HumanVsHumanGame", result.ViewName);
        }

        [TestMethod]
        public void PlaceTurn_Should_Return_HumanVsHumanGameViewModel_As_Model_To_The_View()
        {
            HumanVsHumanController controller = this.CreateHumanVsHumanControllerMock();

            PlaceTurnInputModel model = new PlaceTurnInputModel() { GameId = 1, TileIndex = 0 };

            ActionResult actionResult = controller.PlaceTurn(model);

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            bool isCastValidCast = partialViewResult.Model is HumanVsHumanGameViewModel;

            Assert.IsTrue(isCastValidCast);
        }

        [TestMethod]
        public void PlaceTurn_HumanVsHumanGameViewModel_Properties_Should_Not_Be_Null()
        {
            HumanVsHumanController controller = this.CreateHumanVsHumanControllerMock();

            PlaceTurnInputModel model = new PlaceTurnInputModel() { GameId = 1, TileIndex = 0 };

            ActionResult actionResult = controller.PlaceTurn(model);

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            HumanVsHumanGameViewModel result = partialViewResult.Model as HumanVsHumanGameViewModel;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.GameInfo);
            Assert.IsNotNull(result.GameTiles);
        }

        [TestMethod]
        public void PlaceTurn_Should_Redirect_To_FinishedGame_Action_If_Game_Is_Finished()
        {
            HumanVsHumanController controller = this.CreateHumanVsHumanControllerMock();

            PlaceTurnInputModel model = new PlaceTurnInputModel() { GameId = 2, TileIndex = 0 };

            RedirectToRouteResult redirectResult = (RedirectToRouteResult)controller.PlaceTurn(model);

            Assert.AreEqual(redirectResult.RouteValues.Values.ElementAt(1), "FinishedGame");
        }

        #endregion

        #region FinishedGame Tests

        [TestMethod]
        public void FinishedGame_Action_Should_Exist()
        {
            HumanVsHumanController controller = this.CreateHumanVsHumanControllerMock();

            Assert.IsNotNull(controller.FinishedGame(1));
        }

        [TestMethod]
        public void FinishedGame_Action_Should_Accept_gameId_As_Parameter()
        {
            HumanVsHumanController controller = this.CreateHumanVsHumanControllerMock();

            Type controllerType = controller.GetType();

            var method = controllerType.GetTypeInfo().DeclaredMethods.ToList().FirstOrDefault(m => m.Name == "FinishedGame");

            Assert.IsNotNull(method);

            Assert.IsTrue(method.ToString().Contains("Int32"));
        }

        [TestMethod]
        public void FinishedGame_Should_Return_PartialView()
        {
            HumanVsHumanController controller = this.CreateHumanVsHumanControllerMock();

            ActionResult actionResult = controller.FinishedGame(1);

            Assert.IsInstanceOfType(actionResult, typeof(PartialViewResult));
        }

        [TestMethod]
        public void FinishedGame_Should_Return_PartialView_Named__FinishedHumanVsHumanGame()
        {
            HumanVsHumanController controller = this.CreateHumanVsHumanControllerMock();

            ActionResult actionResult = controller.FinishedGame(1);

            PartialViewResult result = actionResult as PartialViewResult;

            Assert.IsNotNull(result);

            Assert.AreEqual("_FinishedHumanVsHumanGame", result.ViewName);
        }

        [TestMethod]
        public void FinishedGame_Should_Return_FinishedGameViewModel_As_Model_To_The_View()
        {
            HumanVsHumanController controller = this.CreateHumanVsHumanControllerMock();

            ActionResult actionResult = controller.FinishedGame(1);

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            bool isCastValidCast = partialViewResult.Model is FinishedGameViewModel;

            Assert.IsTrue(isCastValidCast);
        }

        [TestMethod]
        public void FinishedGame_FinishedGameViewModel_Properties_Should_Not_Be_Null()
        {
            HumanVsHumanController controller = this.CreateHumanVsHumanControllerMock();

            ActionResult actionResult = controller.FinishedGame(1);

            PartialViewResult partialViewResult = actionResult as PartialViewResult;

            Assert.IsNotNull(partialViewResult);

            FinishedGameViewModel result = partialViewResult.Model as FinishedGameViewModel;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.GameInfo);
            Assert.IsNotNull(result.GameTiles);
        }

        #endregion

        /// <summary>
        /// Creates a mocked instance of HumanVsHuman controller
        /// </summary>
        /// <returns>HumanVsHumanController</returns>
        private HumanVsHumanController CreateHumanVsHumanControllerMock()
        {
            Mock<ITicTacToeGameService> ticTacToeServiceMock = mockHelper.SetupTicTacToeServiceMock();

            Mock<ControllerContext> mockContext = mockHelper.SetupControllerContextMock();

            HumanVsHumanController controller = new HumanVsHumanController(ticTacToeServiceMock.Object)
            {
                ControllerContext = mockContext.Object,
                GetCurrentUserName = () => MockConstants.OtherGuyId
            };

            return controller;
        }
    }
}