using Restaurant.DTO.Request;
using Restaurant.DTO.Response;
using Restaurant.DTO;

namespace Restaurant.BusinessLogic.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<GenericResponse<CustomerRegistrationResponseDTO>> RegistrationAsync(CustomerRegistrationDTO traineeRegistrationDTO);
        Task<GenericResponse<List<ReturningUserByIdDTO>>> GettingUserById(string userId);
    }
}
