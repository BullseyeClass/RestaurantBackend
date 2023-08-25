using BootCamp.BusinessLogic.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.BusinessLogic.Services.Implementations;
using Restaurant.BusinessLogic.Services.Interfaces;
using Restaurant.Data.Repository.Implementation;
using Restaurant.Data.Repository.Interface;

namespace Restaurant.API.Configuration
{
    public static class ServicesCOnfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            services.AddScoped<ICustomerService, CustomerService>()
                .AddScoped<IAuthentication, Authentication>()
                .AddScoped<ITokenGenerator, TokenGenerator>()
                .AddScoped<ICartItemService, CartItemService>()
                .AddScoped<IWishListService, WishListService>()
                .AddScoped<IProductsFiltering, ProductsFiltering>()
              .AddScoped<IRequestSupportService, RequestSupportService>()
              .AddScoped<IAddressService, AddressService>()
              .AddScoped<IGetAllProductID, GetAllProductIDsServices>()
              .AddScoped<IOrderService, OrderService>()
              .AddScoped<IPaymentService, PaymentService>();
        }
    }
}
