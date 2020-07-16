using PetsLostAndFoundSystem.Reporters.Gateway.Models.ReportsViews;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetsLostAndFoundSystem.Reporters.Gateway.Services.ReportsViews
{
    public interface IReportViewService
    {
        [Get("/ReportViews")]
        Task<IEnumerable<ReportViewOutputModel>> TotalViews(
            [Query(CollectionFormat.Multi)] IEnumerable<int> ids);
    }
}
