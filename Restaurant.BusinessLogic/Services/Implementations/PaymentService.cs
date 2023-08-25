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
using Microsoft.Extensions.Configuration;
using PayStack.Net;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.BusinessLogic.Services.Implementations
{
    public class PaymentService : IPaymentService
    {

        private readonly IGenericRepo<Payment> _genericPaymentRepo;
        private readonly IGenericRepo<Order> _genericOrderRepo;
        private readonly string token;
        private readonly IConfiguration _configuration;
        private readonly UserManager<Customer> _userManager;

        private PayStackApi Paystack { get; set; }


        public PaymentService(IGenericRepo<Payment> genericRepo, IConfiguration configuration, IGenericRepo<Order> genericOrderRepo)
        {
            _genericPaymentRepo = genericRepo;
            _configuration = configuration;
            _genericOrderRepo = genericOrderRepo;
        }


        public async Task<GenericResponse<string>> PaymentAsync(PaymentRequestDTO paymentRequestDTO)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(paymentRequestDTO.CustomerId.ToString());

                if(user == null)
                {
                    // Create Paystack payment request
                    var paystackRequest = new TransactionInitializeRequest
                    {
                        AmountInKobo = (int)paymentRequestDTO.Amount * 100,
                        Email = paymentRequestDTO.Email,
                        Reference = GenerateReference().ToString(),
                        Currency = "NGN",
                        CallbackUrl = "https://localhost:7159/Donate/Verify"
                    };

                    TransactionInitializeResponse response = Paystack.Transactions.Initialize(paystackRequest);
                    if (response.Status)
                    {
                        var transaction = new Payment()
                        {
                            Id = paymentRequestDTO.Id,
                            Name = paymentRequestDTO.Name,
                            Amount = paymentRequestDTO.Amount,
                            TrxRef = paystackRequest.Reference,
                            Email = paymentRequestDTO.Email,
                            //Status = response.Status,
                            PaymentDate = DateTime.Now,
                            PaymentMethod = "PayStack",
                        };
                        bool success = await _genericPaymentRepo.InsertAsync(transaction);

                        if (success)
                        {
                            return GenericResponse<string>.SuccessResponse(response.Data.AuthorizationUrl);
                        }

                        return GenericResponse<string>.ErrorResponse($"Payment failed");

                    }

                    return GenericResponse<string>.ErrorResponse($"Customer Not Found");
                }
                else
                {
                    return GenericResponse<string>.ErrorResponse($"User not found");
                }



            }
            catch (Exception ex)
            {
                return GenericResponse<string>.ErrorResponse(ex.Message, false);
            }
        }


        public async Task<GenericResponse<string>> VerifyAsync(string reference, Guid Id)
        {
            TransactionVerifyResponse response = Paystack.Transactions.Verify(reference);

            if (response.Data.Status == "success")
            {
                var allTransaction = await _genericPaymentRepo.GetAllAsync();
                var transaction = allTransaction.Where(x => x.TrxRef == reference).FirstOrDefault();

                if (transaction != null)
                {
                    transaction.Status = true;

                    var updateOrder = new Order()
                    {
                        OrderDate = DateTime.Now,
                        //TotalAmount =,
                        CustomerId = Id,
                    };

                    bool success = await _genericOrderRepo.InsertAsync(updateOrder);

                    if (success)
                    {
                        return GenericResponse<string>.SuccessResponse("Your Order was successful");
                    }

                    return GenericResponse<string>.ErrorResponse($"Order failed");
           
                }
                else
                {
                    return GenericResponse<string>.ErrorResponse($"No transaction found");
                }
            }
            else
            {
                return GenericResponse<string>.ErrorResponse($"Transaction failed");
            }
           
        }

        public static int GenerateReference()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            return rand.Next(100000000, 999999999);
        }

    }
}
