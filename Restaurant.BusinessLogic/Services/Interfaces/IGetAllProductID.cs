using Restaurant.DTO;
using Restaurant.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BusinessLogic.Services.Interfaces
{
    public interface IGetAllProductID
    {
        Task<GenericResponse<List<GetAllProductIDsDTO>>> GetAllProductID(List<Guid> guids);
    }
}
