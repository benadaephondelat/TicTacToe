namespace TicTacToe.Web.Controllers
{
    using System.Web.Mvc;

    using FrameworkExtentions.Filters.ActionFilters;

    using static FrameworkExtentions.UserIdentityHelpers.UserIdentityHelper;
    using static Views.ViewConstants.ViewConstants;

    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (UserIsLoggedIn(this.User))
            {
                return View("Index", AuthenticatedUserLayoutName);
            }

            return View("Index", AnonymousUserLayoutName);
        }

        [CheckIfLoggedInFilter]
        public ActionResult HumanVsHuman()
        {
            return PartialView(HumanVsHumanPartialViewName);
        }
    }
}