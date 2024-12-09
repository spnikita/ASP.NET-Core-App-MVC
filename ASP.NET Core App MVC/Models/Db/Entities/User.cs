namespace ASP.NET_Core_App_MVC.Models.Db.Entities
{
    /// <summary>
    /// Модель пользователя в блоге
    /// </summary>
    public class User
    {
        /// <summary>
        /// Уникальный идентификатор сущности в БД
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Дата регистрации
        /// </summary>
        public DateTime JoinDate { get; set; }
    }
}
