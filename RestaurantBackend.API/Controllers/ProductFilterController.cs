using Microsoft.AspNetCore.Mvc;
using Restaurant.BusinessLogic.Services.Interfaces;
using Restaurant.DTO.Response;
using Restaurant.DTO;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductFilterController : ControllerBase
    {
        private readonly IProductsFiltering _productsFiltering;
        public ProductFilterController(IProductsFiltering productsFiltering)
        {
            _productsFiltering = productsFiltering;
        }

        [HttpGet("AllProduct")]
        [ProducesResponseType(typeof(GenericResponse<FilterProductDTO>), 200)]
        public async Task<IActionResult> FilterAllProduct()
        {
            var response = await _productsFiltering.GetAllProduct();

            if (response.Success)
            {
                return Ok(response.Data);
            }

            return BadRequest(response);
        }

        [HttpGet("ProductById/{ProductId}")]
        [ProducesResponseType(typeof(GenericResponse<GetProductByIdResponseDTO>), 200)]
        public async Task<IActionResult> GetProductById(Guid ProductId)
        {
            var response = await _productsFiltering.GetProductByIdAsync(ProductId);

            if (response.Success)
            {
                return Ok(response.Data);
            }

            return BadRequest(response);
        }

        [HttpGet("BestDealProduct")]
        [ProducesResponseType(typeof(GenericResponse<FilterProductDTO>), 200)]
        public async Task<IActionResult> FilterBestDealProduct()
        {
            var response = await _productsFiltering.GetBestDealProduct();

            if (response.Success)
            {
                return Ok(response.Data);
            }

            return BadRequest(response);
        }

        [HttpGet("MostPopularProduct")]
        [ProducesResponseType(typeof(GenericResponse<FilterProductDTO>), 200)]
        public async Task<IActionResult> GetMostPopularProduct()
        {
            var response = await _productsFiltering.GetMostPopularProduct();

            if (response.Success)
            {
                return Ok(response.Data);
            }

            return BadRequest(response);
        }

        [HttpGet("VegetableProduct")]
        [ProducesResponseType(typeof(GenericResponse<FilterProductDTO>), 200)]
        public async Task<IActionResult> GetAllVegetableProduct()
        {
            var response = await _productsFiltering.GetAllVegetableProduct();

            if (response.Success)
            {
                return Ok(response.Data);
            }

            return BadRequest(response);
        }

        [HttpGet("FishandSeafoodProduct")]
        [ProducesResponseType(typeof(GenericResponse<FilterProductDTO>), 200)]
        public async Task<IActionResult> GetAllFishandSeafoodProduct()
        {
            var response = await _productsFiltering.GetAllFishandSeafoodProduct();

            if (response.Success)
            {
                return Ok(response.Data);
            }

            return BadRequest(response);
        }

        [HttpGet("DairyandEggsProduct")]
        [ProducesResponseType(typeof(GenericResponse<FilterProductDTO>), 200)]
        public async Task<IActionResult> GetAllDairyandEggsProduct()
        {
            var response = await _productsFiltering.GetAllDairyandEggsProduct();

            if (response.Success)
            {
                return Ok(response.Data);
            }

            return BadRequest(response);
        }

        [HttpGet("BakeryProduct")]
        [ProducesResponseType(typeof(GenericResponse<FilterProductDTO>), 200)]
        public async Task<IActionResult> GetAllBakeryProduct()
        {
            var response = await _productsFiltering.GetAllBakeryProduct();

            if (response.Success)
            {
                return Ok(response.Data);
            }

            return BadRequest(response);
        }
    }
}
