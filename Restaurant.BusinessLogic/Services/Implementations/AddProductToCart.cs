using BootCamp.Data.Repository.Implementation;
using BootCamp.Data.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Entities;
using Restaurant.DTO.Request;
using Restaurant.DTO.Response;
using Restaurant.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Data.Context;
using Restaurant.BusinessLogic.Services.Interfaces;

namespace Restaurant.BusinessLogic.Services.Implementations
{
    public class AddProductToCart : IAddProductToCart
    {
        private readonly UserManager<Customer> _userManager;
        private readonly IGenericRepo<Product> _genericRepo;
        private readonly MyAppContext _myAppContext;
        public AddProductToCart(IGenericRepo<Product> genericRepo, UserManager<Customer> userManager, MyAppContext myAppContext)
        {
            _genericRepo = genericRepo;
            _userManager = userManager;
            _myAppContext = myAppContext;
        }

        public async Task<GenericResponse<string>> AddProductToCartAsync(string email, Guid id)
        {
          
            var customer = await _userManager.FindByEmailAsync(email);

            if (customer != null)
            {
                Product product = _myAppContext.Products.FirstOrDefault(p => p.Id == id);

                if (product != null)
                {
                    // Create a CartItem instance
                    CartItem cartItem = new CartItem
                    {
                        Quantity = 1,
                        Customer = customer,
                        Product = product,
                        CreatedAt = DateTime.UtcNow,
                        CustomerId = Guid.Parse(customer.Id),
                        ProductId = product.Id,
                        CreatedBy = Guid.Parse(customer.Id)
                    };

                    _myAppContext.CartItems.Add(cartItem);
                    _myAppContext.SaveChanges();

                    return GenericResponse<string>.SuccessResponse("successful", "Your Product has been added to cart");
                }

                return GenericResponse<string>.ErrorResponse("errors", false);
            }
            return GenericResponse<string>.ErrorResponse("errors", false);
        }
    }
}