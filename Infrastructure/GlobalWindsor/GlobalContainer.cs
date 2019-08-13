using Castle.MicroKernel.Registration;
using Castle.Windsor;


namespace GlobalWindsor
{
    public class GlobalContainer
    {
        public static WindsorContainer Container { get; private set; } = new WindsorContainer();

        public static void Initialize(WindsorContainer container)
        {
            // если контейнер ещё не проинициализирован - тогда инициализируем его
            if (Container == null)
            {
                Container = container;
            }
        }
        public static void Initialize(IWindsorInstaller installer)
        {
            if (installer != null)
            {
                Container.Install(installer);
            }
        }
    }
}