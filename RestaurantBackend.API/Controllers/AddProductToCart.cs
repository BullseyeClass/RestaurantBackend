using Microsoft.AspNetCore.Mvc;
using Restaurant.BusinessLogic.Services.Interfaces;
using Restaurant.DTO.Request;
using Restaurant.DTO.Response;
using Restaurant.DTO;
using Restaurant.BusinessLogic.Services.Implementations;

namespace Restaurant.API.Controllers
{
    public class AddProductToCart : ControllerBase
    {
        public readonly IAddProductToCart _addProductToCart;
        public AddProductToCart(IAddProductToCart addProductToCart)
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
                return Ok(generic);
            }

            return BadRequest(generic);
        }
    }
}
