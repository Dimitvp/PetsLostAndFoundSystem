using System.Collections.Generic;

namespace PetsLostAndFoundSystem.MVC.Models.Reports
{
    public abstract class ReportsOutputModel<TReportOutputModel>
    {
        protected ReportsOutputModel(IEnumerable<TReportOutputModel> reports, int page, int totalPages)
        {
            this.Reports = reports;
            this.Page = page;
            this.TotalPages = totalPages;
        }

        public IEnumerable<TReportOutputModel> Reports { get; }

        public int Page { get; }

        public int TotalPages { get; }
    }
}
