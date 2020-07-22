using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using PetsLostAndFoundSystem.MVC.Services.Contracts;

namespace PetsLostAndFoundSystem.MVC.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReporterService reports;

        public ReportController(IReporterService reports)
        {
            this.reports = reports;
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var report = await this.reports.Details(id);

            return View(await this.reports.Details(id));
        }
    }
}
