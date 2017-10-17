namespace TicTacToe.Web.FrameworkExtentions.ModelBinders
{
    using System.Web;
    using System.Web.Mvc;
    using Models.HumanVsComputer.InputModels;

    public class NewHumanVsComputerGameModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(NewHumanVsComputerInputModel))
            {
                HttpRequestBase request = controllerContext.HttpContext.Request;

                string startingFirstUsername = request.Form.Get("Sides");
                string oponentUsername = request.Form.Get("Computers");

                return new NewHumanVsComputerInputModel
                {
                    StartingFirstUsername = startingFirstUsername,
                    OponentUsername = oponentUsername
                };
            }
            else
            {
                return base.BindModel(controllerContext, bindingContext);
            }
        }
    }
}