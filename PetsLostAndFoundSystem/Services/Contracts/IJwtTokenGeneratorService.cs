using PetsLostAndFoundSystem.Data.Models;

namespace PetsLostAndFoundSystem.Services.Contracts
{
    public interface IJwtTokenGeneratorService
    {
        string GenerateToken(User user);
    }
}
