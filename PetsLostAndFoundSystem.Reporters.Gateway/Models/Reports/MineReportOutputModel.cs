using PetsLostAndFoundSystem.Models;

namespace PetsLostAndFoundSystem.Reporters.Gateway.Models.Reports
{
    public class MineReportOutputModel : ReportOutputModel, IMapFrom<ReportOutputModel>
    {
        public int TotalViews { get; set; }
    }
}
