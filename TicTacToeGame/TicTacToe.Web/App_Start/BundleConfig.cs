namespace TicTacToe.Web
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region DefaultBundles

            bundles.Add(new ScriptBundle("~/bundles/jquery")
                   .Include("~/Scripts/Default/jquery-2.1.4.js")
                   .Include("~/Scripts/Default/jquery.validate.js")
                   .Include("~/Scripts/Default/jquery.unobtrusive-ajax.js")
                   .Include("~/Scripts/Default/jquery.validate.unobtrusive.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                   .Include("~/Scripts/Default/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                   .Include("~/Scripts/Default/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                   .Include("~/Scripts/Default/bootstrap.js", "~/Scripts/Default/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                   .Include("~/Content/Default/bootstrap.css", "~/Content/Default/site.css"));

            bundles.Add(new StyleBundle("~/Content/mvc-grid-css")
                   .Include("~/Content/MvcGrid/mvc-grid.css"));

            #endregion

            #region Custom Script Bundles

            bundles.Add(new ScriptBundle("~/bundles/ajaxCallsModule")
                   .Include("~/Scripts/Modules/AjaxCallsModule/ajaxCallsModule.js"));

            bundles.Add(new ScriptBundle("~/bundles/gameModule")
                   .Include("~/Scripts/Modules/GameModule/gameModule.js"));

            bundles.Add(new ScriptBundle("~/bundles/loadGameGridModule")
                   .Include("~/Scripts/Modules/LoadGameModule/loadGameGridModule.js"));

            bundles.Add(new ScriptBundle("~/bundles/authenticatedUserIndexModule")
                   .Include("~/Scripts/Home/_AuthenticatedUserIndex/authenticatedUserIndexModule.js"));

            bundles.Add(new ScriptBundle("~/bundles/humanVsHumanNewGameModule")
                   .Include("~/Scripts/HumanVsHuman/NewGame/humanVsHumanNewGameModule.js"));

            bundles.Add(new ScriptBundle("~/bundles/finishedHumanVsHumanGameModule")
                   .Include("~/Scripts/HumanVsHuman/_FinishedHumanVsHumanGame/finishedHumanVsHumanGameModule.js"));

            bundles.Add(new ScriptBundle("~/bundles/finishedComputerVsHumanGameModule")
                   .Include("~/Scripts/HumanVsComputer/_FinishedComputerVsHumanGame/finishedComputerVsHumanGameModule.js"));

            bundles.Add(new ScriptBundle("~/bundles/loadHumanVsHumanGameModule")
                   .Include("~/Scripts/HumanVsHuman/_LoadGameGrid/loadHumanVsHumanGameModule.js"));

            bundles.Add(new ScriptBundle("~/bundles/humanVsComputerGameModule")
                   .Include("~/Scripts/HumanVsComputer/NewGame/humanVsComputerGameModule.js"));

            bundles.Add(new ScriptBundle("~/bundles/mvc-grid")
                   .Include("~/Scripts/MvcGrid/mvc-grid.js"));

            #endregion

            #region Custom Style Bundles

            bundles.Add(new StyleBundle("~/Content/game-style")
                   .Include("~/Content/Custom/game-style.css"));

            #endregion

            #if DEBUG
                BundleTable.EnableOptimizations = false;
            #else
                BundleTable.EnableOptimizations = true;
            #endif
        }
    }
}