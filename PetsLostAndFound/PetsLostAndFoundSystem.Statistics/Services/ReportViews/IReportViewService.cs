using PetsLostAndFoundSystem.Statistics.Models.ReportViews;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetsLostAndFoundSystem.Statistics.Services.ReportViews
{
    public interface IReportViewService
    {
        Task<int> GetTotalViews(int reportId);

        Task<IEnumerable<ReportViewOutputModel>> GetTotalViews(IEnumerable<int> ids);
    }
}
