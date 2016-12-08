using System.Web.Mvc;

using static TicTacToe.Web.FrameworkExtentions.UserIdentityHelpers.UserIdentityHelper;

namespace TicTacToe.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (UserIsLoggedIn(this.User))
            {
                return View("Index", "_AuthenticatedUserLayout");
            }

            return View("Index", "_AnonymousUserLayout");
        }
    }
}