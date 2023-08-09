﻿using BootCamp.BusinessLogic.Services.Interfaces;
using BootCamp.Data.Repository.Interface;
using Microsoft.AspNetCore.Identity;
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


        public async Task<GenericResponse<CustomerRegistrationResponseDTO>> RegistrationAsync(CustomerRegistrationDTO traineeRegistrationDTO)
        {
            Customer trainee = new Customer()
            {
                FirstName = traineeRegistrationDTO.FirstName,
                LastName = traineeRegistrationDTO.LastName,
                Email = traineeRegistrationDTO.Email,
                UserName = traineeRegistrationDTO.Email.Split('@')[0], 
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

    }
}