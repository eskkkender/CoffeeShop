﻿using Castle.MicroKernel.Registration;
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
            container.Register(Component.For(typeof(IProductRepository)).ImplementedBy(typeof(ProductRepository)).LifestyleTransient());
            container.Register(Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork>().LifestyleScoped());
            container.Register(Component.For<IFactoryRepository>().ImplementedBy<FactoryRepository>()
                    .DependsOn(Dependency.OnValue(typeof(IWindsorContainer), container)));
        }
    }
}
