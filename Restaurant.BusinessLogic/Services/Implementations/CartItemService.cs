
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
    public class CartItemService : ICartItemService
    {
        private readonly UserManager<Customer> _userManager;
        private readonly IGenericRepo<CartItem> _genericRepoCartItem;

        public CartItemService(IGenericRepo<CartItem> genericRepo, UserManager<Customer> userManager)
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

        public async Task<GenericResponse<string>> DeleteProductFromCartAsync(DeleteCartItemRequestDTO deleteCartItemRequestDTO)
        {
            var CartItemExist = await _genericRepoCartItem.GetByIdAysnc(deleteCartItemRequestDTO.CartItemId);

            if (CartItemExist != null)
            {
                await _genericRepoCartItem.DeleteAsync(CartItemExist);

                return GenericResponse<string>.SuccessResponse("Cart Item Deleted Sucessfully", "Successful");
            }
            return GenericResponse<string>.ErrorResponse("No Address Found");

        }

        public async Task<GenericResponse<string>> UpdateCartAsync(EditCartItemRequestDTO editCartItemRequestDTO)
        {
            var cartItemExist = await _genericRepoCartItem.GetByIdAysnc(editCartItemRequestDTO.CartItemId);

            if (cartItemExist != null)
            {
                cartItemExist.Quantity = editCartItemRequestDTO.Quantity;
                cartItemExist.UpdatedAt = editCartItemRequestDTO.UpdatedAt;
                cartItemExist.UpdatedBy = editCartItemRequestDTO.UpdatedBy;

                await _genericRepoCartItem.UpdateAsync(cartItemExist);

                return GenericResponse<string>.SuccessResponse("Cart Item Edited Successfully", "Successful");

            }
            return GenericResponse<string>.ErrorResponse("No Cart Item Found");

        }
    }
}