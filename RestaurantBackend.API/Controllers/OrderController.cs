using Microsoft.AspNetCore.Mvc;
using Restaurant.DTO.Response;
using Restaurant.DTO;
using Restaurant.BusinessLogic.Services.Interfaces;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("AllOrder")]
        [ProducesResponseType(typeof(GenericResponse<GetAllOrderResponseDTO>), 200)]
        public async Task<IActionResult> GetOrder()
        {

            var response = await _orderService.GetOrderListAsync();

            if (response.Success)
            {
                return Ok(response.Data);
            }

            return BadRequest(response);

        }
    }
}
