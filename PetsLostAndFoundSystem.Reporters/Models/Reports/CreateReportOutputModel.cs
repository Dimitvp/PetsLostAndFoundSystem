namespace PetsLostAndFoundSystem.Reporters.Models.Reports
{
    public class CreateReportOutputModel
    {
        public CreateReportOutputModel(int reportId)
            => this.ReportId = reportId;

        public int ReportId { get; }
    }
}
