using Restaurant.Data.Entities;

namespace Restaurant.BusinessLogic.Services.Interfaces
{
    public interface ITokenGenerator
    {
        public Task<string> GenerateTokenAsync(Customer user);
    }
}
