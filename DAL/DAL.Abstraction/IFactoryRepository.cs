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
        /// <returns>Экземпляр репозитория</returns>
        IRepositoryBase Repository<IRepositoryBase>();
    }
}
