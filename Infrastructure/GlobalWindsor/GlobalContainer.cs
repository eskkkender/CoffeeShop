using Castle.Windsor;


namespace GlobalContainer
{
    public class Container
    {
        public static WindsorContainer Instance { get; private set; } = new WindsorContainer();

        public static void Initialize(WindsorContainer container)
        {
            // если контейнер ещё не проинициализирован - тогда инициализируем его
            if (Instance == null)
            {
                Instance = container;
            }
        }
    }
}