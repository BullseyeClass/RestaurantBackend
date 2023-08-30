using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayStack.Net;
using Restaurant.BusinessLogic.Services.Interfaces;
using Restaurant.Data.Context;
using Restaurant.Data.Entities;
using Restaurant.DTO;
using Restaurant.DTO.Request;
using System;
using System.Security.Claims;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string token;
        public readonly IPaymentService _paymentService;

        private PayStackApi Paystack { get; set; }
        public PaymentController(IConfiguration configuration, IPaymentService paymentService)
        {
            _configuration = configuration;
            token = _configuration["Payment:PaystackSK"];
            Paystack = new PayStackApi(token);
            _paymentService = paymentService;
        }


        [HttpPost("Payment/{OrderId}")]
        [ProducesResponseType(typeof(GenericResponse<string>), 200)]
        public async Task<IActionResult> Payment(PaymentRequestDTO payment, Guid OrderId)
        {
            var userId = HttpContext.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value;

            payment.CustomerId = Guid.Parse(userId);

            var response = await _paymentService.PaymentAsync(payment, OrderId);

            if (response.Success)
            {
                return Ok(response.Data);
            }

            return BadRequest(response);

        }

        [HttpPost("Verify")]
        [ProducesResponseType(typeof(GenericResponse<string>), 200)]
        public async Task<IActionResult> Verify(string reference)
        {
            var userId = HttpContext.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value;

            var response = await _paymentService.VerifyAsync(reference, Guid.Parse(userId));

            if (response.Success)
            {
                return Ok(response.Data);
            }

            return BadRequest(response);

        }
    }
}
