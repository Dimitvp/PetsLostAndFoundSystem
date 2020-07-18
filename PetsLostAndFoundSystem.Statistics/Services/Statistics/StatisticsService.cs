namespace PetsLostAndFoundSystem.Statistics.Services.Statistics
{
    using AutoMapper;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using PetsLostAndFoundSystem.Statistics.Data;
    using PetsLostAndFoundSystem.Statistics.Models.Statistics;
    using PetsLostAndFoundSystem.Services;
    using System.Threading.Tasks;

    public class StatisticsService : DataService<Statistics>, IStatisticsService
    {
        private readonly IMapper mapper;

        public StatisticsService(StatisticsDbContext db, IMapper mapper)
            : base(db)
        {
            this.mapper = mapper;
        }

        public async Task<StatisticsOutputModel> Full()
            => await this.mapper
                .ProjectTo<StatisticsOutputModel>(this.All())
                .SingleOrDefaultAsync();
    }
}
