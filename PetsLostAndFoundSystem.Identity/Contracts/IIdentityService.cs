using System.Threading.Tasks;

using PetsLostAndFoundSystem.Identity.Data.Models;
using PetsLostAndFoundSystem.Identity.Models;
using PetsLostAndFoundSystem.Identity.Models.Identity;
using PetsLostAndFoundSystem.Services;

namespace PetsLostAndFoundSystem.Identity.Contracts
{
    public interface IIdentityService
    {
        Task<Result<User>> Register(UserInputModel userInput);

        Task<Result<UserOutputModel>> Login(UserInputModel userInput);

        Task<Result> ChangePassword(string userId, ChangePasswordInputModel changePasswordInput);
    }
}
