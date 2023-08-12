using Microsoft.AspNetCore.Identity;
using Restaurant.BusinessLogic.Services.Interfaces;
using Restaurant.Data.Entities;
using Restaurant.Data.Repository.Interface;
using Restaurant.DTO;
using Restaurant.DTO.Request;

namespace Restaurant.BusinessLogic.Services.Implementations
{
    public class WishListService : IWishListService
    {
        private readonly IGenericRepo<WishList> _genericRepoWishlist;
        private readonly UserManager<Customer> _userManager;

        public WishListService(IGenericRepo<WishList> genericRepoWishlist, UserManager<Customer> userManager)
        {
            this._genericRepoWishlist = genericRepoWishlist;
            this._userManager = userManager;
        }

        public async Task<GenericResponse<string>> CreateWishListAsync(CreatingWishlistRequestDTO model)
        {
            var user = await _userManager.FindByIdAsync(model.CustomerId);

            WishList wishList = new()
            {
                ProductId = model.ProductId,
                CustomerId = new Guid(user.Id),
                CreatedAt = DateTime.Now,
                CreatedBy = new Guid(model.CustomerId),
                Customer = user,
            };

            bool success = await _genericRepoWishlist.InsertAsync(wishList);

            if (success)
            {
                return GenericResponse<string>.SuccessResponse($"Wishlist has been added sucessfully");
            }

            return GenericResponse<string>.ErrorResponse($"Wishlist has not been added");
        }


    }
}
