using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using PetsLostAndFoundSystem.Data;
using PetsLostAndFoundSystem.Data.Models;
using PetsLostAndFoundSystem.Services.Contracts;

namespace PetsLostAndFoundSystem.Services.LocationService
{
    public class LocationService : DataService<Location>, ILocationService
    {
        public LocationService(PetsLostAndFoundDbContext db)
            :base(db)
        {
        }

        public async Task<Location> FindByLongAndLat(double longitude, double latitude)
            => await this
                .Data
                .Locations
                .FirstOrDefaultAsync(l => l.Latitude == latitude && l.Longitude == longitude);
    }
}
