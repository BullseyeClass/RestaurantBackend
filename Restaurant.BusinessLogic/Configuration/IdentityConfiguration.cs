using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Data.Context;
using Restaurant.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BusinessLogic.Configuration
{
    public static class IdentityConfiguration
    {
        public static void ConfigurationIdentity(this IServiceCollection services)
        {
            services.AddIdentity<Customer, IdentityRole>(x =>
            {
                x.Password.RequireUppercase = true;
                x.Password.RequiredLength = 7;
                x.Password.RequireDigit = true;
                x.SignIn.RequireConfirmedEmail = true;
            })
                .AddEntityFrameworkStores<MyAppContext>()
                .AddDefaultTokenProviders();
        }
    }
}
