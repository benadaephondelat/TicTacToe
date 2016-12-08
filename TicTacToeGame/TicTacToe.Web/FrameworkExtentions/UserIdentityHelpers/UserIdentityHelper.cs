﻿using System.Security.Principal;

namespace TicTacToe.Web.FrameworkExtentions.UserIdentityHelpers
{
    /// <summary>
    /// Contains methods that helps with the user's identity. 
    /// </summary>
    public static class UserIdentityHelper
    {
        /// <summary>
        /// Checks if the current user is logged in.
        /// </summary>
        /// <param name="userIdentity">IPrincipal</param>
        /// <returns>bool</returns>
        public static bool UserIsLoggedIn(IPrincipal userIdentity)
        {
            if (userIdentity.Identity.IsAuthenticated)
            {
                return true;
            }

            return false;
        }
    }
}