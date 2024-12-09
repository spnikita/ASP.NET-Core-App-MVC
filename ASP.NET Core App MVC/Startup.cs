using ASP.NET_Core_App_MVC.Interfaces;
using ASP.NET_Core_App_MVC.Middlewears;
using ASP.NET_Core_App_MVC.Models.Db;
using ASP.NET_Core_App_MVC.Models.Db.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_App_MVC
{
    public class Startup
    {
        /// <summary>
        /// Конфигурация приложения
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Параметризированный конструктор
        /// </summary>
        /// <param name="configuration"><inheritdoc cref="_configuration" path="/summary"/></param>
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = _configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<BlogContext>(options => options.UseSqlServer(connection), ServiceLifetime.Singleton);

            // регистрация сервиса репозитория для взаимодействия с базой данных
            services.AddSingleton<IBlogRepository, BlogRepository>();
            services.AddSingleton<IRequestRepository, RequestRepository>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseStatusCodePages();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<LoggingMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
