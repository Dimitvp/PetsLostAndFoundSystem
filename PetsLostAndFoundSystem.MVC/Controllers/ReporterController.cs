using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetsLostAndFoundSystem.Controllers;
using PetsLostAndFoundSystem.Models;
using PetsLostAndFoundSystem.MVC.Models.Reporters;
using PetsLostAndFoundSystem.MVC.Services;
using PetsLostAndFoundSystem.MVC.Services.Contracts;

namespace PetsLostAndFoundSystem.MVC.Controllers
{
    public class ReporterController : CommunicationBaseController
    {
        private readonly IReporterService reporters;
        private readonly ICurrentUserService currentUser;
        private readonly IMapper mapper;

        public ReporterController(
            IReporterService reporters,
            ICurrentUserService currentUser,
            IMapper mapper)
        {
            this.reporters = reporters;
            this.currentUser = currentUser;
            this.mapper = mapper;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> Create(CreateReporterFormModel input)
            => await this.Handle(
                async () => await this.reporters
                    .Create(this.mapper.Map<CreateReporterInputModel>(input)),
                success: RedirectToAction(nameof(HomeController.Index), "Home"),
                failure: View("../Home/Index", input));
        //{
        //    var reporter = new Reporter
        //    {
        //        Name = input.Name,
        //        PhoneNumber = input.PhoneNumber,
        //        UserId = this.currentUser.UserId
        //    };

        //    await this.reporters.Save(reporter);

        //    return reporter.Id;
        //}

        [HttpGet]
        public async Task<ActionResult<ReporterDetailsOutputModel>> Details(int id)
            => await this.reporters.Details(id);

        [HttpPut]
        public async Task<ActionResult> Edit(int id, EditReporterFormModel input)
            => await this.Handle(
                async () => await this.reporters
                    .Edit(id, this.mapper.Map<EditReporterInputModel>(input)),
                success: RedirectToAction(nameof(HomeController.Index), "Home"),
                failure: View(input));
        //{
        //    var reporter = await this.reporters.FindByUser(this.currentUser.UserId);

        //    if (id != reporter.Id)
        //    {
        //        return BadRequest(Result.Failure("You cannot edit this reporter."));
        //    }

        //    reporter.Name = input.Name;
        //    reporter.PhoneNumber = input.PhoneNumber;

        //    await this.reporters.Save(reporter);

        //    return Ok();
        //}
    }
}
