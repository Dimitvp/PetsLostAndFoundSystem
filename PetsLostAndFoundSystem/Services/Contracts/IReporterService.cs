using System.Threading.Tasks;

using PetsLostAndFoundSystem.Data.Models;
using PetsLostAndFoundSystem.Models.Reporters;

namespace PetsLostAndFoundSystem.Services.Contracts
{
    public interface IReporterService : IDataService<Reporter>
    {
        Task<Reporter> FindByUser(string userId);

        Task<int> GetIdByUser(string userId);

        Task<bool> HasReports(int reporterId, int reportId);

        Task<ReporterDetailsOutputModel> GetDetails(int id);

        Task<ReporterOutputModel> GetDetailsByReportId(int reportId);
    }
}
