using PetsLostAndFoundSystem.MVC.Data.Models;

namespace PetsLostAndFoundSystem.MVC.Models.Reporters
{
    public class ReporterOutputModel : IMapFrom<Reporter>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }
    }
}
