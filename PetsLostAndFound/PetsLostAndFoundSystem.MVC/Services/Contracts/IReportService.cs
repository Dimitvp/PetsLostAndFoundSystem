using System.Collections.Generic;
using System.Threading.Tasks;

using Refit;

using PetsLostAndFoundSystem.MVC.Models.Reports;

namespace PetsLostAndFoundSystem.MVC.Services.Contracts
{
    public interface IReportService
    {
        [Get("/Reports")]
        Task<IEnumerable<ReportDetailsOutputModel>> All();

        [Get("/Reoports/{id}")]
        Task<ReportDetailsOutputModel> Details(int id);
    }
}
