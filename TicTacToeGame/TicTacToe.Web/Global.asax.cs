﻿namespace TicTacToe.Web
{
    using System.Web;
    using System.Web.Mvc;
    using System.Reflection;
    using System.Web.Routing;
    using System.Web.Optimization;
    using System.Collections.Generic;
    using FrameworkExtentions.Mappings;
    using FrameworkExtentions.ModelBinders;
    using Models.HumanVsComputer.InputModels;
    using Models.ComputerVsComputer.InputModels;
    using Models.HumanVsHuman.InputModels;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ModelBinders.Binders.Add(typeof(NewHumanVsComputerInputModel), new NewHumanVsComputerGameModelBinder());
            ModelBinders.Binders.Add(typeof(NewComputerVsComputerGameInputModel), new NewComputerVsComputerGameModelBinder());
            ModelBinders.Binders.Add(typeof(NewHumanVsHumanGameInputModel), new NewHumanVsHumanGameModelBinder());

            this.RegisterRazorViewEngineOnly();
            this.ConfigureAutoMapper();
        }

        /// <summary>
        /// Triggers AutoMapper configuration
        /// </summary>
        private void ConfigureAutoMapper()
        {
            List<Assembly> executingAssembly = new List<Assembly> { Assembly.GetExecutingAssembly() };

            AutoMapperConfig autoMapperConfig = new AutoMapperConfig(executingAssembly);

            autoMapperConfig.LoadMappings();
        }

        /// <summary>
        /// Registers RazorViewEngine as the only view engine of the application
        /// </summary>
        private void RegisterRazorViewEngineOnly()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}