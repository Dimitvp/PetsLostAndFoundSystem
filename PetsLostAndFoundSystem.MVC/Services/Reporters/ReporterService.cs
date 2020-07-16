using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetsLostAndFoundSystem.MVC.Data;
using PetsLostAndFoundSystem.MVC.Data.Models;
using PetsLostAndFoundSystem.MVC.Models.Reporters;
using PetsLostAndFoundSystem.MVC.Services.Contracts;

namespace PetsLostAndFoundSystem.MVC.Services.Reporters
{
    public class ReporterService : DataService<Reporter>, IReporterService
    {
        private readonly IMapper mapper;

        public ReporterService(PetsLostAndFoundDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public Task<Reporter> FindByUser(string userId)
            => this.FindByUser(userId, reporter => reporter);

        public async Task<ReporterDetailsOutputModel> GetDetails(int id)
            => await this.mapper
                .ProjectTo<ReporterDetailsOutputModel>(this
                    .All()
                    .Where(r => r.Id == id))
                .FirstOrDefaultAsync();

        public async Task<ReporterOutputModel> GetDetailsByReportId(int reportId)
            => await this.mapper
                .ProjectTo<ReporterOutputModel>(this
                    .All()
                    .Where(r => r.Reports.Any(re => re.Id == reportId)))
                .SingleOrDefaultAsync();

        public Task<int> GetIdByUser(string userId)
            => this.FindByUser(userId, reporter => reporter.Id);

        public async Task<bool> HasReports(int reporterId, int reportId)
            => await this
                .All()
                .Where(r => r.Id == reporterId)
                .AnyAsync(r => r.Reports
                    .Any(re => re.Id == reportId));

        private async Task<T> FindByUser<T>(
            string userId,
            Expression<Func<Reporter, T>> selector)
        {
            var reporterData = await this
                .Data
                .Reporters
                .Where(u => u.UserId == userId)
                .Select(selector)
                .FirstOrDefaultAsync();

            if (reporterData == null)
            {
                throw new InvalidOperationException("This user is not a reporter.");
            }

            return reporterData;
        }
    }
}
