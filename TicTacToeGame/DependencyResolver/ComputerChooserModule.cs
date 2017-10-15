namespace DependencyResolver
{
    using Ninject.Modules;
    using TicTacToe.Computer;
    using TicTacToe.ComputerChooser;
    using TicTacToe.ComputerChooser.Interfaces;

    public class ComputerChooserModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IComputerChooser>().To<ComputerChooser>()
                  .WithConstructorArgument("myComputer", new Computer());
        }
    }
}