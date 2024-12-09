using ASP.NET_Core_App_MVC.Models.Db.Entities;

namespace ASP.NET_Core_App_MVC.Interfaces
{
    /// <summary>
    /// Определяет методы работы с БД
    /// </summary>
    public interface IBlogRepository : IGenericRepository<User>
    {
    }
}
