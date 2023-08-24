using Microsoft.AspNetCore.Mvc;
using Restaurant.BusinessLogic.Services.Implementations;
using Restaurant.BusinessLogic.Services.Interfaces;
using Restaurant.Data.Entities;
using Restaurant.Data.Repository.Implementation;
using Restaurant.DTO;
using Restaurant.DTO.Request;
using Restaurant.DTO.Response;
using System.Security.Claims;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private readonly IWishListService _wishListService;

        public WishListController(IWishListService wishListService)
        {
            this._wishListService = wishListService;
        }

        [HttpPost("AddWishList/{ProductId}")]
        public async Task<IActionResult> AddWishList(Guid ProductId)
        {
            var userId = HttpContext.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value;

            CreatingWishlistRequestDTO model = new()
            {
                ProductId = ProductId,
                CustomerId = userId,

            };
            GenericResponse<string> generic = await _wishListService.CreateWishListAsync(model);

            if (generic != null && generic.Success)
            {
                return Ok(generic);
            }

            return BadRequest(generic);
        }

        [HttpGet("AllWishList")]
        [ProducesResponseType(typeof(GenericResponse<GetWishListResponseDTO>), 200)]
        public async Task<IActionResult> GetWishList()
        {
           
                var response = await _wishListService.GetAllWishListAsync();

                if (response.Success)
                {
                    return Ok(response.Data);
                }

                return BadRequest(response);
            
        }

        [HttpDelete("DeleteWishList/{AddressId}")]
        [ProducesResponseType(typeof(GenericResponse<string>), 200)]
        public async Task<IActionResult> DeleteWishLISTAsync(Guid Id)
        {
            DeleteWishListItemRequestDTO deleteWishListRequestDTO = new()
            {
                WishListItemId = Id
            };
            var response = await _wishListService.DeleteAddressAsync(deleteWishListRequestDTO);

            if (response.Success)
            {
                return Ok(response.Data);
            }

            return BadRequest(response);
        }
    }
}
