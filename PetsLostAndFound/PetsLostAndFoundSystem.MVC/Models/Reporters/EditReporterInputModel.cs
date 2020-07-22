using PetsLostAndFoundSystem.Models;

namespace PetsLostAndFoundSystem.MVC.Models.Reporters
{
    public class EditReporterInputModel : IMapFrom<EditReporterFormModel>
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }
    }
}
