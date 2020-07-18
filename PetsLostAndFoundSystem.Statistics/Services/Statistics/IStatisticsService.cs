using PetsLostAndFoundSystem.Statistics.Models.Statistics;
using System.Threading.Tasks;

namespace PetsLostAndFoundSystem.Statistics.Services.Statistics
{
    public interface IStatisticsService
    {
        Task<StatisticsOutputModel> Full();
    }
}
