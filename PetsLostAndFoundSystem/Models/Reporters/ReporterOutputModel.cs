using PetsLostAndFoundSystem.Data.Models;

namespace PetsLostAndFoundSystem.Models.Reporters
{
    public class ReporterOutputModel : IMapFrom<Reporter>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }
    }
}
