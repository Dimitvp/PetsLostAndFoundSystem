using System.Threading.Tasks;

using Refit;

using PetsLostAndFoundSystem.Admin.Models.Statistics;


namespace PetsLostAndFoundSystem.Admin.Services.Statistics
{
    public interface IStatisticsService
    {
        [Get("/Statistics")]
        Task<StatisticsOutputModel> Full();
    }
}
