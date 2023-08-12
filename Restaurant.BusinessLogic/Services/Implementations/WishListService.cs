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

        public WishListService(IGenericRepo<WishList> genericRepoWishlist)
        {
            this._genericRepoWishlist = genericRepoWishlist;
        }

        public async Task<GenericResponse<string>> CreateWishListAsync(CreatingWishlistRequestDTO model)
        {
            WishList wishList = new()
            {
                ProductId = model.ProductId,
                CustomerId = new Guid(model.CustomerId),
                CreatedAt = DateTime.Now,
                CreatedBy = new Guid(model.CustomerId)
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
