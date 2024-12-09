using ASP.NET_Core_App_MVC.Interfaces;
using ASP.NET_Core_App_MVC.Models.Db.Entities;

namespace ASP.NET_Core_App_MVC.Models.Db.Repositories
{
    /// <summary>
    /// Репозиторий для работы с БД
    /// </summary>
    public class BlogRepository : GenericRepository<User>, IBlogRepository
    {
        /// <inheritdoc />
        public BlogRepository(BlogContext context) : base(context)
        {
        }
    }
}
