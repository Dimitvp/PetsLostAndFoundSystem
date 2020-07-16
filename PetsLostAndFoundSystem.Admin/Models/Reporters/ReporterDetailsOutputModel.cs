namespace PetsLostAndFoundSystem.Admin.Models.Reporters
{
    public class ReporterDetailsOutputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public int TotalReports { get; private set; }
    }
}
