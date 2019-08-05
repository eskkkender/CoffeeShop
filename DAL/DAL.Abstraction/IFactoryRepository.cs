namespace DAL.Abstraction
{
    /// <summary>
    /// Интерфейс для фабрики для репозиториев
    /// </summary>
    public interface IFactoryRepository
    {
        /// <summary>
        /// Получить репозиторий по его интерфейсу
        /// </summary>
        /// <typeparam name="T">Интерфейс для репозитория</typeparam>
        /// <returns>Экземпляр репозитория</returns>
        T Repository<T>() where T : IRepositoryBase;
    }
}
