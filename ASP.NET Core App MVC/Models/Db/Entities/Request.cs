namespace ASP.NET_Core_App_MVC.Models.Db.Entities
{
    /// <summary>
    /// Запрос
    /// </summary>
    public class Request
    {
        /// <summary>
        /// Уникальный идентификатор сущности в БД
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Дата запроса
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// URL запроса
        /// </summary>
        public string Url { get; set; }
    }
}
