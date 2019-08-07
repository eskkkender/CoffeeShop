
using Castle.Windsor;
using BLL.Services.Installers;

namespace BLL.Services
{
    public static class Windsor
    {
        public static WindsorContainer Container = new WindsorContainer();
        public static void Initialize()
        {
            Container.Install(new DatabasesInstaller());
            Container.Install(new RepositoriesInstaller());
            Container.Install(new ServicesInstaller());
        }
    }
}
