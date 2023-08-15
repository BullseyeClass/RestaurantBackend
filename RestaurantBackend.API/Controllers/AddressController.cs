using Microsoft.AspNetCore.Mvc;
using Restaurant.BusinessLogic.Services.Interfaces;
using Restaurant.DTO.Request;
using Restaurant.DTO.Response;
using Restaurant.DTO;
using Restaurant.Data.Entities;

namespace Restaurant.API.Controllers
{
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
            var userId = "c1b2a3d4-5678-90e1-f2ab-c3de4f567890";

            var response = await _addressService.AddAddressAsync(userRequest);

            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
