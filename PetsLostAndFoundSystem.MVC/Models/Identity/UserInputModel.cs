
namespace PetsLostAndFoundSystem.MVC.Models.Identity
{
    public class UserInputModel : IMapFrom<LoginFormModel>, IMapFrom<CreateUserFormModel>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
