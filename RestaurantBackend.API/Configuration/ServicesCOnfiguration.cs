using BootCamp.BusinessLogic.Services.Implementations;
using BootCamp.BusinessLogic.Services.Interfaces;
using BootCamp.Data.Repository.Implementation;
using BootCamp.Data.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.BusinessLogic.Services.Implementations;

namespace Restaurant.API.Configuration
{
    public static class ServicesCOnfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            services.AddScoped<ICustomerService, CustomerService>()
                .AddScoped<IAuthentication,  Authentication>()
                .AddScoped<ITokenGenerator, TokenGenerator>();
        }
    }
}
