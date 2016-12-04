using System;
using Owin;

using TicTacToe.ServiceLayer.IdentityConfiguration;

namespace TicTacToe.Web
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            OwinConfiguration.ConfigureAuth(app);
        }
    }
}