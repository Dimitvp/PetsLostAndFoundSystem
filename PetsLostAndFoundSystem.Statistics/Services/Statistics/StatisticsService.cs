namespace PetsLostAndFoundSystem.Statistics.Services.Statistics
{
    using AutoMapper;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using PetsLostAndFoundSystem.Statistics.Data;
    using PetsLostAndFoundSystem.Statistics.Models.Statistics;
    using PetsLostAndFoundSystem.Services;
    using System.Threading.Tasks;
    using PetsLostAndFoundSystem.Data.Enums;

    public class StatisticsService : DataService<Statistics>, IStatisticsService
    {
        private readonly IMapper mapper;

        public StatisticsService(StatisticsDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<StatisticsOutputModel> Full()
            => await this.mapper
                .ProjectTo<StatisticsOutputModel>(this.All())
                .SingleOrDefaultAsync();

        public async Task AddReport(PetStatusType status)
        {
            var statistics = await this.All().SingleOrDefaultAsync();

            statistics.TotalReports++;

            if (status == PetStatusType.Found)
            {
                statistics.TotalFoundPets++;
            }
            else
            {
                statistics.TotalLostPets++;
            }

            await this.Data.SaveChangesAsync();
        }
    }
}
