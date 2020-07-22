using System.Collections.Generic;

namespace PetsLostAndFoundSystem.MVC.Models.Reports
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
