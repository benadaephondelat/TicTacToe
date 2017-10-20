namespace DependencyResolver
{
    using Ninject.Modules;
    using TicTacToe.Computer;
    using TicTacToe.ComputerChooser;
    using TicTacToe.ComputerChooser.Interfaces;
    using TicTacToe.ComputerMinMax;

    public class ComputerChooserModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IComputerChooser>().To<ComputerChooser>()
                  .WithConstructorArgument("myComputer", new Computer())
                  .WithConstructorArgument("minMaxComputer", new MinMaxComputer());
        }
    }
}