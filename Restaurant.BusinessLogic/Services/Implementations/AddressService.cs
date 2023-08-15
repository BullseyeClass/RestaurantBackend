using Microsoft.AspNetCore.Identity;
using Restaurant.BusinessLogic.Services.Interfaces;
using Restaurant.Data.Entities;
using Restaurant.Data.Repository.Interface;
using Restaurant.DTO;
using Restaurant.DTO.Request;
using Restaurant.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BusinessLogic.Services.Implementations
{
    public class AddressService : IAddressService
    {
        private readonly UserManager<Customer> _userManager;
        private readonly IGenericRepo<Address> _genericRepoAddress;
        public AddressService(UserManager<Customer> userManager, IGenericRepo<Address> genericRepoAddress)
        {
            _userManager = userManager;
            _genericRepoAddress = genericRepoAddress;
        }

        public async Task<GenericResponse<AddingAddressResponseDTO>> AddAddressAsync(AddingAddressRequestDTO addingAddressRequestDTO)
        {
            var user = await _userManager.FindByIdAsync(addingAddressRequestDTO.CustomerId.ToString());

            Address address = new()
            {
                Street = addingAddressRequestDTO.Street,
                City = addingAddressRequestDTO.City,
                State = addingAddressRequestDTO.State,
                PostalCode = addingAddressRequestDTO.PostalCode,
                Country = addingAddressRequestDTO.Country,
                CustomerId = addingAddressRequestDTO.CustomerId,
                IsShippingAddress = addingAddressRequestDTO.IsShippingAddress
            };

            bool success = await _genericRepoAddress.InsertAsync(address);

            if (success)
            {
                var addingAddressResponseDTO = new AddingAddressResponseDTO()
                {
                    Id = address.Id,
                    Street = addingAddressRequestDTO.Street,
                    City = addingAddressRequestDTO.City,
                    State = addingAddressRequestDTO.State,
                    PostalCode = addingAddressRequestDTO.PostalCode,
                    Country = addingAddressRequestDTO.Country,
                    CustomerId = addingAddressRequestDTO.CustomerId,
                    IsShippingAddress = addingAddressRequestDTO.IsShippingAddress

                };

                return GenericResponse<AddingAddressResponseDTO>.SuccessResponse(addingAddressResponseDTO, "Address Added successfully");
            }

            return GenericResponse<AddingAddressResponseDTO>.ErrorResponse("Error, Can't add Address", false);
        }
    }
}