using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.EntityFrameworkCore;

using PetsLostAndFoundSystem.Reporters.Data;
using PetsLostAndFoundSystem.Reporters.Data.Models;
using PetsLostAndFoundSystem.Reporters.Models.Reporters;
using PetsLostAndFoundSystem.Reporters.Services.Contracts;
using PetsLostAndFoundSystem.Services;

namespace PetsLostAndFoundSystem.Reporters.Services
{
    public class ReporterService : DataService<Reporter>, IReporterService
    {
        private readonly IMapper mapper;

        public ReporterService(ReportersDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<Reporter> FindById(int id)
            => await this.Data.FindAsync<Reporter>(id);

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

        public async Task<bool> IsReporter(string userId)
            => await this
                .All()
                .AnyAsync(r => r.UserId == userId);

        public async Task<IEnumerable<ReporterDetailsOutputModel>> GetAll()
           => await this.mapper
               .ProjectTo<ReporterDetailsOutputModel>(this.All())
               .ToListAsync();

        private async Task<T> FindByUser<T>(
            string userId,
            Expression<Func<Reporter, T>> selector)
        {
            var reporterData = await this
                .All()
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
