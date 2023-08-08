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
            // Access IPAddressSettings section
            IPAddressSettings ipAddressSettings = configuration.GetSection("IPAddressSettings").Get<IPAddressSettings>();

            //services.AddDbContext<MyAppContext>(options =>
            //    options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

           IPAddressSettings iPAddress= GettingIPAddress.GetMyIpAddress();

            if (ipAddressSettings.IPv4 == iPAddress.IPv4 && ipAddressSettings.IPv6 == iPAddress.IPv6)
            {
                services.AddDbContext<MyAppContext>(options =>
               options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
            }
            else
            {
                services.AddDbContext<MyAppContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("WindowsAuthenticationConnection")));
            }
            
            //string ipv4Address = ipAddressSettings.IPv4;
            //string ipv6Address = ipAddressSettings.IPv6;
          
        }
    }

    
}
