using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Abstraction;
using DAL.EntityFramework;
using System.Data.Entity;

namespace BLL.Services.Installers
{
    public class DatabasesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component
                .For<DbContext>().ImplementedBy<CoffeeShopDbContext>());
        }
    }
}
