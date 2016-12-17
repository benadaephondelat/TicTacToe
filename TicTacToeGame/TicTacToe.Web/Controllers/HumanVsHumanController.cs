namespace TicTacToe.Web.Controllers
{
    using System.Web.Mvc;
    using FrameworkExtentions.Filters.ActionFilters;

    [CheckIfLoggedInFilter]
    public class HumanVsHumanController : Controller
    {
    }
}