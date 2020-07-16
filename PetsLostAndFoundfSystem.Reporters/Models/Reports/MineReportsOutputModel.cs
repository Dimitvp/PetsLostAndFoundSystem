using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsLostAndFoundSystem.Reporters.Models.Reports
{
    public class MineReportsOutputModel : ReportsOutputModel<MineReportOutputModel>
    {
        public MineReportsOutputModel(IEnumerable<MineReportOutputModel> reports, int page, int totalPages)
            : base (reports, page, totalPages)
        {

        }
    }
}
