using PetsLostAndFoundSystem.MVC.Data.Models;
using System.Threading.Tasks;

namespace PetsLostAndFoundSystem.MVC.Services.Contracts
{
    public interface ILocationService
    {
        Task<Location> FindByLongAndLat(double longitude, double latitude);
    }
}
