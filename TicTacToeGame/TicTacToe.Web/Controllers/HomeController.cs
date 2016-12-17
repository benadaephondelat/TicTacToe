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
                return View("Index", ViewConstants.AuthenticatedUserLayoutName);
            }

            return View("Index", ViewConstants.AnonymousUserLayoutName);
        }

        [HttpGet]
        public ActionResult HumanVsHuman()
        {
            if (UserIdentityHelper.UserIsLoggedIn(this.User))
            {
                return PartialView(ViewConstants.HumanVsHumanPartialViewName);
            }

            return RedirectToAction("Index");
        }
    }
}