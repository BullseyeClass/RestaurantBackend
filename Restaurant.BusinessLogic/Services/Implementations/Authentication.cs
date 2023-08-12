using Microsoft.AspNetCore.Identity;
using Restaurant.BusinessLogic.Services.Interfaces;
using Restaurant.Data.Entities;
using Restaurant.Data.Repository.Interface;
using Restaurant.DTO;
using Restaurant.DTO.Request;
using Restaurant.DTO.Response;

namespace BootCamp.BusinessLogic.Services.Implementations
{
    public class Authentication : IAuthentication
    {
        private readonly UserManager<Customer> _userManager;
        private readonly IGenericRepo<Customer> _genericCustomerRepo;
        private readonly ITokenGenerator _tokenGenerator;

        public Authentication(UserManager<Customer> userManager, IGenericRepo<Customer> genericTraineeRepo, ITokenGenerator tokenGenerator)
        {
            this._userManager = userManager;
            this._genericCustomerRepo = genericTraineeRepo;
            this._tokenGenerator = tokenGenerator;
        }

        public async Task<GenericResponse<LoginResponseDTO>> LoginAsync(LoginRequestDTO userRequest)
        {
            var user = await _userManager.FindByEmailAsync(userRequest.Email);
            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, userRequest.Password))
                {
                    if (user.EmailConfirmed)
                    {
                        var userResponse = new LoginResponseDTO
                        {
                            Email = user.Email,
                            FullName = $"{user.FirstName} {user.LastName}",
                            Id = user.Id,
                            Token = await _tokenGenerator.GenerateTokenAsync(user)
                        };

                        return GenericResponse<LoginResponseDTO>.SuccessResponse(userResponse, "Login Successful");
                    }
                    return GenericResponse<LoginResponseDTO>.ErrorResponse("Kindly verify your email address to login", false);
                }
                return GenericResponse<LoginResponseDTO>.ErrorResponse("Invalid credentials", false);
            }
            return GenericResponse<LoginResponseDTO>.ErrorResponse("Invalid Credentials", false);

        }

    }
}
