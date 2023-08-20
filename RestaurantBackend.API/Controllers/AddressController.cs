using Microsoft.AspNetCore.Mvc;
using Restaurant.BusinessLogic.Services.Interfaces;
using Restaurant.DTO.Request;
using Restaurant.DTO.Response;
using Restaurant.DTO;
using Restaurant.Data.Entities;
using Restaurant.BusinessLogic.Services.Implementations;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Restaurant.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        public readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost("AddAddress")]
        [ProducesResponseType(typeof(GenericResponse<AddingAddressResponseDTO>), 200)]
        public async Task<IActionResult> AddAddressAsync([FromBody] AddingAddressRequestDTO userRequest)
        {
            //var userId = "c1b2a3d4-5678-90e1-f2ab-c3de4f567890";
            var userId = HttpContext.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value;

            userRequest.CustomerId = Guid.Parse(userId);

            GenericResponse<AddingAddressResponseDTO> response = await _addressService.AddAddressAsync(userRequest);

            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("GetAllAddress")]
        [ProducesResponseType(typeof(GenericResponse<AddingAddressResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAddressAsync()
        {
            var response = await _addressService.GetAllAddressAsync();

            if (response.Success)
            {
                return Ok(response.Data);
            }

            return BadRequest(response);
        }

        [HttpGet("GetAddressById/{Id}")]
        [ProducesResponseType(typeof(GenericResponse<AddingAddressResponseDTO>), 200)]
        public async Task<IActionResult> GetAddressByIdAsync(Guid Id)
        {
            var response = await _addressService.GetAddressByIdAsync(Id);

            if (response.Success)
            {
                return Ok(response.Data);
            }

            return BadRequest(response);
        }


        [HttpDelete("DeleteAddress/{AddressId}")]
        [ProducesResponseType(typeof(GenericResponse<string>), 200)]
        public async Task<IActionResult> DeleteAddressAsync(Guid AddressId)
        {
            DeleteAddressRequestDTO deleteAddressRequestDTO = new()
            {
                AddressId = AddressId
            };
            var response = await _addressService.DeleteAddressAsync(deleteAddressRequestDTO);

            if (response.Success)
            {
                return Ok(response.Data);
            }

            return BadRequest(response);
        }

        [HttpPut("UpdateAddress/{AddressId}")]
        [ProducesResponseType(typeof(GenericResponse<UpdateAddressResponseDTO>), 200)]
        public async Task<IActionResult> UpdateAddressAsync(Guid AddressId, [FromBody]UpdateAddressRequestDTO updateAddressRequestDTO)
        {

            var userId = "c1b2a3d4-5678-90e1-f2ab-c3de4f567890";

            updateAddressRequestDTO.AddressId = AddressId;
            updateAddressRequestDTO.UpdatedBy = Guid.Parse(userId);
            updateAddressRequestDTO.UpdatedAt = DateTime.Now;


            var response = await _addressService.UpdateAddressAsync(updateAddressRequestDTO);

            if (response.Success)
            {
                return Ok(response.Data);
            }

            return BadRequest(response);
        }
    }
}
