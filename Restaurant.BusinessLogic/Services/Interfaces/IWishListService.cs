using Restaurant.DTO.Request;
using Restaurant.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BusinessLogic.Services.Interfaces
{
    public interface IWishListService
    {
        Task<GenericResponse<string>> CreateWishListAsync(CreatingWishlistRequestDTO model);
    }
}
