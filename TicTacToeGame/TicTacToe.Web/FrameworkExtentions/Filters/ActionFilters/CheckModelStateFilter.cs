namespace TicTacToe.Web.FrameworkExtentions.Filters.ActionFilters
{
    using System.Web.Mvc;

    /// <summary>
    /// Checks the model state.
    /// </summary>
    public class CheckModelStateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.Controller.ViewData.ModelState.IsValid)
            {
                return;
            }

            filterContext.Result = new ViewResult
            {
                ViewName = filterContext.ActionDescriptor.ActionName,
                ViewData = filterContext.Controller.ViewData,
                TempData = filterContext.Controller.TempData
            };

            base.OnActionExecuting(filterContext);
        }
    }
}