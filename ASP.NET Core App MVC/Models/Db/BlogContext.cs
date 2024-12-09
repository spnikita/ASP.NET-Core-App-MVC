using ASP.NET_Core_App_MVC.Models.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_App_MVC.Models.Db
{
    /// <summary>
    /// Контекст БД
    /// </summary>
    public class BlogContext : DbContext
    {
        /// <summary>
        /// Ссылка на таблицу Users
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Ссылка на таблицу UserPosts
        /// </summary>
        public DbSet<UserPost> UserPosts { get; set; }

        /// <summary>
        /// Ссылка на таблицу Requests
        /// </summary>
        public DbSet<Request> Requests { get; set; }

        /// <summary>
        /// Параметризированный конструктор
        /// </summary>
        /// <param name="options">Настройки контекста БД</param>
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
