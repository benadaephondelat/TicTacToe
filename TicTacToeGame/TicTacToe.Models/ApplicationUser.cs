namespace TicTacToe.Models
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationUser : IdentityUser
    {
        private ICollection<Game> games;

        public ApplicationUser()
        {
            this.Games = new HashSet<Game>();
        }

        public virtual ICollection<Game> Games
        {
            get
            {
                return this.games;
            }

            set
            {
                this.games = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return userIdentity;
        }
    }
}