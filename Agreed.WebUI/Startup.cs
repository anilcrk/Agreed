using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Agreed.Core.Repositories;
using Agreed.Core.Service;
using Agreed.Core.Services;
using Agreed.Core.UnitOfWorks;
using Agreed.DataAccess;
using Agreed.DataAccess.Repositories;
using Agreed.DataAccess.UnitOfWorks;
using Agreed.Service.Services;
using Agreed.WebUI.ModelServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Agreed.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Dependecy Injections
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<OrderModelService, OrderModelService>();
            services.AddScoped<CompanyModelService, CompanyModelService>();
            services.AddScoped<CommissionModelService, CommissionModelService>();
            services.AddScoped<CargoModelService, CargoModelService>();
            services.AddScoped<UserModelService, UserModelService>();
            services.AddScoped<AgreedModelService, AgreedModelService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddHttpContextAccessor();

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString(), o =>
                {
                    // Migration asembly
                    o.MigrationsAssembly("Agreed.DataAccess");
                });
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Index";
                    options.Cookie.Name = "AgreedCookie";
                });
            services.AddMvc();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCookiePolicy();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
