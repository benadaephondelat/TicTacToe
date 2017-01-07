namespace TicTacToe.ServiceLayer.App_Start
{
    using Ninject.Modules;
    using TicTacToeGameService;

    public class NinjectWebCommon : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<ITicTacToeGameService>().To<TicTacToeGameService>();
        }
    }
}