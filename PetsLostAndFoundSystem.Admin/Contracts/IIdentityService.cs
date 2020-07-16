using PetsLostAndFoundSystem.Admin.Models.Identity;
using Refit;

using System.Threading.Tasks;

namespace PetsLostAndFoundSystem.Admin.Contracts
{
    public interface IIdentityService
    {
        [Post("/Identity/Login")]
        Task<UserOutputModel> Login([Body] UserInputModel loginInput);
    }
}
