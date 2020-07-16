using System.Collections.Generic;

using PetsLostAndFoundSystem.Identity.Data.Models;

namespace PetsLostAndFoundSystem.Identity.Contracts
{
    public interface ITokenGeneratorService
    {
        string GenerateToken(User user, IEnumerable<string> roles = null);
    }
}
