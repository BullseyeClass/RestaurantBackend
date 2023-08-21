using Microsoft.AspNetCore.Mvc;
using Restaurant.BusinessLogic.Services.Interfaces;
using Restaurant.DTO;
using Restaurant.DTO.Request;

namespace Restaurant.API.Controllers
{
    public class GetAllProductController : ControllerBase
    {
        private readonly IGetAllProductID _getAllProductID;

        public GetAllProductController(IGetAllProductID getAllProductID)
        {
            _getAllProductID = getAllProductID;
        }

        [HttpGet("GetAllProductIDs")]
        [ProducesResponseType(typeof(GenericResponse<GetAllProductIDsDTO>), 200)]

        public async Task<IActionResult> GetAllProductIDs(List<Guid> guids)
        {
            var result = await _getAllProductID.GetAllProductID(guids);

            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }

       
    }
}
