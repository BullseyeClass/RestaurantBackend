using Restaurant.BusinessLogic.Services.Implementations;
using Restaurant.BusinessLogic.Services.Interfaces;
using Restaurant.Data.Entities;

namespace Restaurant.API.Configuration
{
    public static class CloudinaryConfiguration
    {

        public static void AddCloudinaryConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CloudinarySettings>(configuration.GetSection("CloudinarySettings"));
            services.AddScoped<ICloudinaryService, CloudinaryService>();
        }
    }
}
