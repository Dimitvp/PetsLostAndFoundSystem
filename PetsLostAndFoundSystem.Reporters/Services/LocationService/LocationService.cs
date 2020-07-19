using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using PetsLostAndFoundSystem.Reporters.Data;
using PetsLostAndFoundSystem.Reporters.Data.Models;
using PetsLostAndFoundSystem.Reporters.Services.Contracts;
using PetsLostAndFoundSystem.Services;

namespace PetsLostAndFoundSystem.Reporters.Services.LocationService
{
    public class LocationService : DataService<Location>, ILocationService
    {
        public LocationService(ReportersDbContext db)
            :base(db)
        {
        }

        public async Task<Location> FindByLongAndLat(double longitude, double latitude)
            => await this
                .All()
                .FirstOrDefaultAsync(l => l.Latitude == latitude && l.Longitude == longitude);
    }
}
