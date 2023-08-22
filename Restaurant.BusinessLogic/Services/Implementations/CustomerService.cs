using Restaurant.Data.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using Restaurant.BusinessLogic.Services.Interfaces;
using Restaurant.Data.Entities;
using Restaurant.DTO;
using Restaurant.DTO.Request;
using Restaurant.DTO.Response;

namespace Restaurant.BusinessLogic.Services.Implementations
{

    public class CustomerService : ICustomerService
    {
        private readonly UserManager<Customer> _userManager;
        private readonly IGenericRepo<Customer> _genericRepo;

        public CustomerService(UserManager<Customer> userManager, IGenericRepo<Customer> genericRepo)
        {
            this._userManager = userManager;
            this._genericRepo = genericRepo;
        }


        public async Task<GenericResponse<CustomerRegistrationDTO>> RegistrationAsync(CustomerRegistrationDTO traineeRegistrationDTO)
        {
            Customer trainee = new Customer()
            {
                FirstName = traineeRegistrationDTO.FirstName,
                LastName = traineeRegistrationDTO.LastName,
                Email = traineeRegistrationDTO.Email,
                UserName = traineeRegistrationDTO.Email.Split('@')[0],
                EmailConfirmed = true
            };

            IdentityResult result = await _userManager.CreateAsync(trainee, traineeRegistrationDTO.Password);

            if (result.Succeeded)
            {
                var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(trainee);
                var registrationResult = new CustomerRegistrationDTO()
                {
                    Id = trainee.Id,
                    Email = traineeRegistrationDTO.Email,
                    FullName = $"{trainee.FirstName} {trainee.LastName}",
                    Token = emailToken
                };

                return GenericResponse<CustomerRegistrationDTO>.SuccessResponse(registrationResult, "Registration successful");
            }
            else
            {
                string errors = result.Errors.Aggregate(string.Empty, (current, error) => current + (error.Description + Environment.NewLine));
                return GenericResponse<CustomerRegistrationDTO>.ErrorResponse(errors, false);
            }
        }


        public async Task<GenericResponse<ReturningUserByIdDTO>> GettingUserById(string userId)
        {
            Customer customer = await _userManager.FindByIdAsync(userId);

            ReturningUserByIdDTO returningUserByIdDTO = new()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                MiddleName = customer.MiddleName,
            };
            if (customer != null)
            {
                return GenericResponse<ReturningUserByIdDTO>.SuccessResponse(returningUserByIdDTO, "Returning Customer Details");
            }

            return GenericResponse<ReturningUserByIdDTO>.ErrorResponse("Customer Details empty");
        }
    }
}

