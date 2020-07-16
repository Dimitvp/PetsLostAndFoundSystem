using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetsLostAndFoundSystem.MVC.Services.Contracts
{
    public interface IReporterService
    {
        [Get("/Reporters")]
        Task<IEnumerable<ReporterDetailsOutputModel>> All();

        [Get("/Reportera/{id}")]
        Task<ReportersDetailsOutputModel> Details(int id);

        [Put("/Reporter/{id}")]
        Task Edit(int id, ReporterInputModel dealer);
    }
}
