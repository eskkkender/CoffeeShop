using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace WebUI.Windsor
{
    public class ControllersInstaller : IWindsorInstaller
    {
        private readonly Assembly _assembly;

        public ControllersInstaller(Assembly assembly)
        {
            _assembly = assembly;
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes
                .FromAssembly(_assembly)
                .BasedOn<Controller>()
                .LifestylePerWebRequest());

            container.Register(Classes
                .FromAssembly(_assembly)
                .BasedOn<ApiController>()
                .LifestylePerWebRequest());
        }
    }
}