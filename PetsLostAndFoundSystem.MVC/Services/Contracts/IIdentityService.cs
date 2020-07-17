using System.Threading.Tasks;

using PetsLostAndFoundSystem.MVC.Models.Identity;
using Refit;

namespace PetsLostAndFoundSystem.MVC.Services.Contracts
{
    public interface IIdentityService
    {
        [Post("/Identity/Login")]
        Task<UserOutputModel> Login([Body] UserInputModel loginInput);

        [Post("/Identity/Register")]
        Task<UserOutputModel> Register([Body] UserInputModel registerInput);

        [Put("/Identity/ChangePassword")]
        Task<ChangePasswordInputModel> ChangePassword([Body] ChangePasswordInputModel input);

        //Task<Result<User>> Register(UserInputModel userInput);

        //Task<Result<LoginSuccessModel>> Login(UserInputModel userInput);

        //Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInput);
    }
}
    