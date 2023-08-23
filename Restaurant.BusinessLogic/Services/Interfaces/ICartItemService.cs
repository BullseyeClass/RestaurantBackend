using Restaurant.DTO;
using Restaurant.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BusinessLogic.Services.Interfaces
{
    public interface ICartItemService
    {
        Task<GenericResponse<string>> AddProductToCartAsync(AddingProductToCartRequestDTO addingProductToCartRequestDTO);
        Task<GenericResponse<string>> DeleteProductFromCartAsync(DeleteCartItemRequestDTO deleteCartItemRequestDTO);
        Task<GenericResponse<string>> UpdateCartAsync(EditCartItemRequestDTO editCartItemRequestDTO);
        Task<GenericResponse<int>> GetActiveCartItemAsync(Guid editCartItemRequestDTO);
    }
}
