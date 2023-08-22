using Microsoft.AspNetCore.Identity;
using Restaurant.BusinessLogic.Services.Interfaces;
using Restaurant.Data.Entities;
using Restaurant.Data.Repository.Interface;
using Restaurant.DTO.Request;
using Restaurant.DTO.Response;
using Restaurant.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentDTO = Restaurant.DTO.Request.PaymentDTO;

namespace Restaurant.BusinessLogic.Services.Implementations
{
    public class PaymentService : IPaymentService
    {

        private readonly IGenericRepo<Payment> _genericRepo;

        public PaymentService(IGenericRepo<Payment> genericRepo)
        {
            _genericRepo = genericRepo;
        }


        public async Task<GenericResponse<PaymentDTO>> RegistrationAsync(CustomerRegistrationDTO traineeRegistrationDTO)
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
                var registrationResult = new PaymentDTO()
                {
                    Id = trainee.Id,
                    Email = traineeRegistrationDTO.Email,
                    FullName = $"{trainee.FirstName} {trainee.LastName}",
                    Token = emailToken
                };

                return GenericResponse<PaymentDTO>.SuccessResponse(registrationResult, "Registration successful");
            }
            else
            {
                string errors = result.Errors.Aggregate(string.Empty, (current, error) => current + (error.Description + Environment.NewLine));
                return GenericResponse<PaymentDTO>.ErrorResponse(errors, false);
            }
        }

    }
}
