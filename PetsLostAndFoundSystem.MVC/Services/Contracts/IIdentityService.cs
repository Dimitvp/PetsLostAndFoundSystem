using System.Threading.Tasks;

using PetsLostAndFoundSystem.MVC.Data.Models;
using PetsLostAndFoundSystem.MVC.Models.Identity;

namespace PetsLostAndFoundSystem.MVC.Services.Contracts
{
    public interface IIdentityService
    {
        Task<Result<User>> Register(UserInputModel userInput);

        Task<Result<LoginSuccessModel>> Login(UserInputModel userInput);

        Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInput);
    }
}
