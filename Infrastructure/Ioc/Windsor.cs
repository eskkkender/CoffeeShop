using Castle.Windsor;
using Ioc.Installers;

namespace Ioc
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
