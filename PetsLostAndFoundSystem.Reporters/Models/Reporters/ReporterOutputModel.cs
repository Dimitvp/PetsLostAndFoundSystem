using PetsLostAndFoundSystem.Models;
using PetsLostAndFoundSystem.Reporters.Data.Models;

namespace PetsLostAndFoundSystem.Reporters.Models.Reporters
{
    public class ReporterOutputModel : IMapFrom<Reporter>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }
    }
}
