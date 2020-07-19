using System.Collections.Generic;
using System.Threading.Tasks;

using PetsLostAndFoundSystem.Reporters.Data.Models;
using PetsLostAndFoundSystem.Reporters.Models.Reporters;
using PetsLostAndFoundSystem.Services;

namespace PetsLostAndFoundSystem.Reporters.Services.Contracts
{
    public interface IReporterService : IDataService<Reporter>
    {
        Task<Reporter> FindByUser(string userId);

        Task<Reporter> FindById(int id);

        Task<int> GetIdByUser(string userId);

        Task<bool> HasReports(int reporterId, int reportId);

        Task<bool> IsReporter(string userId);

        Task<IEnumerable<ReporterDetailsOutputModel>> GetAll();

        Task<ReporterDetailsOutputModel> GetDetails(int id);

        Task<ReporterOutputModel> GetDetailsByReportId(int reportId);
    }
}
