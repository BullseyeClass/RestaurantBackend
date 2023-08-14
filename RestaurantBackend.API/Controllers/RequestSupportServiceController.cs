using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BusinessLogic.Services.Implementations;
using Restaurant.BusinessLogic.Services.Interfaces;
using Restaurant.DTO;
using Restaurant.DTO.Request;
using Restaurant.DTO.Response;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestSupportServiceController : Controller
    {
        private readonly IRequestSupportService _request;

        public RequestSupportServiceController(IRequestSupportService request)
        {
            _request = request;
        }

        [HttpPost("RequestSupport")]
        [ProducesResponseType(typeof(GenericResponse<RequestingCustomerSupportDTO>), 200)]
        public async Task<ActionResult> RequestSupport(IFormCollection collection)
        {
            var userId = "c1b2a3d4-5678-90e1-f2ab-c3de4f567890";

            RequestingCustomerSupportDTO support = new()
            {
                CustomerId = userId,



            };

            GenericResponse<string> generic = await _request.RequestSupportAsync(support);

            if (generic != null && generic.Success)
            {
                return Ok(generic);
            }

            return BadRequest(generic);
        }
    }
}
