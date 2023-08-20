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
            return BadRequest(response);
        }

        //[HttpPost]
        //[Route("login")]
        //public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginDTO)
        //{

        //    var user = await _userManager.FindByEmailAsync(loginDTO.Email);

        //    if (user != null && await _userManager.CheckPasswordAsync(user, loginDTO.Password))
        //    {
        //        var userRoles = await _userManager.GetRolesAsync(user);
        //        var authClaims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, user.UserName),
        //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //        };

        //        foreach (var userRole in userRoles)
        //        {
        //            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        //        }

        //        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTSettings:Secretkey"]));

        //        var token = new JwtSecurityToken(
        //            issuer: _configuration["JWTSettings:Issuer"],
        //            audience: _configuration["JWTSettings:Audience"],
        //            expires: DateTime.Now.AddHours(3),
        //            claims: authClaims,
        //            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        //        );

        //        return Ok(new
        //        {
        //            token = new JwtSecurityTokenHandler().WriteToken(token),
        //            expiration = token.ValidTo
        //        });
        //    }
        //    return Unauthorized();
        //}
    }
}
