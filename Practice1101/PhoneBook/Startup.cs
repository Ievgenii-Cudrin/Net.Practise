using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhoneBook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhoneBook.Interfaces;
using PhoneBook.Repository;
using PhoneBook.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using FluentValidation.AspNetCore;
using FluentValidation;
using PhoneBook.ModelsView;
using PhoneBook.ModelsView.Validators;

namespace PhoneBook
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

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IWorkWithAuthorizedUser, AuthorizedUser>();
            services.AddTransient<IAuthorizedUser, AuthorizedUser>();
            services.AddTransient<ILogInService, LogInService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IOperationResult, OperationResult>();
            services.AddTransient<IAutoMapperService, AutoMapperService>();
            services.AddTransient<IRecordService, RecordService>();
            services.AddTransient<IStatusService, StatusService>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.Cookie.Name = "PhoneBookCookie";
                });

            services.AddControllersWithViews().AddFluentValidation();
            services.AddTransient<IValidator<RecordViewModel>, RecordViewModelValidator>();
            services.AddTransient<IValidator<RegisterModel>, RegisterModelValidator>();
            services.AddDbContext<PhoneBookContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
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
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
