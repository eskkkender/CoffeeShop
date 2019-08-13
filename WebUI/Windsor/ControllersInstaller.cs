using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Reflection;
using System.Web.Mvc;

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
                .BasedOn<Controller>().LifestyleTransient());
        }
    }
}