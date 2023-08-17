using Restaurant.DTO.Request;
using Restaurant.DTO.Response;
using Restaurant.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BusinessLogic.Services.Interfaces
{
    public interface IAddressService
    {
        Task<GenericResponse<AddingAddressResponseDTO>> AddAddressAsync(AddingAddressRequestDTO addingAddressRequestDTO);
        Task<GenericResponse<List<AddingAddressResponseDTO>>> GetAllAddressAsync();
        Task<GenericResponse<string>> DeleteAddressAsync(DeleteAddressRequestDTO deleteAddressRequestDTO);
        Task<GenericResponse<UpdateAddressResponseDTO>> UpdateAddressAsync(UpdateAddressRequestDTO updateAddressRequestDTO);
    }
}
