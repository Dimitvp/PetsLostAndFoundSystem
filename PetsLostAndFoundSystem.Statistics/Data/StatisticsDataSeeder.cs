namespace PetsLostAndFoundSystem.Statistics.Data
{
    using PetsLostAndFoundSystem.Services;
    using System.Linq;
    using Models;
    public class StatisticsDataSeeder : IDataSeeder
    {
        private readonly StatisticsDbContext db;

        public StatisticsDataSeeder(StatisticsDbContext db) => this.db = db;

        public void SeedData()
        {
            if (this.db.Statistics.Any())
            {
                return;
            }

            this.db.Statistics.Add(new Statistics
            {
                TotalReports = 0,
                TotalLostPets = 0,
                TotalFoundPets = 0
            });

            this.db.SaveChanges();
        }
    }
}
