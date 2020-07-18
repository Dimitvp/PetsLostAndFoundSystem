namespace PetsLostAndFoundSystem.Statistics.Services.Statistics
{
    using PetsLostAndFoundSystem.Statistics.Models.Statistics;
    using System.Threading.Tasks;

    public interface IStatisticsService
    {
        Task<StatisticsOutputModel> Full();
    }
}
