using ASP.NET_Core_App_MVC.Interfaces;
using ASP.NET_Core_App_MVC.Models.Db.Entities;

namespace ASP.NET_Core_App_MVC.Middlewears
{
    /// <summary>
    /// Middleware для логирования
    /// </summary>
    public class LoggingMiddleware
    {
        /// <summary>
        /// Обработчик http-запроса, необходим для Middleware
        /// </summary>
        private readonly RequestDelegate _next;

        /// <summary>
        /// Репозиторий БД
        /// </summary>
        private readonly IRequestRepository _repository;

        /// <summary>
        ///  Параметризированный конструктор
        /// </summary>
        /// <param name="next"><inheritdoc cref="_next" path="/summary"/></param>
        /// <param name="repository"><inheritdoc cref="_repository" path="/summary"/></param>
        public LoggingMiddleware(RequestDelegate next, IRequestRepository repository)
        {
            _next = next;
            _repository = repository;
        }

        /// <summary>
        /// Логирование запросов в консоль
        /// </summary>
        /// <param name="context">HTTP-контекст</param>
        private void LogConsole(HttpContext context) => Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");

        /// <summary>
        /// Логирование запросов в БД
        /// </summary>
        /// <param name="context">HTTP-контекст</param>
        /// <returns></returns>
        private async Task LogDb(HttpContext context)
        {
            var url = context.Request.Host.Value + context.Request.Path;

            var request = new Request
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Url = url
            };

            await _repository.AddAsync(request);
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            LogConsole(context);
            await LogDb(context);

            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }
    }
}
