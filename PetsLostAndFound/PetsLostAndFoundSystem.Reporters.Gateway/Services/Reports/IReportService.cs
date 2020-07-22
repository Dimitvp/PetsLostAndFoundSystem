using PetsLostAndFoundSystem.Reporters.Gateway.Models.Reports;
using Refit;
using System.Threading.Tasks;

namespace PetsLostAndFoundSystem.Reporters.Gateway.Services.Reports
{
    public interface IReportService
    {
        [Get("/Reports/Mine")]
        Task<MineReportsOutputModel> Mine();
    }
}
