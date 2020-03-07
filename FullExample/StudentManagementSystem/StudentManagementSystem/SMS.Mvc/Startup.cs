using System;
using AutoMapper;
using LazyCache;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using SMS.BL.Infra;
using SMS.Core.Data.Interfaces;
using SMS.DAL;
using SMS.Mvc.Infra;

namespace SMS.Mvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment _env;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDalServices();
            services.AddBlServices();
            if (_env.IsEnvironment("Testing"))
            {
                var connString = Configuration["ConnectionStrings:InMemoryConnection"];
                services.AddDbContext<DbContext, SmsDbContext>(
                    options => options.UseInMemoryDatabase(connString), ServiceLifetime.Scoped);
            }
            else if (_env.IsProduction())
            {
                var connString = Configuration["ConnectionStrings:InMemoryConnection"];
                services.AddDbContext<DbContext, SmsDbContext>(
                    options => options.UseNpgsql(connString), ServiceLifetime.Scoped);
            }
            else
            {
                var connString = Configuration["ConnectionStrings:InMemoryConnection"];
                services.AddDbContext<DbContext, SmsDbContext>(
                    options => options.UseSqlite(connString), ServiceLifetime.Scoped);
            }
            services.AddAutoMapper(typeof(MvcMappingProfile), typeof(BlMappingProfile));

            services.AddControllersWithViews();

            services.AddLazyCache();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
           
            if (_env.IsDevelopment() || _env.IsEnvironment("Testing") || _env.IsEnvironment("UAT"))
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            //added
            app.UseHttpsRedirection();

            app.UseRouting();

           // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "student",
                    pattern: "{controller=Student}/{action=List}/{id?}");
            });
        }
    }
}
