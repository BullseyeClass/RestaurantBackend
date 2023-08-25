using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.BusinessLogic.Utilities;
using Restaurant.Data.Context;

namespace Restaurant.API.Configuration
{
    public static class DbConfiguration
    {
        public static void AddDbConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var con = configuration.GetConnectionString(name: "DefaultConnection");

            services.AddDbContext<MyAppContext>(options =>
           options.UseMySql(con, ServerVersion.AutoDetect(con)));
   
          
        }
    }

    
}
