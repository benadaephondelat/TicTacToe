﻿namespace DependencyResolver
{
    using Ninject.Modules;
    using TicTacToe.Computer;
    using TicTacToe.ComputerChooser;
    using TicTacToe.ComputerMinMax;
    using TicTacToe.ServiceLayer.Interfaces;
    using TicTacToe.ServiceLayer.TicTacToeGameService;

    public class ServiceLayerModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<ITicTacToeGameService>().To<TicTacToeGameService>()
                  .WithConstructorArgument("computerChooser", new ComputerChooser(new Computer(), new MinMaxComputer()));
        }
    }
}