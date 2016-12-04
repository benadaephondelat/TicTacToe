using Ninject.Modules;
using Ninject.Web.Common;

using TicTacToe.ServiceLayer.DataLayer;

namespace TicTacToe.ServiceLayer.App_Start
{
    public class NinjectWebCommon : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IDataLayerService>().To<DataLayerService>().InRequestScope();
        }
    }
}