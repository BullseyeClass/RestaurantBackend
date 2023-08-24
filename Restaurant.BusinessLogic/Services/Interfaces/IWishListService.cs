using Restaurant.DTO.Request;
using Restaurant.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.DTO.Response;

namespace Restaurant.BusinessLogic.Services.Interfaces
{
    public interface IWishListService
    {
        Task<GenericResponse<string>> CreateWishListAsync(CreatingWishlistRequestDTO model);
        Task<GenericResponse<string>> DeleteAddressAsync(DeleteWishListItemRequestDTO deleteWishListItemRequestDTO);
        Task<GenericResponse<List<GetWishListResponseDTO>>> GetAllWishListAsync();
    }
}
