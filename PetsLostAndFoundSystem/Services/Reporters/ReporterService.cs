using AutoMapper;

using PetsLostAndFoundSystem.Data;
using PetsLostAndFoundSystem.Data.Models;
using PetsLostAndFoundSystem.Models.Reporters;
using PetsLostAndFoundSystem.Services.Contracts;
using System.Threading.Tasks;

namespace PetsLostAndFoundSystem.Services.Reporters
{
    public class ReporterService : DataService<Report>, IReporterService
    {
        private readonly IMapper mapper;

        public ReporterService(PetsLostAndFoundDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;
        public Task<Reporter> FindByUser(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ReporterDetailsOutputModel> GetDetails(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ReporterOutputModel> GetDetailsByReportId(int reportId)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> GetIdByUser(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> HasReports(int reporterId, int reportId)
        {
            throw new System.NotImplementedException();
        }

        public Task Save(Reporter entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
