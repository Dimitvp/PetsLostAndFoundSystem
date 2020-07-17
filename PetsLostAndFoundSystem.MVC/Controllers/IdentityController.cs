using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PetsLostAndFoundSystem.MVC.Models.Identity;
using PetsLostAndFoundSystem.MVC.Services.Contracts;
using PetsLostAndFoundSystem.MVC.Services.Identity;
using static PetsLostAndFoundSystem.Infrastructure.InfrastructureConstants;

namespace PetsLostAndFoundSystem.MVC.Controllers
{
    public class IdentityController : CommunicationBaseController
    {
        private readonly IIdentityService identity;
        private readonly ICurrentUserService currentUser;
        private readonly IReporterService reporters;
        private readonly IMapper mapper;

        public IdentityController(
            IIdentityService identity,
            ICurrentUserService currentUser,
            IReporterService reporters,
            IMapper mapper)
        {
            this.identity = identity;
            this.currentUser = currentUser;
            this.reporters = reporters;
            this.mapper = mapper;
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
        public async Task<ActionResult> Register(CreateUserFormModel input)
            => await this.Handle(
                async () => await this.identity.Register(this.mapper.Map<UserInputModel>(input)),
            success: RedirectToAction(nameof(ReporterController.Create), "Reporter"),
            failure: View("../Home/Index", input));
        //{
        //    var result = await this.identity.Register(input);

        //    if (!result.Succeeded)
        //    {
        //        return BadRequest(result);
        //    }

        //    var user = result.Data;

        //    var reporter = new Reporter
        //    {
        //        Name = input.Name,
        //        PhoneNumber = input.Phone,
        //        UserId = user.Id
        //    };

        //    await this.reporters.Save(reporter);

        //    return RedirectToAction(nameof(HomeController.Index), "Home");
        //}

        [HttpGet]
        [AllowAnonymous]
        [Route(nameof(Login))]
        public IActionResult Login() => View();

        [HttpPost]
        [Route(nameof(Login))]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginFormModel input)
            => await this.Handle(
                async () =>
                {
                    var result = await this.identity
                        .Login(this.mapper.Map<UserInputModel>(input));

                    this.Response.Cookies.Append(
                        AuthenticationCookieName,
                        result.Token,
                        new CookieOptions
                        {
                            HttpOnly = true,
                            Secure = true,
                            MaxAge = TimeSpan.FromDays(1)
                        });
                },
                success: RedirectToAction(nameof(HomeController.Index), "Home"),
                failure: View("../Home/Index", input));

        [HttpPut]
        [Authorize]
        [Route(nameof(ChangePassword))]
        public async Task<ActionResult> ChangePassword(ChangePasswordFormModel input)
            => await this.Handle(
                async () => await this.identity.ChangePassword(this.mapper.Map<ChangePasswordInputModel>(input)),
            success: RedirectToAction(nameof(HomeController.Index), "Home"),
            failure: View("../Home/Index", input));
            //=> await this.identity.ChangePassword(new ChangePasswordInputModel
            //{
            //    CurrentPassword = input.CurrentPassword,
            //    NewPassword = input.NewPassword
            //});
    }
}
