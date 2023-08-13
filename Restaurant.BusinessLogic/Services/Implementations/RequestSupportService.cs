using Microsoft.AspNetCore.Identity;
using Restaurant.Data.Entities;
using Restaurant.Data.Repository.Interface;
using Restaurant.DTO.Request;
using Restaurant.DTO.Response;
using Restaurant.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BusinessLogic.Services.Implementations
{

    public class RequestSupportService
    {
        private readonly UserManager<Customer> _userManager;
        private readonly IGenericRepo<CustomerSupport> _genericRepo;

        public RequestSupportService(UserManager<Customer> userManager,IGenericRepo<CustomerSupport> genericRepo)
        {
            _userManager = userManager;
            _genericRepo = genericRepo;
        }


        public async Task<GenericResponse<string>> RequestSupportAsync(RequestingCustomerSupportDTO requestingCustomerSupport)
        {

            var user = await _userManager.FindByIdAsync(requestingCustomerSupport.CustomerId);

            CustomerSupport customerSupport = new CustomerSupport()
            {
                Id = requestingCustomerSupport.Id,
                Message = requestingCustomerSupport.Message,
                CreatedAt = DateTime.Now,
                CreatedBy = new Guid(requestingCustomerSupport.CustomerId),
                Customer = user,
            };

            bool success = await _genericRepo.InsertAsync(customerSupport);

            if (success)
            {
                return GenericResponse<string>.SuccessResponse($"Your message has been sent sucessfully");
            }
            return GenericResponse<string>.ErrorResponse($"Failed to send, please try again");
        }


    }
}
