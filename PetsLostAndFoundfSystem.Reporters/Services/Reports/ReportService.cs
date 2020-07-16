using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using AutoMapper;

using PetsLostAndFoundSystem.Services;
using PetsLostAndFoundSystem.Reporters.Data.Models;
using PetsLostAndFoundSystem.Reporters.Data;
using PetsLostAndFoundSystem.Reporters.Services.Contracts;
using PetsLostAndFoundSystem.Reporters.Models.Reports;

namespace PetsLostAndFoundSystem.Reporters.Services.ReportService
{
    public class ReportService : DataService<Report>, IReportService
    {
        private const int ReportsPerPage = 10;

        private readonly IMapper mapper;

        public ReportService(ReportersDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<bool> Delete(int id)
        {
            var report = await this.Data.FindAsync<Report>(id);

            if (report == null)
            {
                return false;
            }

            this.Data.Remove(report);

            await this.Data.SaveChangesAsync();

            return true;
        }

        public async Task<Report> Find(int id)
            => await this
                .All()
                .Include(r => r.Pet)
                .FirstOrDefaultAsync(c => c.Id == id);

        public async Task<ReportDetailsOutputModel> GetDetails(int id)
            => await this.mapper
                .ProjectTo<ReportDetailsOutputModel>(this
                    .AllApproved()
                    .Where(c => c.Id == id))
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<ReportOutputModel>> GetListings(ReportsQuery query)
            => (await this.mapper
                .ProjectTo<ReportOutputModel>(this
                    .GetReportsQuery(query))
                .ToListAsync())
                .Skip((query.Page - 1) * ReportsPerPage)
                .Take(ReportsPerPage);

        public async Task<IEnumerable<MineReportOutputModel>> Mine(int reportId, ReportsQuery query)
        => (await this.mapper
                .ProjectTo<MineReportOutputModel>(this
                    .GetReportsQueryForUser(query, reportId))
                .ToListAsync())
                .Skip((query.Page - 1) * ReportsPerPage)
                .Take(ReportsPerPage);

        public async Task<int> Total(ReportsQuery query)
            => await this
                .GetReportsQuery(query)
                .CountAsync();

        private IQueryable<Report> AllApproved()
            => this
                .All()
                .Where(report => report.IsApproved);

        private IQueryable<Report> GetReportsQueryForUser(
            ReportsQuery query, int reporterId)
        {
            var dataQuery = this.All();

            dataQuery = dataQuery.Where(r => r.ReporterId == reporterId);

            dataQuery = dataQuery.Where(r => r.PetId == query.PetId);

            dataQuery = dataQuery.Where(r => r.Location.Longitude == query.Longitude && r.Location.Latitude == query.Latitude);

            return dataQuery;
        }

        private IQueryable<Report> GetReportsQuery(
            ReportsQuery query)
        {
            var dataQuery = this.All();

            dataQuery = dataQuery.Where(c => c.PetId == query.PetId);

            dataQuery = dataQuery.Where(r => r.Location.Longitude == query.Longitude && r.Location.Latitude == query.Latitude);

            return dataQuery;
        }
    }
}
