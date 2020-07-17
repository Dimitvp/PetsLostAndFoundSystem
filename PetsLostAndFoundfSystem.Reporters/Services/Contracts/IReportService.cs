using System.Collections.Generic;
using System.Threading.Tasks;

using PetsLostAndFoundSystem.Reporters.Models.Reports;
using PetsLostAndFoundSystem.Reporters.Data.Models;
using PetsLostAndFoundSystem.Services;

namespace PetsLostAndFoundSystem.Reporters.Services.Contracts
{
    public interface IReportService : IDataService<Report>
    {
        Task<IEnumerable<ReportOutputModel>> GetAll();

       Task<Report> Find(int id);

        Task<bool> Delete(int id);

        Task<IEnumerable<ReportOutputModel>> GetListings(ReportsQuery query);

        Task<IEnumerable<MineReportOutputModel>> Mine(int reportId, ReportsQuery query);

        Task<ReportDetailsOutputModel> GetDetails(int id);

        Task<int> Total(ReportsQuery query);
    }
}
