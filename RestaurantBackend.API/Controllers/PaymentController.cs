using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayStack.Net;
using Restaurant.Data.Context;
using Restaurant.DTO.Request;
using System;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly MyAppContext _context;
        private readonly string token;

        private PayStackApi Paystack { get; set; }
        public PaymentController(IConfiguration configuration, MyAppContext context)
        {
            _configuration = configuration;
            _context = context;
            token = _configuration["Payment:PaystackSK"];
            Paystack = new PayStackApi(token);
        }

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost("Payment")]
        public async Task<IActionResult> Payment(PaymentDTO payment)
        {
            TransactionInitializeRequest request = new()
            {
                AmountInKobo = (int)(payment.Amount * 100),
                Email = payment.Email,
                Reference = Generate().ToString(),
                Currency = "NGN",
                CallbackUrl = "https://localhost:7159/Donate/Verify"
            };

            TransactionInitializeResponse response = Paystack.Transactions.Initialize(request);
            if (response.Status)
            {
                var transaction = new OrderDTO()
                {
                    TotalAmount = payment.Amount,
                    Email = payment.Email,
                    TrxRef = request.Reference,
                    Name = payment.Name,
                };
                //await _context.Orders.AddAsync(transaction);
                //await _context.SaveChangesAsync();
                return Redirect(response.Data.AuthorizationUrl);
            }
            return Ok(response);
            //ViewData["error"] = response.Message;
            //return View();
        }

      
        //public IActionResult Donations()
        //{
        //    //var transactions = _context.Orders.Where(x => x.Status == true).ToList();
        //    //ViewData["transactions"] = transactions;
        //    //return View();
        //    return Ok();
        //}

       
        //public async Task<IActionResult> Verify(string reference)
        //{
        //    //TransactionVerifyResponse response = Paystack.Transactions.Verify(reference);
        //    //if (response.Data.Status == "success")
        //    //{
        //    //    var transaction = _context.Orders.Where(x => x.TrxRef == reference).FirstOrDefault();
        //    //    if (transaction != null)
        //    //    {
        //    //        transaction.Status = true;
        //    //        _context.Orders.Update(transaction);
        //    //        await _context.SaveChangesAsync();
        //    //        return RedirectToAction("Donations");
        //    //    }
        //    //}
        //    //ViewData["error"] = response.Data.GatewayResponse;
        //    return RedirectToAction("Index");
        //}

        public static int Generate()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            return rand.Next(100000000, 999999999);
        }
    }
}
