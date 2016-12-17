namespace TicTacToe.Web.Controllers
{
    using System.Web.Mvc;
    using FrameworkExtentions.UserIdentityHelpers;
    using FrameworkExtentions.Filters.ActionFilters;
    using Views.ViewConstants;
    
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (UserIdentityHelper.UserIsLoggedIn(this.User))
            {
                return View("Index", ViewConstants.AuthenticatedUserLayoutName);
            }

            return View("Index", ViewConstants.AnonymousUserLayoutName);
        }

        [CheckIfLoggedInFilter]
        public ActionResult HumanVsHuman()
        {
            return PartialView(ViewConstants.HumanVsHumanPartialViewName);
        }
    }
}