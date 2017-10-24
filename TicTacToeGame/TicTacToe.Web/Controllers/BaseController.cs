namespace TicTacToe.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity;
    using TicTacToeCommon.Constants;

    public abstract class BaseController : Controller
    {
        public Func<string> CurrentUserName;

        public BaseController()
        {
            this.CurrentUserName = this.GetUserIdentityUsername;
        }

        /// <summary>
        /// Returns a list containing the the usernames of all computers
        /// </summary>
        /// <returns>List<string></string></returns>
        protected List<string> GetComputersUsernames()
        {
            List<string> computersUsernames = new List<string>()
            {
                UserConstants.ComputerUsername,
                UserConstants.OtherComputerUsername
            };

            return computersUsernames;
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