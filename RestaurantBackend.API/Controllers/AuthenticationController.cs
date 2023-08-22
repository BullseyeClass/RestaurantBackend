using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.DTO.Request;
using Restaurant.DTO.Response;
using Restaurant.DTO;
using Restaurant.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Restaurant.Data.Entities;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthentication _authenticationService;
        private readonly UserManager<Customer> _userManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IAuthentication authentication, UserManager<Customer> userManager, IConfiguration configuration)
        {
            _authenticationService = authentication;
            _userManager = userManager;
            _configuration = configuration;
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
            return BadRequest(response.Message);
        }

    }
}
