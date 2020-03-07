using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace SMS.Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .ConfigureHostConfiguration(ConfigureDelegate)
                .Build()
                .Run();
        }

        private static void ConfigureDelegate(IConfigurationBuilder obj)
        {
            obj.AddJsonFile("hosting.json", optional: true)
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json")
                .AddJsonFile("appsettings.Testing.json")
                .AddJsonFile("appsettings.Staging.json")
                .AddJsonFile("appsettings.Production.json");
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
                                                                        .ConfigureWebHostDefaults(webBuilder =>{webBuilder.UseStartup<Startup>();});
    }
}
