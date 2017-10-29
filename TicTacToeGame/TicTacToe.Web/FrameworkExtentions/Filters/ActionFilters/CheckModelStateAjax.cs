namespace TicTacToe.Web.FrameworkExtentions.Filters.ActionFilters
{
    using System.Linq;
    using System.Web.Mvc;

    /// <summary>
    /// Checks the model state for ajax requests, returns false and errors as JSON.
    /// </summary>
    public class CheckModelStateAjax : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest() == false)
            {
                return;
            }

            if (filterContext.Controller.ViewData.ModelState.IsValid)
            {
                return;
            }

            filterContext.Result = new JsonResult()
            {
                Data = filterContext.Controller.ViewData.ModelState.Select(x => x.Value.Errors)
                                                                   .Where(y => y.Count > 0)
                                                                   .ToList(),
            };

            base.OnActionExecuting(filterContext);
        }
    }
}