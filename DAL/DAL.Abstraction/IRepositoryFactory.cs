
namespace DAL.Abstraction
{
    /// <summary>
    /// Интерфейс для фабрики для репозиториев
    /// </summary>
    public interface IRepositoryFactory
    {
        /// <summary>
        /// Получить репозиторий по его интерфейсу
        /// </summary>
        T Repository<T>() where T : IRepositoryBase;
    }
}
