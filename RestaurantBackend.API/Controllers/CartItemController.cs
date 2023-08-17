using Microsoft.AspNetCore.Mvc;
using Restaurant.BusinessLogic.Services.Interfaces;
using Restaurant.DTO.Request;
using Restaurant.DTO.Response;
using Restaurant.DTO;
using Restaurant.BusinessLogic.Services.Implementations;

namespace Restaurant.API.Controllers
{
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
            var userId = "c1b2a3d4-5678-90e1-f2ab-c3de4f567890";

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

            var userId = "c1b2a3d4-5678-90e1-f2ab-c3de4f567890";

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
    }
}
