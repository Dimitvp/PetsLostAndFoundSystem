using PetsLostAndFoundSystem.Models;

namespace PetsLostAndFoundSystem.MVC.Models.Identity
{
    public class CreateUserFormModel : IMapFrom<RegisterViewModel>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
