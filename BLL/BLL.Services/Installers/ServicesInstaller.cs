using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using BLL.Interfaces;

namespace BLL.Services.Installers
{
    class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IProductManager>().ImplementedBy<ProductManager>()
                .LifestyleScoped());
        }
    }
}
