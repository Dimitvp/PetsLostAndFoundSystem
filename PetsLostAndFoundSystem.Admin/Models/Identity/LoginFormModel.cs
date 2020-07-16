using System.ComponentModel.DataAnnotations;

namespace PetsLostAndFoundSystem.Admin.Models.Identity
{
    public class LoginFormModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
