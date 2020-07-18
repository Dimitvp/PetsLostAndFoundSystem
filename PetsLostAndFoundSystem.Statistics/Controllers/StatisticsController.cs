using Microsoft.AspNetCore.Mvc;
using PetsLostAndFoundSystem.Controllers;
using PetsLostAndFoundSystem.Statistics.Models.Statistics;
using PetsLostAndFoundSystem.Statistics.Services.Statistics;
using System.Threading.Tasks;

namespace PetsLostAndFoundSystem.Statistics.Controllers
{
    public class StatisticsController : ApiController
    {
        private readonly IStatisticsService statistics;

        public StatisticsController(IStatisticsService statistics)
            => this.statistics = statistics;

        [HttpGet]
        public async Task<StatisticsOutputModel> Full()
            => await this.statistics.Full();
    }
}
