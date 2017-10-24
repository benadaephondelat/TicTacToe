namespace DependencyResolver.Tests
{
    using System.Linq;
    using Ninject;
    using TicTacToe.Web.App_Start;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class ModulesTests
    {
        [TestMethod]
        public void Ninject_Kernel_Should_Be_Created_Successfuly()
        {
            try
            {
                IKernel kernel = NinjectWebCommon.CreateKernel();
            }
            catch
            {
                Assert.Fail();
            }

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ServiceLayerModule_Should_Exists()
        {
            ServiceLayerModule serviceLayerModule = new ServiceLayerModule();

            Assert.IsNotNull(serviceLayerModule);
        }

        [TestMethod]
        public void ServiceLayerModule_Load_Method_Should_Not_Throw_Exception()
        {
            try
            {
                IKernel kernel = NinjectWebCommon.CreateKernel();

                var modules = kernel.GetModules().ToList();

                ServiceLayerModule module = modules.FirstOrDefault(m => m.Name == "DependencyResolver.ServiceLayerModule") as ServiceLayerModule;

                module.Load();
            }
            catch (Exception e) when (e.StackTrace.Contains("DependencyResolver.ServiceLayerModule"))
            {
                Assert.Fail();
            }
            finally
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void DataLayerModule_Should_Exists()
        {
            DataLayerModule dataLayerModule = new DataLayerModule();

            Assert.IsNotNull(dataLayerModule);
        }

        [TestMethod]
        public void DataLayerModule_Load_Method_Should_Not_Throw_Exception()
        {
            try
            {
                IKernel kernel = NinjectWebCommon.CreateKernel();

                var modules = kernel.GetModules().ToList();

                DataLayerModule module = modules.FirstOrDefault(m => m.Name == "DependencyResolver.DataLayerModule") as DataLayerModule;

                module.Load();
            }
            catch (Exception e) when (e.StackTrace.Contains("DependencyResolver.DataLayerModule"))
            {
                Assert.Fail();
            }
            finally
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void ComputerModule_Should_Exists()
        {
            ComputerModule computerModule = new ComputerModule();

            Assert.IsNotNull(computerModule);
        }

        [TestMethod]
        public void ComputerModule_Load_Method_Should_Not_Throw_Exception()
        {
            try
            {
                IKernel kernel = NinjectWebCommon.CreateKernel();

                var modules = kernel.GetModules().ToList();

                ComputerModule module = modules.FirstOrDefault(m => m.Name == "DependencyResolver.ComputerModule") as ComputerModule;

                module.Load();
            }
            catch (Exception e) when (e.StackTrace.Contains("DependencyResolver.ComputerModule"))
            {
                Assert.Fail();
            }
            finally
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void ComputerChooserModule_Should_Exists()
        {
            ComputerChooserModule computerChooserModule = new ComputerChooserModule();

            Assert.IsNotNull(computerChooserModule);
        }

        [TestMethod]
        public void ComputerChooserModule_Load_Method_Should_Not_Throw_Exception()
        {
            try
            {
                IKernel kernel = NinjectWebCommon.CreateKernel();

                var modules = kernel.GetModules().ToList();

                ComputerChooserModule module = modules.FirstOrDefault(m => m.Name == "DependencyResolver.ComputerChooserModule") as ComputerChooserModule;

                module.Load();
            }
            catch (Exception e) when (e.StackTrace.Contains("DependencyResolver.ComputerChooserModule"))
            {
                Assert.Fail();
            }
            finally
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void Kernel_Should_Have_4_Modules()
        {
            IKernel kernel = NinjectWebCommon.CreateKernel();

            var modules = kernel.GetModules().ToList();

            Assert.AreEqual(4, modules.Count());
        }
    }
}