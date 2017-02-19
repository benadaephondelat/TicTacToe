namespace TicTacToe.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using System.Collections.Generic;
    using Constants;

    public abstract class BaseController : Controller
    {
        public Func<string> CurrentUserName;

        public BaseController()
        {
            this.CurrentUserName = this.GetUserIdentityUsername;
        }

        /// <summary>
        /// Returns a list containing the current user's Id and the default oponent's Id
        /// </summary>
        /// <returns>List<string></string></returns>
        protected List<string> GetDefaultPlayersList()
        {
            List<string> humanVsHumanDefaultPlayers = new List<string>()
            {
                this.CurrentUserName(),
                HumanVsHumanConstants.OponentUsername
            };

            return humanVsHumanDefaultPlayers;
        }

        /// <summary>
        /// Returns the current user's username
        /// </summary>
        /// <returns>string</returns>
        private string GetUserIdentityUsername()
        {
            string result = this.User.Identity.GetUserName();

            return result;
        }
    }
}