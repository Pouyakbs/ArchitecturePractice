using ArchitecturePractice.Core.ApplicationService.Config;
using ArchitecturePractice.Core.ApplicationService.Facade;
using ArchitecturePractice.Core.ApplicationService.UnitofWork;
using ArchitecturePractice.Core.Contracts.Facade;
using ArchitecturePractice.Core.Contracts.Repository;
using ArchitecturePractice.Core.Contracts.Repository.Common;
using ArchitecturePractice.Core.Contracts.UnitofWork;
using ArchitecturePractice.Data;
using ArchitecturePractice.Infrastructure.Data;
using ArchitecturePractice.Infrastructure.Data.Common;
using ArchitecturePractice.Infrastructure.EF;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchitecturePractice
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
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new BookProfile());
                mc.AddProfile(new WriterProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<IUnitOfWork, UnitofWork>();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("ArchitecturePractice")));
            services.AddDbContext<DemoContext>(options =>
            {
                options.EnableSensitiveDataLogging();
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.UseSqlServer(
                    Configuration.GetConnectionString("ArchitecturePractice"));
            });
                
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IGenericRepository<IBookRepository>, GenericRepository<IBookRepository>>();
            services.AddScoped<IGenericRepository<IWriterRepository>, GenericRepository<IWriterRepository>>();
            services.AddScoped<IWriterRepository, WriterRepository>();
            services.AddScoped<IBookFacade, BookFacade>();
            services.AddScoped<IWriterFacade, WriterFacade>();

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;
            }).AddEntityFrameworkStores<ApplicationDbContext>();

            Log.Logger = new LoggerConfiguration()
                  .ReadFrom.Configuration(Configuration)
                  .CreateLogger();
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "ArchitecturePracticeCookie";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.LoginPath = "/Accounting/Login";
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SwaggerDemoApplication",
                    Version = "v1"
                });
            });

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

             app.UseSwagger();
        app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ArchitecturePracticeSwagger V1");
                });
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
