namespace TicTacToe.Web.Controllers
{
    using System.Web.Mvc;
    using static Views.ViewConstants.ViewConstants;
    using static FrameworkExtentions.UserIdentityHelpers.UserIdentityHelper;

    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (UserIsLoggedIn(this.User))
            {
                return View(IndexView, AuthenticatedUserLayout);
            }

            return View(IndexView, AnonymousUserLayout);
        }

        [HttpGet]
        public ActionResult HumanVsHuman()
        {
            if (UserIsLoggedIn(this.User))
            {
                return PartialView(HumanVsHumanPartialView);
            }

            return RedirectToAction(IndexView);
        }

        [HttpGet]
        public ActionResult HumanVsComputer()
        {
            if (UserIsLoggedIn(this.User))
            {
                return PartialView(HumanVsComputerPartialView);
            }

            return RedirectToAction(IndexView);
        }
    }
}