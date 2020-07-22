using Microsoft.EntityFrameworkCore;
using PetsLostAndFoundSystem.Services;
using PetsLostAndFoundSystem.Statistics.Data;
using PetsLostAndFoundSystem.Statistics.Data.Models;
using PetsLostAndFoundSystem.Statistics.Models.ReportViews;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsLostAndFoundSystem.Statistics.Services.ReportViews
{
    public class ReportViewService : DataService<ReportView>, IReportViewService
    {
        public ReportViewService(StatisticsDbContext db)
            : base(db)
        {
        }

        public async Task<int> GetTotalViews(int reportId)
            => await this
                .All()
                .CountAsync(v => v.ReportId == reportId);

        public async Task<IEnumerable<ReportViewOutputModel>> GetTotalViews(
            IEnumerable<int> ids)
            => await this
                .All()
                .Where(v => ids.Contains(v.ReportId))
                .GroupBy(v => v.ReportId)
                .Select(gr => new ReportViewOutputModel
                {
                    ReportId = gr.Key,
                    TotalViews = gr.Count()
                })
                .ToListAsync();
    }
}
