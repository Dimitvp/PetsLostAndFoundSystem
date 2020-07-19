using System.Collections.Generic;

namespace PetsLostAndFoundSystem.Reporters.Models.Reports
{
    public class SearchReportsOutputModel : ReportsOutputModel<ReportOutputModel>
    {
        public SearchReportsOutputModel(IEnumerable<ReportOutputModel> reports,
            int page,
            int totalPages)
            : base(reports, page, totalPages)
        {

        }
    }
}
