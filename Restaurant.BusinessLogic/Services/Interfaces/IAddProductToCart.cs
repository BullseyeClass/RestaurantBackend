using Restaurant.DTO;
using Restaurant.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BusinessLogic.Services.Interfaces
{
    public interface IAddProductToCart
    {
        Task<GenericResponse<string>> AddProductToCartAsync(AddingProductToCartRequestDTO addingProductToCartRequestDTO);
    }
}
