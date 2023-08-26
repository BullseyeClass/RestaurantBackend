﻿
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
using Microsoft.AspNetCore.Mvc;

namespace Restaurant.BusinessLogic.Services.Implementations
{
    public class CartItemService : ICartItemService
    {
        private readonly UserManager<Customer> _userManager;
        private readonly IGenericRepo<CartItem> _genericRepoCartItem;
        private readonly IGenericRepo<Order> _genericRepoOrder;

        public CartItemService(IGenericRepo<CartItem> genericRepo, UserManager<Customer> userManager, IGenericRepo<Order> genericRepoOrder)
        {
            _genericRepoCartItem = genericRepo;
            _userManager = userManager;
            _genericRepoOrder = genericRepoOrder;
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

        public async Task<GenericResponse<int>> GetActiveCartItemAsync(Guid editCartItemRequestDTO)
        {
            int count = 0;
            var customer = await _userManager.FindByIdAsync(editCartItemRequestDTO.ToString());
            if (customer != null)
            {
                var cartItemExist = await _genericRepoCartItem.GetAllAsync();
                if (cartItemExist != null)
                {


                    foreach (var item in cartItemExist)

                    {
                        if (new Guid(customer.Id) == item.CustomerId)
                        {
                            count++;
                        }
                    }

                    if (count != 0)
                    {
                        return GenericResponse<int>.SuccessResponse(count, "Successful");
                    }
                    else
                    {
                        return GenericResponse<int>.ErrorResponse("No Cart Item Found");
                    }

                }
                return GenericResponse<int>.ErrorResponse("Cart Item Not Reachable");
            }
            return GenericResponse<int>.ErrorResponse("No User Found");

        }


      

        public async Task<GenericResponse<string>> UpdateOrderAndOrderItemAsync(CheckoutRequestDTO checkoutRequestDTO)
        {
            //Guid oderItemId = Guid.Empty;

            var newOrder = new Order
            {
                CreatedBy = checkoutRequestDTO.CustomerId,
                CustomerId = checkoutRequestDTO.CustomerId,
                CreatedAt = DateTime.Now,
                OrderDate = DateTime.Now,
                TotalAmount = checkoutRequestDTO.TotalAmount,
            };

            foreach (var item in checkoutRequestDTO.Items)
            {
                var newOrderItem = new OrderItem
                {
                    Quantity = item.Quantity,
                    OrderId = newOrder.Id,
                    ProductId = item.ProductId,
                };

                newOrder.OrderItems.Add(newOrderItem);
            }

            bool sucess = await _genericRepoOrder.InsertAsync(newOrder);

            if (sucess)
            {
                return GenericResponse<string>.SuccessResponse($"{newOrder.Id}");
            }
            else
            {
                return GenericResponse<string>.ErrorResponse("fail");
            }
        }
    }
}