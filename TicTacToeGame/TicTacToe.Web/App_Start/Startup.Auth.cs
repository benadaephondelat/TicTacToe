namespace TicTacToe.Web
{
    using DependencyResolver.IdentityConfiguration;
    using Owin;

    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            OwinConfiguration.ConfigureAuth(app);
        }
    }
}