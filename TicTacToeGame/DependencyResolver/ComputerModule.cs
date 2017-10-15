namespace DependencyResolver
{
    using Ninject.Modules;
    using TicTacToe.Computer;
    using TicTacToe.Computer.Interfaces;

    public class ComputerModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IComputer>().To<Computer>();
        }
    }
}