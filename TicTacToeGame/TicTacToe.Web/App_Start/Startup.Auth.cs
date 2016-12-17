namespace TicTacToe.Web
{
    using Owin;

    using TicTacToe.ServiceLayer.IdentityConfiguration;

    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            OwinConfiguration.ConfigureAuth(app);
        }
    }
}