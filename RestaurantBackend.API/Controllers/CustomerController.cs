using Microsoft.AspNetCore.Mvc;
using Restaurant.BusinessLogic.Services.Interfaces;
using Restaurant.DTO;
using Restaurant.DTO.Request;
using Restaurant.DTO.Response;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _traineeService;

        public CustomerController(ICustomerService customerService)
        {
            _traineeService = customerService;
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(GenericResponse<PaymentDTO>), 200)]

        public async Task<IActionResult> RegisterAsync([FromBody] CustomerRegistrationDTO traineeRegistrationDTO)
        {
            var response = await _traineeService.RegistrationAsync(traineeRegistrationDTO);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}
