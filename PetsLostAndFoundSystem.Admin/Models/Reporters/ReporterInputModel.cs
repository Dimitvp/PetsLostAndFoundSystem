using PetsLostAndFoundSystem.Models;

namespace PetsLostAndFoundSystem.Admin.Models.Reporters
{
    public class ReporterInputModel : IMapFrom<ReporterFromModel>
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }
    }
}
