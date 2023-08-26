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
        private readonly IGenericRepo<Address> _genericRepoAddress;

        public CustomerService(UserManager<Customer> userManager, IGenericRepo<Customer> genericRepo, IGenericRepo<Address> genericRepoAddress)
        {
            this._userManager = userManager;
            this._genericRepo = genericRepo;
            _genericRepoAddress = genericRepoAddress;
        }


        public async Task<GenericResponse<CustomerRegistrationResponseDTO>> RegistrationAsync(CustomerRegistrationDTO traineeRegistrationDTO)
        {

            Customer userExist = await _userManager.FindByEmailAsync(traineeRegistrationDTO.Email);

            if (userExist != null)
            {
                return GenericResponse<CustomerRegistrationResponseDTO>.ErrorResponse("Email already Exist", false);
            }

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
                var registrationResult = new CustomerRegistrationResponseDTO()
                {
                    Id = trainee.Id,
                    Email = traineeRegistrationDTO.Email,
                    FullName = $"{trainee.FirstName} {trainee.LastName}",
                    Token = emailToken
                };

                return GenericResponse<CustomerRegistrationResponseDTO>.SuccessResponse(registrationResult, "Registration successful");
            }
            else
            {
                string errors = result.Errors.Aggregate(string.Empty, (current, error) => current + (error.Description + Environment.NewLine));
                return GenericResponse<CustomerRegistrationResponseDTO>.ErrorResponse(errors, false);
            }
        }


        public async Task<GenericResponse<List<ReturningUserByIdDTO>>> GettingUserById(string userId)
        {
            Customer customer = await _userManager.FindByIdAsync(userId);

            if (customer == null)
            {
                // Handle the case where the customer is not found.
                return GenericResponse<List<ReturningUserByIdDTO>>.ErrorResponse("Customer not found");
            }

            ReturningUserByIdDTO returningUserByIdDTO = new()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                MiddleName = customer.MiddleName,
                Addresses = new List<AddingAddressResponseDTO>(),
            };

            // Retrieve addresses associated with the customer
            var addresses = await _genericRepoAddress.GetAllAsync();
            var customerAddresses = addresses
                .Where(x => x.CustomerId == Guid.Parse(customer.Id))
                .Select(address => new AddingAddressResponseDTO
                {
                    Id = address.Id,
                    Street = address.Street,
                    City = address.City,
                    State = address.State,
                    PostalCode = address.PostalCode,
                    Country = address.Country,
                    IsShippingAddress = address.IsShippingAddress,
                    CustomerId = address.CustomerId
                    // Map other address-related properties...
                })
                .ToList();

            // Add the customer's addresses to the DTO
            returningUserByIdDTO.Addresses.AddRange(customerAddresses);

            // Create a list for the DTO and add the customer details
            List<ReturningUserByIdDTO> FullUserDetails = new();
            FullUserDetails.Add(returningUserByIdDTO);

            return GenericResponse<List<ReturningUserByIdDTO>>.SuccessResponse(FullUserDetails, "Returning Customer Details");
        }


    }
}
