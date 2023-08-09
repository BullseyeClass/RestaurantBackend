using Restaurant.Data.Entities;

namespace BootCamp.BusinessLogic.Services.Interfaces
{
    public interface ITokenGenerator
    {
        public Task<string> GenerateTokenAsync(Customer user);
    }
}
