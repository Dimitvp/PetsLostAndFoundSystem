using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetsLostAndFoundSystem.MVC.Data.Models;
using PetsLostAndFoundSystem.MVC.Models.Identity;
using PetsLostAndFoundSystem.MVC.Services.Contracts;

namespace PetsLostAndFoundSystem.MVC.Controllers
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

        [HttpGet]
        [AllowAnonymous]
        [Route(nameof(Register))]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [Route(nameof(Register))]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register([FromForm]
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
                PhoneNumber = input.Phone,
                UserId = user.Id
            };

            await this.reporters.Save(reporter);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        [Route(nameof(Login))]
        public IActionResult Login() => View();

        [HttpPost]
        [Route(nameof(Login))]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login([FromForm]
            UserInputModel input)
        {
            var result = await this.identity.Login(input);

            if (!result.Succeeded)
            {
                return BadRequest(result);
            }

            var user = result.Data;

            var reporterId = await this.reporters.GetIdByUser(user.UserId);

            return RedirectToAction(nameof(HomeController.Index), "Home");
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
