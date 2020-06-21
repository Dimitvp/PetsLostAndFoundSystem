using System.Threading.Tasks;

using PetsLostAndFoundSystem.Data.Models;
using PetsLostAndFoundSystem.Models.Identity;

namespace PetsLostAndFoundSystem.Services.Contracts
{
    public interface IIdentityService
    {
        Task<Result<User>> Register(UserInputModel userInput);

        Task<Result<LoginSuccessModel>> Login(UserInputModel userInput);

        Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInput);
    }
}
