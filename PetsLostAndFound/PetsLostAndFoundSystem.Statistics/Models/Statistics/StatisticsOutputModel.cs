namespace PetsLostAndFoundSystem.Statistics.Models.Statistics
{
    using PetsLostAndFoundSystem.Models;
    using Data.Models;
    public class StatisticsOutputModel : IMapFrom<Statistics>
    {
        public int TotalReports { get; set; }

        public int TotalFoundPets { get; set; }

        public int TotalLostPets { get; set; }
    }
}
