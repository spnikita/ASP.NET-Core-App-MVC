namespace ASP.NET_Core_App_MVC.Models.Db.Entities
{
    /// <summary>
    /// Модель пользовательского поста в блоге
    /// </summary>
    public class UserPost
    {
        /// <summary>
        /// Уникальный идентификатор сущности в БД
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Дата поста
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Заголовок
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Текст
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Уникальный идентификатор пользователя
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public User User { get; set; }
    }
}
