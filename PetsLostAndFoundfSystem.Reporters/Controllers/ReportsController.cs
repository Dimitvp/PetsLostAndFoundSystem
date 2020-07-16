using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetsLostAndFoundSystem.Controllers;
using PetsLostAndFoundSystem.Reporters.Data.Models;
using PetsLostAndFoundSystem.Reporters.Models.Pets;
using PetsLostAndFoundSystem.Reporters.Models.Reports;
using PetsLostAndFoundSystem.Reporters.Services.Contracts;
using PetsLostAndFoundSystem.Services;
using PetsLostAndFoundSystem.Services.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsLostAndFoundSystem.Reporters.Controllers
{
    public class ReportsController : ApiController
    {
        private readonly IReportService reports;
        private readonly IReporterService reporters;
        private readonly IPetService pets;
        private readonly ILocationService locations;
        private readonly ICurrentUserService currentUser;

        public ReportsController(
            IReportService reports,
            IReporterService reporters,
            IPetService pets,
            ILocationService locations,
            ICurrentUserService currentUser)
        {
            this.reports = reports;
            this.reporters = reporters;
            this.pets = pets;
            this.locations = locations;
            this.currentUser = currentUser;
        }

        [HttpGet]
        public async Task<ActionResult<SearchReportsOutputModel>> Search(
            [FromQuery] ReportsQuery query)
        {
            var reportListings = await this.reports.GetListings(query);

            var totalPages = await this.reports.Total(query);

            return new SearchReportsOutputModel(reportListings, query.Page, totalPages);
        }

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<ReportDetailsOutputModel>> Details(int id)
            => await this.reports.GetDetails(id);

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateReportOutputModel>> Create(ReportInputModel input)
        {
            var reporter = await this.reporters.FindByUser(this.currentUser.UserId);

            var pet = await this.pets.Find(input.Pet.Id);

            if (pet == null)
            {
                return BadRequest(Result.Failure("Pet does not exist."));
            }

            pet = new Pet
            {
                PetType = input.Pet.PetType,
                Name = input.Pet.Name,
                Age = input.Pet.Age,
                RFID = input.Pet.RFID,
                PetDescription = input.Pet.PetDescription
            };

            var location = await this.locations.FindByLongAndLat(input.Location.Latitude, input.Location.Longitude);

            location ??= new Location
            {
                Address = input.Location.Address,
                Longitude = input.Location.Longitude,
                Latitude = input.Location.Latitude
            };

            var report = new Report
            {
                Status = input.Status,
                LostDate = input.LostDate,
                ImagesLinksPost = input.ImagesLinksPost,
                RewardSum = input.RewardSum,
                Location = location,
                Pet = pet,
                IsApproved = false
            };

            await this.reports.Save(report);

            return new CreateReportOutputModel(report.Id);
        }

        [HttpPut]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult> Edit(int id, ReportInputModel input)
        {
            var reporterId = await this.reporters.GetIdByUser(this.currentUser.UserId);

            var reporterHasReport = await this.reporters.HasReports(reporterId, id);

            if (!reporterHasReport)
            {
                return BadRequest(Result.Failure("You cannot edit this ."));
            }

            var pet = await this.pets.Find(input.Pet.Id);

            var location = await this.locations.FindByLongAndLat(input.Location.Latitude, input.Location.Longitude);

            location ??= new Location
            {
                Address = input.Location.Address,
                Longitude = input.Location.Longitude,
                Latitude = input.Location.Latitude
            };

            var report = await this.reports.Find(id);

            report.Location = location;
            report.Status = input.Status;
            report.Pet = pet;
            report.ImagesLinksPost = input.ImagesLinksPost;
            report.RewardSum = input.RewardSum;

            await this.reports.Save(report);

            return Result.Success;
        }

        [HttpDelete]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var reporterId = await this.reporters.GetIdByUser(this.currentUser.UserId);

            var reporterHasReport = await this.reporters.HasReports(reporterId, id);

            if (!reporterHasReport)
            {
                return BadRequest(Result.Failure("You cannot edit this "));
            }

            return await this.reports.Delete(id);
        }

        [HttpGet]
        [Authorize]
        [Route(nameof(Mine))]
        public async Task<ActionResult<MineReportsOutputModel>> Mine(
            [FromQuery] ReportsQuery query)
        {
            var reporterId = await this.reporters.GetIdByUser(this.currentUser.UserId);

            var reportListings = await this.reports.Mine(reporterId, query);

            var totalPages = await this.reports.Total(query);

            return new MineReportsOutputModel(reportListings, query.Page, totalPages);
        }

        [HttpGet]
        [Route(nameof(Pet))]
        public async Task<IEnumerable<PetOutputModel>> Pets()
            => await this.pets.GetAll();

        [HttpPut]
        [Authorize]
        [Route(Id + PathSeparator + nameof(ChangeApprovel))]
        public async Task<ActionResult> ChangeApprovel(int id)
        {
            var reporterId = await this.reporters.GetIdByUser(this.currentUser.UserId);

            var reporterHasReport = await this.reporters.HasReports(reporterId, id);

            if (!reporterHasReport)
            {
                return BadRequest(Result.Failure("You cannot edit this "));
            }

            var report = await this.reports.Find(id);

            report.IsApproved = !report.IsApproved;

            await this.reports.Save(report);

            return Result.Success;
        }
    }
}
