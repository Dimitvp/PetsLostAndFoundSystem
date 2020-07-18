using PetsLostAndFoundSystem.Models;

namespace PetsLostAndFoundSystem.MVC.Models.Reporters
{
    public class CreateReporterInputModel : IMapFrom<CreateReporterFormModel>
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }
    }
}
    