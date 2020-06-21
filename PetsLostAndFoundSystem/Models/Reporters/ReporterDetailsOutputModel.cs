using AutoMapper;
using PetsLostAndFoundSystem.Data.Models;
using System.Linq;

namespace PetsLostAndFoundSystem.Models.Reporters
{
    public class ReporterDetailsOutputModel : ReporterOutputModel
    {
        public int TotalReports { get; private set; }

        public void Mapping(Profile mapper)
            => mapper
                .CreateMap<Reporter, ReporterDetailsOutputModel>()
                .IncludeBase<Reporter, ReporterOutputModel>()
                .ForMember(r => r.TotalReports, cfg => cfg
                    .MapFrom(r => r.Reports.Count()));

    }
}
