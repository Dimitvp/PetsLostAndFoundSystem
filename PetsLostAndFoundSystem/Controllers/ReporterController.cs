using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using PetsLostAndFoundSystem.Models.Reporters;
using PetsLostAndFoundSystem.Services;
using PetsLostAndFoundSystem.Services.Contracts;

namespace PetsLostAndFoundSystem.Controllers
{
    public class ReporterController : ApiController
    {
        private readonly IReporterService reporters;
        private readonly ICurrentUserService currentUser;

        public ReporterController(
            IReporterService reporters,
            ICurrentUserService currentUser)
        {
            this.reporters = reporters;
            this.currentUser = currentUser;
        }

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<ReporterDetailsOutputModel>> Details(int id)
            => await this.reporters.GetDetails(id);

        [HttpPut]
        [Route(Id)]
        public async Task<ActionResult> Edit(int id, EditReporterInputModel input)
        {
            var reporter = await this.reporters.FindByUser(this.currentUser.UserId);

            if (id != reporter.Id)
            {
                return BadRequest(Result.Failure("You cannot edit this reporter."));
            }

            reporter.Name = input.Name;
            reporter.PhoneNumber = input.PhoneNumber;

            await this.reporters.Save(reporter);

            return Ok();
        }
    }
}
