namespace TicTacToe.Web.FrameworkExtentions.ModelBinders
{
    using System.Web;
    using System.Web.Mvc;
    using Models.HumanVsHuman.InputModels;

    public class NewHumanVsHumanGameModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(NewHumanVsHumanGameInputModel))
            {
                HttpRequestBase request = controllerContext.HttpContext.Request;

                string startingFirstUsername = request.Form.Get("Players");

                return new NewHumanVsHumanGameInputModel
                {
                    StartingFirstUsername = startingFirstUsername,
                };
            }
            else
            {
                return base.BindModel(controllerContext, bindingContext);
            }
        }
    }
}