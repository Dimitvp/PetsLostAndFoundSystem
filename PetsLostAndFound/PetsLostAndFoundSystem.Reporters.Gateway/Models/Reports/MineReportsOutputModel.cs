using System.Collections.Generic;

namespace PetsLostAndFoundSystem.Reporters.Gateway.Models.Reports
{
    public class MineReportsOutputModel
    {
        public IEnumerable<ReportOutputModel> Reports { get; set; }
    }
}
