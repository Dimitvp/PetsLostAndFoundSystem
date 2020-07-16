using System.Threading.Tasks;

using PetsLostAndFoundSystem.Reporters.Data.Models;

namespace PetsLostAndFoundSystem.Reporters.Services.Contracts
{
    public interface ILocationService
    {
        Task<Location> FindByLongAndLat(double longitude, double latitude);
    }
}
