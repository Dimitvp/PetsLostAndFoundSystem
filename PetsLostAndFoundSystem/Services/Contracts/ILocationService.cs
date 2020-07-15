using PetsLostAndFoundSystem.Data.Models;
using System.Threading.Tasks;

namespace PetsLostAndFoundSystem.Services.Contracts
{
    public interface ILocationService
    {
        Task<Location> FindByLongAndLat(double longitude, double latitude);
    }
}
