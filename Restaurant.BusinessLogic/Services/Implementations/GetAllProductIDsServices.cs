using Restaurant.BusinessLogic.Services.Interfaces;
using Restaurant.Data.Entities;
using Restaurant.Data.Repository.Interface;
using Restaurant.DTO;
using Restaurant.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BusinessLogic.Services.Implementations
{
    public class GetAllProductIDsServices : IGetAllProductID
    {
        private readonly IGenericRepo<Product> _genericRepo;

        public GetAllProductIDsServices(IGenericRepo<Product> genericRepo)
        {
            _genericRepo = genericRepo;
        }
        public async Task<GenericResponse<List<GetAllProductIDsDTO>>> GetAllProductID(List<Guid> guids)
        {
            List<Product> allProductIds = new();

            foreach (var item in guids)
            {
                Product allProductID = await _genericRepo.GetByIdAysnc(item);
                if(allProductID != null)
                {
                    allProductIds.Add(allProductID);
                }
            } 
           
            if(allProductIds != null)
            {
                List<GetAllProductIDsDTO> returnAllProductById  = new();

                foreach(var product in allProductIds)
                {
                    GetAllProductIDsDTO getAllProductIDsDTO = new()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Category = product.Category,
                        Tag = product.Tag,
                        Image = product.Image,
                        SKU = product.SKU,
                        MostPopular = product.MostPopular,
                        BestDeal = product.BestDeal,
                        Price = product.Price,
                        DiscountedPrice = product.DiscountedPrice,
                        ProductInfo = product.ProductInfo,
                        ReturnPolicy = product.ReturnPolicy,
                        DeliveryInfo = product.DeliveryInfo,
                        QuantityInStock = product.QuantityInStock,
                    };
                    returnAllProductById.Add(getAllProductIDsDTO);
                };
                return GenericResponse<List<GetAllProductIDsDTO>>.SuccessResponse(returnAllProductById, "Successful");
            }
            return GenericResponse<List<GetAllProductIDsDTO>>.ErrorResponse("No Prouct With these Ids Found");
        }
    }
}
