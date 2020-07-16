using System.Collections.Generic;
using System.Threading.Tasks;

using Refit;

using PetsLostAndFoundSystem.Admin.Models.Reporters;

namespace PetsLostAndFoundSystem.Admin.Services.Reporters
{
    public interface IReportersService
    {
        [Get("/Reporters")]
        Task<IEnumerable<ReporterDetailsOutputModel>> All();

        [Get("/Reoporters/{id}")]
        Task<ReporterDetailsOutputModel> Details(int id);

        [Put("/Reporters/{id}")]
        Task Edit(int id, ReporterInputModel reporter);
    }
}