namespace TicTacToe.DataLayer.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        private readonly SeedHelper seedHelper;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;

            this.seedHelper = new SeedHelper();
        }

        protected override void Seed(ApplicationDbContext context)
        {
            bool areThereNoComputersInTheDb = context.Users.Any() == false;

            if (areThereNoComputersInTheDb)
            {
                var users = this.seedHelper.GetDefaultUsers();

                this.AddUsersToDatabase(context, users);
            }
        }

        private void AddUsersToDatabase(ApplicationDbContext context, IEnumerable<ApplicationUser> users)
        {
            foreach (var user in users)
            {
                context.Users.Add(user);
            }

            context.SaveChanges();
        }
    }
}