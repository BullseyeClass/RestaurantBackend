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
using PaymentRequestDTO = Restaurant.DTO.Request.PaymentRequestDTO;

namespace Restaurant.BusinessLogic.Services.Implementations
{
    public class PaymentService : IPaymentService
    {

        private readonly IGenericRepo<Payment> _genericRepo;

        public PaymentService(IGenericRepo<Payment> genericRepo)
        {
            _genericRepo = genericRepo;
        }


        public async Task<GenericResponse<PaymentResponseDTO>> PaymentAsync(PaymentRequestDTO paymentRequestDTO)
        {
            try
            {
                // Create Paystack payment request
                var paystackRequest = new TransactionInitializeRequest
                {
                    AmountInKobo = paymentRequestDTO.Amount * 100, // Convert Naira to Kobo
                    Email = paymentRequestDTO.Email,
                    Reference = GenerateReference(),
                    Currency = "NGN",
                    CallbackUrl = "https://localhost:7159/Donate/Verify" // Replace with your actual callback URL
                };

                // Call Paystack API to initialize payment
                var paystackResponse = await InitializePaystackTransaction(paystackRequest);

                // Return Paystack response
                return GenericResponse<PaymentResponseDTO>.SuccessResponse(paystackResponse, "Payment initialization successful");
            }
            catch (Exception ex)
            {
                return GenericResponse<PaymentResponseDTO>.ErrorResponse(ex.Message, false);
            }
        }

        public static int GenerateReference()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            return rand.Next(100000000, 999999999);
        }

    }
}
