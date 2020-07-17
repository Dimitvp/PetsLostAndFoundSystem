using System.Collections.Generic;
using System.Threading.Tasks;

using Refit;

using PetsLostAndFoundSystem.MVC.Models.Reporters;


namespace PetsLostAndFoundSystem.MVC.Services.Contracts
{
    public interface IReportService
    {
        [Get("/Report")]
        Task<IEnumerable<ReporterDetailsOutputModel>> All();

        [Get("/Reoport/{id}")]
        Task<ReporterDetailsOutputModel> Details(int id);
    }
}
