using Restaurant.DTO.Request;
using Restaurant.DTO.Response;
using Restaurant.DTO;

namespace BootCamp.BusinessLogic.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<GenericResponse<CustomerRegistrationResponseDTO>> RegistrationAsync(CustomerRegistrationDTO traineeRegistrationDTO);
    }
}
