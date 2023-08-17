using Microsoft.AspNetCore.Identity;
using Restaurant.BusinessLogic.Services.Interfaces;
using Restaurant.Data.Entities;
using Restaurant.Data.Repository.Interface;
using Restaurant.DTO;
using Restaurant.DTO.Request;
using Restaurant.DTO.Response;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
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

        public async Task<GenericResponse<List<AddingAddressResponseDTO>>> GetAllAddressAsync()
        {
            var allAddress = await _genericRepoAddress.GetAllAsync();

            if (allAddress != null)
            {
                List<AddingAddressResponseDTO> filteraddressDTOList = new();

                foreach (var item in allAddress)
                {
                    AddingAddressResponseDTO filteraddressDTO = new()
                    {
                        Id = item.Id,
                        Street = item.Street,
                        City = item.City,
                        State = item.State,
                        PostalCode = item.PostalCode,
                        Country = item.Country,
                        CustomerId = item.CustomerId,
                        IsShippingAddress = item.IsShippingAddress

                    };
                    filteraddressDTOList.Add(filteraddressDTO);
                };
                return GenericResponse<List<AddingAddressResponseDTO>>.SuccessResponse(filteraddressDTOList, "Successful");
            }
            return GenericResponse<List<AddingAddressResponseDTO>>.ErrorResponse("No Product Found");

        }

        public async Task<GenericResponse<string>> DeleteAddressAsync(DeleteAddressRequestDTO deleteAddressRequestDTO)
        {
            var addressExist = await _genericRepoAddress.GetByIdAysnc(deleteAddressRequestDTO.AddressId);

            if (addressExist != null)
            {
                await _genericRepoAddress.DeleteAsync(addressExist);

                return GenericResponse<string>.SuccessResponse("Address Deleted Sucessfully", "Successful");
            }
            return GenericResponse<string>.ErrorResponse("No Address Found");

        }

        public async Task<GenericResponse<UpdateAddressResponseDTO>> UpdateAddressAsync(UpdateAddressRequestDTO updateAddressRequestDTO)
        {
            var addressExist = await _genericRepoAddress.GetByIdAysnc(updateAddressRequestDTO.AddressId);

            if (addressExist != null)
            {
                addressExist.Street = updateAddressRequestDTO.Street;
                addressExist.City = updateAddressRequestDTO.City;
                addressExist.State = updateAddressRequestDTO.State;
                addressExist.PostalCode = updateAddressRequestDTO.PostalCode;
                addressExist.Country = updateAddressRequestDTO.Country;
                addressExist.IsShippingAddress = updateAddressRequestDTO.IsShippingAddress;
                addressExist.UpdatedBy = updateAddressRequestDTO.UpdatedBy;
                addressExist.UpdatedAt = updateAddressRequestDTO.UpdatedAt;

                await _genericRepoAddress.UpdateAsync(addressExist);

                UpdateAddressResponseDTO updateAddressResponseDTO = new()
                {
                    Id = addressExist.Id,
                    Street = updateAddressRequestDTO.Street,
                    City = updateAddressRequestDTO.City,
                    State = updateAddressRequestDTO.State,
                    PostalCode = updateAddressRequestDTO.PostalCode,
                    Country = updateAddressRequestDTO.Country,
                    CustomerId = addressExist.CustomerId,
                    IsShippingAddress = updateAddressRequestDTO.IsShippingAddress,
                    UpdatedAt= updateAddressRequestDTO.UpdatedAt,

                };
                return GenericResponse<UpdateAddressResponseDTO>.SuccessResponse(updateAddressResponseDTO, "Successful");

            }
            return GenericResponse<UpdateAddressResponseDTO>.ErrorResponse("No Address Found");

        }
    }
}