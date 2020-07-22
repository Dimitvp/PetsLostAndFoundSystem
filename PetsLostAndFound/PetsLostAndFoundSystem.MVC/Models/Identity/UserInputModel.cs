
using PetsLostAndFoundSystem.Models;

namespace PetsLostAndFoundSystem.MVC.Models.Identity
{
    public class UserInputModel : IMapFrom<LoginFormModel>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
