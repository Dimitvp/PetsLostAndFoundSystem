using System.Collections.Generic;
using System.Threading.Tasks;

using PetsLostAndFoundSystem.MVC.Data.Models;
using PetsLostAndFoundSystem.MVC.Models.Reports;

namespace PetsLostAndFoundSystem.MVC.Services.Contracts
{
    public interface IReportService : IDataService<Report>
    {
        Task<Report> Find(int id);

        Task<bool> Delete(int id);

        Task<IEnumerable<ReportOutputModel>> GetListings(ReportsQuery query);

        Task<IEnumerable<MineReportOutputModel>> Mine(int reportId, ReportsQuery query);

        Task<ReportDetailsOutputModel> GetDetails(int id);

        Task<int> Total(ReportsQuery query);
    }
}
