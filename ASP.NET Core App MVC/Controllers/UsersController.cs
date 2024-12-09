using ASP.NET_Core_App_MVC.Interfaces;
using ASP.NET_Core_App_MVC.Models;
using ASP.NET_Core_App_MVC.Models.Db.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_App_MVC.Controllers
{
    /// <summary>
    /// Контроллер для работы с пользователями
    /// </summary>
    public class UsersController : Controller
    {
        /// <summary>
        /// Репозиторий БД
        /// </summary>
        private readonly IBlogRepository _repository;

        /// <summary>
        /// Параметризированный конструктор
        /// </summary>
        /// <param name="repository">Репозиторий БД</param>
        public UsersController(IBlogRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Открыть страницу со списком пользователей
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> IndexAsync()
        {
            var authors = await _repository.GetAllAsync();
            return View(authors);
        }

        /// <summary>
        /// Открыть форму регистрации нового пользователя
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Зарегистрировать нового пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegistratonViewModel registrationModel)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = registrationModel.FirstName,
                LastName = registrationModel.LastName,
                JoinDate = DateTime.Now
            };

            await _repository.AddAsync(user);

            return View(user);
        }
    }
}
