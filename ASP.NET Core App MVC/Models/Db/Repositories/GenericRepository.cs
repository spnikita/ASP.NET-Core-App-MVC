using ASP.NET_Core_App_MVC.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_App_MVC.Models.Db.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        /// <summary>
        /// DB-контекст
        /// </summary>
        protected readonly BlogContext _context;

        /// <summary>
        /// Параметризированный конструктор
        /// </summary>
        /// <param name="context"><inheritdoc cref="_context" path="/summary"/></param>
        protected GenericRepository(BlogContext context) => _context = context;

        /// <inheritdoc />
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToArrayAsync();
        }
    }
}
