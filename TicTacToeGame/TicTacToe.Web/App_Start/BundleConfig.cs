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

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/Default/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/Default/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/Default/bootstrap.js",
                      "~/Scripts/Default/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Default/bootstrap.css",
                      "~/Content/Default/site.css"));

            #endregion

            #region Custom Script Bundles

            bundles.Add(new ScriptBundle("~/bundles/authenticatedUserIndexModule")
                   .Include("~/Scripts/Home/_AuthenticatedUserIndex/authenticatedUserIndexModule.js"));

            bundles.Add(new ScriptBundle("~/bundles/humanVsHumanNewGameModule")
                   .Include("~/Scripts/HumanVsHuman/NewGame/humanVsHumanNewGameModule.js"));

            bundles.Add(new ScriptBundle("~/bundles/finishedHumanVsHumanGameModule")
                   .Include("~/Scripts/HumanVsHuman/_FinishedHumanVsHumanGame/finishedHumanVsHumanGameModule.js"));
            
            #endregion

            #region Custom Style Bundles

            #endregion

            #if DEBUG
            BundleTable.EnableOptimizations = false;
            #else
                BundleTable.EnableOptimizations = true;
            #endif
        }
    }
}