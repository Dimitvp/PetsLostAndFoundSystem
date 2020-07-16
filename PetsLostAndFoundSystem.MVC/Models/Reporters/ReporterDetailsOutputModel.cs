using AutoMapper;
using PetsLostAndFoundSystem.MVC.Data.Models;
using System.Linq;

namespace PetsLostAndFoundSystem.MVC.Models.Reporters
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
