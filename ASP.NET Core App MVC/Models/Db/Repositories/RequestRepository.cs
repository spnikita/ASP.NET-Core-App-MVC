using ASP.NET_Core_App_MVC.Interfaces;
using ASP.NET_Core_App_MVC.Models.Db.Entities;

namespace ASP.NET_Core_App_MVC.Models.Db.Repositories
{
    /// <summary>
    /// Репозиторий дял работы с БД
    /// </summary>
    public class RequestRepository : GenericRepository<Request>, IRequestRepository
    {
        /// <inheritdoc />
        public RequestRepository(BlogContext context) : base(context)
        {
        }
    }
}
