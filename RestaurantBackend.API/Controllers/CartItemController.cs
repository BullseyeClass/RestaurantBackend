using Microsoft.AspNetCore.Mvc;
using Restaurant.BusinessLogic.Services.Interfaces;
using Restaurant.DTO.Request;
using Restaurant.DTO.Response;
using Restaurant.DTO;
using Restaurant.BusinessLogic.Services.Implementations;
using System.Security.Claims;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItem : ControllerBase
    {
        public readonly ICartItemService _addProductToCart;
        public CartItem(ICartItemService addProductToCart)
        {
            _addProductToCart = addProductToCart;
        }


        [HttpPost("AddProductToCart/{ProductId}")]
        public async Task<IActionResult> AddingProductToCart(Guid ProductId, int quantity)
        {
            var userId = HttpContext.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value;

            AddingProductToCartRequestDTO model = new()
            {
                Quantity= quantity,
                ProductId = ProductId,
                CustomerId = Guid.Parse(userId),

            };
            GenericResponse<string> generic = await _addProductToCart.AddProductToCartAsync(model);

            if (generic != null && generic.Success)
            {
                return Ok(generic.Message);
            }

            return BadRequest(generic);
        }

        [HttpDelete("DeleteCartItem/{CartItemId}")]
        [ProducesResponseType(typeof(GenericResponse<string>), 200)]
        public async Task<IActionResult> DeleteCartItemAsync(Guid CartItemId)
        {
            DeleteCartItemRequestDTO deleteCartItemRequestDTO =  new ()
            {
                CartItemId = CartItemId
            };
            var response = await _addProductToCart.DeleteProductFromCartAsync(deleteCartItemRequestDTO);

            if (response.Success)
            {
                return Ok(response.Data);
            }

            return BadRequest(response);
        }

        [HttpPut("DUpdateCartItem/{CartItemId}")]
        [ProducesResponseType(typeof(GenericResponse<string>), 200)]
        public async Task<IActionResult> DUpdateCartItemAsync(Guid CartItemId, [FromBody] EditCartItemRequestDTO editCartItemRequestDTO)
        {

            var userId = HttpContext.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value;

            editCartItemRequestDTO.CartItemId = CartItemId;
            editCartItemRequestDTO.UpdatedBy = Guid.Parse(userId);
            editCartItemRequestDTO.UpdatedAt = DateTime.Now;


            var response = await _addProductToCart.UpdateCartAsync(editCartItemRequestDTO);

            if (response.Success)
            {
                return Ok(response.Data);
            }

            return BadRequest(response);
        }

        [HttpGet("GetAllActiveCartCount")]
        [ProducesResponseType(typeof(GenericResponse<int>), 200)]

        public async Task<IActionResult> GetAllActiveCartCount(Guid guids)
        {
            var result = await _addProductToCart.GetActiveCartItemAsync(guids);

            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }

        [HttpPost("UpdateOrders")]
        [ProducesResponseType(typeof(GenericResponse<string>), 200)]
        public async Task<IActionResult> UpdateOrdersAsync([FromBody] CheckoutRequestDTO checkoutRequestDTO)
        {

            var userId = HttpContext.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value;

            checkoutRequestDTO.CustomerId = Guid.Parse(userId);


            var response = await _addProductToCart.UpdateOrderAndOrderItemAsync(checkoutRequestDTO);

            if (response.Success)
            {
                return Ok(response.Data);
            }

            return BadRequest(response);
        }
    }
}
