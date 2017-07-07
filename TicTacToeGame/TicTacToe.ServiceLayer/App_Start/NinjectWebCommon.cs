namespace TicTacToe.ServiceLayer.App_Start
{
    using Computer;
    using Ninject.Modules;
    using TicTacToeGameService;

    public class NinjectWebCommon : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IComputer>().To<Computer>();

            Kernel.Bind<ITicTacToeGameService>().To<TicTacToeGameService>();
        }
    }
}