namespace ASP.NET_Core_App_MVC.Interfaces
{
    /// <summary>
    /// Определяет методы работы с БД
    /// </summary>
    /// <typeparam name="T">Тип объекта</typeparam>
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Добавить объект
        /// </summary>
        /// <param name="entity">Объект</param>
        Task AddAsync(T entity);

        /// <summary>
        /// Получить все объекты
        /// </summary>
        /// <returns>Список всех объектов</returns>
        Task<IEnumerable<T>> GetAllAsync();
    }
}
