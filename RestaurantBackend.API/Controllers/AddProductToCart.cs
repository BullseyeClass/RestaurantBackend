using Microsoft.AspNetCore.Mvc;
using Restaurant.BusinessLogic.Services.Interfaces;
using Restaurant.DTO.Request;
using Restaurant.DTO.Response;
using Restaurant.DTO;

namespace Restaurant.API.Controllers
{
    public class AddProductToCart : ControllerBase
    {
        public readonly IAddProductToCart _addProductToCart;
        public AddProductToCart(IAddProductToCart addProductToCart)
        {
            _addProductToCart = addProductToCart;
        }

        [HttpPost("AddProductToCart")]
        [ProducesResponseType(typeof(GenericResponse<CustomerRegistrationResponseDTO>), 200)]

        public async Task<IActionResult> RegisterAsync(Guid id, string email)
        {
            var response = await _addProductToCart.AddProductToCartAsync(email, id);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}
