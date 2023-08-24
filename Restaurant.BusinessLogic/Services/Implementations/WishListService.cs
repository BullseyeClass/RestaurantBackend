using Microsoft.AspNetCore.Identity;
using Restaurant.BusinessLogic.Services.Interfaces;
using Restaurant.Data.Entities;
using Restaurant.Data.Repository.Interface;
using Restaurant.DTO;
using Restaurant.DTO.Request;
using Restaurant.DTO.Response;

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

        public async Task<GenericResponse<List<GetWishListResponseDTO>>> GetAllWishListAsync()
        {
            var allWishList = await _genericRepoWishlist.GetAllAsync();

            if (allWishList != null)
            {
                List<GetWishListResponseDTO> filterWishListDTOList = new();

                foreach (var item in allWishList)
                {
                    GetWishListResponseDTO filterwishListDTO = new()
                    {
                        Id = item.Id,
                        CustomerId = item.CustomerId,
                        ProductId = item.ProductId

                    };
                    filterWishListDTOList.Add(filterwishListDTO);
                };
                return GenericResponse<List<GetWishListResponseDTO>>.SuccessResponse(filterWishListDTOList, "WishList Added Successfully");
            }
            return GenericResponse<List<GetWishListResponseDTO>>.ErrorResponse("No WishList Found");

        }


        public async Task<GenericResponse<string>> DeleteAddressAsync(DeleteWishListItemRequestDTO deleteWishListItemRequestDTO)
        {
            var wishListExist = await _genericRepoWishlist.GetByIdAysnc(deleteWishListItemRequestDTO.WishListItemId);

            if (wishListExist != null)
            {
                await _genericRepoWishlist.DeleteAsync(wishListExist);

                return GenericResponse<string>.SuccessResponse("Address Deleted Sucessfully", "Successful");
            }
            return GenericResponse<string>.ErrorResponse("No Address Found");

        }
    }
}
