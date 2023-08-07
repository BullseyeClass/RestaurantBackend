using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Context;

namespace Restaurant.API.Configuration
{
    public static class DbCOnfiguration
    {
        public static void AddDbConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyAppContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
