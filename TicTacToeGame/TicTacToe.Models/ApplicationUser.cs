using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TicTacToe.Models
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            const string applicationCookie = DefaultAuthenticationTypes.ApplicationCookie;

            ClaimsIdentity userIdentity = await manager.CreateIdentityAsync(this, applicationCookie);

            return userIdentity;
        }
    }
}