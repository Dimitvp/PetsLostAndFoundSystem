namespace PetsLostAndFoundSystem.Statistics.Services.Statistics
{
    using PetsLostAndFoundSystem.Data.Enums;
    using PetsLostAndFoundSystem.Statistics.Models.Statistics;
    using System.Threading.Tasks;

    public interface IStatisticsService
    {
        Task<StatisticsOutputModel> Full();

        Task AddReport(PetStatusType status);
    }
}
