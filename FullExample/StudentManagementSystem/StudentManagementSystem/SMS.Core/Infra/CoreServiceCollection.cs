using SMS.Core.FileImage;

namespace Microsoft.Extensions.DependencyInjection.Extensions
{
    public static class CoreServiceCollection
    {
        public static IServiceCollection AddBlServices(this IServiceCollection services)
        {
            services.AddSingleton<IImageManager, ImageManager>();
            services.AddTransient<IFileManager, FileManager>(); 
            return services;
        }

    }
}
