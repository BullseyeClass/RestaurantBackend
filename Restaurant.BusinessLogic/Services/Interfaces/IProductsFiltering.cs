using Restaurant.DTO;
using Restaurant.DTO.Request;
using Restaurant.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BusinessLogic.Services.Interfaces
{
    public interface IProductsFiltering
    {
        Task<GenericResponse<List<FilterProductDTO>>> GetAllProduct();
        Task<GenericResponse<List<FilterProductDTO>>> GetBestDealProduct();
        Task<GenericResponse<List<FilterProductDTO>>> GetMostPopularProduct();
        Task<GenericResponse<List<FilterProductDTO>>> GetAllVegetableProduct();
        Task<GenericResponse<List<FilterProductDTO>>> GetAllFishandSeafoodProduct();
        Task<GenericResponse<List<FilterProductDTO>>> GetAllDairyandEggsProduct();
        Task<GenericResponse<List<FilterProductDTO>>> GetAllBakeryProduct();
        Task<GenericResponse<GetProductByIdResponseDTO>> GetProductByIdAsync(Guid guid);
    }
}
