using PetsLostAndFoundSystem.Models;

namespace PetsLostAndFoundSystem.MVC.Models.Identity
{
    public class ChangePasswordInputModel : IMapFrom<ChangePasswordFormModel>
    {
        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
