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

                services.AddDbContext<MyAppContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
   
          
        }
    }

    
}
