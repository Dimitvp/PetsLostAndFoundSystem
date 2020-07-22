using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PetsLostAndFoundSystem.Controllers;
using PetsLostAndFoundSystem.Infrastructure;
using PetsLostAndFoundSystem.Reporters.Data.Models;
using PetsLostAndFoundSystem.Reporters.Models.Reporters;
using PetsLostAndFoundSystem.Reporters.Services.Contracts;
using PetsLostAndFoundSystem.Services;
using PetsLostAndFoundSystem.Services.Identity;

namespace PetsLostAndFoundSystem.Reporters.Controllers
{
    public class ReportersController : ApiController
    {
        private readonly IReporterService reporters;
        private readonly ICurrentUserService currentUser;

        public ReportersController(
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

        [HttpGet]
        [Authorize]
        [Route("Id")]
        public async Task<ActionResult<int>> GetReporterId()
        {
            var userId = this.currentUser.UserId;

            var userIsDealer = await this.reporters.IsReporter(userId);

            if (!userIsDealer)
            {
                return this.BadRequest("This user is not a reporter.");
            }

            return await this.reporters.GetIdByUser(this.currentUser.UserId);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> Create(CreateReporterInputModel input)
        {
            var reporter = new Reporter
            {
                Name = input.Name,
                PhoneNumber = input.PhoneNumber,
                UserId = this.currentUser.UserId
            };

            await this.reporters.Save(reporter);

            return reporter.Id;
        }

        [HttpPut]
        [Route(Id)]
        public async Task<ActionResult> Edit(int id, EditReporterInputModel input)
        {
            var reporter = this.currentUser.IsAdministrator
                ? await this.reporters.FindById(id)
                : await this.reporters.FindByUser(this.currentUser.UserId);

            if (id != reporter.Id)
            {
                return BadRequest(Result.Failure("You cannot edit this dealer."));
            }

            reporter.Name = input.Name;
            reporter.PhoneNumber = input.PhoneNumber;

            await this.reporters.Save(reporter);

            return Ok();
        }

        [HttpGet]
        [AuthorizeAdministrator]
        public async Task<IEnumerable<ReporterDetailsOutputModel>> All()
            => await this.reporters.GetAll();
    }
}
