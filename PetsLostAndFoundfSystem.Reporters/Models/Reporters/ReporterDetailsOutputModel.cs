using System.Linq;

using AutoMapper;

using PetsLostAndFoundSystem.Reporters.Data.Models;

namespace PetsLostAndFoundSystem.Reporters.Models.Reporters
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
