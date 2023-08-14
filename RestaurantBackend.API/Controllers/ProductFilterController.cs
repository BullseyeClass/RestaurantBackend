﻿using Microsoft.AspNetCore.Mvc;
using Restaurant.BusinessLogic.Services.Interfaces;
using Restaurant.DTO.Response;
using Restaurant.DTO;

namespace Restaurant.API.Controllers
{
    public class ProductFilterController : ControllerBase
    {
        private readonly IProductsFiltering _productsFiltering;
        public ProductFilterController(IProductsFiltering productsFiltering)
        {
            _productsFiltering = productsFiltering;
        }

        [HttpGet("FilterAllProduct")]
        [ProducesResponseType(typeof(GenericResponse<CustomerRegistrationResponseDTO>), 200)]
        public async Task<IActionResult> FilterAllProduct()
        {
            var response = await _productsFiltering.GetAllProduct();

            if (response.Success)
            {
                return Ok(response.Data);
            }

            return BadRequest(response);
        }

        [HttpGet("FilterBestDealProduct")]
        [ProducesResponseType(typeof(GenericResponse<CustomerRegistrationResponseDTO>), 200)]
        public async Task<IActionResult> FilterBestDealProduct()
        {
            var response = await _productsFiltering.GetBestDealProduct();

            if (response.Success)
            {
                return Ok(response.Data);
            }

            return BadRequest(response);
        }

        [HttpGet("GetMostPopularProduct")]
        [ProducesResponseType(typeof(GenericResponse<CustomerRegistrationResponseDTO>), 200)]
        public async Task<IActionResult> GetMostPopularProduct()
        {
            var response = await _productsFiltering.GetMostPopularProduct();

            if (response.Success)
            {
                return Ok(response.Data);
            }

            return BadRequest(response);
        }

        [HttpGet("GetAllVegetableProduct")]
        [ProducesResponseType(typeof(GenericResponse<CustomerRegistrationResponseDTO>), 200)]
        public async Task<IActionResult> GetAllVegetableProduct()
        {
            var response = await _productsFiltering.GetAllVegetableProduct();

            if (response.Success)
            {
                return Ok(response.Data);
            }

            return BadRequest(response);
        }

        [HttpGet("GetAllFishandSeafoodProduct")]
        [ProducesResponseType(typeof(GenericResponse<CustomerRegistrationResponseDTO>), 200)]
        public async Task<IActionResult> GetAllFishandSeafoodProduct()
        {
            var response = await _productsFiltering.GetAllFishandSeafoodProduct();

            if (response.Success)
            {
                return Ok(response.Data);
            }

            return BadRequest(response);
        }

        [HttpGet("GetAllDairyandEggsProduct")]
        [ProducesResponseType(typeof(GenericResponse<CustomerRegistrationResponseDTO>), 200)]
        public async Task<IActionResult> GetAllDairyandEggsProduct()
        {
            var response = await _productsFiltering.GetAllDairyandEggsProduct();

            if (response.Success)
            {
                return Ok(response.Data);
            }

            return BadRequest(response);
        }

        [HttpGet("GetAllBakeryProduct")]
        [ProducesResponseType(typeof(GenericResponse<CustomerRegistrationResponseDTO>), 200)]
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
