using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DAL.EntityFramework;
using DAL.Abstraction;

namespace BLL.Services.Installers
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            container.Register(Classes.FromAssembly(typeof(ProductRepository).Assembly)
                                    .BasedOn<IRepositoryBase>()
                                    .WithService.FromInterface()
                                    .LifestyleTransient());

            container.Register(Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork>().LifestyleScoped());
        }
    }
}
