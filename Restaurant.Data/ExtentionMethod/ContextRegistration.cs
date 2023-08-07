using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.ExtentionMethod
{
    public static class ContextRegistration
    {
        public static void RegisterDBContext(this IServiceCollection services, IConfiguration config)
        {
 //           services.AddDbContext<MyAppContext>(options =>
 //    options.UseSqlServer(config.GetConnectionString("DefaultConnection"),
 //    options => options.MigrationsAssembly(typeof(MyAppContext).Assembly.FullName)
 //));

        }
    }
}
