using Restaurant.BusinessLogic.Services.Interfaces;
using Restaurant.Data.Entities;
using Restaurant.Data.Repository.Interface;
using Restaurant.DTO;
using Restaurant.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BusinessLogic.Services.Implementations
{
    public class ProductsFiltering : IProductsFiltering
    {
        private readonly IGenericRepo<Product> _genericRepoProduct;
        public ProductsFiltering(IGenericRepo<Product> genericRepoProduct)
        {
            _genericRepoProduct = genericRepoProduct;
        }

        public async Task<GenericResponse<List<FilterProductDTO>>> GetAllProduct()
        {
            var allProduct = await _genericRepoProduct.GetAllAsync();


            if (allProduct != null)
            {
                List<FilterProductDTO> filterProductDTOList = new();

                foreach (var product in allProduct)
                {
                    FilterProductDTO filterProductDTO = new()
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
                        QuantityInStock = product.QuantityInStock
                    };
                    filterProductDTOList.Add(filterProductDTO);
                };
                return GenericResponse<List<FilterProductDTO>>.SuccessResponse(filterProductDTOList, "Successful");
            }
            return GenericResponse<List<FilterProductDTO>>.ErrorResponse("No Product Found");

        }

        public async Task<GenericResponse<List<FilterProductDTO>>> GetBestDealProduct()
        {
            var allProduct = await _genericRepoProduct.GetAllAsync();


            if (allProduct != null)
            {
                List<FilterProductDTO> filterProductDTOList = new();

                foreach (var product in allProduct)
                {
                    if (product.BestDeal == true)
                    {
                        FilterProductDTO filterProductDTO = new()
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
                            QuantityInStock = product.QuantityInStock
                        };
                        filterProductDTOList.Add(filterProductDTO);
                    }

                };
                return GenericResponse<List<FilterProductDTO>>.SuccessResponse(filterProductDTOList, "Successful");
            }
            return GenericResponse<List<FilterProductDTO>>.ErrorResponse("No Product Found");

        }


        public async Task<GenericResponse<List<FilterProductDTO>>> GetMostPopularProduct()
        {
            var allProduct = await _genericRepoProduct.GetAllAsync();


            if (allProduct != null)
            {
                List<FilterProductDTO> filterProductDTOList = new();

                foreach (var product in allProduct)
                {
                    if (product.MostPopular == true)
                    {
                        FilterProductDTO filterProductDTO = new()
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
                            QuantityInStock = product.QuantityInStock
                        };
                        filterProductDTOList.Add(filterProductDTO);
                    }

                };
                return GenericResponse<List<FilterProductDTO>>.SuccessResponse(filterProductDTOList, "Successful");
            }
            return GenericResponse<List<FilterProductDTO>>.ErrorResponse("No Product Found");

        }


        public async Task<GenericResponse<List<FilterProductDTO>>> GetAllVegetableProduct()
        {
            var allProduct = await _genericRepoProduct.GetAllAsync();


            if (allProduct != null)
            {
                List<FilterProductDTO> filterProductDTOList = new();

                foreach (var product in allProduct)
                {
                    if (product.Tag == "Vegetables")
                    {
                        FilterProductDTO filterProductDTO = new()
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
                            QuantityInStock = product.QuantityInStock
                        };
                        filterProductDTOList.Add(filterProductDTO);
                    }
                    
                };
                return GenericResponse<List<FilterProductDTO>>.SuccessResponse(filterProductDTOList, "Successful");
            }
            return GenericResponse<List<FilterProductDTO>>.ErrorResponse("No Product Found");

        }

        public async Task<GenericResponse<List<FilterProductDTO>>> GetAllFishandSeafoodProduct()
        {
            var allProduct = await _genericRepoProduct.GetAllAsync();


            if (allProduct != null)
            {
                List<FilterProductDTO> filterProductDTOList = new();

                foreach (var product in allProduct)
                {
                    if (product.Tag == "Fish & Seafood")
                    {
                        FilterProductDTO filterProductDTO = new()
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
                            QuantityInStock = product.QuantityInStock
                        };
                        filterProductDTOList.Add(filterProductDTO);
                    }

                };
                return GenericResponse<List<FilterProductDTO>>.SuccessResponse(filterProductDTOList, "Successful");
            }
            return GenericResponse<List<FilterProductDTO>>.ErrorResponse("No Product Found");

        }

        public async Task<GenericResponse<List<FilterProductDTO>>> GetAllDairyandEggsProduct()
        {
            var allProduct = await _genericRepoProduct.GetAllAsync();


            if (allProduct != null)
            {
                List<FilterProductDTO> filterProductDTOList = new();

                foreach (var product in allProduct)
                {
                    if (product.Tag == "Dairy & Eggs")
                    {
                        FilterProductDTO filterProductDTO = new()
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
                            QuantityInStock = product.QuantityInStock
                        };
                        filterProductDTOList.Add(filterProductDTO);
                    }

                };
                return GenericResponse<List<FilterProductDTO>>.SuccessResponse(filterProductDTOList, "Successful");
            }
            return GenericResponse<List<FilterProductDTO>>.ErrorResponse("No Product Found");

        }

        public async Task<GenericResponse<List<FilterProductDTO>>> GetAllBakeryProduct()
        {
            var allProduct = await _genericRepoProduct.GetAllAsync();


            if (allProduct != null)
            {
                List<FilterProductDTO> filterProductDTOList = new();

                foreach (var product in allProduct)
                {
                    if (product.Tag == "Bakery")
                    {
                        FilterProductDTO filterProductDTO = new()
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
                            QuantityInStock = product.QuantityInStock
                        };
                        filterProductDTOList.Add(filterProductDTO);
                    }

                };
                return GenericResponse<List<FilterProductDTO>>.SuccessResponse(filterProductDTOList, "Successful");
            }
            return GenericResponse<List<FilterProductDTO>>.ErrorResponse("No Product Found");

        }

        //public async Task<GenericResponse<List<FilterProductDTO>>> GetAllProduct()
        //{
        //    var allProduct = await _genericRepoProduct.GetAllAsync();

        //    if (allProduct != null)
        //    {
        //        List<FilterProductDTO> filterProductDTOList = new();

        //        foreach (var product in allProduct)
        //        {
        //            FilterProductDTO filterProductDTO = new()
        //            {
        //                Id = product.Id,
        //                Name = product.Name,
        //                Category = product.Category,
        //                Tag = product.Tag,
        //                Image = product.Image,
        //                SKU = product.SKU,
        //                MostPopular = product.MostPopular,
        //                BestDeal = product.BestDeal,
        //                Price = product.Price,
        //                DiscountedPrice = product.DiscountedPrice,
        //                ProductInfo = product.ProductInfo,
        //                ReturnPolicy = product.ReturnPolicy,
        //                DeliveryInfo = product.DeliveryInfo,
        //                QuantityInStock = product.QuantityInStock
        //            };

        //            filterProductDTOList.Add(filterProductDTO);
        //        }

        //        return GenericResponse<List<FilterProductDTO>>.SuccessResponse(filterProductDTOList, "Successful");
        //    }

        //    return GenericResponse<List<FilterProductDTO>>.ErrorResponse("No Product Found");
        //}

    }
}
