using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Data.Context;
using Restaurant.Data.Entities;
using System;

namespace Restaurant.API.Configuration
{
    public static class IdentityConfiguration
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<Customer, IdentityRole>(options =>
            {
                // Password settings
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 7;
                options.Password.RequireDigit = true;
                options.SignIn.RequireConfirmedEmail = true;
            })
            .AddEntityFrameworkStores<MyAppContext>()
            .AddDefaultTokenProviders();

            // Optionally, you can configure other Identity settings here if needed.
        }
    }
}
