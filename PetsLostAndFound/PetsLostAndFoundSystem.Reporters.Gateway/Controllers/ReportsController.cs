using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;

using PetsLostAndFoundSystem.Controllers;
using PetsLostAndFoundSystem.Reporters.Gateway.Models.Reports;
using PetsLostAndFoundSystem.Reporters.Gateway.Services.Reports;
using PetsLostAndFoundSystem.Reporters.Gateway.Services.ReportsViews;

namespace PetsLostAndFoundSystem.Reporters.Gateway.Controllers
{
    public class ReportsController : ApiController
    {
        private readonly IReportService reports;
        private readonly IReportViewService reportViews;
        private readonly IMapper mapper;

        public ReportsController(
            IReportService reports,
            IReportViewService reportViews,
            IMapper mapper)
        {
            this.reports = reports;
            this.reportViews = reportViews;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        [Route(nameof(Mine))]
        public async Task<IEnumerable<MineReportOutputModel>> Mine()
        {
            var mineReports = await this.reports.Mine();

            var mineReportsIds = mineReports.Reports.Select(c => c.Id);

            var mineReportViews = await this
                .reportViews
                .TotalViews(mineReportsIds);

            var outputMineReports =
                this.mapper
                    .Map<
                        IEnumerable<ReportOutputModel>,
                        IEnumerable<MineReportOutputModel>>(mineReports.Reports)
                    .ToDictionary(c => c.Id);

            var mineReportViewsDictionary = mineReportViews
                .ToDictionary(v => v.ReportId, v => v.TotalViews);

            foreach (var (reportId, totalViews) in mineReportViewsDictionary)
            {
                outputMineReports[reportId].TotalViews = totalViews;
            }

            return outputMineReports.Values;
        }
    }
}
