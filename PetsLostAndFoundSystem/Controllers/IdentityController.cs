using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetsLostAndFoundSystem.Data.Models;
using PetsLostAndFoundSystem.Models.Identity;
using PetsLostAndFoundSystem.Services.Contracts;

namespace PetsLostAndFoundSystem.Controllers
{
    public class IdentityController : ApiController
    {
        private readonly IIdentityService identity;
        private readonly ICurrentUserService currentUser;
        private readonly IReporterService reporters;

        public IdentityController(
            IIdentityService identity,
            ICurrentUserService currentUser,
            IReporterService reporters)
        {
            this.identity = identity;
            this.currentUser = currentUser;
            this.reporters = reporters;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(
            CreateUserInputModel input)
        {
            var result = await this.identity.Register(input);

            if (!result.Succeeded)
            {
                return BadRequest(result);
            }

            var user = result.Data;

            var reporter = new Reporter
            {
                Name = input.Name,
                PhoneNumber = input.PhoneNumber,
                UserId = user.Id
            };

            await this.reporters.Save(reporter);

            return Ok();
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginOutputModel>> Login(
            UserInputModel input)
        {
            var result = await this.identity.Login(input);

            if (!result.Succeeded)
            {
                return BadRequest(result);
            }

            var user = result.Data;

            var reporterId = await this.reporters.GetIdByUser(user.UserId);

            return new LoginOutputModel(user.Token, reporterId);
        }

        [HttpPut]
        [Authorize]
        [Route(nameof(ChangePassword))]
        public async Task<ActionResult> ChangePassword(
            ChangePasswordInputModel input)
            => await this.identity.ChangePassword(new ChangePasswordInputModel
            {
                UserId = this.currentUser.UserId,
                CurrentPassword = input.CurrentPassword,
                NewPassword = input.NewPassword
            });
    }
}
