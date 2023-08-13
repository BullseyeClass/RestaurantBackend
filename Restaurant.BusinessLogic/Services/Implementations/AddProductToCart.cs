
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
using Restaurant.Data.Repository.Interface;

namespace Restaurant.BusinessLogic.Services.Implementations
{
    public class AddProductToCart : IAddProductToCart
    {
        private readonly UserManager<Customer> _userManager;
        private readonly IGenericRepo<CartItem> _genericRepoCartItem;

        public AddProductToCart(IGenericRepo<CartItem> genericRepo, UserManager<Customer> userManager)
        {
            _genericRepoCartItem = genericRepo;
            _userManager = userManager;
        }

        public async Task<GenericResponse<string>> AddProductToCartAsync(AddingProductToCartRequestDTO addingProductToCartRequestDTO)
        {

            var customer = await _userManager.FindByIdAsync(addingProductToCartRequestDTO.CustomerId.ToString());

            if (customer != null)
            {
               
                CartItem cartItem = new()
                {
                    Quantity = addingProductToCartRequestDTO.Quantity,
                    Customer = customer,
                    CreatedAt = DateTime.UtcNow,
                    CustomerId = Guid.Parse(customer.Id),
                    ProductId = addingProductToCartRequestDTO.ProductId,
                    CreatedBy = addingProductToCartRequestDTO.CustomerId
                };

                bool success = await _genericRepoCartItem.InsertAsync(cartItem);

                if (success)
                {
                    return GenericResponse<string>.SuccessResponse("successful", "Your Product has been added to cart");
                }

            }
            return GenericResponse<string>.ErrorResponse("error adding product to cart", false);
        }
    }
}