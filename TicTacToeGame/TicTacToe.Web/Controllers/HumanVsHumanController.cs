namespace TicTacToe.Web.Controllers
{
    using System.Web.Mvc;
    using FrameworkExtentions.Filters.ActionFilters;
    using Views.ViewConstants;

    [CheckIfLoggedInFilter]
    public class HumanVsHumanController : Controller
    {
        [HttpGet]
        public ActionResult NewGame()
        {
            return View(ViewConstants.NewGameView);
        }
    }
}