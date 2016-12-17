namespace TicTacToe.Web.Controllers
{
    using System.Web.Mvc;
    using Views.ViewConstants;
    using FrameworkExtentions.UserIdentityHelpers;
    
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (UserIdentityHelper.UserIsLoggedIn(this.User))
            {
                return View("Index", ViewConstants.AuthenticatedUserLayout);
            }

            return View("Index", ViewConstants.AnonymousUserLayout);
        }

        [HttpGet]
        public ActionResult HumanVsHuman()
        {
            if (UserIdentityHelper.UserIsLoggedIn(this.User))
            {
                return PartialView(ViewConstants.HumanVsHumanPartialView);
            }

            return RedirectToAction("Index");
        }
    }
}