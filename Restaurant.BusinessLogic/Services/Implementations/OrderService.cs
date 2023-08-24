using Microsoft.AspNetCore.Identity;
using Restaurant.Data.Entities;
using Restaurant.Data.Repository.Interface;
using Restaurant.DTO.Response;
using Restaurant.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.BusinessLogic.Services.Interfaces;

namespace Restaurant.BusinessLogic.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepo<Order> _genericRepoOrder;
        private readonly UserManager<Customer> _userManager;

        public OrderService(IGenericRepo<Order> genericRepoOrder, UserManager<Customer> userManager)
        {
            _genericRepoOrder = genericRepoOrder;
            _userManager = userManager;
        }


        public async Task<GenericResponse<List<GetAllOrderResponseDTO>>> GetOrderListAsync()
        {
            var allOrder = await _genericRepoOrder.GetAllAsync();

            if (allOrder != null)
            {
                List<GetAllOrderResponseDTO> filterOrderDTOList = new();

                foreach (var item in allOrder)
                {
                    GetAllOrderResponseDTO filterOrderDTO = new()
                    {
                        Id = item.Id,
                        CustomerId = item.CustomerId,
                        OrderDate = item.OrderDate,
                        TotalAmount = item.TotalAmount

                    };
                    filterOrderDTOList.Add(filterOrderDTO);
                };
                return GenericResponse<List<GetAllOrderResponseDTO>>.SuccessResponse(filterOrderDTOList, "Sucessful");
            }
            return GenericResponse<List<GetAllOrderResponseDTO>>.ErrorResponse("No WishList Found");

        }
    }
}
