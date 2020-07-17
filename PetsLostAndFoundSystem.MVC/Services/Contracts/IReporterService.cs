using PetsLostAndFoundSystem.MVC.Models.Reporters;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetsLostAndFoundSystem.MVC.Services.Contracts
{
    public interface IReporterService
    {
        [Post("/Reporters")]
        Task Create(CreateReporterInputModel input);

        [Get("/Reporters")]
        Task<IEnumerable<ReporterDetailsOutputModel>> All();

        [Get("/Reporters/{id}")]
        Task<ReporterDetailsOutputModel> Details(int id);

        [Put("/Reporters/{id}")]
        Task Edit(int id, EditReporterInputModel dealer);
    }
}
