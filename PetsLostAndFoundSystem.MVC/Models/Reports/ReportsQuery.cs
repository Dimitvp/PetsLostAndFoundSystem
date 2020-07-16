namespace PetsLostAndFoundSystem.MVC.Models.Reports
{
    public class ReportsQuery
    {
        public int PetId { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    
        public int Page { get; set; } = 1;
    }
}
    