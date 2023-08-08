using Restaurant.DTO;
using Restaurant.DTO.Request;
using Restaurant.DTO.Response;

namespace BootCamp.BusinessLogic.Services.Interfaces
{
    public interface IAuthentication
    {
        Task<GenericResponse<LoginResponseDTO>> LoginAsync(LoginRequestDTO userRequest);
    }
}
