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
        public PaymentController(IConfiguration configuration)
        {
            _configuration = configuration;
            token = _configuration["Payment:PaystackSK"];
            Paystack = new PayStackApi(token);
        }


        //[HttpPost("Payment")]
        //public async Task<IActionResult> Payment(PaymentRequestDTO payment)
        //{

        //    TransactionInitializeRequest request = new()
        //    {
        //        AmountInKobo = (int)(payment.Amount * 100),
        //        Email = payment.Email,
        //        Reference = Generate().ToString(),
        //        Currency = "NGN",
        //        CallbackUrl = "https://localhost:7013/api/Payment/Verify"
        //    };

        //    TransactionInitializeResponse response = Paystack.Transactions.Initialize(request);
        //    if (response.Status)
        //    {
        //        var transaction = new OrderDTO()
        //        {
        //            TotalAmount = payment.Amount,
        //            Email = payment.Email,
        //            TrxRef = request.Reference,
        //            Name = payment.Name,
        //        };
        //        //await _context.Orders.AddAsync(transaction);
        //        //await _context.SaveChangesAsync();
        //        return Ok(response.Data.AuthorizationUrl);
        //    }
        //    return Ok(response);

        //}

        [HttpPost("Payment")]
        [ProducesResponseType(typeof(GenericResponse<string>), 200)]
        public async Task<IActionResult> Payment(PaymentRequestDTO payment)
        {
            var userId = HttpContext.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value;

            payment.CustomerId = Guid.Parse(userId);

            var response = await _paymentService.PaymentAsync(payment);

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

        //    [HttpPost("Verify")]
        //public async Task<IActionResult> Verify(string reference)
        //{
        //    TransactionVerifyResponse response = Paystack.Transactions.Verify(reference);
        //    if (response.Data.Status == "success")
        //    {
        //        //    var transaction = _context.Orders.Where(x => x.TrxRef == reference).FirstOrDefault();
        //        //    if (transaction != null)
        //        //    {
        //        //transaction.Status = true;
        //        //        _context.Orders.Update(transaction);
        //        //        await _context.SaveChangesAsync();
        //        //return RedirectToAction("Payment");
        //        //    }
        //        return Ok(response.Data.Status);
        //    }
        //    //ViewData["error"] = response.Data.GatewayResponse;
        //    return RedirectToAction("Index");
        //}


        //public static int Generate()
        //{
        //    Random rand = new Random((int)DateTime.Now.Ticks);
        //    return rand.Next(100000000, 999999999);
        //}
    }
}
