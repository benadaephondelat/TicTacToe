namespace DependencyResolver
{
    using Ninject;
    using Ninject.Modules;
    using Ninject.Web.Common;
    using TicTacToe.DataLayer;
    using TicTacToe.DataLayer.Data;
    using TicTacToe.DataLayer.Repository;

    public class DataLayerModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(typeof(IGenericRepository<>)).To(typeof(GenericRepository<>))
                  .WithConstructorArgument("context", Kernel.Get<ApplicationDbContext>());

            Kernel.Bind<ITicTacToeData>().To<TicTacToeData>();
            Kernel.Bind<IApplicationDbContext>().To<ApplicationDbContext>().InRequestScope();
        }
    }
}