using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetsLostAndFoundSystem.Admin.Models.Reporters;
using PetsLostAndFoundSystem.Admin.Services.Reporters;

namespace PetsLostAndFoundSystem.Admin.Controllers
{
    public class ReportersController : AdministrationController
    {
        private readonly IReportersService reporters;
        private readonly IMapper mapper;

        public ReportersController(IReportersService reporters, IMapper mapper)
        {
            this.reporters = reporters;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
           => View(await this.reporters.All());

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var reporter = await this.reporters.Details(id);

            var dealerForm = this.mapper.Map<ReporterFromModel>(reporter);

            return View(dealerForm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ReporterFromModel model)
            => await this.Handle(
                async () => await this.reporters
                    .Edit(id, this.mapper.Map<ReporterInputModel>(model)),
                success: RedirectToAction(nameof(Index)),
                failure: View(model));
    }
}
