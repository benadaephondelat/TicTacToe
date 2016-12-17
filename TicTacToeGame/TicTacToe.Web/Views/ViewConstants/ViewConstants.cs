namespace TicTacToe.Web.Views.ViewConstants
{
    /// <summary>
    /// Contains constants to be used in the views.
    /// </summary>
    public static class ViewConstants
    {
        /// <summary>
        /// Path to the _AuthenticatedUserLayout partial view
        /// </summary>
        public const string AuthenticatedUserLayoutPath = "~/Views/Shared/_AuthenticatedUserLayout.cshtml";

        /// <summary>
        /// Path to the _AnonymousUserLayout partial view
        /// </summary>
        public const string AnonymousUserLayoutPath = "~/Views/Shared/_AnonymousUserLayout.cshtml";

        /// <summary>
        /// Authenticated User layout name 
        /// </summary>
        public const string AuthenticatedUserLayoutName = "_AuthenticatedUserLayout";

        /// <summary>
        /// Anonymous User layout name
        /// </summary>
        public const string AnonymousUserLayoutName = "_AnonymousUserLayout";

        /// <summary>
        /// Human vs Human partial view name
        /// </summary>
        public const string HumanVsHumanPartialViewName = "_HumanVsHuman";
    }
}