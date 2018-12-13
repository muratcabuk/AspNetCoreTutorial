using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MySecondApi
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
            //javascript le çalışırken policy ye eklemek lazım
            services.AddCors(option =>
            {

                option.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });

            });



            //dikkat burada AddMvc yazıyorsu burayı Core a çevirdik. çünki normal Mvc de .AddAuthorization().AddJsonFormatters() burası yok
            services.AddMvcCore().AddAuthorization().AddJsonFormatters();

            services.AddAuthentication("Bearer").AddIdentityServerAuthentication(

                opt =>
                {
                    opt.Authority = "http://localhost:5000";
                    opt.RequireHttpsMetadata = false;

                    //identityserver da versiğimiz isim
                    opt.ApiName = "MySecondApi";
                }

                );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            //biz ekledik
            app.UseAuthentication();
            app.UseCors("CorsPolicy");

            app.UseMvc();
        }
    }
}
