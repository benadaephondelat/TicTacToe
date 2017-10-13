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
        public const string AuthenticatedUserLayout = "_AuthenticatedUserLayout";

        /// <summary>
        /// Anonymous User layout name
        /// </summary>
        public const string AnonymousUserLayout = "_AnonymousUserLayout";

        /// <summary>
        /// Human vs Human partial view name
        /// </summary>
        public const string HumanVsHumanPartialView = "_HumanVsHuman";

        /// <summary>
        /// Human vs Computer partial view name
        /// </summary>
        public const string HumanVsComputerPartialView = "_HumanVsComputer";

        /// <summary>
        /// HumanVsHuman Controller name
        /// </summary>
        public const string HumanVsHumanController = "HumanVsHuman";

        /// <summary>
        /// NewGameView view name
        /// </summary>
        public const string NewGameView = "NewGame";

        /// <summary>
        /// _HumanVsHumanGame partial view
        /// </summary>
        public const string HumanVsHumanGame = "_HumanVsHumanGame";

        /// <summary>
        /// Computer vs Computer partial view name
        /// </summary>
        public const string ComputerVsComputerPartialView = "_ComputerVsComputer";

        /// <summary>
        /// _HumanVsComputerGame partial view
        /// </summary>
        public const string HumanVsComputerGame = "_HumanVsComputerGame";

        /// <summary>
        /// HumanVsComputer Controller name
        /// </summary>
        public const string HumanVsComputerController = "HumanVsComputer";

        /// <summary>
        /// _FinishedHumanVsHumanGame partial view
        /// </summary>
        public const string FinishedHumanVsHumanGame = "_FinishedHumanVsHumanGame";

        /// <summary>
        /// _FinishedComputerVsHumanGame partial view
        /// </summary>
        public const string FinishedComputerVsHumanGame = "_FinishedComputerVsHumanGame";

        /// <summary>
        /// FinishedGame Action name
        /// </summary>
        public const string FinishedGame = "FinishedGame";

        /// <summary>
        /// Index view name
        /// </summary>
        public const string IndexView = "Index";

        /// <summary>
        /// Load Game view name
        /// </summary>
        public const string LoadGameView = "LoadGame";

        /// <summary>
        /// Load Game Grid partial view name
        /// </summary>
        public const string LoadGameGridPartialView = "_LoadGameGrid";
    }
}