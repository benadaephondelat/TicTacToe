namespace TicTacToe.DataLayer.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (context.Users.Any() == false)
            {
                this.SeedUsers(context);
            }
        }

        private void SeedUsers(ApplicationDbContext context)
        {
            ApplicationUser defaultUser = new ApplicationUser()
            {
                Id = "df7a5022-4fa9-42d9-ba27-7bc45a935199",
                UserName = "georgi_iliev@yahoo.com",
                Email = "georgi_iliev@yahoo.com",
                PasswordHash = "AJ7E9shNQrG/SWhj1CCMERYN4ufQgFf/Cc7gPSVSQS5eMrb5XKLFbLzvzpKHOI6GZw==",
                SecurityStamp = "a2bf1cb6-af83-41db-87aa-6ae520d93121"
            };

            ApplicationUser oponentUser = new ApplicationUser()
            {
                Id = "6e335e25-14ab-4ed8-8f9f-5301208304e7",
                UserName = "the-other-guy@yahoo.com",
                Email = "the-other-guy@yahoo.com",
                PasswordHash = "AJBLSm6hkwpNbL1DatGCOkRF3QXYnjltoOPM7Tzw3GyPn/QKz4luJyoBUXtcwIUKjw==",
                SecurityStamp = "edb0a930-0105-4d19-a4f1-5ffdb99c9a46"
            };

            ApplicationUser computer = new ApplicationUser()
            {
                Id = "computer-id",
                UserName = "computer@yahoo.com",
                Email = "computer@yahoo.com",
                PasswordHash = "AJBLSm6hkwpNbL1DatGCOkRF3QXYnjltoOPM7Tzw3GyPn/QKz4luJyoBUXtcwIUKjw==",
                SecurityStamp = "edb0a930-0105-4d19-a4f1-5ffdb99c9a46"
            };

            context.Users.Add(defaultUser);
            context.Users.Add(oponentUser);
            context.Users.Add(computer);

            context.SaveChanges();
        }
    }
}