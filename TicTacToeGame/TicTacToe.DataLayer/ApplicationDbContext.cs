using System.Data.Entity;

using Microsoft.AspNet.Identity.EntityFramework;

using TicTacToe.Models;
using TicTacToe.DataLayer.Migrations;

namespace TicTacToe.DataLayer
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}