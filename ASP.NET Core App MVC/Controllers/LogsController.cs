using ASP.NET_Core_App_MVC.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_App_MVC.Controllers
{
    /// <summary>
    /// Контроллер логирования
    /// </summary>
    public class LogsController : Controller
    {
        /// <summary>
        /// Репозиторий для работы с БД
        /// </summary>
        private readonly IRequestRepository _requestRepository;

        /// <summary>
        /// Параметризированный конструктор
        /// </summary>
        /// <param name="repository"><inheritdoc cref="_requestRepository" path="/summary"/></param>
        public LogsController(IRequestRepository repository)
        {
            _requestRepository = repository;
        }

        /// <summary>
        /// Отобразить список логирования запросов
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> IndexAsync()
        {
            var requests = await _requestRepository.GetAllAsync();

            return View(requests.OrderByDescending(el => el.Date));
        }
    }
}
