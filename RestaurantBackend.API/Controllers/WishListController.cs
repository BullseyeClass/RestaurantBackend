﻿using Microsoft.AspNetCore.Mvc;
using Restaurant.BusinessLogic.Services.Interfaces;
using Restaurant.Data.Entities;
using Restaurant.Data.Repository.Implementation;
using Restaurant.DTO;
using Restaurant.DTO.Request;
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
    }
}
