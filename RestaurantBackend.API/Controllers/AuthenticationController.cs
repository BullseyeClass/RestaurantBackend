using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.DTO.Request;
using Restaurant.DTO.Response;
using Restaurant.DTO;
using BootCamp.BusinessLogic.Services.Interfaces;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthentication _authenticationService;

        public AuthenticationController(IAuthentication authentication)
        {
            _authenticationService = authentication;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(GenericResponse<LoginResponseDTO>), 200)]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequestDTO userRequest)
        {
            var response = await _authenticationService.LoginAsync(userRequest);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
